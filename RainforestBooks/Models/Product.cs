using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImageRef { get; set; }
        public int InStock { get;set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Genre { get; set; }
    }
}