using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.BAL;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace ThreeTier_MultiUser_AddressBook
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region FillCountryDropDownList
        public static void FillCountryDropDownList(DropDownList ddl,SqlInt32 UserID)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectForDropDownList(UserID);
            ddl.DataTextField = "CountryName";
            ddl.DataValueField = "CountryID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Select Country --", "-1"));
        }
        #endregion FillCountryDropDownList

        #region FillStateDropDownList
        public static void FillStateDropDownList(DropDownList ddl,SqlInt32 UserID)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownList(UserID);
            ddl.DataTextField = "StateName";
            ddl.DataValueField = "StateID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Select State --", "-1"));
        }
        #endregion FillStateDropDownList

        #region FillStateDropDownListByPK
        public static void FillStateDropDownListByPK(DropDownList ddl,SqlInt32 CountryID,SqlInt32 UserID)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownListByPK(CountryID,UserID);
            ddl.DataTextField = "StateName";
            ddl.DataValueField = "StateID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Select State --", "-1"));
        }
        #endregion FillStateDropDownListByPK

        #region FillCityDropDownListByPK
        public static void FillCityDropDownListByPK(DropDownList ddl ,SqlInt32 StateID,SqlInt32 UserID)
        {
            CityBAL balCity = new CityBAL();    
            ddl.DataSource =  balCity.SelectForDropDownListByPK(StateID,UserID);
            ddl.DataTextField = "CityName";
            ddl.DataValueField = "CityID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Select City --", "-1"));
        }
        #endregion FillCityDropDownListByPK

        #region FillContactCategoryDropDownList
        public static void FillContactCategoryDropDownList(DropDownList ddl,SqlInt32 UserID)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            ddl.DataSource = balContactCategory.SelectForDropDownList(UserID);
            ddl.DataTextField = "ContactCategoryName";
            ddl.DataValueField = "ContactCategoryID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Select Contact Category --", "-1"));
        }
        #endregion FillContactCategoryDropDownList

        public static void FillCBLDropDownList(CheckBoxList cbl, SqlInt32 UserID)
        {
            ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
            cbl.DataSource = balContactWiseContactCategory.SelectAll(UserID);
            cbl.DataValueField ="ContactCategoryID";
            cbl.DataTextField = "ContactCategoryName";
            cbl.DataBind();
        }


    }

}
