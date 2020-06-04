using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Casetek.KPI {

public class ScoreAssess
{
    private static string _connectionString;
    static ScoreAssess()
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

    public static DataSet SelfAssessofEmployeAbove6(string v_empid)
    {
        string sql = "select EmpID,EmpName,DeptID,DeptName,rsDutyRank from HR_Emp_Now where EmpID = '"+v_empid+ "' and DutyRank >= 'D006' ";

        SqlConnection con = new SqlConnection(_connectionString);
        SqlDataAdapter da = new SqlDataAdapter(sql,con);

        DataSet ds = new DataSet();

        try
        {
            con.Open();
            da.Fill(ds, "HR_Emp_Now");
        }
        catch(SqlException ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;
    }


        public static string SelfAssessofEmployeDeptID(string v_empid)
        {
            string deptid = "";
            string sql = "select DeptID from HR_Emp_Now where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "HR_Emp_Now");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            if (ds.Tables["HR_Emp_Now"].Rows.Count>0)
            {
                deptid = ds.Tables["HR_Emp_Now"].Rows[0]["DeptID"].ToString();
            }
            return deptid;
        }

        public static string SelfAssessofEmployeDeptName(string v_empid)
        {
            string deptname = "";
            string sql = "select DeptName from HR_Emp_Now where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "HR_Emp_Now");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            if (ds.Tables["HR_Emp_Now"].Rows.Count > 0)
            {
                deptname = ds.Tables["HR_Emp_Now"].Rows[0]["DeptName"].ToString();
            }
            return deptname;
        }
    }

}