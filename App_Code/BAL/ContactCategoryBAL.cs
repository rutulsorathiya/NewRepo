using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.DAL;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for ContactCategoryBAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.BAL
{
	public class ContactCategoryBAL
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
		public ContactCategoryBAL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		#region Insert Operation
		public Boolean Insert(ContactCategoryENT entContactCategory)
        {
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			if(dalContactCategory.Insert(entContactCategory))
            {
				return true;
            }
            else
			{
				Message = dalContactCategory.Message;	
				return false;
            }
		}
		#endregion Insert Operation

		#region Update Operation
		public Boolean UpdateByPK(ContactCategoryENT entContactCategory)
        {
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			if(dalContactCategory.UpdateByPK(entContactCategory))
            {
				return true;
            }
			else
            {
				Message = dalContactCategory.Message;
				return false;
            }
        }
		#endregion Update Operation

		#region Delete Operation
		public Boolean DeleteByPK(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			if(dalContactCategory.DeleteByPK(ContactCategoryID,UserID))
            {
				return true;
            }
            else
            {
				Message = dalContactCategory.Message;
				return false ;
            }
        }
		#endregion Delete Operation

		#region Select Operation
		public DataTable SelectAll(SqlInt32 UserID)
        {
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			return dalContactCategory.SelectAll(UserID);
        }
		public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			return dalContactCategory.SelectForDropDownList(UserID);
        }
		public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			return dalContactCategory.SelectByPK(ContactCategoryID,UserID);
        }
		#endregion Select Operation
	}
}
