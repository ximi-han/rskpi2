using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using Casetek.KPI;

public partial class MasterPageDefault : System.Web.UI.MasterPage
{
    string urlLogin;
    protected void Page_Load(object sender, EventArgs e)
    {
        urlLogin = System.Configuration.ConfigurationManager.AppSettings["urlLogin"].ToString();
        string loginUserName = null;

        if (!IsPostBack)
        {
            loginUserName = Request.QueryString["loginUserName"];
            loginUserName = Coeno.Common.Utility.Encrypt.Decrypto(loginUserName);
            if (Session["loginUserName"] == null || Session["loginUserName"] == "")
            {
                Session["loginUserName"] = loginUserName;
            }
            
        }

        if (Session["loginUserName"] == null || Session["loginUserName"] == "")
        {
            Response.Redirect(urlLogin, true);
        }
        else
        {
            AccountUserBind();
        }
    }

    protected void AccountUserBind()
    {
        string v_Empid = "";
        string EmpID = "";
        string v_domain;
        string v_domainaccount;
        //使用login输入账号或工号查找User工号
        v_Empid = Session["empid"].ToString();

        EmpID = Casetek.KPI.UserName.UsersEmpID(v_Empid);
        if (EmpID != "")
        {
            txtCurrentEmpID.Text = EmpID;
        }

        EmpID = Casetek.KPI.UserName.UserEmpID(v_Empid);
        if (EmpID != "")
        {
            txtCurrentEmpID.Text = EmpID;
        }
        //工号查找User姓名
        string v_name = Casetek.KPI.UserName.UsersName(txtCurrentEmpID.Text);
        txtCurrentEmpName.Text = v_name;

        //工号查找账号
        v_domain = Casetek.KPI.DomainAccount.UserDomain(txtCurrentEmpID.Text);
        v_domainaccount = Casetek.KPI.DomainAccount.UserDomainAccount(txtCurrentEmpID.Text);

        txtCurrentDomainAccount.Text = (v_domain + "\\" + v_domainaccount).ToUpper();

        Session["txtCurrentEmpID"] = txtCurrentEmpID.Text;
    }


}
