using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Casetek.KPI
{
    public class Factorys
    {
        private static string _connectionString;
        static Factorys()
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

        _connectionString =ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString;
    }

    //一、廠區查詢
        public static DataTable QueryFactory()
        {
            string sql = "select GroupID, FactoryName from CasetekFactory";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekFactory");
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        public static DataTable QueryFactoryPara(string v_factory)
        {
            string sql = "select FactoryID from CasetekFactory where FactoryID = '"+v_factory+"'";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekFactory");
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }


        //用戶廠區查詢是否有該人員//1.UserRoleSet
        public static DataSet  UserInFactory(string v_empid)
        {
            //string UserFactory = "";
            string sql = "select GroupID from HR_Emp_Now where EmpID = '"+v_empid+"'";

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

            //if (ds.Tables["HR_Emp_Now"].Rows.Count > 0)
            //{
            //    UserFactory = ds.Tables["HR_Emp_Now"].Rows[0]["GroupID"].ToString();
            //}
            return ds;
        }

        // //用戶廠區查詢//1.UserRoleSet

        public static string UserInFactorys(string v_empid)
        {
            string UserFactory = "";
            string sql = "select GroupID from HR_Emp_Now where EmpID = '" + v_empid + "'";

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
                UserFactory = ds.Tables["HR_Emp_Now"].Rows[0]["GroupID"].ToString();
            }
            return UserFactory;
        }


        //通过Site查询DeptID
        public static DataTable QueryDept(string v_site)
        {
            string sql = "";
            sql = "select DeptID,DeptName from HR_Dept where GroupID = '"+v_site+"'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "QueryDept");
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }
    }

}