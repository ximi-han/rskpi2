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
}