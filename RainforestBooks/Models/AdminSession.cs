using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    static public class AdminSession
    {
        static AdminSession()
        {
            
        }

        static public void Login()
        {
            if (HttpContext.Current.Session["AdminSession"] == null)
            {
                HttpContext.Current.Session["AdminSession"] = true;
                
            }
            
        }
        static public bool IsAdminSession()
        {
            bool retVal;

            if (HttpContext.Current.Session["AdminSession"] != null)
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        static public void LogOut()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }
}