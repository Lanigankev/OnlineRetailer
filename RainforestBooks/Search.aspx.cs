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
            if (Session["UserView"] != null)
            {
                this.MasterPageFile = "~/UserView.master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSearchTerm.Text = Request.QueryString["search"];
        }
        public IQueryable<Product> SearchMethod([QueryString("search")] string searchTerm)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Product> query = from p in db.Products
                                        where p.ProductTitle.Contains(searchTerm)
                                        || p.Genre.Contains(searchTerm)
                                        select p;
            //if (searchTerm != string.Empty)
            //{
            //    query = query.Where(product => product.ProductId == ProductId);
            //}
            return query;
        }
        
    }
}