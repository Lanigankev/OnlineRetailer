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
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (UserSession.ReturnUserId() == -1)
            {
                Response.Redirect("Default.aspx");
            }
            else if (AdminSession.IsAdminSession() == true)
            {
                Response.Redirect("Default.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            using(var db = new Context())
            {
                int custId = UserSession.ReturnUserId();
                Customer user = (from c in db.Customers
                                 where c.CustomerId == custId
                                 select c).FirstOrDefault();

                txtFName.Text = user.FirstName;
                txtLName.Text = user.LastName;
                txtCountry.Text = user.Country;
                txtCity.Text = user.City;
                txtAddress1.Text = user.Address1;
                txtAddress2.Text = user.Address2;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtUserName.Text = user.UserName;
            }
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
            //bool passwordExists = _db.Customers.Any(customer => customer.Email == txtEmail.Text);


            Validation val = new Validation();

            fNameEmpty = string.IsNullOrEmpty(txtFName.Text);
            lNameEmpty = string.IsNullOrEmpty(txtLName.Text);
            phoneEmpty = string.IsNullOrEmpty(txtPhone.Text);
            phoneEmpty = val.PhoneValidator(txtPhone.Text) == null ? false : true;
            address1Empty = string.IsNullOrEmpty(txtAddress1.Text);
            address2Empty = string.IsNullOrEmpty(txtAddress2.Text);
            cityEmpty = string.IsNullOrEmpty(txtCity.Text);
            countryEmpty = string.IsNullOrEmpty(txtCountry.Text);
            passwordEmpty = string.IsNullOrEmpty(txtOldPassword.Text);


         
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

            if (chckChange.Checked && passwordEmpty)
            {
                lblOldPassword.Visible = true;
            }
            else
            {
                lblOldPassword.Visible = false;
            }
            if (chckChange.Checked && txtConfirm.Text != txtNewPassword.Text)
            {
                lblConfirm.Visible = true;
            }
            else
            {
                lblConfirm.Visible = false;
            }
            if (!fNameEmpty && !lNameEmpty && !address1Empty && !address2Empty && !cityEmpty && !countryEmpty && !phoneEmpty) //&& !passwordEmpty && txtConfirm.Text == txtPassword.Text)
            {
                if (chckChange.Checked && !passwordEmpty && txtConfirm.Text == txtNewPassword.Text)
                {
                    Customer customer = (from cus in _db.Customers
                                         where cus.UserName == txtUserName.Text
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
                    customer.UserPassword = HashCode.PassHash(txtNewPassword.Text);

                    //_db.Customers.Add(customer);
                    _db.SaveChanges();

                    ClearForm();
                }
                else if (!chckChange.Checked)
                {
                    Customer customer = (from cus in _db.Customers
                                         where cus.UserName == txtUserName.Text
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

                    //_db.Customers.Add(customer);
                    _db.SaveChanges();

                    ClearForm();
                }
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
            //txtPassword.Text = string.Empty;
        }
        


        protected void Button1_Click(object sender, EventArgs e)
        {
            EditDetails();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var _db = new Context();

            Customer customer = (from cus in _db.Customers
                                 where cus.UserName == txtUserName.Text
                                 select cus).First();

            txtFName.Text = customer.FirstName;

            txtLName.Text = customer.LastName;

            txtAddress1.Text = customer.Address1;

            txtAddress2.Text = customer.Address2;

            txtCity.Text = customer.City;

            txtCountry.Text = customer.Country;

            txtEmail.Text = customer.Email;

            txtPhone.Text = customer.Phone;

            //txtPassword.Text = customer.UserPassword.ToString();
        }

        protected void chckChange_CheckedChanged(object sender, EventArgs e)
        {
            if (chckChange.Checked)
            {
                txtOldPassword.Enabled = true;
                txtNewPassword.Enabled = true;
                txtConfirm.Enabled = true;
            }
            else
            {
                txtOldPassword.Enabled = false;
                txtNewPassword.Enabled = false;
                txtConfirm.Enabled = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var _db = new Context();

            Customer customer = (from cus in _db.Customers
                                 where cus.UserName == txtUserName.Text
                                 select cus).First();
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }

    }
}