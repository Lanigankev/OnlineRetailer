using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainforestBooks
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (UserSession.ReturnUserId() != -1)
            {
                this.MasterPageFile = "~/UserView.master";
            }
            else if (AdminSession.IsAdminSession() == true)
            {
                
                this.MasterPageFile = "~/AdminView.master";  
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSearchTerm.Text = Request.QueryString["search"];
            
        }
        public IQueryable<Product> SearchMethod([QueryString("search")] string searchTerm)
        {
            if (searchTerm != string.Empty)
            {
                using (var db = new RainforestBooks.Models.Context())
                {
                    try
                    {
                        IQueryable<Product> query = from p in db.Products
                                                    where p.ProductTitle.Contains(searchTerm)
                                                    || p.Genre.Contains(searchTerm)
                                                    select p;

                        return query;
                    }
                    catch (Exception ex)
                    {
                        return null;
                        throw ex;
                        
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
                return null;
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (AdminSession.IsAdminSession() != true && UserSession.ReturnUserId() != -1)
            {
                try
                {
                    LinkButton btn = (LinkButton)sender;
                    int prodId = int.Parse(btn.CommandArgument);
                    ShoppingCart.Instance.AddItem(prodId);
                    Response.Write("<script language='javascript'>alert('Item added to cart');</script>");

                }
                catch(Exception ex)
                { throw ex; }
            }
            else if (AdminSession.IsAdminSession() != true && UserSession.ReturnUserId() == -1)
            {
                Response.Redirect("EditItem.aspx");
            }
        }
        
    }
}