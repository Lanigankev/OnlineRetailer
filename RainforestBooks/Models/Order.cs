using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    [Table("tblOrders")]
    public class Order
    {
        [Key]
        public int OrderId  { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public int TotalNoItems { get; set; }
        public string AdditionalInfo  { get; set; }
        public DateTime DateOrderCompleted { get; set; }
        public int CustomerId { get; set; }
        
    }
}