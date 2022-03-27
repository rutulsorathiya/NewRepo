using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactGridView();
        }
    }
    #endregion Load Event

    #region FillContactGridView
    private void FillContactGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dt = new DataTable();
        dt = balContact.SelectAll(Convert.ToInt32(Session["UserID"]));
            gvContactList.DataSource = dt;
            gvContactList.DataBind();
        if(dt.Rows.Count ==0)
            lblMessage.Text = balContact.Message;
        

    }
    #endregion FillContactGridView

    #region gvContactList_RowCommand : Delete Record
    protected void gvContactList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Path = null;
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                #region Delete Photo
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ThreeTier_MultiUser_AddressBookConnectionString"].ConnectionString);
                objConn.Open();
                SqlCommand obj = objConn.CreateCommand();
                obj.CommandType = CommandType.StoredProcedure;
                obj.CommandText = "PR_Contact_SelectByPKAndUserID";
                obj.Parameters.AddWithValue("@UserID",Session["UserID"]);
                obj.Parameters.AddWithValue("@ContactID", Convert.ToInt32(e.CommandArgument));
                SqlDataReader objSDR = obj.ExecuteReader();
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                        {
                            Path = objSDR["ContactPhotoPath"].ToString().Trim();
                        }
                        break;
                    }
                }
                FileInfo file = new FileInfo(Server.MapPath(Path));
                if (file.Exists)
                {
                    file.Delete();
                }
                objConn.Close();
                #endregion Delete Photo

                ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
                balContactWiseContactCategory.DeleteByPK(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(e.CommandArgument));

                ContactBAL balContact = new ContactBAL();
                if (balContact.DeleteByPK(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["UserID"])))
                {
                    FillContactGridView();
                }
                else
                {
                    lblMessage.Text = balContact.Message;
                }
            }
        }
    }
    #endregion gvContactList_RowCommand : Delete Record

   
 
}