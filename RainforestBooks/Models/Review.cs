using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    [Table("tblReviews")]
    public class Review
    {
        [Key,Column(Order = 0)]
        public int CustomerId { get; set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        public string ReviewText { get; set; }
        public int Stars { get; set; }
    }
}