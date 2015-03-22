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
    public partial class Book : System.Web.UI.Page
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

        }
        public IQueryable<Product> GetProduct([QueryString("id")] int? QueryProductId)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Product> query = db.Products;

            if (QueryProductId.HasValue && QueryProductId > 0)
            {
                query = query.Where(product => product.ProductId == QueryProductId);
            }
            return query;
        }
        public IQueryable<Product> GetProductReview([QueryString("id")] int? QueryProductId)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Product> query = db.Products;
            if (QueryProductId.HasValue && QueryProductId > 0)

            {
                query = query.Where(product => product.ProductId == QueryProductId);
            }
            return query;
        }

        public IQueryable<Review> GetReview([QueryString("id")] int? ProductId)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Review> query = db.Reviews;
            if (ProductId.HasValue && ProductId > 0)
            {
                query = query.Where(review => review.ProductId == ProductId);
            }
            return query;
        }
        
    }
}