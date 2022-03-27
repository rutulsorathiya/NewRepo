using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for UserDAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.DAL
{
    public class UserDAL : DataBaseConfig
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
        public UserDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(UserENT entUser)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_User_Insert]";
                        objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("@DisplayName", entUser.DisplayName);
                        objCmd.Parameters.AddWithValue("@Email",entUser.Email);
                        objCmd.Parameters.AddWithValue("@ContactNo", entUser.ContactNo);
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

        #region SelectByPK

        public UserENT SelectByPK(SqlString UserName,SqlString Password)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                        objCmd.Parameters.AddWithValue("@UserName", UserName);
                        objCmd.Parameters.AddWithValue("@Password", Password);
                        UserENT ENTUser = new UserENT();
                        using(SqlDataReader objSDR= objCmd.ExecuteReader())
                        {
                            if(objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                    {
                                        ENTUser.DisplayName = objSDR["DisplayName"].ToString().Trim();
                                    }
                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                    {
                                        ENTUser.UserID = Convert.ToInt32(objSDR["UserID"]);
                                    }
                                }
                                return ENTUser;
                            }
                            return null;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if(objConn.State==ConnectionState.Open)
                        {
                            objConn.Close();
                        }   
                    }
                }
            }

        }
        #endregion SelectByPK
    }
}
