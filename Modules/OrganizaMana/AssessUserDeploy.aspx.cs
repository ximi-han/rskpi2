using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Modules_OrganizaMana_AssessUserDeploy : System.Web.UI.Page
{
    private string empID;
    string[] role = new string[] { "GSKPI_ADM", "GSKPI_HR" };
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = System.Configuration.ConfigurationManager.AppSettings["WebSiteTitle"].ToString();

        LabMsg.Text = "";
        empID = Session["txtCurrentEmpID"].ToString();
        if (!IsPostBack)
        {
            PageForm_Permission(empID,role);
            PageForm_ddlSiteBind();
            PageForm_ddlDept(DropDownList1.SelectedValue);
            Button1.Enabled = false;
        }
    }

    //1.1驗證權限
    protected void PageForm_Permission(string v_empID,string[] v_roleID)
    {
        string  UserInFactory = Coeno.BLL.Entity.SystemSet.Factorys.UserInFactorys(v_empID);

        if (!(Casetek.KPI.UsersInRoles.UserInRoles(v_empID, v_roleID[0], UserInFactory)) && !(Casetek.KPI.UsersInRoles.UserInRoles(v_empID, v_roleID[1], UserInFactory)))
        {
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlPermissionDenied"].ToString(), true);
            return;
        }
    }
    //1.2綁定Site
    protected void PageForm_ddlSiteBind()
    {
        DataTable site = new DataTable();
        site = Coeno.BLL.Entity.SystemSet.Factorys.QueryFactory();
        DropDownList1.DataSource = site;
        DropDownList1.DataTextField = "FactoryName";
        DropDownList1.DataValueField = "GroupID";
        DropDownList1.DataBind();
    }
    //1.3綁定Dept
    protected void PageForm_ddlDept(string site)
    {
        DataTable Dept = new DataTable();
        Dept = Coeno.BLL.Entity.SystemSet.Factorys.QueryDept(site);

        DropDownList2.DataSource = Dept;
        DropDownList2.DataTextField = "DeptName";
        DropDownList2.DataValueField = "DeptID";
        DropDownList2.DataBind();
    }
    //2 Site點選并更
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabMsg.Text = "";
        PageForm_ddlDept(DropDownList1.SelectedValue);
        
    }

    //3 查詢
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        if (txtEmpID.Text!="")
        {
            DataTable dt = new DataTable();
            dt = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployUser(txtEmpID.Text);
            if (dt.Rows.Count<=0)
            {
                LabMsg.Text = "無調配人員信息！！";
                LabMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();                          
            }
        }
        else
        {
            DataTable DT = new DataTable();
            DT = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployUser(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
            if (DT.Rows.Count <= 0)
            {
                LabMsg.Text = "無調配人員信息！！";
                LabMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = DT;
                GridView1.DataBind();
            }
        }
                
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        DataTable DS = new DataTable();
        DS = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployUser(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
        GridView1.DataSource = DS;
        GridView1.DataBind();
    }

    //excel導出
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        try
        {
            if (txtEmpID.Text!="")
            {
                DataTable dt = new DataTable();
                dt = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployUser(txtEmpID.Text);
                if (dt.Rows.Count<=0)
                {
                    LabMsg.Text = "無數據可導出！！";
                    LabMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    Coeno.Common.Utility.ExcelUtility.DataTableToExcel(dt);
                }
            }
            else
            {
                DataTable DT = new DataTable();
                DT = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployUser(DropDownList1.SelectedValue,DropDownList2.SelectedValue);
                if (DT.Rows.Count <= 0)
                {
                    LabMsg.Text = "無數據可導出！！";
                    LabMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    Coeno.Common.Utility.ExcelUtility.DataTableToExcel(DT);
                }
            }
        }
        catch(Exception ex)
        {
            LabMsg.Text = "錯誤：" + ex.Message;
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LabMsg1.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox5.Enabled = true;
        if (e.CommandName== "UserDeploy")
        {
            DataTable dt = new DataTable();
            dt = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployUser(e.CommandArgument.ToString());
            ModalPopupExtenderDeploy.Show();
            TextBox1.Text = dt.Rows[0]["EmpID"].ToString();
            TextBox2.Text = dt.Rows[0]["EmpName"].ToString();
            TextBox3.Text = dt.Rows[0]["DeptID"].ToString();
            TextBox4.Text = dt.Rows[0]["DeptName"].ToString();
        }
    }

    //檢索部門
    protected void Button2_Click(object sender, EventArgs e)
    {
        LabMsg1.Text = "";
        DataTable dt = new DataTable();
        dt = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployDeptName(TextBox5.Text);

        if (dt.Rows.Count>0)
        {
            ModalPopupExtenderDeploy.Show();
            TextBox6.Text = dt.Rows[0]["DeptName"].ToString();
        }
        else
        {
            MPEShow();
            LabMsg1.Text = "未檢索到部門名稱，請檢查部門ID輸入是否有誤！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            TextBox6.Text = "";
            return;
        }
    }

    //調配
    protected void Button3_Click(object sender, EventArgs e)
    {
        string nowtime = DateTime.Now.ToString();
        empID = Session["txtCurrentEmpID"].ToString();
        if (TextBox5.Text == "")
        {
            MPEShow();
            LabMsg1.Text = "調配后部門ID不可為空！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (TextBox6.Text =="")
        {
            MPEShow();
            LabMsg1.Text = "請先檢索調配后部門名稱！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            return;
        }

        DataTable DT = new DataTable();
        DT = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployDeptName(TextBox5.Text);
        if (DT.Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryEmpAdjust(TextBox1.Text);
            if (dt.Rows.Count>0)
            {
                int result = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.upEmpAdjust(TextBox1.Text,TextBox5.Text,TextBox6.Text, empID, nowtime);
                if (result == 0)
                {
                    MPEShow();
                    LabMsg1.Text = "人員調配更新失敗，請確認填寫信息是否有誤！！";
                    LabMsg1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    MPEShow();
                    TextBox5.Enabled = false;
                    LabMsg1.Text = "人員調配更新成功,請關閉窗口！！";
                    LabMsg1.ForeColor = System.Drawing.Color.Blue;
                    return;
                }
            }
            else
            {
                DataTable gpdt = new DataTable();
                gpdt = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.QueryDeployDeptName(TextBox5.Text);

                if (gpdt.Rows.Count>0)
                {
                    string gropid = gpdt.Rows[0]["GroupID"].ToString();
                    int result = Coeno.BLL.Entity.OrganizaMana.AssessUserDeploy.adEmpAdjust(TextBox1.Text, TextBox2.Text,gropid,TextBox3.Text,TextBox4.Text,TextBox5.Text,TextBox6.Text,empID, nowtime);

                    if (result==0)
                    {
                        MPEShow();
                        LabMsg1.Text = "人員調配新增失敗，請確認填寫信息是否有誤！！";
                        LabMsg1.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        MPEShow();
                        LabMsg1.Text = "人員調配新增成功,請關閉窗口！！";
                        TextBox5.Enabled = false;
                        LabMsg1.ForeColor = System.Drawing.Color.Blue;
                        return;
                    }
                }
                else
                {
                    MPEShow();
                    LabMsg1.Text = "人員廠區獲取失敗！！";
                    LabMsg1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }
        else
        {
            MPEShow();
            LabMsg1.Text = "未檢索到部門名稱，請檢查部門ID輸入是否有誤！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            TextBox6.Text = "";
            return;
        }
    }

    protected void MPEShow()
    {
        ModalPopupExtenderDeploy.Show();
    } 
}