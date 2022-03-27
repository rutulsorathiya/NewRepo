using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;
using ThreeTier_MultiUser_AddressBook.ENT;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strErrorMessage = "";
        if (txtContactCategoryName.Text == "")
        {
            strErrorMessage = "- Enter Contact Category <br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        #region Gather Information
        if (txtContactCategoryName.Text != "")
        {
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.ToString().Trim();
        }
        #endregion Gather Information
        entContactCategory.UserID = Convert.ToInt32(Session["UserID"]);
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if(Request.QueryString["ContactCategoryID"] != null)
        {
            #region Update Record
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);
            balContactCategory.UpdateByPK(entContactCategory);
            Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
            #endregion Update Record
        }
        else
        {
            #region Insert Record
            if (balContactCategory.Insert(entContactCategory))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
                ClearControl();
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
            #endregion Insert Record
        }

    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion Button : Cancel

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID,Convert.ToInt32(Session["UserID"]));
        if (!entContactCategory.ContactCategoryName.IsNull)
        {
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.ToString().Trim();
        }
    }
    #endregion FillControls

    #region ClearControl
    private void ClearControl()
    {
        txtContactCategoryName.Text = "";
        txtContactCategoryName.Focus();
    }
    #endregion ClearControl
}