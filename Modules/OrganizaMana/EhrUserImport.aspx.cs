using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modules_OrganizaMana_EhrUserImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FactoryBind();
        }
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

    protected void btnRT_Click(object sender, EventArgs e)
    {
        //
        string groupID = "RT";
        string returnNum;
        string returnID;
        string returnMsg;
        Coeno.BLL.Entity.OrganizaMana.EhrUserImport.ImprotUser(groupID, out returnNum,out  returnID,out  returnMsg);
        LabMsg.Text = returnMsg+ " 匯整入人員資料數據：" + returnNum + "條";
    }

    protected void btnRP_Click(object sender, EventArgs e)
    {
        //
        string groupID = "RP";
        string returnNum;
        string returnID;
        string returnMsg;
        Coeno.BLL.Entity.OrganizaMana.EhrUserImport.ImprotUser(groupID, out returnNum, out returnID, out returnMsg);
        LabMsg.Text = returnMsg + " 匯整入人員資料數據：" + returnNum + "條";

    }

    protected void btnRM_Click(object sender, EventArgs e)
    {
        //
        string groupID = "RM";
        string returnNum;
        string returnID;
        string returnMsg;
        Coeno.BLL.Entity.OrganizaMana.EhrUserImport.ImprotUser(groupID, out returnNum, out returnID, out returnMsg);
        LabMsg.Text = returnMsg + " 匯整入人員資料數據：" + returnNum + "條";
    }

    protected void btnRK_Click(object sender, EventArgs e)
    {
        //
        string groupID = "RK";
        string returnNum;
        string returnID;
        string returnMsg;
        Coeno.BLL.Entity.OrganizaMana.EhrUserImport.ImprotUser(groupID, out returnNum, out returnID, out returnMsg);
        LabMsg.Text = returnMsg + " 匯整入人員資料數據：" + returnNum + "條";
    }

    protected void btnRS_Click(object sender, EventArgs e)
    {
        //
        string groupID = "RS";
        string returnNum;
        string returnID;
        string returnMsg;
        Coeno.BLL.Entity.OrganizaMana.EhrUserImport.ImprotUser(groupID, out returnNum, out returnID, out returnMsg);
        LabMsg.Text = returnMsg + " 匯整入人員資料數據：" + returnNum + "條";
    }

    protected void btnSR_Click(object sender, EventArgs e)
    {
        //
        string groupID = "SR";
        string returnNum;
        string returnID;
        string returnMsg;
        Coeno.BLL.Entity.OrganizaMana.EhrUserImport.ImprotUser(groupID, out returnNum, out returnID, out returnMsg);
        LabMsg.Text = returnMsg + " 匯整入人員資料數據：" + returnNum + "條";
    }

}