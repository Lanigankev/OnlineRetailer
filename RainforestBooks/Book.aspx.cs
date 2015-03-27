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
        public int Rating { get; set; }
        //Has the current site user reviewed this product
        private bool HasReviewed { get; set; }

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
            int productId;
            bool isValid = int.TryParse(Request.QueryString["id"], out productId);
            if (isValid)
            {
                ProductId = productId;
            }
            
            if (UserSession.ReturnUserId() != -1)
            {
                btnAddReview.Visible = true;
                btnAddToCart.Visible = true;
                using (var db = new Context())
                {
                    int customerId = UserSession.ReturnUserId();
                    var review = (from r in db.Reviews
                                  where r.CustomerId == customerId
                                  && r.ProductId == ProductId
                                  select r).FirstOrDefault();
                    if (review != null)
                    {
                        HasReviewed = true;
                        btnDeleteReview.Visible = true;
                    }
                }
                
            }
            else if (AdminSession.IsAdminSession() == true)
            {
                btnAddReview.Visible = false;
                btnAddToCart.Visible = false;
                
            }
            else
            {
                btnDeleteReview.Visible = false;
                btnAddReview.Visible = false;
                btnDeleteReview.Visible = false;

            }

            
            lblWarning.Visible = false;
            
            rdo1.Visible = false;
            rdo2.Visible = false;
            rdo3.Visible = false;
            rdo4.Visible = false;
            rdo5.Visible = false;
            txtReview.Visible = false;
            btnSubmitReview.Visible = false;
            
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

        public IQueryable<ProductReviewCustomer> GetProductReview([QueryString("id")] int? QueryProductId)
        {
            var db = new RainforestBooks.Models.Context();

            if (QueryProductId.HasValue && QueryProductId > 0)
            {
                double averageStars=0;
                int length;
                IQueryable<ProductReviewCustomer> query = from c in db.Customers
                            join r in db.Reviews
                            on c.CustomerId equals r.CustomerId
                            join p in db.Products
                            on r.ProductId equals p.ProductId
                            where p.ProductId == QueryProductId
                            select new ProductReviewCustomer { thisProduct=p,thisCustomer =c, thisReview = r };
                if (query != null)
                {
                    foreach (var item in query)
                    {
                        averageStars += item.thisReview.Stars;
                    }
                    length = query.Count();
                    averageStars = averageStars / length;
                    averageStars = Math.Round(averageStars, 1);
                    lblReviewAverage.Text = string.Format("Average Rating: {0}", averageStars);
                    
                }
                return query;
            }
            else
            {
                return null;
            }
            
        }

        public IQueryable<Review> GetReview([QueryString("id")] int? ProductId)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Review> query = db.Reviews;
            if (ProductId.HasValue && ProductId > 0)
            {
                query = query.Where(review => review.ProductId == ProductId);
                return query;
            }
            return query=null;
        }
        public void GetRating()
        {

            if (rdo1.Checked)
            {
                rdo2.Checked = false;
                rdo3.Checked = false;
                rdo4.Checked = false;
                rdo5.Checked = false;
                Rating = 1;
            }
            else if (rdo2.Checked)
            {
                rdo1.Checked = false;
                rdo3.Checked = false;
                rdo4.Checked = false;
                rdo5.Checked = false;
                Rating = 2;
            }
            else if (rdo3.Checked)
            {
                rdo2.Checked = false;
                rdo1.Checked = false;
                rdo4.Checked = false;
                rdo5.Checked = false;
                Rating = 3;
            }
            else if (rdo4.Checked)
            {
                rdo2.Checked = false;
                rdo3.Checked = false;
                rdo1.Checked = false;
                rdo5.Checked = false;
                Rating = 4;
            }
            else if (rdo5.Checked)
            {
                rdo2.Checked = false;
                rdo3.Checked = false;
                rdo4.Checked = false;
                rdo1.Checked = false;
                Rating = 5;
            }
           
        }
        protected void btnSubmitReview_Click(object sender, EventArgs e)
        {
            int customerId = UserSession.ReturnUserId();
           
            using(var db = new Context())
            {

            }
            if (rdo1.Checked || rdo2.Checked || rdo3.Checked || rdo4.Checked || rdo5.Checked && !HasReviewed)
            {
                lblWarning.Visible = false;
                

                GetRating();

                using (var db = new Context())
                {
                    string reviewText;
                    reviewText = txtReview.Text;
                    Review review = new Review();
                    review.CustomerId = customerId;
                    review.ProductId = ProductId;
                    review.ReviewText = reviewText;
                    review.Stars = Rating;

                    db.Reviews.Add(review);
                    db.SaveChanges();
                }

                Response.Redirect(Request.RawUrl);
            }
            else 
            {
                lblWarning.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            txtReview.Visible = true;
            btnSubmitReview.Visible = true;
            rdo1.Visible = true;
            rdo2.Visible = true;
            rdo3.Visible = true;
            rdo4.Visible = true;
            rdo5.Visible = true;

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

        protected void btnDeleteReview_Click(object sender, EventArgs e)
        {
            if (HasReviewed)
            { 
            using(var db = new Context())
            {
                int customerId = UserSession.ReturnUserId();

                Review review = (from r in db.Reviews
                                where r.CustomerId == customerId
                                && r.ProductId == ProductId
                                select r).FirstOrDefault();
                db.Reviews.Remove(review);
                db.SaveChanges();

            }
            Response.Redirect(Request.RawUrl);
            }

        }
        
    }
}