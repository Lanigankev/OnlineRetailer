using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    public class ProductReviewCustomer
    {
        public Product thisProduct { get; set; }
        public Review thisReview { get; set; }
        public Customer thisCustomer { get; set; }
        
    }
}