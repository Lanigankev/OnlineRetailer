using RainforestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainforestBooks
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if(UserSession.ReturnUserId() != -1)
            {
                this.MasterPageFile = "~/UserView.master";
            }
            else if (AdminSession.IsAdminSession() == true)
            {
                this.MasterPageFile = "~/AdminView.master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}