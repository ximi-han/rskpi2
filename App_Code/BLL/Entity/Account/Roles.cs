using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Coeno.BLL.Data;

namespace Coeno.BLL.Entity.Account
{
    public class Roles
    {
        private static string v_connString;

        static Roles()
        {
            Initialize();
        }
        public static void Initialize()
        {
            // Initialize data source. Use connection string from configuration.
            v_connString = Coeno.BLL.Data.DbAccess.GetKpiDbConnStr();
           
        }

        /// <summary>
        /// IsUserInRole
        /// </summary>
        /// <param name="v_systemid"></param>
        /// <param name="v_empid"></param>
        /// <param name="v_roleid"></param>
        /// <returns></returns>
        public static bool IsUserInRole(string v_systemid,string v_empid,string v_roleid)
        {

            bool result = false;

            string sqlCmd = "SELECT * FROM DevChk_UsersInRole "
                + " where systemid = '" + v_systemid + "' and empid = '" + v_empid + "' and roleid='" + v_roleid + "'";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sqlCmd, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "Portal_AnnounceType");
            }
            catch (SqlException e)
            {
                // Handle exception.
                throw new Exception(e.Message + sqlCmd);
            }
            finally
            {
                con.Close();
            }

            if (dst.Tables["Portal_AnnounceType"].Rows.Count > 0)
            {
                result = true;
            }
            return result;

        }

        /// <summary>
        /// QueryUserInRole
        /// </summary>
        /// <param name="v_roleid"></param>
        /// <returns></returns>
        public static DataSet QueryUserInRole(string v_roleid)
        {
            //Get the Sql************************************************
            string sql = "select a.empid,a.roleid,b.EmpCName,b.EmpEName,b.Domain,b.DomainAccount,b.deptid,b.Email,b.Ext1 from DevChk_UsersInRole a,HR_Emp_Now b where a.roleid='" + v_roleid + "' and a.empid=b.empid ";

            sql = sql + " order by a.empid";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "QueryUserInRole");
            }
            catch (SqlException e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return dst;
        }

        /// <summary>
        /// DeleteUserInRole
        /// </summary>
        /// <param name="v_roleid"></param>
        /// <param name="v_empid"></param>
        /// <returns></returns>
        public static int DeleteUserInRole(string roleid, string empid)
        {

            string sql = "Delete DevChk_UsersInRole where roleid='" + roleid + "' and empid='" + empid + "'";
            int v_result = 0;

            SqlConnection con = new SqlConnection(v_connString);
         
            SqlCommand DeleteCommand = new SqlCommand(sql, con);

            try
            {
                con.Open();
                v_result = DeleteCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return v_result;
        }

        /// <summary>
        /// AddUserInRole
        /// </summary>
        /// <param name="v_systemid"></param>
        /// <param name="roleid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static int AddUserInRole(string systemid, string roleid, string empid, string cuser)
        {

            string sql = "insert into DevChk_UsersInRole(systemid,roleid,empid,cuser) values ('" + systemid + "','" + roleid + "','" + empid + "','" + cuser + "')";
            int v_result = 0;

            SqlConnection con = new SqlConnection(v_connString);

            SqlCommand AddCommand = new SqlCommand(sql, con);

            try
            {
                con.Open();
                v_result = AddCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return v_result;
        }

        /// <summary>
        /// 取得角色列表
        /// </summary>
        /// <param name="systemid"></param>
        /// <returns></returns>
        public static DataSet QueryRoleList(string systemid)
        {
            //Get the Sql************************************************
            string sql = "select * from DevChk_Roles where SystemID='" + systemid + "' order by roleid ";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "QueryRoleList");
            }
            catch (SqlException e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return dst;
        }
    }
}
