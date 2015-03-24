using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainforestBooks
{
    public partial class MyCart : System.Web.UI.Page
    {
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
            Order order = new Order();
            order.CustomerId = (int)Session["UserView"];
            order.OrderPlacedDate = DateTime.Now.Date;
            order.TotalNoItems = ShoppingCart.Instance.CartItems.Count();
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
                }}
                catch(Exception)
                {
                
                }


            }
        }
    }
