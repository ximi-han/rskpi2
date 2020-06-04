using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;



namespace Casetek.KPI
{ 
    public class InsertDB
      {
          private static string _connectionString;

        static InsertDB()
        {
            Initialize();
        }

        public static void Initialize()
        {
            string v_ConnectionStringsType = "KPIConnectionString";

            if (ConfigurationManager.ConnectionStrings[v_ConnectionStringsType] == null ||
                ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString.Trim() == "")
            {
                throw new Exception("A connection string named 'ConnectionStringType' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }

            _connectionString = ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString;
        }

        public static void InsertEHREmp(out int v_ResultID, out string v_ResultMsg)
        {
            v_ResultID = 999;
            v_ResultMsg = String.Empty;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@ResultStatus",SqlDbType.Int),
                 new SqlParameter("@ResultMsg",SqlDbType.NVarChar,50)
            };
            sqlParams[0].Direction = ParameterDirection.Output;
            sqlParams[1].Direction = ParameterDirection.Output;

            try
            {
                SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "HR_Emp_NowRS_insert", sqlParams);
                //sql执行成功 返回代码等于0
                if (int.Parse(sqlParams[0].Value.ToString()) == 0)
                {
                    v_ResultID = 0; //调用本函数执行成功 ，则返回代码等于0
                    v_ResultMsg = sqlParams[1].Value.ToString();
                }

            }
            catch (SqlException e)
            {
                v_ResultID = -1;
                v_ResultMsg = e.Message;
            }
        }
      }

}