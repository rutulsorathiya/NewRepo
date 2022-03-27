using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_ThreeTier_MultiUser_AddressBook : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != "")
        {
            if (Session["DisplayName"] != "")
            {
                lblDisplayName.Text = "Hi, <strong>Mr." + Session["DisplayName"] + "</Strong>";
            }
        }
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login/Login.aspx", true);
        }
    }

    protected void hlLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
    }
}
