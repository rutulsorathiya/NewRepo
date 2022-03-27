using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for ContactWiseContactCategoryDAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.DAL
{
    public class ContactWiseContactCategoryDAL : DataBaseConfig
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
        public ContactWiseContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_ContactWiseContactCategory_Insert]";
                        objCmd.Parameters.AddWithValue("@UserID", entContactWiseContactCategory.UserID);
                        objCmd.Parameters.AddWithValue("@ContactID",entContactWiseContactCategory.ContactID);
                        objCmd.Parameters.AddWithValue("@ContactCategoryID",entContactWiseContactCategory.ContactCategoryID);
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if(objConn.State== ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Insert Operation


        public DataTable SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
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
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        public DataTable SelectByPK(SqlInt32 UserID,SqlInt32 ContactID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_ContactWiseContactCategory_SelectByUserIDAndContactID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
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

        public Boolean DeleteByPK(SqlInt32 UserID,SqlInt32 ContactID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType= CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_ContactWiseContactCategory_DeleteByUserIDAndContactID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
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
    }
}
