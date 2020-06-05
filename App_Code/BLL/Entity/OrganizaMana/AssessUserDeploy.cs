using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for AssessUserDeploy
/// </summary>
namespace Coeno.BLL.Entity.OrganizaMana
{ 
public class AssessUserDeploy
{
    private static string _connectionString;
    static AssessUserDeploy()
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

        //查詢調配人員信息以廠區部門
        public static DataTable QueryDeployUser(string v_site ,string v_deptid)
        {
            string sql = "";
            sql = "select a.EmpID,a.EmpName,a.DomainAccount,a.GroupID,b.FactoryName,a.DeptID,a.DeptName,a.TitleName from HR_Emp_Now a ,CasetekFactory b where a.GroupID='" + v_site+ "' and a.DeptID like '"+v_deptid+ "%' and a.GroupID=b.GroupID";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "QueryDeployUser");
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

        //查詢調配人員信息，以工號
        public static DataTable QueryDeployUser(string v_empid)
        {
            string sql = "";
            sql = "select a.EmpID,a.EmpName,a.DomainAccount,a.GroupID,b.FactoryName,a.DeptID,a.DeptName,a.TitleName from HR_Emp_Now a,CasetekFactory b where a.EmpID = '" + v_empid+ "' and a.GroupID=b.GroupID";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "QueryDeployUser");
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

        //查詢部門名稱，以部門ID
        public static DataTable QueryDeployDeptName(string v_deptid)
        {
            string sql = "";
            sql = "select DeptName from HR_Dept where DeptID = '"+v_deptid+"'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "QueryDeployDeptName");
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        //查詢人員調配表是否有此人，有update，無insert
        public static DataTable QueryEmpAdjust(string v_empid)
        {
            string sql = "";
            sql = "select EmpID,EmpName,GroupID,DeptID,DeptName from HR_Emp_Now_Adjust where EmpID = '"+v_empid+"'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "QueryEmpAdjust");
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        //無insert
        public static int adEmpAdjust(string v_empid,string v_empname,string v_groupid,string v_deptid,string v_deptname,string v_newdeptid,string v_newdeptname,string v_cuser,string v_cdate)
        {
            int result = 0;
            string sql = "";
            sql = "insert into HR_Emp_Now_Adjust (EmpID,EmpName,GroupID,DeptID,DeptName,NewDeptID,NewDeptName,CUser,CDate) values ('" + v_empid+"','"+v_empname+"','"+v_groupid+"','"+v_deptid+"','"+v_deptname+"','"+v_newdeptid+"','"+v_newdeptname+"','"+v_cuser+"','"+v_cdate+"')";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql,con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                result = 1;
            }
            catch
            {
                result = 0;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        //有update
        public static int upEmpAdjust(string v_empid,string v_newdepid,string v_newdeptname,string v_Luser,string v_Ldate)
        {
            int result = 0;
            string sql = "";
            sql = "update HR_Emp_Now_Adjust set NewDeptID = '"+v_newdepid+ "' , NewDeptName= '"+v_newdeptname+ "',LUser='"+v_Luser+ "',LDate='"+v_Ldate+"' where EmpID= '" + v_empid+"'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql,con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                result = 1;
            }
            catch 
            {
                result = 0;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }
}