using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class Modules_OrganizaMana_AssessUserValidation : System.Web.UI.Page
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

    //1 FactoryBind
    protected void FactoryBind()
    {
        string GroupID = null;
        string ParentDeptID = null;

        /*廠區*/
        DataTable dtfactory = Coeno.BLL.Entity.SystemSet.Factorys.QueryFactory();
        DropDownList1.DataSource = dtfactory;
        DropDownList1.DataTextField = "FactoryName";
        DropDownList1.DataValueField = "GroupID";
        DropDownList1.DataBind();

        GroupID = DropDownList1.SelectedValue;

        /*顯示中心層級*/
        ParentDeptID = GroupID;
        DataTable dtDeptL1 = new DataTable();
        dtDeptL1 = Coeno.BLL.Entity.SystemSet.Depts.QueryDeptBySite_For_L1(GroupID, ParentDeptID);
        DropDownList2.DataSource = dtDeptL1;
        DropDownList2.DataTextField = "DeptName";
        DropDownList2.DataValueField = "DeptID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("ALL", "ALL"));
    }

    //2 Site點選并更
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabMsg.Text = "";
        string GroupID = null;
        string ParentDeptID = null;

        GroupID = DropDownList1.SelectedValue;
        ParentDeptID = GroupID;
        DataTable dtDeptL1 = new DataTable();
        dtDeptL1 = Coeno.BLL.Entity.SystemSet.Depts.QueryDeptBySite_For_L1(GroupID, ParentDeptID);
        DropDownList2.DataSource = dtDeptL1;
        DropDownList2.DataTextField = "DeptName";
        DropDownList2.DataValueField = "DeptID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("ALL", "ALL"));
    }

    //3 生效確認事件
    protected void btnValConfig_Click(object sender, EventArgs e)
    {
        string returnNum;
        string returnID;
        string returnMsg;
        empID = Session["txtCurrentEmpID"].ToString();

        string flag = Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.Querykpiperiod(nowtime);
        if (flag=="Y")
        {
            LabMsg.Text = "人員生效狀態已鎖定，不可進行人員生效確認！！";
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.ValConfig(empID, out returnNum, out returnID, out returnMsg);
            LabMsg.Text = returnMsg + "人員生效:" + returnNum + "條";
        }
        
    }


    //4.查詢
    protected void btnquery_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        if (txtempid.Text != "")
        {
            DataTable dt = new DataTable();
            dt = Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.QueryValEmp(txtempid.Text);

            if (dt.Rows.Count <= 0)
            {
                LabMsg.Text = "未查詢到該人員生效后信息！！";
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
            string GroupID = DropDownList1.SelectedValue;
            string ParentDeptID = DropDownList2.SelectedValue;
            DataTable DT = new DataTable();
            DT = Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.QueryValFacdep(GroupID, ParentDeptID);

            if (DT.Rows.Count <= 0)
            {
                LabMsg.Text = "該廠區部門無生效后人員信息！！";
                LabMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                GridView1.DataSource = DT;
                GridView1.DataBind();
                LabMsg.Text = "查询到" + DT.Rows.Count.ToString() + "条";
                LabMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }
    }

    //5.換行
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        DataTable DT = new DataTable();
        DT = Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.QueryValFacdep(DropDownList1.SelectedValue, DropDownList2.SelectedValue);

        GridView1.DataSource = DT;
        GridView1.DataBind();
    }

    //6.Excel匯出
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        try
        {
            if (txtempid.Text != "")
            {
                DataTable dt = new DataTable();
                dt = Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.QueryValEmp(txtempid.Text);

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
            else
            {
                DataTable DT = new DataTable();
                DT = Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.QueryValFacdep(DropDownList1.SelectedValue, DropDownList2.SelectedValue);

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


    //7.鎖定
    protected void btnsock_Click(object sender, EventArgs e)
    {
        int result = Coeno.BLL.Entity.OrganizaMana.AssessUserValidation.sockemp(nowtime);

        if (result==1)
        {
            LabMsg.Text = "考核人員鎖定成功！！";
            LabMsg.ForeColor = System.Drawing.Color.Blue;
            return;
        }
        else
        {
            LabMsg.Text = "考核人員鎖定失敗！！";
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }
}