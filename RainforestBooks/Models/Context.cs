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

        public DbSet<RegisterTest> Registers { get; set; }

    }
}