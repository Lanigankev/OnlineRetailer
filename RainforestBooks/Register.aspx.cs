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
            RegisterTest reg = new RegisterTest();
            reg.FirstName = txtFName.Text;
            reg.LastName = txtLName.Text;
            reg.Address1 = txtAddress1.Text;
            reg.Address2 = txtAddress2.Text;
            reg.Address3 = txtAddress3.Text;
            reg.City = txtCity.Text;
            reg.Country = txtCountry.Text;
            reg.Phone = txtPhone.Text;
            reg.UserName = txtUserName.Text;
            reg.Password = HashCode.PassHash(txtPassword.Text);


            var _db = new Context();
            _db.Registers.Add(reg);
            _db.SaveChanges();
        }
    }
}