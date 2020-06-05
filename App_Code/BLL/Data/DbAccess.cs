using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Coeno.BLL.Data
{
    /// <summary>
    /// Summary description for DbAccess
    /// </summary>
    public  class DbAccess
    {
        private static string KpiDbConnStr = string.Empty;

        static DbAccess()
        {
            Initialize();
        }


        public static void Initialize()
        {
            KpiDbConnStr = "KPIConnectionString";           
        }

        public static string GetKpiDbConnStr()
        {
            if (ConfigurationManager.ConnectionStrings[KpiDbConnStr] == null ||
                ConfigurationManager.ConnectionStrings[KpiDbConnStr].ConnectionString.Trim() == "")
            {
                throw new Exception("A connection string named 'ConnectionStringType' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }
            return ConfigurationManager.ConnectionStrings[KpiDbConnStr].ConnectionString;
        }

    }
}