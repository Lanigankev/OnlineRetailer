using RainforestBooks.Functions;
using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace RainforestBooks
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (UserSession.ReturnUserId() != -1)
            {
                Response.Redirect("MyCart.aspx");
            }
            else if (AdminSession.IsAdminSession() == true)
            {

                Response.Redirect("Default.aspx");
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isValidLogin = false;
            bool isValidAdmin = false;
            
            using (var db = new Context())
            { 
            string username;
            string password;
            Customer customer = new Customer();

            username = txtUsername.Text;
            password = HashCode.PassHash(txtPassword.Text);
            customer.UserName = username;
            customer.UserPassword = password;

            Customer user = (from c in db.Customers
                        where c.UserName == customer.UserName
                        && c.UserPassword == customer.UserPassword
                        select c).First();

            if (user != null && user.AdminRights == 0)
            {
                
                isValidLogin = true;
                isValidAdmin = false;
            }
            else if (user != null && user.AdminRights > 0)
            {
                isValidAdmin = true;
                isValidLogin = false;
            }
            else
            {
                isValidLogin = false;
                isValidAdmin = false;
             }

             
           if (isValidLogin)
           {
               UserSession.Login(user.CustomerId);
               string cookieId = UserSession.ReturnUserId().ToString();

               if(Request.Cookies[cookieId]!= null)
               {
                   int customerId;
                   string xmlString;
                   customerId = UserSession.ReturnUserId();
                   string reference = Request.Cookies[cookieId].Value;
                   

                       xmlString = (from xml in db.StoredCarts
                                   where xml.Reference == reference
                                   && xml.CustomerId == customerId
                                   select xml.XmlList).FirstOrDefault();
                       
                   if (xmlString != null)
                       {
                           XmlSerializer serializer = new XmlSerializer(typeof(List<CartItem>));
                           TextReader reader = new StringReader(xmlString);
                           List<CartItem> storedList = (List<CartItem>)serializer.Deserialize(reader);


                           ShoppingCart.Instance.CartItems = storedList;
                       }
               }
               Response.Redirect("About.aspx", true);   
               
           }
           else if(isValidAdmin)
           {

               AdminSession.Login();
               Response.Redirect("About.aspx", true); 
           }
           else
           {
               Response.Write("<script language='javascript'>alert('Invalid Login');</script>");
           }

            }
            
            
        }
    }
}