using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoInventory
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean isLoggedIn = (Boolean?)Session["LoggedIn"] ?? false;
            if (!isLoggedIn) Response.Redirect("/Login");
        }
    }
}