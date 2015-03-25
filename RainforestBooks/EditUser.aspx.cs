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
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void EditDetails()
        {
            var _db = new Context();

            bool fNameEmpty = true;
            bool lNameEmpty = true;
            bool phoneEmpty = true;
            //bool isPlaceHolderEmail = true;
            //bool isPlaceHolderPhone = true;
            bool address1Empty = true;
            bool address2Empty = true;
            bool cityEmpty = true;
            bool countryEmpty = true;
            bool passwordEmpty = true;
           


            Validation val = new Validation();

            fNameEmpty = string.IsNullOrEmpty(txtFName.Text);
            lNameEmpty = string.IsNullOrEmpty(txtLName.Text);
            phoneEmpty = string.IsNullOrEmpty(txtPhone.Text);
            phoneEmpty = val.PhoneValidator(txtPhone.Text) == null ? false : true;
            address1Empty = string.IsNullOrEmpty(txtAddress1.Text);
            address2Empty = string.IsNullOrEmpty(txtAddress2.Text);
            cityEmpty = string.IsNullOrEmpty(txtCity.Text);
            countryEmpty = string.IsNullOrEmpty(txtCountry.Text);
            passwordEmpty = string.IsNullOrEmpty(txtPassword.Text);


         
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
            
            if (phoneEmpty)
            {
                lblPhone.Text = val.PhoneValidator(txtPhone.Text);
                lblPhone.Visible = true;
            }
            else
            {
                lblPhone.Visible = false;
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
            if (!fNameEmpty && !lNameEmpty && !address1Empty && !address2Empty && !cityEmpty && !countryEmpty && !phoneEmpty && !passwordEmpty && txtConfirm.Text == txtPassword.Text)
            {
                Customer customer = (from cus in _db.Customers
                                     where cus.FirstName == txtFName.Text
                                     select cus).First();

                
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

                //_db.Customers.Add(customer);
                _db.SaveChanges();

                ClearForm();
            }
            else
            {
                lblPassword.Visible = true;
                lblPassword.Text = "Sex";
            }
        }
        private void ClearForm()
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var _db = new Context();

            txtFName.Text = (from customers in _db.Customers
                             where customers.UserName == txtUserName.Text
                             select customers.FirstName).Single();

            txtLName.Text = (from customers in _db.Customers
                             where customers.UserName == txtUserName.Text
                             select customers.LastName).Single();

            txtAddress1.Text = (from customers in _db.Customers
                                where customers.UserName == txtUserName.Text
                                select customers.Address1).Single();

            txtAddress2.Text = (from customers in _db.Customers
                                where customers.UserName == txtUserName.Text
                                select customers.Address2).Single();

            txtCity.Text = (from customers in _db.Customers
                            where customers.UserName == txtUserName.Text
                            select customers.City).Single();

            txtCountry.Text = (from customers in _db.Customers
                               where customers.UserName == txtUserName.Text
                               select customers.Country).Single();

            txtEmail.Text = (from customers in _db.Customers
                             where customers.UserName == txtUserName.Text
                             select customers.Email).Single();

            txtPhone.Text = (from customers in _db.Customers
                             where customers.UserName == txtUserName.Text
                             select customers.Phone).Single();

            txtPassword.Text = (from customers in _db.Customers
                                where customers.UserName == txtUserName.Text
                                select customers.UserPassword).Single();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            EditDetails();
        }

    }
}