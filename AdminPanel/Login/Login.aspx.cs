using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;
using ThreeTier_MultiUser_AddressBook.ENT;

public partial class AdminPanel_Login_Login : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event

    #region Button : Login
    protected void lbLogin_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strErrorMessage = "";
        if(txtUserName.Text=="")
        {
            strErrorMessage += "- Enter UserName <br/>";
        }
        if(txtPassword.Text=="")
        {
            strErrorMessage += "- Enter Password<br/>";
        }
        if(strErrorMessage !="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();
        entUser = balUser.SelectByPK(txtUserName.Text, txtPassword.Text);
        if (entUser != null)
        {
            if (!entUser.DisplayName.IsNull)
            {
                Session["DisplayName"] = entUser.DisplayName.ToString();
            }
            if (!entUser.UserID.IsNull)
            {
                Session["UserID"] = entUser.UserID.ToString();
            }
            Response.Redirect("~/AdminPanel/Home/HomePage.aspx", true);
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Invalid UserName or Password";
        }
    }
    #endregion Button : Login
}