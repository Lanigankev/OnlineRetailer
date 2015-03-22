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
            if (Session["UserView"] != null)
            {
                this.MasterPageFile = "~/UserView.master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        public List<Product> GetProduct()
        {
            var db = new RainforestBooks.Models.Context();

            List<Product> query = db.Products.ToList();
            List<Product> returnSix = new List<Product>();

            Random rnd = new Random();
            int val;
            //int[] values = RandomSix(query);
            for (int i = 0; i < 6; i++)
            {
                val = rnd.Next(0, query.Count - 1);
                returnSix.Add(query[val]);
            }
            return returnSix;
        }
        //public int[] RandomSix(List<Product> list)
        //{
        //    List<int> returnVals = new List<int>();
        //    int val;
        //    Random rdm = new Random();
        //    do
        //    {
        //        val = rdm.Next(0, list.Count - 1);
        //        if (!returnVals.Contains(val))
        //        {
        //            returnVals.Add(val);
        //        }
        //    }
        //    while
        //    (returnVals.Count != 6);
        //    return returnVals.ToArray();
        //}
    }
}