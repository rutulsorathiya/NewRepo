using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;
using ThreeTier_MultiUser_AddressBook.ENT;

public partial class AdminPanel_Register_Register : System.Web.UI.Page
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
        String strErrorMessage = "";
        if (txtUserName.Text == String.Empty)
        {
            strErrorMessage += "- Enter User Name <br/>";
        }
        if (txtPassword.Text == String.Empty)
        {
            strErrorMessage += "- Enter Password <br/>";
        }
        if (txtReEnterPassowrd.Text == String.Empty)
        {
            strErrorMessage += "Retype Password <br/>";
        }
        if (txtDisplayName.Text == String.Empty)
        {
            strErrorMessage += "- Enter Display Name <br/>";
        }
        if (txtEmail.Text == String.Empty)
        {
            strErrorMessage += "- Enter Email <br/>";
        }
        if (txtContactNo.Text == String.Empty)
        {
            strErrorMessage += "- Enter Contact Number <br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        #region Gather Information

        if(txtPassword.Text== txtReEnterPassowrd.Text)
        {
            if (txtUserName.Text != String.Empty)
            {
                entUser.UserName = txtUserName.Text.ToString().Trim();
            }
            if (txtPassword.Text != String.Empty)
            {
                entUser.Password = txtPassword.Text.ToString().Trim();
            }
            if (txtDisplayName.Text != String.Empty)
            {
                entUser.DisplayName = txtDisplayName.Text.ToString().Trim();
            }
            if (txtEmail.Text != String.Empty)
            {
                entUser.Email = txtEmail.Text.ToString().Trim();
            }
            if (txtContactNo.Text != String.Empty)
            {
                entUser.ContactNo = txtContactNo.Text.ToString().Trim();
            }
            if(balUser.Insert(entUser))
            {
                ClearControl();
            }
            else
            {
                lblMessage.Text = balUser.Message;
            }
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Check Your Retype Password";
            return;
        }

        #endregion Gather Information
    }
    #endregion Button : Login

    #region ClearControl
    private void ClearControl()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtReEnterPassowrd.Text = "";
        txtDisplayName.Text = "";
        txtEmail.Text = "";
        txtContactNo.Text = "";
        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Text = "Registered Successfully";
    }
    #endregion ClearControl
}