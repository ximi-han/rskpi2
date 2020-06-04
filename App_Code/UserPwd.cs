using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Casetek.KPI
{ 
public class UserPwd
{
    private static string _connectionString;
        static UserPwd()
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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
        //1.日善
        public static string ConOldPwdRS(string v_empid)
        {
            string OPwd1 = "";
            string sql = "select Pwd1 from CasetekUserPwd_RS where EmpID = '"+v_empid+"'";

            SqlConnection con = new SqlConnection(_connectionString);
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

            if (ds.Tables["CasetekUserPwd_RS"].Rows.Count>0)
            {
                OPwd1 = ds.Tables["CasetekUserPwd_RS"].Rows[0]["Pwd1"].ToString();
            }
            return OPwd1;
        }
        //2.日騰
        public static string ConOldPwdRT(string v_empid)
        {
            string OPwd1 = "";
            string sql = "select Pwd1 from CasetekUserPwd_RT where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
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

            if (ds.Tables["CasetekUserPwd_RT"].Rows.Count > 0)
            {
                OPwd1 = ds.Tables["CasetekUserPwd_RT"].Rows[0]["Pwd1"].ToString();
            }
            return OPwd1;
        }

        //3.日沛

        public static string ConOldPwdRP(string v_empid)
        {
            string OPwd1 = "";
            string sql = "select Pwd1 from CasetekUserPwd_RP where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
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

            if (ds.Tables["CasetekUserPwd_RP"].Rows.Count > 0)
            {
                OPwd1 = ds.Tables["CasetekUserPwd_RP"].Rows[0]["Pwd1"].ToString();
            }
            return OPwd1;
        }

        //4.日銘
        public static string ConOldPwdRM(string v_empid)
        {
            string OPwd1 = "";
            string sql = "select Pwd1 from CasetekUserPwd_RM where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
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

            if (ds.Tables["CasetekUserPwd_RM"].Rows.Count > 0)
            {
                OPwd1 = ds.Tables["CasetekUserPwd_RM"].Rows[0]["Pwd1"].ToString();
            }
            return OPwd1;
        }

        //5.日鎧
        public static string ConOldPwdRK(string v_empid)
        {
            string OPwd1 = "";
            string sql = "select Pwd1 from CasetekUserPwd_RK where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
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

            if (ds.Tables["CasetekUserPwd_RK"].Rows.Count > 0)
            {
                OPwd1 = ds.Tables["CasetekUserPwd_RK"].Rows[0]["Pwd1"].ToString();
            }
            return OPwd1;
        }

        //6.
        public static string ConOldPwdSR(string v_empid)
        {
            string OPwd1 = "";
            string sql = "select Pwd1 from CasetekUserPwd_SR where EmpID = '" + v_empid + "'";

            SqlConnection con = new SqlConnection(_connectionString);
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

            if (ds.Tables["CasetekUserPwd_SR"].Rows.Count > 0)
            {
                OPwd1 = ds.Tables["CasetekUserPwd_SR"].Rows[0]["Pwd1"].ToString();
            }
            return OPwd1;
        }
        #endregion

        #region 二、更新新密碼
        //1.日善
        public static string UpPwdRS(string v_empid,string v_pwd)
        {
            string v_result = "";

            string sql = "update CasetekUserPwd_RS set Pwd1 = '"+v_pwd+"' where empid = '"+v_empid+"'";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql,con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                v_result = "密碼更新成功";
            }
            catch(SqlException e)
            {
                v_result = "密碼更新失敗";
            }
            finally
            {
                con.Close();
            }
            return v_result;
        }
        //2.日騰
        public static string UpPwdRT(string v_empid, string v_pwd)
        {
            string v_result = "";

            string sql = "update CasetekUserPwd_RT set Pwd1 = '" + v_pwd + "' where empid = '" + v_empid + "'";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                v_result = "密碼更新成功";
            }
            catch (SqlException e)
            {
                v_result = "密碼更新失敗";
            }
            finally
            {
                con.Close();
            }
            return v_result;
        }

        //3.日沛
        public static string UpPwdRP(string v_empid, string v_pwd)
        {
            string v_result = "";

            string sql = "update CasetekUserPwd_RP set Pwd1 = '" + v_pwd + "' where empid = '" + v_empid + "'";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                v_result = "密碼更新成功";
            }
            catch (SqlException e)
            {
                v_result = "密碼更新失敗";
            }
            finally
            {
                con.Close();
            }
            return v_result;
        }

        //4.日銘
        public static string UpPwdRM(string v_empid, string v_pwd)
        {
            string v_result = "";

            string sql = "update CasetekUserPwd_RM set Pwd1 = '" + v_pwd + "' where empid = '" + v_empid + "'";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                v_result = "密碼更新成功";
            }
            catch (SqlException e)
            {
                v_result = "密碼更新失敗";
            }
            finally
            {
                con.Close();
            }
            return v_result;
        }

        //5.日鎧
        public static string UpPwdRK(string v_empid, string v_pwd)
        {
            string v_result = "";

            string sql = "update CasetekUserPwd_RK set Pwd1 = '" + v_pwd + "' where empid = '" + v_empid + "'";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                v_result = "密碼更新成功";
            }
            catch (SqlException e)
            {
                v_result = "密碼更新失敗";
            }
            finally
            {
                con.Close();
            }
            return v_result;
        }

        //6.勝瑞
        public static string UpPwdSR(string v_empid, string v_pwd)
        {
            string v_result = "";

            string sql = "update CasetekUserPwd_SR set Pwd1 = '" + v_pwd + "' where empid = '" + v_empid + "'";
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                v_result = "密碼更新成功";
            }
            catch (SqlException e)
            {
                v_result = "密碼更新失敗";
            }
            finally
            {
                con.Close();
            }
            return v_result;
        }
        #endregion

        #region//用戶密碼信息查詢PwdInitialization
        //1.日善
        public static DataSet UserPwdMessageRS(string v_empid,string v_group)
        {
            string sqlrs = "select a.EmpID,a.EmpName,a.DeptID,a.DeptName,a.GroupID from HR_Emp_Now a,CasetekUserPwd_RS b where a.EmpID = b.EmpID and b.EmpID = '"+v_empid+ "' and a.GroupID = '"+v_group+"'";

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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

            SqlConnection con = new SqlConnection(_connectionString);
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
        public static int PwdInitialization(string v_empid,string v_groupid)
        {
            int result = 0;
            string sql = "";
            string sqlrs = "update CasetekUserPwd_RS set Pwd1 ='12345' from CasetekUserPwd_RS a,HR_Emp_Now b where a.EmpID = b.EmpID and a.EmpID = '" + v_empid + "' and b.GroupID = '" + v_groupid + "'";
            string sqlrt = "update CasetekUserPwd_RT set Pwd1 ='12345' from CasetekUserPwd_RT a,HR_Emp_Now b where a.EmpID = b.EmpID and a.EmpID = '" + v_empid + "' and b.GroupID = '" + v_groupid + "'";
            string sqlrp = "update CasetekUserPwd_RP set Pwd1 ='12345' from CasetekUserPwd_RP a,HR_Emp_Now b where a.EmpID = b.EmpID and a.EmpID = '" + v_empid + "' and b.GroupID = '" + v_groupid + "'";
            string sqlrk = "update CasetekUserPwd_RK set Pwd1 ='12345' from CasetekUserPwd_RK a,HR_Emp_Now b where a.EmpID = b.EmpID and a.EmpID = '" + v_empid + "' and b.GroupID = '" + v_groupid + "'";
            string sqlrm = "update CasetekUserPwd_RM set Pwd1 ='12345' from CasetekUserPwd_RM a,HR_Emp_Now b where a.EmpID = b.EmpID and a.EmpID = '" + v_empid + "' and b.GroupID = '" + v_groupid + "'";
            string sqlsr = "update CasetekUserPwd_SR set Pwd1 ='12345' from CasetekUserPwd_SR a,HR_Emp_Now b where a.EmpID = b.EmpID and a.EmpID = '" + v_empid + "' and b.GroupID = '" + v_groupid + "'";

            if (v_groupid== "0112")
            {
                sql = sqlrs;
            }
            if (v_groupid== "0111")
            {
                sql = sqlrk;
            }
            if (v_groupid== "0103")
            {
                sql = sqlrm;
            }
            if (v_groupid== "0105")
            {
                sql = sqlrp;
            }
            if (v_groupid== "0000")
            {
                sql = sqlrt;
            }
            if (v_groupid== "0102")
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

            SqlConnection con = new SqlConnection(_connectionString);
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
    }

}