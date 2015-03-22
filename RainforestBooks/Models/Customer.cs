using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    
        [Table("tblCustomers")]
        public class Customer
        {
            [Key]
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Email { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string UserName { get; set; }
            public string UserPassword { get; set; }
        }



    
}