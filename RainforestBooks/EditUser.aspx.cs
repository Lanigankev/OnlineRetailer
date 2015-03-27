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
        public Customer CurrentUser { get; set; }
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
            if (!IsPostBack)
            {
                using (var db = new Context())
                {
                    int custId = UserSession.ReturnUserId();
                    Customer user = (from c in db.Customers
                                     where c.CustomerId == custId
                                     select c).FirstOrDefault();

                    CurrentUser = user;

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
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void EditDetails()
        {
            using (var _db = new Context())
            { 

            bool fNameEmpty = true;
            bool lNameEmpty = true;
            bool phoneEmpty = true;
            bool address1Empty = true;
            bool address2Empty = true;
            bool cityEmpty = true;
            bool countryEmpty = true;
            //bool oldpasswordEmpty = true;
            //bool passwordExists = true;
            bool newpasswordEmpty = true;
            bool confirmEmpty = true;


            Validation val = new Validation();

            fNameEmpty = string.IsNullOrEmpty(txtFName.Text);
            lNameEmpty = string.IsNullOrEmpty(txtLName.Text);
            phoneEmpty = string.IsNullOrEmpty(txtPhone.Text);
            phoneEmpty = val.PhoneValidator(txtPhone.Text) == null ? false : true;
            address1Empty = string.IsNullOrEmpty(txtAddress1.Text);
            address2Empty = string.IsNullOrEmpty(txtAddress2.Text);
            cityEmpty = string.IsNullOrEmpty(txtCity.Text);
            countryEmpty = string.IsNullOrEmpty(txtCountry.Text);
            //oldpasswordEmpty = string.IsNullOrEmpty(txtOldPassword.Text);
            //passwordExists = _db.Customers.Any(customer => customer.UserPassword == txtOldPassword.Text);
            newpasswordEmpty = string.IsNullOrEmpty(txtNewPassword.Text);
            confirmEmpty = string.IsNullOrEmpty(txtConfirm.Text);

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
            
            if (phoneEmpty)
            {
                lblPhone.Text = val.PhoneValidator(txtPhone.Text);
                lblPhone.Visible = true;
            }
            else
            {
                lblPhone.Visible = false;
            }

            //if (chckChange.Checked && oldpasswordEmpty) 
            //{
            //    lblOldPasswordWarning.Visible = true;
            //}
            //else if (chckChange.Checked && !passwordExists)
            //{
            //    lblOldPasswordWarning.Visible = true;
            //}
            //else 
            //{
            //    lblOldPasswordWarning.Visible = false;
            //}
            if (chckChange.Checked && (txtConfirm.Text != txtNewPassword.Text || confirmEmpty || newpasswordEmpty))
            {
                lblConfirmWarning.Visible = true;
            }
            else
            {
                lblConfirmWarning.Visible = false;
            }
            if (!fNameEmpty && !lNameEmpty && !address1Empty && !address2Empty && !cityEmpty && !countryEmpty && !phoneEmpty) //&& !passwordEmpty && txtConfirm.Text == txtPassword.Text)
            {
                
                    if (chckChange.Checked && !newpasswordEmpty && !confirmEmpty && txtConfirm.Text == txtNewPassword.Text)
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

                        _db.SaveChanges();

                        //ClearForm();
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

                        _db.SaveChanges();

                        //ClearForm();
                    }
                    
                    Response.Redirect("Default.aspx");
                }
            }
           
        }
        //private void ClearForm()
        //{
        //    txtFName.Text = string.Empty;
        //    txtLName.Text = string.Empty;
        //    txtAddress1.Text = string.Empty;
        //    txtAddress2.Text = string.Empty;
        //    txtEmail.Text = string.Empty;
        //    txtCity.Text = string.Empty;
        //    txtCountry.Text = string.Empty;
        //    txtPhone.Text = string.Empty;
        //    txtUserName.Text = string.Empty;
        //    //txtPassword.Text = string.Empty;
        //}
        


        protected void Button1_Click(object sender, EventArgs e)
        {
            EditDetails();
        }


        protected void chckChange_CheckedChanged1(object sender, EventArgs e)
        {
            if (chckChange.Checked)
            {
                //lblOldPassword.Visible = true;
                lblNewPassword.Visible = true;
                lblConfirm.Visible = true;
                //txtOldPassword.Visible = true;
                txtNewPassword.Visible = true;
                txtConfirm.Visible = true;
            }
            else if (!chckChange.Checked)
            {
                //lblOldPassword.Visible = false;
                lblNewPassword.Visible = false;
                lblConfirm.Visible = false;
                //txtOldPassword.Visible = false;
                txtNewPassword.Visible = false;
                txtConfirm.Visible = false;
            }
        }

    }
}