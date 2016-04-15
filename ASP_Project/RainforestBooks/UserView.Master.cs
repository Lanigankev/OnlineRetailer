using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainforestBooks
{
    public partial class UserView : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;

            Response.Redirect("Search.aspx?search=" + search);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.LogOut();
            Response.Redirect(Request.RawUrl);
        }
    }
}