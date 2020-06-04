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
namespace Casetek.KPI
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
            sql = "select a.EmpID,a.EmpName,a.DomainAccount,a.GroupID,b.FactoryName,a.DeptID,a.DeptName,a.TitleName from HR_Emp_Now a ,CasetekFactory b where a.GroupID='" + v_site+ "' and a.DeptID='"+v_deptid+ "' and a.GroupID=b.GroupID";

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
    }
}