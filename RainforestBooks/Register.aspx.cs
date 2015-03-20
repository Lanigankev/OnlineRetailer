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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            
            customer.FirstName = txtFName.Text;
            customer.LastName = txtLName.Text;
            customer.Address1 = txtAddress1.Text;
            customer.Address2 = txtAddress2.Text;
            customer.Email = txtEmail.Text;
            customer.City = txtCity.Text;
            customer.Country = txtCountry.Text;
            customer.Phone = txtPhone.Text;
            customer.UserName = txtUserName.Text;
            customer.Password = HashCode.PassHash(txtPassword.Text);


            var _db = new Context();
            _db.Customers.Add(customer);
            _db.SaveChanges();
            
            ClearForm();

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
    }
}