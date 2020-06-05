using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Coeno.BLL.Data;
using Coeno.BLL.Model.Account;

namespace Coeno.BLL.Entity.Account
{
    public class Users
    {
        private static string v_connString;

        //
        //  DBHelper_Account Data Factory
        //
        static Users()
        {
            Initialize();
        }


        /// <summary>
        /// Initialize function
        /// </summary>
        public static void Initialize()
        {
            v_connString = Coeno.BLL.Data.DbAccess.GetKpiDbConnStr();
        }


        #region Class The Basic function for users Declarations
        //************************************************************************
        //The Method of Users

        /// <summary>
        /// 抓取User的Account_User的基本資料 GetUserBasicInfo; Parameter:EmpID
        /// </summary>
        /// <param name="v_empid"></param>
        /// <returns></returns>
        public static TUser GetUserBasicInfo(string v_empid)
        {
            string sql = "select * from HR_Emp_Now where EmpID='" + v_empid + "'";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "Account_UserBasicInfo");
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

            TUser Temp_User = new TUser();

            if (dst.Tables["Account_UserBasicInfo"].Rows.Count > 0)
            {
                //Temp_User.UserID = dst.Tables["Account_UserBasicInfo"].Rows[0]["UserID"].ToString();
                Temp_User.EmpID = dst.Tables["Account_UserBasicInfo"].Rows[0]["EmpID"].ToString();
                Temp_User.EmpCardID = dst.Tables["Account_UserBasicInfo"].Rows[0]["EmpCardID"].ToString();
                Temp_User.Domain = dst.Tables["Account_UserBasicInfo"].Rows[0]["Domain"].ToString();
                Temp_User.DomainAccount = dst.Tables["Account_UserBasicInfo"].Rows[0]["DomainAccount"].ToString();
                Temp_User.EmpName = dst.Tables["Account_UserBasicInfo"].Rows[0]["EmpName"].ToString();
                Temp_User.TitleID = dst.Tables["Account_UserBasicInfo"].Rows[0]["TitleID"].ToString();
                Temp_User.TitleName = dst.Tables["Account_UserBasicInfo"].Rows[0]["TitleName"].ToString();
                Temp_User.DeptID = dst.Tables["Account_UserBasicInfo"].Rows[0]["DeptID"].ToString();
                Temp_User.DeptName = dst.Tables["Account_UserBasicInfo"].Rows[0]["DeptName"].ToString();
                Temp_User.Ext1 = dst.Tables["Account_UserBasicInfo"].Rows[0]["Ext1"].ToString();
                Temp_User.MManager1 = dst.Tables["Account_UserBasicInfo"].Rows[0]["MManager1"].ToString();
                Temp_User.MManager2 = dst.Tables["Account_UserBasicInfo"].Rows[0]["MManager2"].ToString();
                Temp_User.eMail = dst.Tables["Account_UserBasicInfo"].Rows[0]["email"].ToString();
                Temp_User.BUID = dst.Tables["Account_UserBasicInfo"].Rows[0]["BUID"].ToString();
                Temp_User.Sex = dst.Tables["Account_UserBasicInfo"].Rows[0]["SEX"].ToString();
                if (dst.Tables["Account_UserBasicInfo"].Rows[0]["DateIn"] != System.DBNull.Value)
                {
                    Temp_User.DateIn = Convert.ToDateTime(dst.Tables["Account_UserBasicInfo"].Rows[0]["DateIn"]);
                }

                if (dst.Tables["Account_UserBasicInfo"].Rows[0]["DateOut"] != System.DBNull.Value)
                {
                    Temp_User.DateOut = Convert.ToDateTime(dst.Tables["Account_UserBasicInfo"].Rows[0]["DateOut"]);
                }
                Temp_User.DutyRank = dst.Tables["Account_UserBasicInfo"].Rows[0]["DutyRank"].ToString();
                Temp_User.ProxyEmpID = dst.Tables["Account_UserBasicInfo"].Rows[0]["ProxyEmpID"].ToString();
                Temp_User.IsDuty = dst.Tables["Account_UserBasicInfo"].Rows[0]["IsDuty"].ToString();
                Temp_User.IsLeave = dst.Tables["Account_UserBasicInfo"].Rows[0]["IsLeave"].ToString();
                Temp_User.BuildID = dst.Tables["Account_UserBasicInfo"].Rows[0]["BuildID"].ToString();
            }
            return Temp_User;
        }

        public static TUser GetUserInfo(string v_empid, out int v_ResultID, out string v_ResultMsg)
        {
            v_ResultID = 999;
            v_ResultMsg = String.Empty;
            string sql = "select * from HR_Emp_Now where EmpID='" + v_empid + "'";
            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);
            DataSet dst = new DataSet();
            try
            {
                con.Open();

                dad.Fill(dst, "UserInfo");
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            TUser v_User = new TUser();
            if (dst.Tables["UserInfo"].Rows.Count > 0)
            {
                v_User.EmpName = dst.Tables["UserInfo"].Rows[0]["EmpName"].ToString();
            }
            v_ResultID = 0;
            v_ResultMsg = "紱釬OK";
            return v_User;

        }
        /// <summary>
        /// 抓取EmpID的Account_User的基本資料 GetUserBasicInfo; Parameter:EmpID
        /// </summary>
        /// <param name="v_empid"></param>
        /// <returns></returns>
        public static DataSet GetEmpBasicInfo(string v_empid)
        {
            string sql = "select * from HR_Emp_Now where EmpID='" + v_empid + "'";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "Account_UserBasicInfo");
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
        /// GetUserBasicInfo
        /// </summary>
        /// <param name="v_cname"></param>
        /// <param name="v_empid"></param>
        /// <param name="v_ename"></param>
        /// <param name="v_titleId"></param>
        /// <param name="v_deptid"></param>
        /// <returns></returns>
        public static DataSet GetUserBasicInfo(string v_cname, string v_empid, string v_ename, string v_titleId, string v_deptid, string v_domainaccount)
        {
            //Get the Sql************************************************
            string sql = "select * from HR_Emp_Now";
            string sql_where = " where ";
            if (v_cname != "")
            {
                sql = sql + sql_where + "empcname like  '" + v_cname + "%'";
                sql_where = " and ";
            }
            if (v_empid != "")
            {
                sql = sql + sql_where + "empid like '" + v_empid + "%'";
                sql_where = " and ";
            }
            if (v_ename != "")
            {
                sql = sql + sql_where + "empename like '" + v_ename + "%'";
                sql_where = " and ";
            }
            if (v_domainaccount != "")
            {
                sql = sql + sql_where + "domainaccount like '" + v_domainaccount + "%'";
                sql_where = " and ";
            }

            if (v_titleId != "")
            {
                sql = sql + sql_where + "titleId = '" + v_titleId + "'";
                sql_where = " and ";
            }
            if (v_deptid != "")
            {
                sql = sql + sql_where + "deptid = '" + v_deptid + "'";
                sql_where = " and ";
            }
            sql = sql + " order by empid";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "QueryUserInfoByMore");
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
        /// 抓取User的Account_User的進階資料 GetUserAdvInfo; Parameter:EmpID
        /// </summary>
        /// <param name="v_empid"></param>
        /// <returns></returns>
        public static TUserAdvance GetUserAdvInfo(string v_empid)
        {
            string sql = "select * from HR_Emp_Now where EmpID='" + v_empid + "'";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "Account_UserAdvInfo");
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

            TUserAdvance Temp_User = new TUserAdvance();

            if (dst.Tables["Account_UserAdvInfo"].Rows.Count > 0)
            {
                Temp_User.UserID = dst.Tables["Account_UserAdvInfo"].Rows[0]["UserID"].ToString();
                Temp_User.EmpID = dst.Tables["Account_UserAdvInfo"].Rows[0]["EmpID"].ToString();
                Temp_User.EmpCardID = dst.Tables["Account_UserAdvInfo"].Rows[0]["EmpCardID"].ToString();
                Temp_User.Domain = dst.Tables["Account_UserAdvInfo"].Rows[0]["Domain"].ToString();
                Temp_User.DomainAccount = dst.Tables["Account_UserAdvInfo"].Rows[0]["DomainAccount"].ToString();
                Temp_User.EmpName = dst.Tables["Account_UserAdvInfo"].Rows[0]["EmpName"].ToString();
                Temp_User.FirstName = dst.Tables["Account_UserAdvInfo"].Rows[0]["FirstName"].ToString();
                Temp_User.LastName = dst.Tables["Account_UserAdvInfo"].Rows[0]["LastName"].ToString();
                Temp_User.EmpCName = dst.Tables["Account_UserAdvInfo"].Rows[0]["EmpCName"].ToString();
                Temp_User.EmpEName = dst.Tables["Account_UserAdvInfo"].Rows[0]["EmpEName"].ToString();
            }
            return Temp_User;
        }

        /// <summary>
        /// 根據Domain,DomainAccount抓取User的EmpID; Parameter:Domain,DomainAccount
        /// </summary>
        /// <param name="v_domain"></param>
        /// <param name="v_domainaccount"></param>
        /// <returns></returns>
        public static string GetUserEmpID(string v_domain, string v_domainaccount)
        {
            string empID = "";
            string sql = "select UserID from Account_User where domain='" + v_domain + "' and domainaccount = '" + v_domainaccount + "'";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "Account_UserEmpID");
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

            if (dst.Tables["Account_UserEmpID"].Rows.Count > 0)
            {
                empID = dst.Tables["Account_UserEmpID"].Rows[0]["UserID"].ToString();
            }
            return empID;
        }

        /// <summary>
        /// IsEmpIDExist
        /// </summary>
        /// <param name="v_empid"></param>
        /// <returns></returns>
        public static int IsEmpIDExist(string v_empid)
        {
            int result = 0;
            string sql = "select * from HR_Emp_Now where EmpID='" + v_empid + "'";

            SqlConnection con = new SqlConnection(v_connString);
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);

            DataSet dst = new DataSet();

            try
            {
                con.Open();

                dad.Fill(dst, "Account_IsEmpIDExist");
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

            if (dst.Tables["Account_IsEmpIDExist"].Rows.Count > 0)
            {
                result = 1;
            }
            return result;
        }
        #endregion


        

    }


}
