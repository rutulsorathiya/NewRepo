using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;

public partial class AdminPanel_Home_HomePage : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountryGridView();
            FillStateGridView();
            FillCityGridView();
            FillContactCategoryGridView();
            FillContactGridView();
        }
    }
    #endregion Load Event

    #region FillCountryGridView
    private void FillCountryGridView()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dt = new DataTable();
        dt = balCountry.SelectAll(Convert.ToInt32(Session["UserID"]));
        if (dt.Rows.Count > 0)
        {
            gvCountryList.DataSource = dt;
            gvCountryList.DataBind();
        }
        else
        {
            lblMessage.Text = balCountry.Message;
        }

    }
    #endregion FillCountryGridView

    #region FillStateGridView
    private void FillStateGridView()
    {
        StateBAL balState = new StateBAL();
        DataTable dt = new DataTable();
        dt = balState.SelectAll(Convert.ToInt32(Session["UserID"]));
        if (dt.Rows.Count > 0)
        {
            gvStateList.DataSource = dt;
            gvStateList.DataBind();
        }
        else
        {
            lblMessage.Text = balState.Message;
        }

    }
    #endregion FillStateGridView

    #region FillStateGridView
    private void FillCityGridView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dt = new DataTable();
        dt = balCity.SelectAll(Convert.ToInt32(Session["UserID"]));
        if (dt.Rows.Count > 0)
        {
            gvCityList.DataSource = dt;
            gvCityList.DataBind();
        }
        else
        {
            lblMessage.Text = balCity.Message;
        }

    }
    #endregion FillCityGridView

    #region FillContactCategoryGridView
    private void FillContactCategoryGridView()
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dt = new DataTable();
        dt = balContactCategory.SelectAll(Convert.ToInt32(Session["UserID"]));
        if (dt.Rows.Count > 0)
        {
            gvContactCategoryList.DataSource = dt;
            gvContactCategoryList.DataBind();
        }
        else
        {
            lblMessage.Text = balContactCategory.Message;
        }

    }
    #endregion FillContactCategoryGridView

    #region FillContactGridView
    private void FillContactGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dt = new DataTable();
        dt = balContact.SelectAll(Convert.ToInt32(Session["UserID"]));
        if (dt.Rows.Count > 0)
        {
            gvContactList.DataSource = dt;
            gvContactList.DataBind();
        }
        else
        {
            lblMessage.Text = balContact.Message;
        }

    }
    #endregion FillContactGridView
}