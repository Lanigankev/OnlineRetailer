﻿using RainforestBooks.Models;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isValidLogin = false;
            
            using (var db = new Context())
            { 
            string username;
            string password;
            Customer customer = new Customer();

            username = txtUsername.Text;
            password = txtPassword.Text;
            customer.UserName = username;
            customer.UserPassword = password;

            var query = (from c in db.Customers
                        where c.UserName == customer.UserName
                        && c.UserPassword == customer.UserPassword
                        select c).ToList();
            
                
           if (query.Count > 0)
            {
                foreach(var user in query)
                {
                    customer = user;
                }
                isValidLogin = true;
            }
            else
            {
                isValidLogin = false;
            }

           if (isValidLogin)
           {
               UserSession.Login(customer.CustomerId);

               if(Request.Cookies["cartRef"]!= null)
               {
                   string xmlString;
                   string reference = Request.Cookies["CartRef"].Value;
                   

                       xmlString = (from xml in db.StoredCarts
                                   where xml.Reference == reference
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
           else
           {
               Response.Write("<script language='javascript'>alert('Invalid Login');</script>");
           }

            }
            
            
        }
    }
}