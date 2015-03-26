using RainforestBooks.Functions;
using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainforestBooks
{
    public partial class Register : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        private void ClearForm()
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text=string.Empty;
            txtPhone.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {   
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        private void RegisterUser()
    {
        var _db = new Context();

            bool fNameEmpty = true;
            bool lNameEmpty = true;
            bool emailEmpty = true;
            bool phoneEmpty = true;
            //bool isPlaceHolderEmail = true;
            //bool isPlaceHolderPhone = true;
            bool address1Empty = true;
            bool address2Empty = true;
            bool cityEmpty = true;
            bool countryEmpty = true;
            bool userNameEmpty = true;
            bool passwordEmpty = true;
            bool contactExists = _db.Customers.Any(customer => customer.Email == txtEmail.Text);
            bool usernameExists = _db.Customers.Any(customer => customer.UserName == txtUserName.Text);


            Validation val = new Validation();

            fNameEmpty = string.IsNullOrEmpty(txtFName.Text);
            lNameEmpty = string.IsNullOrEmpty(txtLName.Text);
            emailEmpty = string.IsNullOrEmpty(txtEmail.Text);
            emailEmpty = val.EmailValidator(txtEmail.Text) == null ? false : true;
            phoneEmpty = string.IsNullOrEmpty(txtPhone.Text);
            phoneEmpty = val.PhoneValidator(txtPhone.Text) == null ? false : true;
            address1Empty = string.IsNullOrEmpty(txtAddress1.Text);
            address2Empty = string.IsNullOrEmpty(txtAddress2.Text);
            cityEmpty = string.IsNullOrEmpty(txtCity.Text);
            countryEmpty = string.IsNullOrEmpty(txtCountry.Text);
            userNameEmpty = string.IsNullOrEmpty(txtUserName.Text);
            passwordEmpty = string.IsNullOrEmpty(txtPassword.Text);
            
            
            if (fNameEmpty)
            {
                lblFName.Visible = true;
            }
            else
            {
                lblFName.Visible = false;
            }
            if (lNameEmpty)
            {
                lblLName.Visible = true;
            }
            else
            {
                lblLName.Visible = false;
            }
            if (address1Empty)
            {
                lblAddress1.Visible = true;
            }
            else
            {
                lblAddress1.Visible = false;
            }
            if (address2Empty)
            {
                lblAddress2.Visible = true;
            }
            else
            {
                lblAddress2.Visible = false;
            }
            if (cityEmpty)
            {
                lblCity.Visible = true;
            }
            else
            {
                lblCity.Visible = false;
            }
            if (countryEmpty)
            {
                lblCountry.Visible = true;
            }
            else
            {
                lblCountry.Visible = false;
            }
            if (emailEmpty)
            {
                lblEmail.Text = "** Email must not be empty and in correct format";
                lblEmail.Visible = true;
               
            }
            else if (contactExists)
            {
                lblEmail.Text = "** This email already exists";
                lblEmail.Visible = true;

            }
            else
            {
                lblEmail.Visible = false;
            }
            if (phoneEmpty)
            {
                lblPhone.Text = val.PhoneValidator(txtPhone.Text);
                lblPhone.Visible = true;
            }
            else
            {
                lblPhone.Visible = false;
            }
            if (userNameEmpty)
            {
                lblUserName.Text = "** User name must not be empty";
                lblUserName.Visible = true;
               
            }
            else if (usernameExists)
            {
                lblUserName.Text = "** This username already exists";
                lblUserName.Visible = true;

            }
            else
            {
                lblUserName.Visible = false;
            }
            if (passwordEmpty)
            {
                lblPassword.Visible = true;
            }
            else
            {
                lblPassword.Visible = false;
            }
            if (txtConfirm.Text != txtPassword.Text)
            {
                lblConfirm.Visible = true;
            }
            else
            {
                lblConfirm.Visible = false;
            }
            if (!fNameEmpty && !lNameEmpty && !address1Empty && !address2Empty && !cityEmpty && !countryEmpty && !emailEmpty && !phoneEmpty && !userNameEmpty && !passwordEmpty && !contactExists && !usernameExists && txtConfirm.Text == txtPassword.Text)
            {
                Customer customer = new Customer();

                customer.FirstName = txtFName.Text;
                customer.LastName = txtLName.Text;
                customer.Address1 = txtAddress1.Text;
                customer.Address2 = txtAddress2.Text;
                customer.City = txtCity.Text;
                customer.Country = txtCountry.Text;
                customer.Email = txtEmail.Text;
                customer.Phone = txtPhone.Text;
                customer.UserName = txtUserName.Text;
                customer.UserPassword = HashCode.PassHash(txtPassword.Text);



                _db.Customers.Add(customer);
                _db.SaveChanges();

                ClearForm();

                UserSession.Login(customer.CustomerId);
                Response.Redirect("Default.aspx");
            }
    }
    }
}