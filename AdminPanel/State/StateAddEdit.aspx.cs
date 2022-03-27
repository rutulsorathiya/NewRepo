using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook;
using ThreeTier_MultiUser_AddressBook.BAL;
using ThreeTier_MultiUser_AddressBook.ENT;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDown();
            if(Request.QueryString["StateID"]!=null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strErrorMessage = "";
        if(ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country<br/>";
        }
        if(txtStateName.Text =="")
        {
            strErrorMessage += "- Enter State Name<br/>";
        }
        if(txtStateCode.Text =="")
        {
            strErrorMessage += "- Enter State Code<br/>";
        }
        if(strErrorMessage!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        StateENT entState = new StateENT();
        #region Gather Information
        if(ddlCountryID.SelectedIndex>0)
        {
            entState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if(txtStateName.Text !="")
        {
            entState.StateName = txtStateName.Text.ToString().Trim();
        }
        if(txtStateCode.Text!="")
        {
            entState.StateCode =txtStateCode.Text.ToString().Trim();
        }
        entState.UserID = Convert.ToInt32(Session["UserID"]);
        #endregion Gather Information
        StateBAL balState = new StateBAL();
        if (Request.QueryString["StateID"] != null)
        {
            #region Update Record
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            balState.UpdateByPK(entState);
            Response.Redirect("~/AdminPanel/State/StateList.aspx");
            #endregion Update Record
        }
        else
        {
            if (balState.Insert(entState))
            {
                ClearControl();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = balState.Message;
            }
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Button : Cancel

    #region FillDropDown
    private void FillDropDown()
    {
        CommonFillMethods.FillCountryDropDownList(ddlCountryID,Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillDropDown

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();
        entState = balState.SelectByPK(StateID,Convert.ToInt32(Session["UserID"]));
        if (!entState.CountryID.IsNull)
        {
            ddlCountryID.SelectedValue = entState.CountryID.ToString();
        }
        if (!entState.StateName.IsNull)
        {
            txtStateName.Text = entState.StateName.ToString().Trim();
        }
        if (!entState.StateCode.IsNull)
        {
            txtStateCode.Text = entState.StateCode.ToString().Trim();
        }
    }
    #endregion FillControls

    #region ClearControl
    private void ClearControl()
    {
        txtStateCode.Text = "";
        txtStateName.Text = "";
        ddlCountryID.SelectedIndex = 0;
        ddlCountryID.Focus();
    }
    #endregion ClearControl
}