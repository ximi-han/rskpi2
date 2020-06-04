using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Casetek.KPI
{
public class UserName
{
        private static string _connectionString;
        static UserName()
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


        //使用工号查找姓名
        public static string UsersName(string v_empid)
        {
            string username = "";
            string sql = "select EmpName from HR_Emp_Now where EmpID = '" + v_empid+"'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "HR_Emp_Now");
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            if (ds.Tables["HR_Emp_Now"].Rows.Count>0)
            {
                username = ds.Tables["HR_Emp_Now"].Rows[0]["EmpName"].ToString();
            }
            return username;
        }


        //使用输入工号查找工号
        public static string UsersEmpID(string  v_empid)
        {
            string userid = "";
            string sql = "select EmpID from HR_Emp_Now where EmpID = '" + v_empid + "'";

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
                userid = ds.Tables["HR_Emp_Now"].Rows[0]["EmpID"].ToString();
            }
            return userid;
        }

        //使用输入账号查找工号
        public static string UserEmpID(string v_empid)
        {
            string userid = "";
            string sql = "select EmpID from HR_Emp_Now where Domain+'\\'+DomainAccount = '" + v_empid + "'";

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
                userid = ds.Tables["HR_Emp_Now"].Rows[0]["EmpID"].ToString();
            }
            return userid;
        }
    }
}