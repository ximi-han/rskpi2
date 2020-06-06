using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void btnPwd_Click(object sender, EventArgs e)
    {
        #region 1.檢查卡控條件
        if (txtEmpID.Text == "")
        {
            lblMsg.Text = "賬號名不可為空！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (txtOPwd.Text == "")
        {
            lblMsg.Text = "舊密碼不可為空！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (txtNPwd.Text == "")
        {
            lblMsg.Text = "新密碼不可為空！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (txtRNPwd.Text == "")
        {
            lblMsg.Text = "確認新密碼不可為空！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        #endregion

        #region 2.驗證新密碼是否一致
        if (txtNPwd.Text != txtRNPwd.Text)
        {
            lblMsg.Text = "新密碼輸入不一致！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        #endregion

        #region 3.驗證舊密碼輸入
        if(Coeno.BLL.Entity.SystemSet.UserPwd.confirmOldPwd(txtEmpID.Text, txtOPwd.Text))
        {
            lblMsg.Text = "舊密碼正確！！";
            lblMsg.ForeColor = System.Drawing.Color.Blue;
        }
        else
        {
            lblMsg.Text = "舊密碼輸入不正確！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return ;
        }

        #endregion

        #region 4.更新密碼
        if (Coeno.BLL.Entity.SystemSet.UserPwd.UpPwd(txtEmpID.Text, txtRNPwd.Text))
        {
            lblMsg.Text = "密碼更新成功！！";
            lblMsg.ForeColor = System.Drawing.Color.Blue;
        }
        else
        {
            lblMsg.Text = "密碼更新失敗！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return ;
        }
        #endregion
    }

  





}