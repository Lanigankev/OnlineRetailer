using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    public class ProductReviewCustomer
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImageRef { get; set; }
        public int InStock { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Genre { get; set; }
        public int CustomerId { get; set; }
        public string ReviewText { get; set; }
        public int Stars { get; set; }
        public string UserName { get; set; }
    }
}