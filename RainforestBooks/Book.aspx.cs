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
        public IQueryable<ProductReviewCustomer> GetProductReview([QueryString("id")] int? QueryProductId)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Product> query = db.Products;
            if (QueryProductId.HasValue && QueryProductId > 0)
            {
                query = query.Where(product => product.ProductId == QueryProductId);
            }
            return query;
        }
        public List<ProductReviewCustomer> GetProductDetails([QueryString("id")] int? QueryProductId)
        {
            var db = new RainforestBooks.Models.Context();
            //var query = from p in db.Products
            //            join r in db.Reviews
            //            on p.ProductId equals r.ProductId
            //            group p by p.ProductId into grp
            //            select new { p.ProductId, p.ProductTitle, p.ProductImageRef,
            //                        p.Genre, p.Cost, p.Category, p.Description, r.Stars };

            var query = (from p in db.Products
                         join r in db.Reviews
                         on p.ProductId equals r.ProductId
                         group new {p,r} by new {p.ProductId} into pr
                         select new 
                         {
                         ProdId = pr.Key.ProductId,
                         

                         }

            double total = 0;
            List<ProductReviewCustomer> ProductReviewList = new List<ProductReviewCustomer>();

            foreach (var item in query)
            {
                ProductReviewCustomer prod = new ProductReviewCustomer();
                prod.ProductId = item.ProductId;
                prod.ProductTitle = item.ProductTitle;
                prod.ProductImageRef = item.ProductImageRef;
                prod.Genre = item.Genre;
                prod.Cost = item.Cost;
                prod.Category = item.Category;
                prod.Description = item.Description;
                //average + item.Stars;
                ProductReviewList.Add(prod);
                total += item.Stars;
            }

            double avg = total / query.Count();



            if (QueryProductId.HasValue && QueryProductId > 0)
            {
                query = query.Where(product => product.ProductId == QueryProductId);
            }
            return ProductReviewList;
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