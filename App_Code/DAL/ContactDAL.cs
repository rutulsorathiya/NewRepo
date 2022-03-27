using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for ContactDAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.DAL
{
    public class ContactDAL : DataBaseConfig
    {
        #region Local Variables
        protected string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variables

        #region Constructor
        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Contact_InsertByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                        objCmd.Parameters.AddWithValue("@ContactNo", entContact.ContactNo);
                        objCmd.Parameters.AddWithValue("@WhatsAppNo", entContact.WhatsAppNo);
                        objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                        objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                        objCmd.Parameters.AddWithValue("@LinkINID", entContact.LinkedINID);
                        objCmd.Parameters.AddWithValue("@ContactPhotoPath", entContact.ContactPhotoPath);
                        objCmd.Parameters.AddWithValue("@PhotoDetail", entContact.PhotoDetail);
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4);
                        objCmd.Parameters["@ContactID"].Direction = ParameterDirection.Output;
                        objCmd.ExecuteNonQuery();
                        SqlInt32 ContactID = 0;
                        entContact.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                        return true;
                        #endregion prepare command
                    }
                    catch (Exception ex)
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
        public Boolean UpdateByPK(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPKAndUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);
                        objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                        objCmd.Parameters.AddWithValue("@ContactNo", entContact.ContactNo);
                        objCmd.Parameters.AddWithValue("@WhatsAppNo", entContact.WhatsAppNo);
                        objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                        objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                        objCmd.Parameters.AddWithValue("@LinkINID", entContact.LinkedINID);
                        objCmd.Parameters.AddWithValue("@ContactPhotoPath", entContact.ContactPhotoPath);
                        objCmd.Parameters.AddWithValue("@PhotoDetail", entContact.PhotoDetail);
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
        public Boolean DeleteByPK(SqlInt32 ContactID, SqlInt32 UserID)
        {
            string Path = null;
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Contact_DeleteByUserID]";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Contact_SelectAllByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion prepare command
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
        public ContactENT SelectByPK(SqlInt32 ContactID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_Contact_SelectByPKAndUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion prepare command
                        ContactENT entContact = new ContactENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                {
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);
                                }
                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                {
                                    entContact.ContactName = objSDR["ContactName"].ToString().Trim();
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                {
                                    entContact.ContactNo = objSDR["ContactNo"].ToString().Trim();
                                }
                                if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                                {
                                    entContact.WhatsAppNo = objSDR["WhatsAppNo"].ToString().Trim();
                                }
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                {
                                    entContact.BirthDate = Convert.ToDateTime(objSDR["BirthDate"].ToString());
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entContact.Email = objSDR["Email"].ToString().Trim();
                                }
                                if (!objSDR["Age"].Equals(DBNull.Value))
                                {
                                    entContact.Age = Convert.ToInt32(objSDR["Age"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entContact.Address = objSDR["Address"].ToString().Trim();
                                }
                                if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                                {
                                    entContact.BloodGroup = objSDR["BloodGroup"].ToString().Trim();
                                }
                                if (!objSDR["FacebookID"].Equals(DBNull.Value))
                                {
                                    entContact.FacebookID = objSDR["FacebookID"].ToString().Trim();
                                }
                                if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                                {
                                    entContact.LinkedINID = objSDR["LinkedINID"].ToString().Trim();
                                }
                                if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                                {
                                    entContact.ContactPhotoPath = objSDR["ContactPhotoPath"].ToString().Trim();
                                }
                                if (!objSDR["PhotoDetail"].Equals(DBNull.Value))
                                {
                                    entContact.PhotoDetail = objSDR["PhotoDetail"].ToString().Trim();
                                }
                            }
                        }
                        return entContact;
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
        #endregion Select Operation
    }

}
