using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class Modules_ScoreAssess_SelfAssessofEmployeAbove6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1Bind();
    }

    protected void GridView1Bind()
    {
        string v_empid;
        v_empid = Session["empid"].ToString();

        DataSet SelfAssessofEmployeAbove6 = Casetek.KPI.ScoreAssess.SelfAssessofEmployeAbove6(v_empid);

        if (SelfAssessofEmployeAbove6.Tables[0].Rows.Count<=0)
        {
            LabMsg.Text = "無自評信息！！";
            LabMsg.ForeColor = System.Drawing.Color.Red;
            return;
            
        }
        else
        {
            GridView1.DataSource = SelfAssessofEmployeAbove6;
            GridView1.DataBind();
        }
    }

    protected void lbtn_selfassess_Click(object sender, EventArgs e)
    {
        MPEShow.Show();
        PnlMPEBind();
    }


    protected void PnlMPEBind()
    {
        string v_empid;
        v_empid = Session["empid"].ToString();

        string depid = Casetek.KPI.ScoreAssess.SelfAssessofEmployeDeptID(v_empid);

        Session["deptid"] = depid;

        Label2.Text = Session["deptid"].ToString();

        string deptname = Casetek.KPI.ScoreAssess.SelfAssessofEmployeDeptName(v_empid);

        Session["deptname"] = deptname;

        Label4.Text = Session["deptname"].ToString();
    }
}