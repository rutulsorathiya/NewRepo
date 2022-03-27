using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillCountryGridView();
        }
    }
    #endregion Load Event

    #region FillCountryGridView
    private void FillCountryGridView()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dt = new DataTable();
        dt=balCountry.SelectAll(Convert.ToInt32(Session["UserID"]));
        if(dt.Rows.Count > 0)
        {
            gvCountryList.DataSource = dt;
            gvCountryList.DataBind();
        }
        else
        {
            lblMessage.Text =balCountry.Message;
        }
        
    }
    #endregion FillCountryGridView

    #region gvCountryList_RowCommand : Delete Record
    protected void gvCountryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteRecord")
        {
           if(e.CommandArgument!=null)
           {
                CountryBAL balCountry = new CountryBAL();
                if(balCountry.DeleteByPK(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillCountryGridView();
                }
                else
                {
                    lblMessage.Text=balCountry.Message;
                }
           }
        }
    }
    #endregion gvCountryList_RowCommand : Delete Record
}