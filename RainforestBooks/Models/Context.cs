using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    public class Context : DbContext
    {
        public Context()

            : base("CxnString") // connection string as defined in web.config
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StoredCart> StoredCarts { get; set; }


    }
}