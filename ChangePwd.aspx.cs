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
            FactoryBind();
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

        #region 2.驗證舊密碼輸入
        string v_OldPwd = "";
        //1.日善
        if (ddlFactory.SelectedValue=="RS")
        {
            v_OldPwd = Casetek.KPI.UserPwd.ConOldPwdRS(txtEmpID.Text);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //2.日騰
        if (ddlFactory.SelectedValue == "RT")
        {
            v_OldPwd = Casetek.KPI.UserPwd.ConOldPwdRT(txtEmpID.Text);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //3.日沛
        if (ddlFactory.SelectedValue == "RP")
        {
            v_OldPwd = Casetek.KPI.UserPwd.ConOldPwdRP(txtEmpID.Text);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //4.日銘
        if (ddlFactory.SelectedValue == "RM")
        {
            v_OldPwd = Casetek.KPI.UserPwd.ConOldPwdRM(txtEmpID.Text);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //5.日鎧
        if (ddlFactory.SelectedValue == "RK")
        {
            v_OldPwd = Casetek.KPI.UserPwd.ConOldPwdRK(txtEmpID.Text);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //6.勝瑞
        if (ddlFactory.SelectedValue == "SR")
        {
            v_OldPwd = Casetek.KPI.UserPwd.ConOldPwdSR(txtEmpID.Text);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        #endregion

        #region 3.驗證新密碼是否一致
        if (txtNPwd.Text != txtRNPwd.Text)
        {
            lblMsg.Text = "新密碼輸入不一致！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        #endregion

        #region 4.更新密碼
        //1.日善
        if (ddlFactory.SelectedValue== "0112")
        {
            string result = Casetek.KPI.UserPwd.UpPwdRS(txtEmpID.Text, txtRNPwd.Text);

            if (result == "密碼更新成功")
            {
                lblMsg.Text = "密碼更新成功！！";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            else
            {
                lblMsg.Text = "密碼更新失敗！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //2.日騰
        if (ddlFactory.SelectedValue == "0000")
        {
            string result = Casetek.KPI.UserPwd.UpPwdRT(txtEmpID.Text, txtRNPwd.Text);

            if (result == "密碼更新成功")
            {
                lblMsg.Text = "密碼更新成功！！";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            else
            {
                lblMsg.Text = "密碼更新失敗！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //3.日沛
        if (ddlFactory.SelectedValue == "0105")
        {
            string result = Casetek.KPI.UserPwd.UpPwdRP(txtEmpID.Text, txtRNPwd.Text);

            if (result == "密碼更新成功")
            {
                lblMsg.Text = "密碼更新成功！！";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            else
            {
                lblMsg.Text = "密碼更新失敗！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //4.日銘
        if (ddlFactory.SelectedValue == "0103")
        {
            string result = Casetek.KPI.UserPwd.UpPwdRM(txtEmpID.Text, txtRNPwd.Text);

            if (result == "密碼更新成功")
            {
                lblMsg.Text = "密碼更新成功！！";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            else
            {
                lblMsg.Text = "密碼更新失敗！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //5.日鎧
        if (ddlFactory.SelectedValue == "0111")
        {
            string result = Casetek.KPI.UserPwd.UpPwdRK(txtEmpID.Text, txtRNPwd.Text);

            if (result == "密碼更新成功")
            {
                lblMsg.Text = "密碼更新成功！！";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            else
            {
                lblMsg.Text = "密碼更新失敗！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        //6.勝瑞
        if (ddlFactory.SelectedValue == "0102")
        {
            string result = Casetek.KPI.UserPwd.UpPwdSR(txtEmpID.Text, txtRNPwd.Text);

            if (result == "密碼更新成功")
            {
                lblMsg.Text = "密碼更新成功！！";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            else
            {
                lblMsg.Text = "密碼更新失敗！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        #endregion
    }

    protected void FactoryBind()
    {
        /*廠區*/
        DataTable dtfactory = Casetek.KPI.Factorys.QueryFactory();
        ddlFactory.DataSource = dtfactory;
        ddlFactory.DataTextField = "FactoryName";
        ddlFactory.DataValueField = "GroupID";
        ddlFactory.DataBind();

    }
}