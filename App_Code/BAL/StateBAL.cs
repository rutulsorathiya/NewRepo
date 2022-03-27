using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.DAL;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for StateBAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.BAL
{
	public class StateBAL
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
		public StateBAL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		#region Insert Opearion
		public Boolean Insert(StateENT entState)
        {
			StateDAL dalState = new StateDAL();
			if (dalState.Insert(entState))
			{
				return true;
			}
			else
            {
				Message = dalState.Message;
				return false;
            }
        }
		#endregion Insert Operation

		#region Update Operation

		public Boolean UpdateByPK(StateENT entState)
        {
			StateDAL dalState = new StateDAL();
			if(dalState.UpdateByPK(entState))
            {
				return true;
            }
            else
            {
				Message = dalState.Message;
				return false;
            }
		}
		#endregion Update Operation

		#region Delete Operation
		public Boolean DeleteByPK(SqlInt32 StateID,SqlInt32 UserID)
        {
			StateDAL dalState = new StateDAL();
			if(dalState.DeleteByPK(StateID,UserID))
            {
				return true;
            }
            else
            {
				Message = dalState.Message;
				return false ;
            }
        }
		#endregion Delete Operation

		#region Select Operation
		public DataTable SelectAll(SqlInt32 UserID)
        {
			StateDAL dalState = new StateDAL();
			return dalState.SelectAll(UserID);
        }
		public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
			StateDAL dalState = new StateDAL();
			return dalState.SelectForDropDownList(UserID);
		}
		public DataTable SelectForDropDownListByPK(SqlInt32 CountryID,SqlInt32 UserID)
        {
			StateDAL dalState = new StateDAL();
			return dalState.SelectForDropDownListByPK(CountryID,UserID);
        }
		public StateENT SelectByPK(SqlInt32 StateID,SqlInt32 UserID)
        {
			StateDAL dalState = new StateDAL();
			return dalState.SelectByPK(StateID,UserID);
        }
		#endregion Select Operation
	}
}
