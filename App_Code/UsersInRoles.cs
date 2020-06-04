using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;                                                                                                                                          

/// <summary>
/// Summary description for UsersInRoles
/// </summary>
namespace Casetek.KPI
{
public class UsersInRoles
{
    private static string  _connectionString;
    static UsersInRoles()
    {
        Initilize();
    }

   public static void Initilize()
   {
        string v_ConnectionStringsType = v_ConnectionStringsType = "KPIConnectionString";
        if (ConfigurationManager.ConnectionStrings[v_ConnectionStringsType]==null ||
            ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString.Trim()=="")
        {
                throw new Exception("A connection string named 'ConnectionStringType' with a valid connection string " +
                    "must exist in the <connectionStrings> configuration section for the application.");
        }
        _connectionString = ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString;
   }

        public static bool UserInRoles(string v_empid,string v_roleid,string v_factoryid)
        {
            bool result = false;
            string sql = "";
            string sqlrs = "select * from KPI_UsersInRoles_RS where EmpID = '" + v_empid + "' and RoleID = '" + v_roleid + "' and GroupID='" + v_factoryid + "'";
            string sqlrk = "select * from KPI_UsersInRoles_RK where EmpID = '" + v_empid + "' and RoleID = '" + v_roleid + "' and GroupID='" + v_factoryid + "'";
            string sqlrm = "select * from KPI_UsersInRoles_RM where EmpID = '" + v_empid + "' and RoleID = '" + v_roleid + "' and GroupID='" + v_factoryid + "'";
            string sqlrp = "select * from KPI_UsersInRoles_RP where EmpID = '" + v_empid + "' and RoleID = '" + v_roleid + "' and GroupID='" + v_factoryid + "'";
            string sqlrt = "select * from KPI_UsersInRoles_RT where EmpID = '" + v_empid + "' and RoleID = '" + v_roleid + "' and GroupID='" + v_factoryid + "'";
            string sqlsr = "select * from KPI_UsersInRoles_SR where EmpID = '" + v_empid + "' and RoleID = '" + v_roleid + "' and GroupID='" + v_factoryid + "'";

            if (v_factoryid== "0000")
            {
                sql = sqlrt;
            }
            if (v_factoryid== "0102")
            {
                sql = sqlsr;
            }
            if (v_factoryid == "0103")
            {
                sql = sqlrm;
            }
            if (v_factoryid == "0105")
            {
                sql = sqlrp;
            }
            if (v_factoryid== "0111")
            {
                sql = sqlrk;
            }
            if (v_factoryid== "0112")
            {
                sql = sqlrs;
            }

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds,"UserInRoles");
            }
            catch
            {
                result = false;
            }
            finally
            {
                con.Close();
            }
            if (ds.Tables["UserInRoles"].Rows.Count>0)
            {
                result = true;
            }
            return result;
        }
}
}