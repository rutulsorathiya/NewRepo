using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.DAL;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for CityBAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.BAL
{
	public class CityBAL
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
		public CityBAL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		#region Insert Operation
		public Boolean Insert(CityENT entCity)
		{
			CityDAL dalCity = new CityDAL();
			if (dalCity.Insert(entCity))
			{
				return true;
			}
			else
			{
				Message = dalCity.Message;
				return false;
			}

		}
		#endregion Insert Operation

		#region Update Operation
		public Boolean UpdateByPK(CityENT entCity)
		{
			CityDAL dalCity = new CityDAL();
			if (dalCity.UpdateByPK(entCity))
			{
				return true;
			}
			else
			{
				Message = dalCity.Message;
				return false;
			}
		}
		#endregion Update Operation

		#region Delete Operation
		public Boolean DeleteByPK(SqlInt32 CityID,SqlInt32 UserID)
		{
			CityDAL dalCity = new CityDAL();
			if (dalCity.DeleteByPK(CityID,UserID))
			{
				return true;
			}
			else
			{
				Message = dalCity.Message;
				return false;
			}
		}
		#endregion Delete Operation

		#region Select Operation
		public DataTable SelectAll(SqlInt32 UserID)
        {
			CityDAL dalCity = new CityDAL();
			return dalCity.SelectAll(UserID);
        }
		public DataTable SelectForDropDownListByPK(SqlInt32 StateID,SqlInt32 UserID)
        {
			CityDAL dalCity = new CityDAL();
			return dalCity.SelectForDropDownListByPK(StateID,UserID);
        }
		public CityENT SelectByPK(SqlInt32 CityID,SqlInt32 UserID)
        {
			CityDAL dalCity = new CityDAL();
			return dalCity.SelectByPK(CityID,UserID);
        }
        #endregion Select Operation		
	}
}
