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
        }
    }

    //protected void txtDeploy_Click(object sender, EventArgs e)
    //{
    //    MPEShow.Show();
    //}

    protected void PageForm_Permission(string v_empID,string[] v_roleID)
    {
        string  UserInFactory = Casetek.KPI.Factorys.UserInFactorys(v_empID);

        if (!(Casetek.KPI.UsersInRoles.UserInRoles(v_empID, v_roleID[0], UserInFactory)) && !(Casetek.KPI.UsersInRoles.UserInRoles(v_empID, v_roleID[1], UserInFactory)))
        {
            Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlPermissionDenied"].ToString(), true);
            return;
        }
    }

    protected void PageForm_ddlSiteBind()
    {
        DataTable site = new DataTable();
        site = Casetek.KPI.Factorys.QueryFactory();
        DropDownList1.DataSource = site;
        DropDownList1.DataTextField = "FactoryName";
        DropDownList1.DataValueField = "GroupID";
        DropDownList1.DataBind();
    }

    protected void PageForm_ddlDept(string site)
    {
        DataTable Dept = new DataTable();
        Dept = Casetek.KPI.Factorys.QueryDept(site);

        DropDownList2.DataSource = Dept;
        DropDownList2.DataTextField = "DeptName";
        DropDownList2.DataValueField = "DeptID";
        DropDownList2.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabMsg.Text = "";
        PageForm_ddlDept(DropDownList1.SelectedValue);
        
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        if (txtEmpID.Text!="")
        {
            DataTable dt = new DataTable();
            dt = Casetek.KPI.AssessUserDeploy.QueryDeployUser(txtEmpID.Text);
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
            DT = Casetek.KPI.AssessUserDeploy.QueryDeployUser(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
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
        DS = Casetek.KPI.AssessUserDeploy.QueryDeployUser(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
        GridView1.DataSource = DS;
        GridView1.DataBind();
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        try
        {
            if (txtEmpID.Text!="")
            {
                DataTable dt = new DataTable();
                dt = Casetek.KPI.AssessUserDeploy.QueryDeployUser(txtEmpID.Text);
                if (dt.Rows.Count<=0)
                {
                    LabMsg.Text = "無數據可導出！！";
                    LabMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    Casetek.KPI.ExcelUtility.DataTableToExcel(dt);
                }
            }
            else
            {
                DataTable DT = new DataTable();
                DT = Casetek.KPI.AssessUserDeploy.QueryDeployUser(DropDownList1.SelectedValue,DropDownList2.SelectedValue);
                if (DT.Rows.Count <= 0)
                {
                    LabMsg.Text = "無數據可導出！！";
                    LabMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    Casetek.KPI.ExcelUtility.DataTableToExcel(DT);
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
}