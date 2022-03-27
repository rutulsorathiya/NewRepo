using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for ContactCategoryDAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.DAL
{
	public class ContactCategoryDAL : DataBaseConfig
	{
		#region Local Variables
		protected string _Message;
		
		public string Message
        {
            get
            {
				return _Message;
            }
			set
			{ 
				 _Message = value; 
			}
        }
		#endregion Local Variables

		#region Constructor
		public ContactCategoryDAL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		#region Insert Operation
		public Boolean Insert(ContactCategoryENT entContactCategory)
        {
			using(SqlConnection objConn = new SqlConnection(ConnectionString) )
            {
				objConn.Open();
				using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "PR_ContactCategory_InsertByUserID";
						objCmd.Parameters.AddWithValue("@ContactCategoryName",entContactCategory.ContactCategoryName);
						objCmd.Parameters.AddWithValue("@UserID", entContactCategory.UserID);
						#endregion prepare command
						objCmd.ExecuteNonQuery();
						return true;
                    }
					catch (Exception ex)
                    {
						Message = ex.Message;
						return false;
                    }
                    finally
                    {
						if(objConn.State == ConnectionState.Open)
                        {
							objConn.Close();
                        }
                    }
                }
            }
        }
		#endregion Insert Operation

		#region Update Operation
		public Boolean UpdateByPK(ContactCategoryENT entContactCategory)
        {
			using( SqlConnection objConn = new SqlConnection(ConnectionString) )
            {
				objConn.Open();
				using( SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
						#region prepare command
						objCmd.CommandType= CommandType.StoredProcedure;
						objCmd.CommandText = "[dbo].[PR_ContactCategory_UpdateByPKAndUserID]";
						objCmd.Parameters.AddWithValue("@UserID", entContactCategory.UserID);
						objCmd.Parameters.AddWithValue("@ContactCategoryID", entContactCategory.ContactCategoryID);
						objCmd.Parameters.AddWithValue("@ContactCategoryName", entContactCategory.ContactCategoryName);
						#endregion prepare command
						objCmd.ExecuteNonQuery();
						return true;
					}
					catch(Exception ex)
                    {
						Message=ex.Message;
						return false;
					}
                    finally
                    {
						if(objConn.State == ConnectionState.Open)
                        {
							objConn.Close();
                        }
                    }
				}
            }
        }
		#endregion Update Operation

		#region Delete Operation
		public Boolean DeleteByPK(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
			using(SqlConnection objConn = new SqlConnection(ConnectionString) )
            {
				objConn.Open();
				using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
						#region prepare command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "[dbo].[PR_ContactCategory_DeleteByUserID]";
						objCmd.Parameters.AddWithValue("@UserID", UserID);
						objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
						#endregion prepare command
						objCmd.ExecuteNonQuery();
						return true;
					}
					catch (Exception ex)
                    {
						Message = ex.Message;
						return false;
                    }
                    finally
                    {
						if( objConn.State == ConnectionState.Open)
                        {
							objConn.Close();
                        }
                    }
				}
            }
        }
		#endregion Delete Operation

		#region Select Operation
		public DataTable SelectAll(SqlInt32 UserID)
        {
			using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
				objConn.Open();
				using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
						#region prepare command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectAllByUserID]";
						objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion prepare command

                        #region Read data and set controls
                        DataTable dt = new DataTable();
						using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						#endregion Read data and set controls
						return dt;	
					}
					catch(Exception ex)
                    {
						Message =ex.Message;
						return null;
				    }
                    finally
                    {
						if(objConn.State == ConnectionState.Open)
                        {
							objConn.Close();
                        }
					}
				}
            }
        }
		public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
			using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
				objConn.Open();
				using( SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForDropDownListByUserID]";
						objCmd.Parameters.AddWithValue("@UserID", UserID);
						DataTable dt = new DataTable();
						using (SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							dt.Load(objSDR);
						}
						return dt;
                    }
					catch (Exception ex)
                    {
						Message =ex.Message;
						return null;
                    }
                    finally
                    {
						if(objConn.State == ConnectionState.Open)
                        {
							objConn.Close();
                        }
                    }
                }
            }
        }
		public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
			using( SqlConnection objConn = new SqlConnection(ConnectionString))
            {
				objConn.Open();
				using( SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
						#region prepare command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectByPKAndUserID]";
						objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
						objCmd.Parameters.AddWithValue("@UserID",UserID);
						#endregion prepare command
						ContactCategoryENT entContactCategory = new ContactCategoryENT();
                        #region Read data and set controls
                        using (SqlDataReader objSDR=objCmd.ExecuteReader())
                        {
							while(objSDR.Read())
                            {
								if(!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                {
									entContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);
                                }
								if(!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                                {
									entContactCategory.ContactCategoryName = objSDR["ContactCategoryName"].ToString().Trim();
                                }
                            }
                        }
						#endregion Read data and set controls
						return entContactCategory;
					}
					catch (Exception ex)
                    {
						Message	= ex.Message;
						return null;
                    }
                    finally
                    {
						if(objConn.State == ConnectionState.Open)
                        {
							objConn.Close();
                        }
                    }

				}
            }
        }
		#endregion Select Operation
	}
}
