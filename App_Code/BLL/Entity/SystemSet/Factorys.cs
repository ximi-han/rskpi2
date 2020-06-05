using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coeno.BLL.Entity.SystemSet
{
    public class Factorys
    {
        private static string v_DbconnStr;
        static Factorys()
        {
            Initialize();
        }

    public static void Initialize()
    {
        v_DbconnStr = Coeno.BLL.Data.DbAccess.GetKpiDbConnStr();

    }

    //一、廠區查詢
        public static DataTable QueryFactory()
        {
            string sql = "select GroupID, FactoryName from CasetekFactory";
            SqlConnection con = new SqlConnection(v_DbconnStr);
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
            SqlConnection con = new SqlConnection(v_DbconnStr);
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

            SqlConnection con = new SqlConnection(v_DbconnStr);
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

        //查詢廠區用戶
        //1.UserRoleSet

        public static string UserInFactorys(string v_empid)
        {
            string UserFactory = "";
            string sql = "select GroupID from HR_Emp_Now where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
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

            SqlConnection con = new SqlConnection(v_DbconnStr);
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