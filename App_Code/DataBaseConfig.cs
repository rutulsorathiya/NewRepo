using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBaseConfig
/// </summary>
namespace ThreeTier_MultiUser_AddressBook
{
    public class DataBaseConfig
    {
        #region Constructor
        public DataBaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ThreeTier_MultiUser_AddressBookConnectionString"].ConnectionString;
    }
}
