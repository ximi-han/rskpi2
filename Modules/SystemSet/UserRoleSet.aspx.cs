using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Modules_SystemSet_UserRoleSet : System.Web.UI.Page
{
    const string GSKPI_ADM = "GSKPI_ADM";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            labRoleBind();
            SiteBind();
            RoleBind();
        }
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LabMsg.Text = "";

        if (txtEmpID.Text =="")
        {
            LabMsg.Text = "請填寫人員工號！！";
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        DataSet UserInRole = Casetek.KPI.UserRole.UserInRole(txtEmpID.Text,DropSite.SelectedValue,DropRoles.SelectedValue);
        if (UserInRole.Tables[0].Rows.Count > 0)
        {
            LabMsg.Text = "人員已在該群組內，無需重複新增！！";
            LabMsg.ForeColor = System.Drawing.Color.Red;

        }
        else
        {
            //**用戶廠區//
            DataSet UserInFactory = Coeno.BLL.Entity.SystemSet.Factorys.UserInFactory(txtEmpID.Text);

            if (UserInFactory.Tables[0].Rows.Count <= 0)
            {
                LabMsg.Text = "該用戶不存在！！";
                LabMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                    int result = Casetek.KPI.UserRole.AddUserInRole(txtEmpID.Text, DropSite.SelectedValue, DropRoles.SelectedValue);
                    if (result == 0)
                    {
                        LabMsg.Text = "用戶新增"+ DropSite.SelectedItem + DropRoles.SelectedItem+"角色失敗！！";
                        LabMsg.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        LabMsg.Text = "用戶新增"+ DropSite.SelectedItem + DropRoles.SelectedItem + "角色成功！！";
                        LabMsg.ForeColor = System.Drawing.Color.Blue;
                        //DataSet UserInRoleRS = Casetek.KPI.UserRole.QueryUserInRole(txtEmpID.Text, DropSite.SelectedValue, DropRoles.SelectedValue);
                        //GridView1.DataSource = UserInRoleRS;
                        //GridView1.DataBind();
                        GridViewBind();
                }           
            }

            
        }
        
    }

    protected void labRoleBind()
    {
        LabRoleName.Text = "您當前新增的角色權限為：" + (DropRoles.Items.Count > 0 ? DropRoles.SelectedItem.Text : "");
    }

    protected void RoleBind()
    {
        DataTable dt = new DataTable();
        dt = Casetek.KPI.UserRole.QueryddlRoleList().Tables[0];
        DropRoles.DataSource = dt;
        DropRoles.DataTextField = "RoleName";
        DropRoles.DataValueField = "RoleID";
        DropRoles.DataBind();
    }

    protected void SiteBind()
    {
        DataTable site = new DataTable();
        site = Coeno.BLL.Entity.SystemSet.Factorys.QueryFactory();
        DropSite.DataSource = site;
        DropSite.DataTextField = "FactoryName";
        DropSite.DataValueField = "GroupID";
        DropSite.DataBind();
    }

    protected void GridViewBind()
    {
        DataSet dt = new DataSet();
        dt= Casetek.KPI.UserRole.QueryUserInRole(DropSite.SelectedValue,DropRoles.SelectedValue);
        if (dt.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            LabMsg.Text = "此群組下無人員信息!";
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
  
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        LabMsg.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        labRoleBind();
        GridViewBind();
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DelEmpRoleActive")
        {
            string[] seq = e.CommandArgument.ToString().Split(',');
            string uid = seq[0];
            string groupname = seq[1];     

            try
            {
                int result =  Casetek.KPI.UserRole.DelUserRole(uid,groupname);
                if (result == 0)
                {
                    LabMsg.Text = "人員角色權限刪除失敗！！";
                    LabMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    LabMsg.Text = "人員角色權限刪除成功！！";
                    LabMsg.ForeColor = System.Drawing.Color.Blue;
                    GridViewBind();
                }
            }
            catch(Exception ex)
            {
                LabMsg.Text = "刪除失敗：" + ex.Message;
                LabMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
    }


    protected void DropRoles_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        LabMsg.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        labRoleBind();
        GridViewBind();
    }

    protected void DropSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabMsg.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        labRoleBind();
        GridViewBind();
    }
}