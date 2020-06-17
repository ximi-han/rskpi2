using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modules_OrganizaMana_AssessOrganizaManaValidation : System.Web.UI.Page
{
    private string empID;
    string[] role = new string[] { "GSKPI_ADM", "GSKPI_HR" };
    string nowtime = System.DateTime.Now.ToString("yyyy/MM/dd").Replace("-", "/");
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = System.Configuration.ConfigurationManager.AppSettings["WebSiteTitle"].ToString();
        LabMsg.Text = "";
        empID = Session["txtCurrentEmpID"].ToString();
        if (!IsPostBack)
        {
            PageForm_Permission(empID, role);
            FactoryBind();
        }
    }

    //1.1權限判斷
    protected void PageForm_Permission(string v_empID, string[] v_roleID)
    {
        string UserInFactory = Coeno.BLL.Entity.SystemSet.Factorys.UserInFactorys(v_empID);

        if (!(Casetek.KPI.UsersInRoles.UserInRoles(v_empID, v_roleID[0], UserInFactory)) && !(Casetek.KPI.UsersInRoles.UserInRoles(v_empID, v_roleID[1], UserInFactory)))
        {
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlPermissionDenied"].ToString(), true);
            return;
        }
    }

    //1.2綁定Site Factory
    protected void FactoryBind()
    {
        string GroupID = null;
        string ParentDeptID = null;
        /*廠區*/
        DataTable dtfactory = Coeno.BLL.Entity.SystemSet.Factorys.QueryFactory();
        ddlFactory.DataSource = dtfactory;
        ddlFactory.DataTextField = "FactoryName";
        ddlFactory.DataValueField = "GroupID";
        ddlFactory.DataBind();
        GroupID = ddlFactory.SelectedValue;

        /*顯示中心層級*/
        ParentDeptID = GroupID;
        DataTable dtDeptL1 = new DataTable();
        dtDeptL1 = Coeno.BLL.Entity.SystemSet.Depts.QueryDeptBySite_For_L1(GroupID, ParentDeptID);
        ddlDeptIDList1.DataSource = dtDeptL1;
        ddlDeptIDList1.DataTextField = "DeptName";
        ddlDeptIDList1.DataValueField = "DeptID";
        ddlDeptIDList1.DataBind();
        ddlDeptIDList1.Items.Insert(0, new ListItem("ALL", "ALL"));
    }



    //2 Site點選并更
    protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
    {
        string GroupID = null;
        string ParentDeptID = null;

        ddlDeptIDList1.Items.Clear();
        GroupID = ddlFactory.SelectedValue;

        /*顯示中心層級*/
        ParentDeptID = GroupID;
        DataTable dtDeptL1 = new DataTable();
        dtDeptL1 = Coeno.BLL.Entity.SystemSet.Depts.QueryDeptBySite_For_L1(GroupID, ParentDeptID);
        ddlDeptIDList1.DataSource = dtDeptL1;
        ddlDeptIDList1.DataTextField = "DeptName";
        ddlDeptIDList1.DataValueField = "DeptID";
        ddlDeptIDList1.DataBind();
        ddlDeptIDList1.Items.Insert(0, new ListItem("ALL", "ALL"));
    }

    //3 生效確認事件
    protected void btnValConfigdept_Click(object sender, EventArgs e)
    {
        string returnNum;
        string returnID;
        string returnMsg;
        empID = Session["txtCurrentEmpID"].ToString();

        string flag = Coeno.BLL.Entity.OrganizaMana.AssessOrganizaManaValidation.Querykpiperiod(nowtime);
        if (flag == "Y")
        {
            LabMsg.Text = "考核組織主管狀態已鎖定，不可進行考核組織主管生效確認！！";
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            Coeno.BLL.Entity.OrganizaMana.AssessOrganizaManaValidation.DepValConfig(empID, out returnNum, out returnID, out returnMsg);
            LabMsg.Text = returnMsg + "人員生效:" + returnNum + "條";

        }
    }

    //4 查詢
    protected void btnquery_Click(object sender, EventArgs e)
    {
        string GroupID = ddlFactory.SelectedValue;
        string ParentDeptID = ddlDeptIDList1.SelectedValue;

        this.gvFormView.DataSource = null;
        this.gvFormView.DataBind();

        DataTable da = Coeno.BLL.Entity.OrganizaMana.AssessOrganizaManaValidation.QueryManaValidation(GroupID, ParentDeptID);
        if (da.Rows.Count > 0)
        {
            gvFormView.DataSource = da;
            gvFormView.DataBind();
            LabMsg.Text = "查询到" + da.Rows.Count.ToString() + "条";
            LabMsg.ForeColor = System.Drawing.Color.Blue;
        }
        else
        {
            LabMsg.Text = "無相關資料";
            LabMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    //5 換行
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFormView.PageIndex = e.NewPageIndex;

        string GroupID = ddlFactory.SelectedValue;
        string ParentDeptID = ddlDeptIDList1.SelectedValue;
        DataTable DT = new DataTable();
        DT = Coeno.BLL.Entity.OrganizaMana.AssessOrganizaManaValidation.QueryManaValidation(GroupID, ParentDeptID);
        gvFormView.DataSource = DT;
        gvFormView.DataBind();
    }
    //7 鎖定
    protected void btnsock_Click(object sender, EventArgs e)
    {
        int result = Coeno.BLL.Entity.OrganizaMana.AssessOrganizaManaValidation.sockdept(nowtime);

        if (result == 1)
        {
            LabMsg.Text = "考核組織主管鎖定成功！！";
            LabMsg.ForeColor = System.Drawing.Color.Blue;
            return;
        }
        else
        {
            LabMsg.Text = "考核組織主管鎖定失敗！！";
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }


    protected void btnexcel_Click(object sender, EventArgs e)
    {
        try
        {
            string GroupID = ddlFactory.SelectedValue;
            string ParentDeptID = ddlDeptIDList1.SelectedValue;

            DataTable dt = new DataTable();
            dt = Coeno.BLL.Entity.OrganizaMana.AssessOrganizaManaValidation.QueryManaValidation(GroupID, ParentDeptID);

            if (dt.Rows.Count <= 0)
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
        catch (Exception ex)
        {
            LabMsg.Text = "錯誤：" + ex.Message;
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }
}