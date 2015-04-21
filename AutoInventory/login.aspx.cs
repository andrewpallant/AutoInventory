using AutoInventory.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoInventory
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                PortalUser user = PortalUser.ValidateUser((String)Request["txtUsername"], (String)Request["txtPassword"]);
                if(user.ID > 0)
                {
                    Session["LoggedIn"] = true;
                    Response.Redirect("/");
                }
                else
                {
                    errorMsg.InnerText = "Username And Password Was Not Found!";
                }
            }
        }
    }
}