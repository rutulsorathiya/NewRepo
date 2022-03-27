using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCityGridView();
        }
    }
    #endregion Load Event

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

    #region gvCityList_RowCommand : Delete Record
    protected void gvCityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CityBAL balCity = new CityBAL();
                if (balCity.DeleteByPK(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillCityGridView();
                }
                else
                {
                    lblMessage.Text = balCity.Message;
                }
            }
        }
    }
    #endregion gvCityList_RowCommand : Delete Record
}