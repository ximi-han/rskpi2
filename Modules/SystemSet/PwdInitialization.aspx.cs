﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public partial class Modules_SystemSet_PwdInitialization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        labMsg.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();

        if (txtEmpID.Text=="")
        {
            labMsg.Text = "請填寫人員工號！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        DataSet UserInFactory = Coeno.BLL.Entity.SystemSet.Factorys.UserInFactory(txtEmpID.Text);

        if (UserInFactory.Tables[0].Rows.Count <= 0)
        {
            labMsg.Text = "該用戶不存在！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            GridViewBind();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        labMsg.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (e.CommandName== "EditUserPwd")
        {
            string[] pwd = e.CommandArgument.ToString().Split(',');
            string empid = pwd[0];
            string groupid = pwd[1];

            try
            {
                int result = Coeno.BLL.Entity.SystemSet.UserPwd.PwdInitialization2(empid,groupid);
                if (result == 0)
                {
                    labMsg.Text = "初始化用戶密碼失敗";
                    labMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    labMsg.Text = "初始化用戶密碼成功，初始密碼為 12345";
                    labMsg.ForeColor = System.Drawing.Color.Blue;
                    GridViewBind1();
                    return;
                }
            }
            catch
            {
                labMsg.Text = "初始化用戶密碼失敗！！";
                labMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
    }

    protected void GridViewBind()
    {
        string UserInFactorys = Coeno.BLL.Entity.SystemSet.Factorys.UserInFactorys(txtEmpID.Text);

        if (UserInFactorys == "0112")
        {
            DataSet UserPwdMessageRS = Coeno.BLL.Entity.SystemSet.UserPwd.UserPwdMessageRS(txtEmpID.Text, UserInFactorys);
            if (UserPwdMessageRS.Tables[0].Rows.Count <= 0)
            {
                labMsg.Text = "未查詢到該用戶登錄賬戶信息！！";
                labMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = UserPwdMessageRS;
                GridView1.DataBind();
            }
        }

        if (UserInFactorys == "0111")
        {
            DataSet UserPwdMessageRK = Coeno.BLL.Entity.SystemSet.UserPwd.UserPwdMessageRK(txtEmpID.Text, UserInFactorys);
            if (UserPwdMessageRK.Tables[0].Rows.Count <= 0)
            {
                labMsg.Text = "未查詢到該用戶登錄賬戶信息！！";
                labMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = UserPwdMessageRK;
                GridView1.DataBind();
            }
        }

        if (UserInFactorys == "0103")
        {
            DataSet UserPwdMessageRM = Coeno.BLL.Entity.SystemSet.UserPwd.UserPwdMessageRM(txtEmpID.Text, UserInFactorys);
            if (UserPwdMessageRM.Tables[0].Rows.Count <= 0)
            {
                labMsg.Text = "未查詢到該用戶登錄賬戶信息！！";
                labMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = UserPwdMessageRM;
                GridView1.DataBind();
            }
        }

        if (UserInFactorys == "0105")
        {
            DataSet UserPwdMessageRP = Coeno.BLL.Entity.SystemSet.UserPwd.UserPwdMessageRP(txtEmpID.Text, UserInFactorys);
            if (UserPwdMessageRP.Tables[0].Rows.Count <= 0)
            {
                labMsg.Text = "未查詢到該用戶登錄賬戶信息！！";
                labMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = UserPwdMessageRP;
                GridView1.DataBind();
            }
        }

        if (UserInFactorys == "0000")
        {
            DataSet UserPwdMessageRT = Coeno.BLL.Entity.SystemSet.UserPwd.UserPwdMessageRT(txtEmpID.Text, UserInFactorys);
            if (UserPwdMessageRT.Tables[0].Rows.Count <= 0)
            {
                labMsg.Text = "未查詢到該用戶登錄賬戶信息！！";
                labMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = UserPwdMessageRT;
                GridView1.DataBind();
            }
        }

        if (UserInFactorys == "0102")
        {
            DataSet UserPwdMessageSR = Coeno.BLL.Entity.SystemSet.UserPwd.UserPwdMessageSR(txtEmpID.Text, UserInFactorys);
            if (UserPwdMessageSR.Tables[0].Rows.Count <= 0)
            {
                labMsg.Text = "未查詢到該用戶登錄賬戶信息！！";
                labMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = UserPwdMessageSR;
                GridView1.DataBind();
            }
        }
    }

    protected void GridViewBind1()
    {
         string UserInFactorys = Coeno.BLL.Entity.SystemSet.Factorys.UserInFactorys(txtEmpID.Text);

         DataSet UserPwdMessage = Coeno.BLL.Entity.SystemSet.UserPwd.UserPwdMessage(txtEmpID.Text, UserInFactorys);
         if (UserPwdMessage.Tables[0].Rows.Count <= 0)
         {
            labMsg.Text = "未查詢到該用戶登錄賬戶信息！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
         }
         else
         {
            GridView2.DataSource = UserPwdMessage;
            GridView2.DataBind();
         }
        



   

      

     

      
    }
}