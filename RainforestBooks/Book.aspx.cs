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
        public IQueryable<Product> GetProduct([QueryString("id")] int? ProductId)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Product> query = db.Products;
            if (ProductId.HasValue && ProductId > 0)
            {
                query = query.Where(product => product.ProductId == ProductId);
            }
            return query;
        }
        //public List<ProductReviewCustomer> GetProduct([QueryString("id")] int? ProductId)
        //{
        //    var db = new RainforestBooks.Models.Context();
        //    List<ProductReviewCustomer> query = (from p in db.Products
        //                                             join r in db.Reviews on 
        //                                                 p.ProductId equals r.ProductId
        //                                       select new ProductReviewCustomer{thisProduct=p,thisReview=r}).ToList();
            
        //    double average = 0; 
            
        //    for(int i = 1;i<=query.Count; i++)
        //    {
        //        average += query[i].thisReview.Stars;
        //        average = average / i;

        //    }
            
        //    if (ProductId.HasValue && ProductId > 0)
        //    {
        //        query = query.Where(productReview => productReview.thisProduct.ProductId == ProductId).ToList();
        //    }
        //    return query;
        //}
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