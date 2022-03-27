using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for StateDAL
/// </summary>

namespace ThreeTier_MultiUser_AddressBook.DAL
{
    public class StateDAL : DataBaseConfig
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

        #region constructor
        public StateDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Insert Operation
        public Boolean Insert(StateENT entState)
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
                        objCmd.CommandText = "PR_State_InsertByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", entState.UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                        objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);
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
        public Boolean UpdateByPK(StateENT entState)
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
                        objCmd.CommandText = "[dbo].[PR_State_UpdateByPKAndUserID]";
                        objCmd.Parameters.AddWithValue("@UserID",entState.UserID);
                        objCmd.Parameters.AddWithValue("@StateID", entState.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                        objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);
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
        public Boolean DeleteByPK(SqlInt32 StateID,SqlInt32 UserID)
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
                        objCmd.CommandText = "[dbo].[PR_State_DeleteByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd =objConn.CreateCommand() )
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_State_SelectAllByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion prepare command

                        #region Read data and set controls
                        DataTable dt = new DataTable();
                        using( SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                             dt.Load(objSDR);   
                        }
                        #endregion Read data and set controls
                        return dt;
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
        public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            using(SqlConnection objConn=new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd =objConn.CreateCommand() )
                {
                    try
                    {
                        #region preapre command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID",UserID);
                        #endregion prepare command
                        #region Read Data And Set Control
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                             dt.Load(objSDR);                          
                        }
                        #endregion Read Data And Set Control
                        return dt;
                    }
                    catch (Exception ex)
                    {
                         Message=ex.Message;
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
        public DataTable SelectForDropDownListByPK(SqlInt32 CountryID,SqlInt32 UserID)
        {
            using( SqlConnection objConn=new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd =objConn.CreateCommand() )
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType =  CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByUserIDAndPK]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion prepare command
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
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
        public StateENT SelectByPK(SqlInt32 StateID,SqlInt32 UserID)
        {
            using(SqlConnection objConn=new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using( SqlCommand objCmd =objConn.CreateCommand() )
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectByPKAndUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@StateID",StateID);
                        #endregion prepare command
                        StateENT entState = new StateENT();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while(objSDR.Read())
                            {
                                if(!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entState.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if(!objSDR["StateName"].Equals(DBNull.Value))
                                {
                                    entState.StateName = objSDR["StateName"].ToString().Trim();
                                }
                                if(!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entState.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if(!objSDR["StateCode"].Equals(DBNull.Value))
                                {
                                    entState.StateCode = objSDR["StateCode"].ToString().Trim();
                                }
                            }
                        }
                        return entState;
                    }
                    catch (Exception ex)
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
        #endregion Select Operation
    }
}
