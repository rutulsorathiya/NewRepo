using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.ENT;


/// <summary>
/// Summary description for CityDAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.DAL
{
    public class CityDAL : DataBaseConfig
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
        public CityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation

        public Boolean Insert(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_InsertByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = entCity.UserID;
                        objCmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = entCity.CityName;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entCity.StateID;
                        objCmd.Parameters.Add("@STDCode", SqlDbType.VarChar).Value = entCity.STDCode;
                        objCmd.Parameters.Add("@PinCode", SqlDbType.VarChar).Value = entCity.PinCode;
                        #endregion prepare command
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

        public Boolean UpdateByPK(CityENT entCity)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_City_UpdateByPKAndUserID]";
                        objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                        objCmd.Parameters.AddWithValue("@UserID", entCity.UserID);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("@PinCode", entCity.PinCode);
                        #endregion prepare command
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException Sqlex)
                    {
                        Message = Sqlex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
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

        #endregion Update Operation

        #region Delete Operation

        public Boolean DeleteByPK(SqlInt32 CityID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd= objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_City_DeleteByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        #endregion prepare command
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
                        if(objConn.State==ConnectionState.Open)
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
                        objCmd.CommandText = "[dbo].[PR_City_SelectAllByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR=objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
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
                        if(objConn.State==ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        public DataTable SelectForDropDownListByPK(SqlInt32 StateID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd =objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_City_SelectForDropDownListByUserIDAndPK]";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion prepare command
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR=objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;    
                    }
                    catch (SqlException ex)
                    {
                        Message=ex.Message;
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
        public CityENT SelectByPK(SqlInt32 CityID,SqlInt32 UserID)
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
                        objCmd.CommandText = "[dbo].[PR_City_SelectByPKAndUserID]";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion prepare command

                        CityENT entCity = new CityENT();
                        using(SqlDataReader objSDR= objCmd.ExecuteReader())
                        {
                            while(objSDR.Read())
                            {
                                if(!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entCity.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if(!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entCity.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if(!objSDR["CityName"].Equals(DBNull.Value))
                                {
                                    entCity.CityName = objSDR["CityName"].ToString().Trim();
                                }
                                if(!objSDR["STDCode"].Equals(DBNull.Value))
                                {
                                    entCity.STDCode = objSDR["STDCode"].ToString().Trim();
                                }
                                if(!objSDR["PinCode"].Equals(DBNull.Value))
                                {
                                    entCity.PinCode = objSDR["PinCode"].ToString().Trim();
                                }
                            }
                        }
                        return entCity;
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
                        if(objConn.State==ConnectionState.Open)
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
