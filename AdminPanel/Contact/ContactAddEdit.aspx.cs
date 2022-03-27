using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook;
using ThreeTier_MultiUser_AddressBook.BAL;
using ThreeTier_MultiUser_AddressBook.ENT;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if(Request.QueryString["ContactID"]!=null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string ContactPhotoPath = null;
        string PhotoDetail= null;

        #region Server Side Validation
        string strErrorMessage = "";
        if (txtContactName.Text == "")
        {
            strErrorMessage += "-Enter Contact Name<br/>";
        }
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";
        }
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select State<br/>";
        }
        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select City <br/>";
        }

        if (txtContactNumber.Text == "")
        {
            strErrorMessage += "- Enter Contact Number <br/>";
        }
        if (txtBirthDate.Text == "")
        {
            strErrorMessage += "- Enter BirthDate <br/>";
        }
        if (txtEmail.Text == "")
        {
            strErrorMessage += "- Enter Email <br/>";
        }
        if (txtAddress.Text == "")
        {
            strErrorMessage += "- Enter Address<br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.ForeColor=System.Drawing.Color.Red;  
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        ContactENT entContact = new ContactENT();

        #region Gather Information
        if (txtContactName.Text.Trim() != "")
        {
            entContact.ContactName = txtContactName.Text.Trim();
        }
        if (ddlCountryID.SelectedIndex > 0)
        {
            entContact.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (ddlStateID.SelectedIndex > 0)
        {
            entContact.StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (ddlCityID.SelectedIndex > 0)
        {
            entContact.CityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }
        if (txtContactNumber.Text.Trim() != "")
        {
            entContact.ContactNo = txtContactNumber.Text.Trim();
        }
        if (txtWhatsAppNumber.Text.Trim() != "")
        {
            entContact.WhatsAppNo = txtWhatsAppNumber.Text.Trim();
        }
        if (txtBirthDate.Text.Trim() != "")
        {
            entContact.BirthDate = Convert.ToDateTime(txtBirthDate.Text.ToString().Trim());
        }
        if (txtEmail.Text.Trim() != "")
        {
            entContact.Email = txtEmail.Text.Trim();
        }
        if (txtAge.Text.Trim() != "")
        {
            entContact.Age = Convert.ToInt32(txtAge.Text.Trim());
        }
        if (txtAddress.Text.Trim() != "")
        {
            entContact.Address = txtAddress.Text.Trim();
        }
        if (txtBloodGroup.Text.Trim() != "")
        {
            entContact.BloodGroup = txtBloodGroup.Text.Trim();
        }
        if (txtFaceBookID.Text.Trim() != "")
        {
            entContact.FacebookID = txtFaceBookID.Text.Trim();
        }
        if (txtLinkedINID.Text.Trim() != "")
        {
            entContact.LinkedINID = txtLinkedINID.Text.Trim();
        }
        #endregion Gather Information

        entContact.UserID = Convert.ToInt32(Session["UserID"]);
        ContactBAL balContact = new ContactBAL();

        if(Request.QueryString["ContactID"]!=null)
        {
            ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
            balContactWiseContactCategory.DeleteByPK(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Request.QueryString["ContactID"]));
            foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
            {
                if (liContactCategoryID.Selected)
                {
                    ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();
                    entContactWiseContactCategory.UserID = Convert.ToInt32(Session["UserID"]);
                    entContactWiseContactCategory.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
                    entContactWiseContactCategory.ContactCategoryID = Convert.ToInt32(liContactCategoryID.Value);
                    ContactWiseContactCategoryBAL balContactWiseContactCategory1 = new ContactWiseContactCategoryBAL();
                    balContactWiseContactCategory1.Insert(entContactWiseContactCategory);
                }
            }
            #region File Upload & Delete Old Record
            if (fuContactPhotoPath.HasFile)
            {
                #region Delete old File 
                FileInfo file = new FileInfo(Server.MapPath(hfContactPhotoPath.Value));
                if (file.Exists)
                {
                    file.Delete();
                }
                #endregion Delete old File
                #region File Details
                string fileExtension = System.IO.Path.GetExtension(fuContactPhotoPath.FileName);
                if (fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".svg" || fileExtension.ToLower() == ".jpg")
                {
                    int fileSize = fuContactPhotoPath.PostedFile.ContentLength;
                    System.Drawing.Image img = System.Drawing.Image.FromStream(fuContactPhotoPath.PostedFile.InputStream);
                    int height = img.Height;
                    int width = img.Width;
                    PhotoDetail = "File Extension :" + fileExtension + "File Size :" + (fileSize / 1024) + "KB" + "Height :" + height + "Width :" + width;
                    ContactPhotoPath = "~/AdminPanel/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();
                    fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));
                    entContact.ContactPhotoPath= ContactPhotoPath;
                    entContact.PhotoDetail= PhotoDetail;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only Photos You Can Upload";
                    return;
                }
                #endregion File Details
            }
            else
            {
                entContact.ContactPhotoPath = hfContactPhotoPath.Value;
                entContact.PhotoDetail = hfPhotoDetail.Value;
            }
            #endregion File Upload & Delete Old Record
            entContact.ContactID = Convert.ToInt32(Convert.ToInt32(Request.QueryString["ContactID"]));
            if (balContact.UpdateByPK(entContact))
            {
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
        }
        else
        {

            #region Insert Photo
            if (fuContactPhotoPath.HasFile == false)
            {
                strErrorMessage += "- Select Photo <br/>";
                lblMessage.Text = strErrorMessage;
                return;
            }
            if (fuContactPhotoPath.HasFile)
            {
                #region File Detail
                string fileExtension = System.IO.Path.GetExtension(fuContactPhotoPath.FileName);
                if (fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".svg" || fileExtension.ToLower() == ".jpg")
                {
                    int fileSize = fuContactPhotoPath.PostedFile.ContentLength;
                    System.Drawing.Image img = System.Drawing.Image.FromStream(fuContactPhotoPath.PostedFile.InputStream);
                    int height = img.Height;
                    int width = img.Width;
                    PhotoDetail = "File Extension :" + fileExtension + "File Size :" + (fileSize / 1024) + "KB" + "Height :" + height + "Width :" + width;
                    ContactPhotoPath = "~/AdminPanel/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();
                    if (!Directory.Exists(Server.MapPath("~/AdminPanel/UserContent/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/AdminPanel/UserContent/"));
                    }
                    fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));
                    entContact.ContactPhotoPath = ContactPhotoPath;
                    entContact.PhotoDetail= PhotoDetail;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only Photos You Can Upload";
                    return;
                }
                #endregion File Detail
            }
            #endregion Insert Photo
            if (balContact.Insert(entContact))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
                
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
            #region Insert CheckBox
            ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();
            entContactWiseContactCategory.UserID = Convert.ToInt32(Session["UserID"]);
            entContactWiseContactCategory.ContactID = entContact.ContactID;
            ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
            foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
            {
                if (liContactCategoryID.Selected)
                {
                    
                    
                    entContactWiseContactCategory.ContactCategoryID = Convert.ToInt32(liContactCategoryID.Value);
                   
                    balContactWiseContactCategory.Insert(entContactWiseContactCategory);
                }
            }
            #endregion Insert CheckBox
            ClearControl();
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
    }
    #endregion Button : Cancel

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillCountryDropDownList(ddlCountryID,Convert.ToInt32(Session["UserID"]));
        CommonFillMethods.FillCBLDropDownList(cblContactCategoryID, Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillDropDownList

    #region ddlCountryID_SelectedIndexChanged
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFillMethods.FillStateDropDownListByPK(ddlStateID, Convert.ToInt32(ddlCountryID.SelectedValue),Convert.ToInt32(Session["UserID"]));
        ddlCityID.Items.Clear();
        ddlCityID.Items.Insert(0, new ListItem("-- Select City --", "-1"));
    }
    #endregion ddlCountryID_SelectedIndexChanged

    #region ddlStateID_SelectedIndexChanged
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFillMethods.FillCityDropDownListByPK(ddlCityID, Convert.ToInt32(ddlStateID.SelectedValue), Convert.ToInt32(Session["UserID"]));
    }
    #endregion ddlStateID_SelectedIndexChanged

    #region FillControls
    private void FillControls(SqlInt32 ContactID)
    {
        ContactBAL balContact = new ContactBAL();
        ContactENT entContact = new ContactENT();
        entContact = balContact.SelectByPK(ContactID, Convert.ToInt32(Session["UserID"]));
        if (!entContact.ContactName.IsNull)
        {
            txtContactName.Text = entContact.ContactName.ToString().Trim();
        }
        if (!entContact.CountryID.IsNull)
        {
            ddlCountryID.SelectedValue = entContact.CountryID.ToString().Trim();
            CommonFillMethods.FillStateDropDownListByPK(ddlStateID, Convert.ToInt32(ddlCountryID.SelectedValue), Convert.ToInt32(Session["UserID"]));
        }
        if (!entContact.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entContact.StateID.ToString().Trim();
            CommonFillMethods.FillCityDropDownListByPK(ddlCityID, Convert.ToInt32(ddlStateID.SelectedValue), Convert.ToInt32(Session["UserID"]));
        }
        if (!entContact.CityID.IsNull)
        {
            ddlCityID.SelectedValue = entContact.CityID.ToString().Trim();
        }
        if (!entContact.ContactNo.IsNull)
        {
            txtContactNumber.Text = entContact.ContactNo.ToString().Trim();
        }
        if (!entContact.WhatsAppNo.IsNull)
        {
            txtWhatsAppNumber.Text = entContact.WhatsAppNo.ToString().Trim();
        }
        if (!entContact.BirthDate.IsNull)
        {
            txtBirthDate.Text = Convert.ToDateTime(entContact.BirthDate.ToString()).ToString("yyyy-MM-dd");
        }
        if (!entContact.Email.IsNull)
        {
            txtEmail.Text = entContact.Email.ToString().Trim();
        }
        if (!entContact.Age.IsNull)
        {
            txtAge.Text = entContact.Age.ToString().Trim();
        }
        if (!entContact.BloodGroup.IsNull)
        {
            txtBloodGroup.Text = entContact.BloodGroup.ToString().Trim();
        }
        if (!entContact.Address.IsNull)
        {
            txtAddress.Text = entContact.Address.ToString().Trim();
        }
        if (!entContact.FacebookID.IsNull)
        {
            txtFaceBookID.Text = entContact.FacebookID.ToString().Trim();
        }
        if (!entContact.LinkedINID.IsNull)
        {
            txtLinkedINID.Text = entContact.LinkedINID.ToString().Trim();
        }
        if(!entContact.ContactPhotoPath.IsNull)
        {
            hfContactPhotoPath.Value= entContact.ContactPhotoPath.ToString().Trim();    
        }
        if(!entContact.PhotoDetail.IsNull)
        {
            hfPhotoDetail.Value = entContact.PhotoDetail.ToString().Trim();
        }
        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        DataTable dt = new DataTable();
        dt = balContactWiseContactCategory.SelectByPK(Convert.ToInt32(Session["UserID"]),ContactID);
        foreach(DataRow dr in dt.Rows)
        {
            foreach(ListItem liContactCategory in cblContactCategoryID.Items)
            {
                if(liContactCategory.Value==dr["ContactCategoryID"].ToString())
                {
                    liContactCategory.Selected = true;
                }
            }
        }
            

    }
    #endregion FillControls

    #region ClearControl
    private void ClearControl()
    {
        txtContactName.Text = "";
        txtContactName.Focus();
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        txtContactNumber.Text = "";
        txtWhatsAppNumber.Text = "";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBloodGroup.Text = "";
        txtFaceBookID.Text = "";
        txtLinkedINID.Text = "";
        cblContactCategoryID.ClearSelection();
    }
    #endregion ClearControl
}