using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillContactCategoryGridView();
        }
    }
    #endregion Load Event

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

    #region gvContactCategoryList_RowCommand : Delete Record
    protected void gvContactCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
                if (balContactCategory.DeleteByPK(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillContactCategoryGridView();
                }
                else
                {
                    lblMessage.Text = balContactCategory.Message;
                }
            }
        }
    }
    #endregion gvContactCategoryList_RowCommand : Delete Record
}