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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Request.QueryString["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation 
        string strErrorMessage = "";
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select State Name <br/>";
        }
        if (txtCityName.Text == String.Empty)
        {
            strErrorMessage += "- Enter City Name <br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation 

        CityENT entCity = new CityENT();

        #region Gather Information
        if (ddlStateID.SelectedIndex > 0)
        {
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (txtCityName.Text != String.Empty)
        {
            entCity.CityName = txtCityName.Text.ToString().Trim();
        }
        if (txtPinCode.Text != String.Empty)
        {
            entCity.PinCode = txtPinCode.Text.ToString().Trim();
        }
        if (txtSTDCode.Text != String.Empty)
        {
            entCity.STDCode = txtSTDCode.Text.ToString().Trim();
        }
        #endregion Gather Information
        entCity.UserID = Convert.ToInt32(Session["UserID"]);
        CityBAL balCity = new CityBAL();
        if(Request.QueryString["CityID"] != null)
        {
            #region Update Record
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            balCity.UpdateByPK(entCity);
            Response.Redirect("~/AdminPanel/City/CityList.aspx");
            #endregion Update Record
        }
        else
        {
            #region Insert Record
            if (balCity.Insert(entCity))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
                ClearControl();
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
            #endregion Insert Record
        }

    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Button : Cancel

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillStateDropDownList(ddlStateID, Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();
        entCity = balCity.SelectByPK(CityID,Convert.ToInt32(Session["UserID"]));
        if (!entCity.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entCity.StateID.ToString();
        }
        if (!entCity.CityName.IsNull)
        {
            txtCityName.Text = entCity.CityName.ToString();
        }
        if (!entCity.STDCode.IsNull)
        {
            txtSTDCode.Text = entCity.STDCode.ToString();
        }
        if (!entCity.PinCode.IsNull)
        {
            txtPinCode.Text = entCity.PinCode.ToString();
        }
    }
    #endregion FillControls

    #region ClearControl
    private void ClearControl()
    {
        txtCityName.Text = "";
        txtPinCode.Text = "";
        txtSTDCode.Text = "";
        ddlStateID.SelectedIndex = 0;
        ddlStateID.Focus();
    }
    #endregion ClearControl
}