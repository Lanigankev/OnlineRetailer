using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    static public class UserSession
    {
        //public int UserId { get; set; }

        static UserSession()
        {
            
        }

        static public void Login(int userId)
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
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }
}