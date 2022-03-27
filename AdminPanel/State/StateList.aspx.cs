using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillStateGridView();
        }
    }
    #endregion Load Event

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

    #region gvStateList_RowCommand: Delete Record
    protected void gvStateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StateBAL balState = new StateBAL();
                if (balState.DeleteByPK(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillStateGridView();
                }
                else
                {
                    lblMessage.Text = balState.Message;
                }
            }
        }
    }
    #endregion gvStateList_RowCommand: Delete Record
}