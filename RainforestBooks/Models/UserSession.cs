﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainforestBooks.Models
{
    static public class UserSession
    {
        

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
            int retVal;

            if (HttpContext.Current.Session["UserSession"] != null)
            {
                retVal = (int)HttpContext.Current.Session["UserSession"];
            }
            else
            {
                retVal = -1;
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