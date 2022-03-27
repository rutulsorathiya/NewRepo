using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;
using ThreeTier_MultiUser_AddressBook.ENT;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strErrorMessage = "";

        if(txtCountryName.Text =="")
        {
            strErrorMessage += "- Enter Country Name<br/>";
        }
        if(txtCountryCode.Text =="")
        {
            strErrorMessage += "- Enter Country Code <br/>";
        }
        if(strErrorMessage!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        CountryENT entCountry = new CountryENT();

        #region Gather Information
        if(txtCountryName.Text!="")
        {
            entCountry.CountryName= txtCountryName.Text.ToString().Trim();
        }
        if(txtCountryCode.Text!="")
        {
            entCountry.CountryCode= txtCountryCode.Text.ToString().Trim();
        }
        #endregion Gather Information

        entCountry.UserID = Convert.ToInt32(Session["UserID"]);
        CountryBAL balCountry = new CountryBAL();

        if(Request.QueryString["CountryID"] != null)
        {
            #region Update Record
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            balCountry.UpdateByPK(entCountry);
            Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            #endregion Update Record
        }
        else
        {
            #region Insert Record
            if (balCountry.Insert(entCountry))
            {
                ClearControl();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = balCountry.Message;
            }
            #endregion Insert Record
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    #endregion Button : Cancel

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();
        entCountry = balCountry.SelectByPK(CountryID,Convert.ToInt32(Session["UserID"]));

        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.ToString().Trim();
        }
        if (!entCountry.CountryCode.IsNull)
        {
            txtCountryCode.Text = entCountry.CountryCode.ToString().Trim();
        }
    }
    #endregion FillControls

    #region ClearControl
    private void ClearControl()
    {
        txtCountryCode.Text = "";
        txtCountryName.Text = "";
        txtCountryName.Focus();
    }
    #endregion ClearControl
}