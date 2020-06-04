using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Casetek.KPI
{ 
public class DomainAccount
{
        private static string _connectionString;
    static DomainAccount()
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

        public static string UserDomain(string v_empid)
        {
            string userdomain = "";
            string sql = "select Domain from HR_Emp_Now where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "HR_Emp_Now");
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            if (ds.Tables["HR_Emp_Now"].Rows.Count > 0)
            {
                userdomain = ds.Tables["HR_Emp_Now"].Rows[0]["Domain"].ToString();
            }
            return userdomain;
        }


        public static string UserDomainAccount(string v_empid)
        {
            string userdomainaccount = "";
            string sql = "select DomainAccount from HR_Emp_Now where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "HR_Emp_Now");
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            if (ds.Tables["HR_Emp_Now"].Rows.Count > 0)
            {
                userdomainaccount = ds.Tables["HR_Emp_Now"].Rows[0]["DomainAccount"].ToString();
            }
            return userdomainaccount;
        }
    }
}