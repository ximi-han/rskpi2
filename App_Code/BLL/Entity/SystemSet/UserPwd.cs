using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coeno.BLL.Entity.SystemSet
{ 
public class UserPwd
{
    private static string v_DbconnStr;
    static UserPwd()
    {
       Initialize();
    }

    public static void Initialize()
    {
         v_DbconnStr = Coeno.BLL.Data.DbAccess.GetKpiDbConnStr();
    }

        /// <summary>
        /// 登錄頁面
        /// </summary>
        /// <param name="v_empid"></param>
        /// <param name="v_pwd"></param>
        /// <returns></returns>

        #region 一、驗證密碼登錄
        //1.日善
        public static DataSet QueryPwdRS(string v_empid,string v_pwd)
        {
            string sql = "select empid from CasetekUserPwd_RS where empid = '"+v_empid+ "' and Pwd1 = '"+v_pwd+"'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd_RS");
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
        //2.日騰
        public static DataSet QueryPwdRT(string v_empid, string v_pwd)
        {
            string sql = "select empid from CasetekUserPwd_RT where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd_RT");
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
        //3.日沛
        public static DataSet QueryPwdRP(string v_empid, string v_pwd)
        {
            string sql = "select empid from CasetekUserPwd_RP where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd_RP");
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
        //4.日銘
        public static DataSet QueryPwdRM(string v_empid, string v_pwd)
        {
            string sql = "select empid from CasetekUserPwd_RM where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd_RM");
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
        //5.日鎧
        public static DataSet QueryPwdRK(string v_empid, string v_pwd)
        {
            string sql = "select empid from CasetekUserPwd_RK where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd_RK");
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
        //6.勝瑞
        public static DataSet QueryPwdSR(string v_empid, string v_pwd)
        {
            string sql = "select empid from CasetekUserPwd_SR where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd_SR");
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
        #endregion

        /// <summary>
        /// 密碼修改頁面
        /// </summary>
        /// <param name="v_empid"></param>
        /// <returns></returns>

        #region 一、驗證舊密碼
        public static string ConOldPwd(string v_empid)
        {
            string OPwd1 = "";
            string sql = "select Pwd1 from CasetekUserPwd where EmpID = '" + v_empid + "'";
            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd");
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            if (ds.Tables["CasetekUserPwd"].Rows.Count > 0)
            {
                OPwd1 = ds.Tables["CasetekUserPwd"].Rows[0]["Pwd1"].ToString();
            }
            return OPwd1;
        }
        #endregion

        #region 二、更新新密碼
        public static bool UpPwd(string v_empid, string v_pwd)
        {
            bool result = false;
            string sql = "update CasetekUserPwd set Pwd1 = '" + v_pwd + "' where empid = '" + v_empid + "'";
            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException e)
            {
                result = false;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        #endregion

        #region//用戶密碼信息查詢PwdInitialization
        //1.日善
        public static DataSet UserPwdMessageRS(string v_empid,string v_group)
        {
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID from HR_Emp_Now a,CasetekUserPwd_RS b where a.EmpID = b.EmpID and b.EmpID = '"+v_empid+ "' and a.GroupID = '"+v_group+"'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlrs,con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "UserPwdMessageRS");
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
        //2.日鎧
        public static DataSet UserPwdMessageRK(string v_empid, string v_group)
        {
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID from HR_Emp_Now a,CasetekUserPwd_RK b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlrs, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "UserPwdMessageRK");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //3.日銘
        public static DataSet UserPwdMessageRM(string v_empid, string v_group)
        {
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID from HR_Emp_Now a,CasetekUserPwd_RM b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlrs, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "UserPwdMessageRM");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //4.日沛
        public static DataSet UserPwdMessageRP(string v_empid, string v_group)
        {
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID from HR_Emp_Now a,CasetekUserPwd_RP b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlrs, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "UserPwdMessageRP");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //5.日騰
        public static DataSet UserPwdMessageRT(string v_empid, string v_group)
        {
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID from HR_Emp_Now a,CasetekUserPwd_RT b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlrs, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "UserPwdMessageRT");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //6.勝瑞
        public static DataSet UserPwdMessageSR(string v_empid, string v_group)
        {
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID from HR_Emp_Now a,CasetekUserPwd_SR b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sqlrs, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "UserPwdMessageSR");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        #endregion

        #region//用戶密碼信息查詢PwdInitialization
        public static DataSet UserPwdMessage(string v_empid, string v_group)
        {
            string sql = "";
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID,b.Pwd1 from HR_Emp_Now a,CasetekUserPwd_RS b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";
            string sqlrk = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID,b.Pwd1 from HR_Emp_Now a,CasetekUserPwd_RK b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";
            string sqlrm = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID,b.Pwd1 from HR_Emp_Now a,CasetekUserPwd_RM b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";
            string sqlrp = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID,b.Pwd1 from HR_Emp_Now a,CasetekUserPwd_RP b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";
            string sqlrt = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID,b.Pwd1 from HR_Emp_Now a,CasetekUserPwd_RT b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";
            string sqlsr = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID,b.Pwd1 from HR_Emp_Now a,CasetekUserPwd_SR b where a.EmpID = b.EmpID and b.EmpID = '" + v_empid + "' and a.GroupID = '" + v_group + "'";

            if (v_group== "0112")
            {
                sql = sqlrs;
            }
            if (v_group== "0111")
            {
                sql =sqlrk;
            }
            if (v_group== "0103")
            {
                sql = sqlrm;
            }
            if (v_group== "0105")
            {
                sql = sqlrp;
            }
            if (v_group== "0000")
            {
                sql = sqlrt;
            }
            if (v_group== "0102")
            {
                sql = "sqlsr";
            }

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "UserPwdMessageRS1");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }     
        #endregion

        #region 初始化用戶密碼
        public static int PwdInitialization2(string v_empid, string v_groupid)
        {
            int result = 0;
            string sql = "update CasetekUserPwd set Pwd1 ='12345' from CasetekUserPwd a,HR_Emp_Now b where a.EmpID = b.EmpID and a.EmpID = '" + v_empid + "' and b.GroupID = '" + v_groupid + "'";
            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlCommand com = new SqlCommand(sql, con);
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
        #endregion


        public static DataSet QueryPwd(string v_factory,string v_empid,string v_pwd)
        {
            string sql = null;
            //1.日善
            if (v_factory=="0112")
            {
                sql = "select empid from CasetekUserPwd_RS where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'"; ;
            }
            //2.日騰
            if (v_factory == "0000")
            {
                sql = "select empid from CasetekUserPwd_RT where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";
            }
            //3.日沛
            if (v_factory == "0105")
            {
                sql = "select empid from CasetekUserPwd_RP where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";
            }
            //4.日銘
            if (v_factory == "0103")
            {
                sql = "select empid from CasetekUserPwd_RM where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";
            }
            //5.日鎧
            if (v_factory == "0111")
            {
                sql = "select empid from CasetekUserPwd_RK where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";
            }
            //6.勝瑞
            if (v_factory == "0102")
            {
                sql = "select empid from CasetekUserPwd_SR where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "'";
            }

            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd");
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

        public static DataSet QueryPwd2(string v_factory, string v_empid, string v_pwd)
        {
            string sql = null;
            sql = "select empid from CasetekUserPwd where empid = '" + v_empid + "' and Pwd1 = '" + v_pwd + "' and GroupID= '" + v_factory + "' ";
            SqlConnection con = new SqlConnection(v_DbconnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "CasetekUserPwd");
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
        /// <summary>
        /// 驗證輸入舊密碼,
        /// </summary>
        /// <param name="v_empid"></param>
        /// <param name="v_OldPwd"></param>
        /// <returns>驗證失敗 false 驗證成功 true</returns>
        public static bool confirmOldPwd(string v_empid, string v_OldPwd)
        {
            bool result = false;
            string oldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwd(v_empid);
            if(oldPwd == v_OldPwd)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


    }

}