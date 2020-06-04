using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

namespace Casetek.KPI
{
    public class PwdInitialization
    {
        private static string _connectionString;
        static PwdInitialization()
        {
            Initialization();
        }

        protected static void Initialization()
        {
            string v_ConnectionStringsType = "KPIConnectionString";

            if (ConfigurationManager.ConnectionStrings[v_ConnectionStringsType] == null || ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString.Trim() =="")
            {
                throw new Exception("A connection string named 'ConnectionStringType' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }

            _connectionString = ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString;
        }


    }
}