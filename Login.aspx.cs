using System;
using System.Data;
using Casetek.KPI;
using System.DirectoryServices;
using Casetek.KPI;


public partial class Login : System.Web.UI.Page
{
    const string ROLEADMIN = "KPI_ADM";
    const string ROLEHR = "KPI_HR";
    const string ROLEUSER = "KPI_USER";
    string strhidempid = "";
    string url = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = System.Configuration.ConfigurationManager.AppSettings["WebSiteName"].ToString();
        Session["loginUserName"] = null;
        if (!IsPostBack)
        {
           txtEmpID.Text = getPageUserIdentityName().ToLower();
        }
    }

    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        string strUserAccount = null;
        string strPwd = null;

        strUserAccount = txtEmpID.Text;
        strPwd = txtPwd.Text;

        if (strUserAccount == "")
        {
            lblMsg.Text = "賬號不可為空！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (strPwd == "")
        {
            lblMsg.Text = "密碼不可為空！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //保存session
        Session["empid"] = txtEmpID.Text;

        //验证用户登录：
        //By工号验证||By域账号验证   
        if (UserLoginVerifyByEmpID(strUserAccount,strPwd) || UserLoginVerifyByADAccount(strUserAccount,strPwd))
        {
            if (url != "")
            {
                Response.Redirect(url,true);
            }
        }
        else
        {
            lblMsg.Text = "輸入的賬號或密碼不正確！！";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

    }

    public string getPageUserIdentityName()
    {
        string puidName = null;
        if (Page.User.Identity.AuthenticationType.ToString()=="Negotiate" || Page.User.Identity.AuthenticationType.ToString()=="NTLM")
        {
            if (Page.User.Identity.Name.IndexOf("\\") > 1)
            {
                puidName = Page.User.Identity.Name;
            }
        }
        else
        {
            puidName = "";
        }
        return puidName;
    }

    //验证用户登录:By工号
    public bool UserLoginVerifyByEmpID(string v_strUserAccount,string v_strPwd)
    {
        bool result = false;
        string Factory = null;
        string strEmpID = null;
        string strEmpPwd = null;

        strEmpID = v_strUserAccount;
        strEmpPwd = v_strPwd;

        DataSet ds = null;
        try
        {
            Factory = Casetek.KPI.Factorys.UserInFactorys(txtEmpID.Text);
            if (Factory == null || Factory =="")
            {
                url = ""; result = false;
            }
            ds = Casetek.KPI.UserPwd.QueryPwd(Factory,strEmpID,strEmpPwd);
            if (ds.Tables[0].Rows.Count>0)
            {
                url = "./Default.aspx?loginUserName="+Encrypt.Encrypto(strEmpID)+"&&LoginState=ID";
                result = true;
            }
            else
            {
                url = "";result = false;
            }
        }
        catch
        {
            url = "";result = false;
        }
        return result;

    }

    //验证用户登录:By域账号
    public bool UserLoginVerifyByADAccount(string v_strUserAccount,string v_strPwd)
    {
        bool result = false;
        string strLDAP = null;
        string strDomainAccount = null;
        string strDomainPwd = null;
        strDomainAccount = v_strUserAccount;
        strDomainPwd = v_strPwd;

        strLDAP = System.Configuration.ConfigurationManager.AppSettings["LDAPDomain"].ToString();
        ViewState["DomainAccount"]= "";
        try
        {
            DirectoryEntry entry = new DirectoryEntry(strLDAP,strDomainAccount,strDomainPwd);
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = string.Format("(SAMAccountName={0})",strDomainAccount);

            SearchResult sresult = search.FindOne();
            if (sresult == null)
            {
                url ="./Default.aspx?loginUserName="+Encrypt.Encrypto(strDomainAccount)+"&&loginState=AD";
                result = true;
            }
            else
            {
                url = "";result = false;
            }
        }
        catch
        {
            url = ""; result = false;
        }
        return result;
    }
}