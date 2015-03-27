using System;
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
            using (var db = new Context())
            {
                Customer customer = (from c in db.Customers
                                    where c.CustomerId == userId
                                    select c).FirstOrDefault();

                if (HttpContext.Current.Session["UserSession"] == null)
                {
                    HttpContext.Current.Session["UserSession"] = customer;

                }
            }
            
            
        }
        static public int ReturnUserId()
        {
            int retVal;

            if (HttpContext.Current.Session["UserSession"] != null)
            {
                Customer customer = (Customer)HttpContext.Current.Session["UserSession"];
                retVal = customer.CustomerId;
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }

         static public string ReturnUserEmail()
        {
            string retVal;

            if (HttpContext.Current.Session["UserSession"] != null)
            {
                Customer customer = (Customer)HttpContext.Current.Session["UserSession"];
                retVal = customer.Email;
            }
            else
            {
                retVal = null;
            }
            return retVal;
        }

        static public Customer ReturnUserObj()
        {
            Customer retVal;

            if (HttpContext.Current.Session["UserSession"] != null)
            {
                Customer customer = (Customer)HttpContext.Current.Session["UserSession"];
                retVal = customer;
            }
            else
            {
                retVal = null;
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