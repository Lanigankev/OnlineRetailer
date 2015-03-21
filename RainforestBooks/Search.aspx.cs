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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Product> GetProduct([QueryString("search")] string searchTerm)
        {
            var db = new RainforestBooks.Models.Context();
            IQueryable<Product> query = from p in db.Products
                                        where p.ProductTitle.Contains(searchTerm)
            if (searchTerm)
            {
                query = query.Where(product => product.ProductId == ProductId);
            }
            return query;
        }
        
    }
}