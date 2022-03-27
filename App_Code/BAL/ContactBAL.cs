using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.DAL;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for ContactBAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.BAL
{
	public class ContactBAL
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
		public ContactBAL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		#region Insert Operation
		public Boolean Insert(ContactENT entContact)
        {
			ContactDAL dalContact = new ContactDAL();
			if(dalContact.Insert(entContact))
            {
				return true;
            }
            else
            {
				Message = dalContact.Message;
				return false;
            }
        }
		#endregion Insert Operation

		#region Update Operation
		public Boolean UpdateByPK(ContactENT entContact)
        {
			ContactDAL dalContact = new ContactDAL();
			if(dalContact.UpdateByPK(entContact))
            {
				return true;
            }
            else
            {
				Message = dalContact.Message;
				return false;
            }
        }
		#endregion Update Operation

		#region Delete Operation
		public Boolean DeleteByPK(SqlInt32 ContactID,SqlInt32 UserID)
        {
			ContactDAL dalContact = new ContactDAL();
			if(dalContact.DeleteByPK(ContactID,UserID))
            {
				return true;
            }
            else
            {
				Message = dalContact.Message;
				return false;
            }
        }
		#endregion Delete Operation

		#region Select Operation
		public DataTable SelectAll(SqlInt32 UserID)
        {
			ContactDAL dalContact =new ContactDAL();
			return dalContact.SelectAll(UserID);
        }
		public ContactENT SelectByPK(SqlInt32 ContactID,SqlInt32 UserID)
        {
			ContactDAL dalContact = new ContactDAL();
			return dalContact.SelectByPK(ContactID,UserID);
        }

		#endregion Select Operation
	}
}
