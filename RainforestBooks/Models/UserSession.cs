using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    public class UserSession
    {

        static UserSession(int userId)
        {
            if (HttpContext.Current.Session["UserSession"] == null)
            {
                HttpContext.Current.Session["UserSession"] = userId;
            }
            
        }

        static public int ReturnUserId()
        {
            return (int)HttpContext.Current.Session["UserSession"];
        }

        static void LogOut()
        {
            HttpContext.Current.Session["UserSession"].;
        }
    }
}