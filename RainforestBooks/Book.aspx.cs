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
            txtReview.Visible = false;
            btnSubmitReview.Visible = false;
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

        protected void btnSubmitReview_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                string reviewText;
                reviewText = txtReview.Text;
                Review review = new Review();
                review.CustomerId = (int)Session["UserView"];
                review.ProductId = int.Parse(Request.QueryString["id"]);
                review.ReviewText = reviewText;
                review.Stars = 3;

                db.Reviews.Add(review);
                db.SaveChanges();
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtReview.Visible = true;
            btnSubmitReview.Visible = true;
            //txtReview.Text = (int)Session["UserView"] + Environment.NewLine + int.Parse(Request.QueryString["id"]);
           
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            ShoppingCart myCart = new ShoppingCart();
            if (Session["ShoppingCart"] == null)
            { //You have to populate a product from the database then add it to myCart.CartItems
            //myCart.CartItems.Add()
            }
            else
            {
            myCart = (ShoppingCart)Session["ShoppingCart"];
                //myCart.CartItems.Add();
                Session["ShoppingCart"] =myCart;
            }
        }
        
    }
}