using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.ENT;
using ThreeTier_MultiUser_AddrressBook.DAL;

/// <summary>
/// Summary description for CountryBAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.BAL
{
    public class CountryBAL
    {
        #region Local Variable
        protected string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable

        #region Constructor
        public CountryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if(dalCountry.Insert(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean UpdateByPK(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if(dalCountry.UpdateByPK(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean DeleteByPK(SqlInt32 CountryID,SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            if(dalCountry.DeleteByPK(CountryID,UserID))
            {
                return true;
            }
            else
            {
                Message= dalCountry.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation
        public DataTable SelectAll(SqlInt32 UserID)
        { 
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAll(UserID);
        }

        public DataTable  SelectForDropDownList(SqlInt32 UserID)
        {
            CountryDAL dalCountry  = new CountryDAL();
            return dalCountry.SelectForDropDownList(UserID);
        }

        public CountryENT SelectByPK(SqlInt32 CountryID,SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByPK(CountryID,UserID);
        }
        #endregion Select Operation
    }
}
 