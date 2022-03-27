using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for CountryDAL
/// </summary>
namespace ThreeTier_MultiUser_AddrressBook.DAL
{
    public class CountryDAL : DataBaseConfig
    {
        #region Local Variable

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
        #endregion Local Variable

        #region Constructor
        public CountryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation

        public Boolean Insert(CountryENT entCountry)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_InsertByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("@CountryName",entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException Sqlex)
                    {
                        Message = Sqlex.Message;
                        return false;
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
                        return false;
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

        #endregion Insert Operation

        #region Update Operation

        public Boolean UpdateByPK(CountryENT entCountry)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Country_UpdateByPKAndUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", entCountry.CountryID);
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch(SqlException Sqlex)
                    {
                        Message = Sqlex.Message;
                        return false;
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
                        return false;
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

        #endregion Update Operation

        #region Delete Operation

        public Boolean DeleteByPK(SqlInt32 CountryID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Country_DeleteByUserID]";
                        objCmd.Parameters.AddWithValue("@CountryID",CountryID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch(SqlException Sqlex)
                    {
                        Message = Sqlex.Message;
                        return false;
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
                        return false;
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
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Country_SelectAllByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                    }
                    catch(SqlException Sqlex)
                    {
                        Message = Sqlex.Message;
                        return null;
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
        public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Country_SelectForDropDownListByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command
                        DataTable dt = new DataTable();
                        #region ReadData and Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        #endregion ReadData and Set Controls
                        return dt;
                    }
                    catch(SqlException Sqlex)
                    {
                        Message = Sqlex.Message;
                        return null;
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
        public CountryENT SelectByPK(SqlInt32 CountryID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectByPKAndUserID";
                        objCmd.Parameters.AddWithValue("@CountryID",CountryID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command
                        CountryENT entCountry = new CountryENT();
                        #region ReadData and Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while(objSDR.Read())
                            {
                                if(!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryName = objSDR["CountryName"].ToString().Trim();
                                }
                                if(!objSDR["CountryCode"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryCode = objSDR["CountryCode"].ToString().Trim();
                                }
                            }
                        }
                        #endregion ReadData and Set Controls
                        return entCountry;
                    }
                    catch(SqlException Sqlex)
                    {
                        Message = Sqlex.Message;
                        return null;
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if(objConn.State ==ConnectionState.Open)
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
