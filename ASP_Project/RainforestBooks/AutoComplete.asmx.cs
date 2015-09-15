using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace RainforestBooks
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(true)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
        
        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<string> CompleteSearch(string prefixText, int count, string contextKey)
        {
            using (var db = new Context())
            {
                List<string> searchResults = (from p in db.Products
                                              where p.ProductTitle.Contains(prefixText)
                                              select p.ProductTitle).ToList(); //.Take(5)

                return searchResults;
            }

        }
    }
}
