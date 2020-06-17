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

public partial class Modules_OrganizaMana_AssessSupervisorDeployMana : System.Web.UI.Page
{
    private string empid;
    string[] role = new string[] { "GSKPI_ADM", "GSKPI_HR" };
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = System.Configuration.ConfigurationManager.AppSettings["WebSiteTitle"].ToString();

        LabMsg.Text = "";
        empid = Session["txtCurrentEmpID"].ToString();
        if (!IsPostBack)
        {
            PageForm_Permission(empid,role);
            PageForm_ddlSiteBind();
            PageForm_ddlDeptBind(DropDownList1.SelectedValue);
        }
    }

    //權限驗證
    protected  void PageForm_Permission(string v_empid,string[] v_role)
    {
        string UserInFactory = Coeno.BLL.Entity.SystemSet.Factorys.UserInFactorys(v_empid);

        if (!(Casetek.KPI.UsersInRoles.UserInRoles(v_empid,v_role[0],UserInFactory)) && !(Casetek.KPI.UsersInRoles.UserInRoles(v_empid,v_role[1],UserInFactory)))
        {
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlPermissionDenied"].ToString(),true);
            return;
        }
    }

    //Site綁定
    protected void PageForm_ddlSiteBind()
    {
        DataTable site = new DataTable();
        site = Coeno.BLL.Entity.SystemSet.Factorys.QueryFactory();
        DropDownList1.DataSource = site;
        DropDownList1.DataTextField = "FactoryName";
        DropDownList1.DataValueField = "GroupID";
        DropDownList1.DataBind();
    }

    //部門綁定
    protected void PageForm_ddlDeptBind(string v_site)
    {
        DataTable Dept = new DataTable();
        Dept = Coeno.BLL.Entity.SystemSet.Factorys.QueryDept(v_site);

        DropDownList2.DataSource = Dept;
        DropDownList2.DataTextField = "DeptName";
        DropDownList2.DataValueField = "DeptID";
        DropDownList2.DataBind();
    }
    //site下拉綁定部門
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabMsg.Text = "";
        PageForm_ddlDeptBind(DropDownList1.SelectedValue);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        DataTable dt = new DataTable();
        dt = Casetek.KPI.AssessSupervisorDeployMana.QueryDeploySupMana(DropDownList1.SelectedValue,DropDownList2.SelectedValue);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable deptmana = new DataTable();
        deptmana = Casetek.KPI.AssessSupervisorDeployMana.QueryDeploySupMana(DropDownList1.SelectedValue, DropDownList2.SelectedValue);

        if (deptmana.Rows.Count>0)
        {
            GridView1.DataSource = deptmana;
            GridView1.DataBind();
        }
        else
        {
            LabMsg.Text = "無調配人員信息！！";
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
        if (e.CommandName == "ManaDeploy")
        {
            string[] seq = e.CommandArgument.ToString().Split(','); 
            DataTable mana = Casetek.KPI.AssessSupervisorDeployMana.QueryMana(seq[0],seq[1],seq[2]);

            ModalPopupExtender.Show();
            TextBox1.Text = mana.Rows[0]["ManagerID"].ToString();
            TextBox2.Text = mana.Rows[0]["ManagerName"].ToString();
            TextBox3.Text = mana.Rows[0]["DeptID"].ToString();
            TextBox4.Text = mana.Rows[0]["DeptName"].ToString();
        }
    }

    //檢索新主管姓名
    protected void Button3_Click(object sender, EventArgs e)
    {
        LabMsg1.Text = "";
        DataTable deptname = new DataTable();
        deptname = Casetek.KPI.AssessSupervisorDeployMana.QueryManaName(TextBox5.Text);

        if (deptname.Rows.Count>0)
        {
            MPEShow();
            TextBox6.Text = deptname.Rows[0]["EmpName"].ToString();
        }
        else
        {
            MPEShow();
            LabMsg1.Text = "未檢索到調配后新主管姓名，請檢查調配后主管ID輸入是否有誤！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            TextBox6.Text = "";
            return;
        }
    }
    //調配
    protected void Button4_Click(object sender, EventArgs e)
    {
        string nowtime = DateTime.Now.ToString();
        empid = Session["txtCurrentEmpID"].ToString();

        if (TextBox5.Text == "")
        {
            MPEShow();
            LabMsg1.Text = "調配后主管ID不可為空！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (TextBox6.Text == "")
        {
            MPEShow();
            LabMsg1.Text = "請先檢索調配后主管姓名！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            return;
        }

        DataTable DT = new DataTable();
        DT = Casetek.KPI.AssessSupervisorDeployMana.QueryManaName(TextBox5.Text);
        //A start若檢索到人員姓名
        if (DT.Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            //A.1檢測部門ID+部門主管ID是否有數據
            dt = Casetek.KPI.AssessSupervisorDeployMana.QueryDepManaAdjust(TextBox1.Text,TextBox3.Text);
            //A.1.1有update
            if (dt.Rows.Count>0)
            {
                int result = Casetek.KPI.AssessSupervisorDeployMana.updepmanaAdjust(TextBox1.Text,TextBox3.Text,TextBox5.Text,TextBox6.Text,empid,nowtime);
                if (result==0)
                {
                    MPEShow();
                    LabMsg1.Text = "主管調配更新失敗，請確認填寫信息是否有誤！！";
                    LabMsg1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    MPEShow();
                    TextBox5.Enabled = false;
                    LabMsg1.Text = "主管調配更新成功,請關閉窗口！！";
                    LabMsg1.ForeColor = System.Drawing.Color.Blue;
                    return;
                }
            }
            //A.1.2无insert
            else
            {
                DataTable gpdt = new DataTable();
                gpdt = Casetek.KPI.AssessSupervisorDeployMana.QueryGroupID(TextBox3.Text);

                if (gpdt.Rows.Count>0)
                {
                    string gropid = gpdt.Rows[0]["GroupID"].ToString();
                    int result = Casetek.KPI.AssessSupervisorDeployMana.insdepmanaAdjust(TextBox3.Text, TextBox4.Text, TextBox1.Text, TextBox2.Text, gropid, TextBox5.Text, TextBox6.Text, empid, nowtime);
                    if (result == 0)
                    {
                        MPEShow();
                        LabMsg1.Text = "主管調配新增失敗，請確認填寫信息是否有誤！！";
                        LabMsg1.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        MPEShow();
                        TextBox5.Enabled = false;
                        LabMsg1.Text = "主管調配新增成功,請關閉窗口！！";
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
        //A end若未检索到部门名称
        else
        {
            MPEShow();
            LabMsg1.Text = "未檢索到調配后新主管姓名，請檢查調配后主管ID輸入是否有誤！！";
            LabMsg1.ForeColor = System.Drawing.Color.Red;
            TextBox6.Text = "";
            return;
        }
    }

    //Excel匯出
    protected void Button6_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        try
        {
            DataTable deptmana = new DataTable();
            deptmana = Casetek.KPI.AssessSupervisorDeployMana.QueryDeploySupMana(DropDownList1.SelectedValue, DropDownList2.SelectedValue);

            if (deptmana.Rows.Count > 0)
            {
                Coeno.Common.Utility.ExcelUtility.DataTableToExcel(deptmana);
            }
            else
            {
                LabMsg.Text = "無數據可導出！！";
                LabMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

        }
        catch(Exception ex)
        {
            LabMsg.Text = "錯誤:" + ex.Message;
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }

    protected void MPEShow()
    {
        ModalPopupExtender.Show();
    }
}