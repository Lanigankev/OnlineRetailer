using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RainforestBooks
{
    public partial class MyCart : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (UserSession.ReturnUserId() == -1)
            {
                Response.Redirect("Login.aspx");
            }
            else if (AdminSession.IsAdminSession() == true)
            {

                Response.Redirect("Default.aspx");

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetCartGrid();
            }
        }

        protected void gvShoppingCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = Convert.ToInt32(e.CommandArgument.ToString());
                ShoppingCart.Instance.RemoveItem(productId);

            }
            else if(e.CommandName=="Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int quantity;
                int productId;

                GridViewRow row = gvShoppingCart.Rows[index];

                TextBox txt = ((TextBox)row.FindControl("txtQuantity"));
                productId = Convert.ToInt32(row.Cells[0].Text);
                quantity = Convert.ToInt32(txt.Text);
                
                ShoppingCart.Instance.SetItemQuantity(productId,quantity);
                SetCartGrid();
                
            }
        }

        protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            //LinkButton button = (LinkButton)sender;
            //button
            //int product = int.Parse(button.CommandArgument);
            SetCartGrid();
        }

        private void SetCartGrid()
        {
            gvShoppingCart.DataSource = ShoppingCart.Instance.CartItems;
            gvShoppingCart.UseAccessibleHeader = true;  
            gvShoppingCart.DataBind();

            decimal totalCost = ShoppingCart.Instance.GetSubTotal();
            lblTotalCost.Text = string.Format("Total Cost: {0:C}",totalCost);

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            
        }

        protected void gvShoppingCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void gvShoppingCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int quantity;
            //quantity = e.NewValues;

            //int index = Convert.ToInt32(e.NewValues);
            //int quantity;
            //int productId;
            //e.

            //GridViewRow row = gvShoppingCart.Rows[index];

            //TextBox txt = ((TextBox)row.FindControl("txtQuantity"));
            //productId = Convert.ToInt32(row.Cells[0].Text);
            //quantity = Convert.ToInt32(txt.Text);

            //ShoppingCart.Instance.SetItemQuantity(productId, quantity);
            //SetCartGrid();
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.Instance.CartItems.Count != 0)
            {
                decimal totalOrderCost=0;
                foreach(CartItem item in ShoppingCart.Instance.CartItems)
                {
                    totalOrderCost += item.TotalPrice;

                }
                Order order = new Order();
                order.CustomerId = UserSession.ReturnUserId();
                order.OrderPlacedDate = DateTime.Now.Date;
                order.TotalNoItems = ShoppingCart.Instance.CartItems.Count();
                order.TotalOrderCost = totalOrderCost;
                order.AdditionalInfo = "Some stuff";
                try
                {
                    using (var db = new Context())
                    {
                        db.Orders.Add(order);
                        db.SaveChanges();


                        foreach (CartItem item in ShoppingCart.Instance.CartItems)
                        {
                            int stockLimit;

                            OrderProduct orderProduct = new OrderProduct();

                            stockLimit = (from p in db.Products
                                          where p.ProductId == item.ProductId
                                          select p.InStock).FirstOrDefault();

                            if (item.Quantity > stockLimit)
                            {
                                Response.Write("<script language='javascript'>alert('This item does not have sufficient stock');</script>");
                            }
                            else
                            {
                                int newStockLevel;
                                orderProduct.OrderId = order.OrderId;
                                orderProduct.ProductId = item.ProductId;
                                orderProduct.Quantity = item.Quantity;
                                orderProduct.TotalCost = item.TotalPrice;
                                db.OrderProducts.Add(orderProduct);
                                Product updatedProduct = (from p in db.Products
                                                          where p.ProductId == item.ProductId
                                                          select p).FirstOrDefault();
                                newStockLevel = updatedProduct.InStock - item.Quantity;
                                updatedProduct.InStock = newStockLevel;

                            }
                        }
                        db.SaveChanges();
                        
                        SendConfirmationEmail(UserSession.ReturnUserObj(), ShoppingCart.Instance.CartItems);
                        Response.Write("<script language='javascript'>alert('Purchase has been successfull');</script>");
                        ClearAllCart();
                    }
                }
                catch (Exception)
                {

                }


            }
        }

        protected void btnStoreCart_Click(object sender, EventArgs e)
        {
            string reference;
            int userId;
            userId = UserSession.ReturnUserId();
            string cookieId = userId.ToString();
           
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<CartItem>));
            List<CartItem> list = ShoppingCart.Instance.CartItems;
            StringWriter sw = new StringWriter(new StringBuilder());

            xmlSerialize.Serialize(sw, list);

            HttpCookie cartRef = Request.Cookies[cookieId];
            if (cartRef == null)
            {

                reference = Guid.NewGuid().ToString();
                StoredCart storedCart = new StoredCart();
                storedCart.CustomerId = UserSession.ReturnUserId();
                storedCart.Reference = reference;
                storedCart.XmlList = sw.ToString();

                using (var db = new Context())
                {
                    db.StoredCarts.Add(storedCart);
                    db.SaveChanges();
                }

                cartRef = new HttpCookie(cookieId);
                cartRef.Value = reference;
                cartRef.HttpOnly = true;
                cartRef.Expires = DateTime.Now.AddMonths(1);
                HttpContext.Current.Response.Cookies.Add(cartRef);
            }
            else
            { 
                using(var db = new Context())
                {
                  StoredCart cart = (from storedCart in db.StoredCarts
                                 where storedCart.CustomerId == userId
                                 select storedCart).FirstOrDefault();

                  cart.XmlList = sw.ToString();
                  db.SaveChanges();
                }
            }
            
        }

        protected void btnClearStoredCart_Click(object sender, EventArgs e)
        {

            ClearAllCart();
        }

        private void ClearAllCart()
        {
            int userId;
            userId = UserSession.ReturnUserId();
            string cookieId = userId.ToString();

            HttpCookie cartRef = Request.Cookies[cookieId];

            XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<CartItem>));
            List<CartItem> list = new List<CartItem>();
            StringWriter sw = new StringWriter(new StringBuilder());

            xmlSerialize.Serialize(sw, list);

            if (cartRef != null)
            {
                using (var db = new Context())
                {
                    StoredCart cart = (from storedCart in db.StoredCarts
                                       where storedCart.CustomerId == userId
                                       select storedCart).FirstOrDefault();

                    cart.XmlList = sw.ToString();
                    db.SaveChanges();
                }

            }

            ShoppingCart.Instance.CartItems.Clear();
            Response.Redirect(Request.RawUrl);
        }
        private void SendConfirmationEmail(Customer user, List<CartItem> order)
        {
            string sender = "rainforestbooksweb@gmail.com";
            string email = user.Email;

            string message = string.Format("Hi "+ user.FirstName+"," + Environment.NewLine
                                                     + Environment.NewLine+"You have successfully purchased:"
                                                     + Environment.NewLine +
                                                     "Title \t Quantity \t Unit Price \t Total Price"+ Environment.NewLine );

            foreach(CartItem item in order)
            {
                message+= item.ToString() + Environment.NewLine;
            }
            message += string.Format("Thank you for shopping at rainforest books");
            
                                          

            using (MailMessage mm = new MailMessage(sender, email))
            {
                mm.Subject = "Your order details";
                mm.Body = message;
                
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(sender, "kevinsimon");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                try
                {
                    smtp.Send(mm);
                }
                catch(Exception ex)
                {
                
                }

            }
        }
        }
    }
