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
        private static string v_DbconnStr;
    static DomainAccount()
    {
        Initialize();
    }

        public static void Initialize()
        {
            v_DbconnStr = Coeno.BLL.Data.DbAccess.GetKpiDbConnStr();
        }

        public static string UserDomain(string v_empid)
        {
            string userdomain = "";
            string sql = "select Domain from HR_Emp_Now where EmpID = '" + v_empid + "'";

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
                userdomain = ds.Tables["HR_Emp_Now"].Rows[0]["Domain"].ToString();
            }
            return userdomain;
        }


        public static string UserDomainAccount(string v_empid)
        {
            string userdomainaccount = "";
            string sql = "select DomainAccount from HR_Emp_Now where EmpID = '" + v_empid + "'";

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
                userdomainaccount = ds.Tables["HR_Emp_Now"].Rows[0]["DomainAccount"].ToString();
            }
            return userdomainaccount;
        }
    }
}