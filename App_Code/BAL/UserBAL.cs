using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ThreeTier_MultiUser_AddressBook.DAL;
using ThreeTier_MultiUser_AddressBook.ENT;

/// <summary>
/// Summary description for UserBAL
/// </summary>
namespace ThreeTier_MultiUser_AddressBook.BAL
{
    public class UserBAL : DataBaseConfig
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
        public UserBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if(dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message=dalUser.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region SelectByPK
        public UserENT SelectByPK(SqlString UserName,SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByPK(UserName,Password);  
        }
        #endregion SelectByPK
    }
}
