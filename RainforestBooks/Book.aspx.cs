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
        private int ProductId { get; set; }

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
            else
            {

                
               
            }
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.ReturnUserId() != -1)
            {
                btnAddReview.Visible = true;
                
            }
            else if (AdminSession.IsAdminSession() == true)
            {
                btnAddReview.Visible = true;
                btnAddToCart.Visible = false;
                
            }
            else
            {

                btnAddReview.Visible = false;

            }
            txtReview.Visible = false;
            btnSubmitReview.Visible = false;
            int productId;
            bool isValid = int.TryParse(Request.QueryString["id"], out productId);
            ProductId = productId;
        }

        public Product GetProduct([QueryString("id")] int? QueryProductId)
        {
            var db = new RainforestBooks.Models.Context();
            Product prod = null;

            if (QueryProductId.HasValue && QueryProductId > 0)
            {
                prod = (from p in db.Products where p.ProductId == QueryProductId select p).FirstOrDefault();
            }
            return prod;
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
            int customerId = UserSession.ReturnUserId();
            using (var db = new Context())
            {
                string reviewText;
                reviewText = txtReview.Text;
                Review review = new Review();
                review.CustomerId = customerId;
                review.ProductId = ProductId;
                review.ReviewText = reviewText;
                review.Stars = 3;

                db.Reviews.Add(review);
                db.SaveChanges();
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtReview.Text = UserSession.ReturnUserId().ToString();
            txtReview.Visible = true;
            btnSubmitReview.Visible = true;
            //txtReview.Text = (int)Session["UserView"] + Environment.NewLine + int.Parse(Request.QueryString["id"]);
           
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (UserSession.ReturnUserId() != -1)
            {
                ShoppingCart.Instance.AddItem(ProductId);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        
    }
}