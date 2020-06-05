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
        //if (!confirmOldPwd(txtEmpID.Text)) return;
        if(!confirmOldPwd2(txtEmpID.Text)) return;

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
            string result = Coeno.BLL.Entity.SystemSet.UserPwd.UpPwdRS(txtEmpID.Text, txtRNPwd.Text);

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
            string result = Coeno.BLL.Entity.SystemSet.UserPwd.UpPwdRT(txtEmpID.Text, txtRNPwd.Text);

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
            string result = Coeno.BLL.Entity.SystemSet.UserPwd.UpPwdRP(txtEmpID.Text, txtRNPwd.Text);

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
            string result = Coeno.BLL.Entity.SystemSet.UserPwd.UpPwdRM(txtEmpID.Text, txtRNPwd.Text);

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
            string result = Coeno.BLL.Entity.SystemSet.UserPwd.UpPwdRK(txtEmpID.Text, txtRNPwd.Text);

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
            string result = Coeno.BLL.Entity.SystemSet.UserPwd.UpPwdSR(txtEmpID.Text, txtRNPwd.Text);

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
        DataTable dtfactory = Coeno.BLL.Entity.SystemSet.Factorys.QueryFactory();
        ddlFactory.DataSource = dtfactory;
        ddlFactory.DataTextField = "FactoryName";
        ddlFactory.DataValueField = "GroupID";
        ddlFactory.DataBind();

    }
    /// <summary>
    /// 驗證舊密碼輸入
    /// </summary>
    /// <param name="v_empid">員工ID</param>
    /// <returns></returns>
    protected bool confirmOldPwd(string v_empid)
    {
        bool result = false;
        string v_OldPwd = "";
        //1.日善
        if (ddlFactory.SelectedValue == "RS")
        {
            v_OldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwdRS(v_empid);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return true;
            }
        }

        //2.日騰
        if (ddlFactory.SelectedValue == "RT")
        {
            v_OldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwdRT(v_empid);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return true;
            }
        }

        //3.日沛
        if (ddlFactory.SelectedValue == "RP")
        {
            v_OldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwdRP(v_empid);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return true;
            }
        }

        //4.日銘
        if (ddlFactory.SelectedValue == "RM")
        {
            v_OldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwdRM(v_empid);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return true;
            }
        }

        //5.日鎧
        if (ddlFactory.SelectedValue == "RK")
        {
            v_OldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwdRK(v_empid);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return true;
            }
        }

        //6.勝瑞
        if (ddlFactory.SelectedValue == "SR")
        {
            v_OldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwdSR(v_empid);

            if (txtOPwd.Text != v_OldPwd)
            {
                lblMsg.Text = "舊密碼輸入不正確！！";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return true;
            }
        }
        return result;
    }

    protected bool confirmOldPwd2(string v_empid)
    {
        bool result = false;
        string v_OldPwd = "";
        v_OldPwd = Coeno.BLL.Entity.SystemSet.UserPwd.ConOldPwd(v_empid);
        if (txtOPwd.Text != v_OldPwd)
        {
           lblMsg.Text = "舊密碼輸入不正確！！";
           lblMsg.ForeColor = System.Drawing.Color.Red;
           return true;
        }
        return result;
    }


}