using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Web;

namespace Casetek.KPI
{
public class UserRole
{
    private static string _connectionString;
    static UserRole()
    {
        Initilize();
    }

    public static void Initilize()
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

     //public static bool UserRoles(string v_empid,string v_role)
     //{
     //     bool result = false;
     //     string sql = "select * from UserRoles_RS where empid = '"+v_empid+"' and roleid = '"+v_role+"'";

     //     SqlConnection con = new SqlConnection(_connectionString);
     //     SqlDataAdapter da = new SqlDataAdapter(sql,con);

     //     DataSet ds = new DataSet();

     //       try
     //       {
     //           con.Open();
     //           da.Fill(ds, "UserRoles_RS");
     //       }
     //       catch(SqlException e)
     //       {
     //           throw new Exception(e.Message);
     //       }
     //       finally
     //       {
     //           con.Close();
     //       }
     //       if (ds.Tables["UserRoles_RS"].Rows.Count > 0)
     //       {
     //           result = true;
     //       }
     //       return result;
     //}

        //角色清單UserRoleSet(DropRoles)
        public static DataSet QueryddlRoleList()
        {
            string sql = "select * from KPI_Roles order by RoleID";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "KPI_Roles");
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //用戶角色清單
        public static DataSet QueryUserInRole(string v_site,string v_roleid)
        {
            string sql = "";
            string sqlrs = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RS b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "'";
            string sqlrp = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RP b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "'";
            string sqlrt = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RT b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "'";
            string sqlrm = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RM b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "'";
            string sqlrk = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RK b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "'";
            string sqlsr = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_SR b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "'";

            if (v_site == "0112")
            {
                sql = sqlrs;
            }
            if (v_site == "0105")
            {
                sql = sqlrp;
            }
            if (v_site == "0000")
            {
                sql = sqlrt;
            }
            if (v_site == "0103")
            {
                sql = sqlrm;
            }
            if (v_site == "0111")
            {
                sql = sqlrk;
            }
            if (v_site == "0102")
            {
                sql = sqlsr;
            }
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "QueryUserInRole");
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //用戶角色查詢UserRoleSet
        public static DataSet UserInRole(string v_empid, string v_site, string v_roleid)
        {
            string sql = "";
            string sqlrs = "select * from KPI_UsersInRoles_RS where EmpID = '" + v_empid + "' and GroupID = '" + v_site + "' and RoleID = '" + v_roleid + "'";
            string sqlrt = "select * from KPI_UsersInRoles_RT where EmpID = '" + v_empid + "' and GroupID = '" + v_site + "' and RoleID = '" + v_roleid + "'";
            string sqlrp = "select * from KPI_UsersInRoles_RP where EmpID = '" + v_empid + "' and GroupID = '" + v_site + "' and RoleID = '" + v_roleid + "'";
            string sqlrm = "select * from KPI_UsersInRoles_RM where EmpID = '" + v_empid + "' and GroupID = '" + v_site + "' and RoleID = '" + v_roleid + "'";
            string sqlrk = "select * from KPI_UsersInRoles_RK where EmpID = '" + v_empid + "' and GroupID = '" + v_site + "' and RoleID = '" + v_roleid + "'";
            string sqlsr = "select * from KPI_UsersInRoles_SR where EmpID = '" + v_empid + "' and GroupID = '" + v_site + "' and RoleID = '" + v_roleid + "'";

            if (v_site == "0112")
            {
                sql = sqlrs;
            }
            if (v_site == "0105")
            {
                sql = sqlrp;
            }
            if (v_site == "0000")
            {
                sql = sqlrt;
            }
            if (v_site == "0103")
            {
                sql = sqlrm;
            }
            if (v_site == "0111")
            {
                sql = sqlrk;
            }
            if (v_site == "0102")
            {
                sql = sqlsr;
            }


            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "UserInRole");
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //用戶角色新增UserRoleSet
        public static int  AddUserInRole(string v_empid, string v_site, string v_roleid)
        {
            int result = 0;
            string sql = "";
            string sqlrs = "insert into KPI_UsersInRoles_RS (EmpID,RoleID,RoleName,GroupID,GroupName) select  '" +v_empid+ "','"+v_roleid+ "', RoleName,'"+v_site+ "','日善電腦' from KPI_Roles where RoleID = '"+v_roleid+"'";
            string sqlrk = "insert into KPI_UsersInRoles_RK (EmpID,RoleID,RoleName,GroupID,GroupName) select  '" + v_empid + "','" + v_roleid + "', RoleName,'" + v_site + "','日鎧電腦' from KPI_Roles where RoleID = '" + v_roleid + "'";
            string sqlrm = "insert into KPI_UsersInRoles_RM (EmpID,RoleID,RoleName,GroupID,GroupName) select  '" + v_empid + "','" + v_roleid + "', RoleName,'" + v_site + "','日銘電腦' from KPI_Roles where RoleID = '" + v_roleid + "'";
            string sqlrp = "insert into KPI_UsersInRoles_RP (EmpID,RoleID,RoleName,GroupID,GroupName) select  '" + v_empid + "','" + v_roleid + "', RoleName,'" + v_site + "','日沛電腦' from KPI_Roles where RoleID = '" + v_roleid + "'";
            string sqlrt = "insert into KPI_UsersInRoles_RT (EmpID,RoleID,RoleName,GroupID,GroupName) select  '" + v_empid + "','" + v_roleid + "', RoleName,'" + v_site + "','日騰電腦' from KPI_Roles where RoleID = '" + v_roleid + "'";
            string sqlsr = "insert into KPI_UsersInRoles_SR (EmpID,RoleID,RoleName,GroupID,GroupName) select  '" + v_empid + "','" + v_roleid + "', RoleName,'" + v_site + "','勝瑞電腦' from KPI_Roles where RoleID = '" + v_roleid + "'";

            if (v_site== "0112")
            {
                sql = sqlrs;
            }
            if (v_site== "0111")
            {
                sql = sqlrk;
            }
            if (v_site== "0103")
            {
                sql = sqlrm;
            }
            if (v_site== "0105")
            {
                sql = sqlrp;
            }
            if (v_site== "0000")
            {
                sql = sqlrt;
            }
            if (v_site== "0102")
            {
                sql = sqlsr;
            }
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql,con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                result = 1;
            }
            catch(SqlException)
            {
                result = 0;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
     
        //用戶角色清單
        public static DataSet QueryUserInRole(string v_empid,string v_site, string v_roleid)
        {
            string sql = "";
            string sqlrs = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RS b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "' and b.EmpID = '" + v_empid + "' and b.GroupID ='" + v_site + "'";
            string sqlrp = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RP b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "' and b.EmpID = '" + v_empid + "' and b.GroupID ='" + v_site + "'";
            string sqlrt = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RT b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "' and b.EmpID = '" + v_empid + "' and b.GroupID ='" + v_site + "'";
            string sqlrm = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RM b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "' and b.EmpID = '" + v_empid + "' and b.GroupID ='" + v_site + "'";
            string sqlrk = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_RK b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "' and b.EmpID = '" + v_empid + "' and b.GroupID ='" + v_site + "'";
            string sqlsr = "select b.UID, a.EmpID,a.EmpName,b.RoleName,a.DomainAccount,a.Email,b.GroupName from HR_Emp_Now a, KPI_UsersInRoles_SR b where a.EmpID = b.EmpID and b.RoleID = '" + v_roleid + "' and b.EmpID = '" + v_empid + "' and b.GroupID ='" + v_site + "'";

            if (v_site == "0112")
            {
                sql = sqlrs;
            }
            if (v_site == "0105")
            {
                sql = sqlrp;
            }
            if (v_site == "0000")
            {
                sql = sqlrt;
            }
            if (v_site == "0103")
            {
                sql = sqlrm;
            }
            if (v_site == "0111")
            {
                sql = sqlrk;
            }
            if (v_site == "0102")
            {
                sql = sqlsr;
            }
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "QueryUserInRole");
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //用户角色删除
        public static int DelUserRole(string v_uid, string v_groupname)
        {
            int result = 0;
            string sql = "";
            string sqlrs = "delete KPI_UsersInRoles_RS where UID = '" + v_uid + "' and GroupName = '" + v_groupname + "'";
            string sqlrt = "delete KPI_UsersInRoles_RT where UID = '" + v_uid + "' and GroupName = '" + v_groupname + "'";
            string sqlrp = "delete KPI_UsersInRoles_RP where UID = '" + v_uid + "' and GroupName = '" + v_groupname + "'";
            string sqlrm = "delete KPI_UsersInRoles_RM where UID = '" + v_uid + "' and GroupName = '" + v_groupname + "'";
            string sqlrk = "delete KPI_UsersInRoles_RK where UID = '" + v_uid + "' and GroupName = '" + v_groupname + "'";
            string sqlsr = "delete KPI_UsersInRoles_SR where UID = '" + v_uid + "' and GroupName = '" + v_groupname + "'";

            if (v_groupname == "日善電腦")
            {
                sql = sqlrs;
            }
            if (v_groupname == "日騰電腦")
            {
                sql = sqlrt;
            }
            if (v_groupname == "日沛電腦")
            {
                sql = sqlrp;
            }
            if (v_groupname == "日銘電腦")
            {
                sql = sqlrm;
            }
            if (v_groupname == "日鎧電腦")
            {
                sql = sqlrk;
            }
            if (v_groupname == "勝瑞電子")
            {
                sql = sqlsr;
            }

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