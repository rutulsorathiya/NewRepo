using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.DAL;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for ContactWiseContactCategoryBAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.BAL
{
    public class ContactWiseContactCategoryBAL
    {
        #region Message
        protected string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Message

        #region Constructor
        public ContactWiseContactCategoryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            if(dalContactWiseContactCategory.Insert(entContactWiseContactCategory))
            {
                return true;
            }         
            else
            {
                Message= dalContactWiseContactCategory.Message;
                return false;
            } 
                
        }
        #endregion Insert Operation

        #region Select Operation
        public DataTable SelectAll(SqlInt32 UserID)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            return dalContactWiseContactCategory.SelectAll(UserID);
        }

        public DataTable SelectByPK(SqlInt32 UserID,SqlInt32 ContactID)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCatwgory = new ContactWiseContactCategoryDAL();
            return dalContactWiseContactCatwgory.SelectByPK(UserID,ContactID);
        }

        #endregion Select Operation

        public Boolean DeleteByPK(SqlInt32 UserID,SqlInt32 ContactID)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCatwgory = new ContactWiseContactCategoryDAL();
            return dalContactWiseContactCatwgory.DeleteByPK(UserID, ContactID);
        }

            
    }
}
