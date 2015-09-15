using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    [Table("tblStoredCarts")]
    public class StoredCart
    {
        [Key]
        public string Reference { get; set; }
        public int CustomerId { get; set; }
        public string XmlList { get; set; }
    }
}