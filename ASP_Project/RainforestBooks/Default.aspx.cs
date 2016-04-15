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
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (UserSession.ReturnUserId() != -1)
            {
                this.MasterPageFile = "~/UserView.master";
            }
            else if (AdminSession.IsAdminSession() == true)
            {
                this.MasterPageFile = "~/AdminView.master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        public List<Product> GetProduct()
        {
            using (var db = new RainforestBooks.Models.Context())
            {
                List<Product> query = new List<Product>();
                try
                {
                    query = db.Products.ToList();
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                List<Product> returnSix = new List<Product>(6);

                Random rnd = new Random();

                int limit = query.Count - 6; ;
                int startPoint = rnd.Next(0, limit);

                for (int i = startPoint; i < startPoint + 6; i++)
                {
                    returnSix.Add(query[i]);
                }

                return returnSix;
            }
        }
        
    }
}