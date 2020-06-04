using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_AssessPara_AnnualEvaluationIntervalSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
        if (txtYear.Text.Length != 4)
        {
            labMsg.Text = "年度格式不正確,正确格式为yyyy！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (ddlQuarter.Text == "")
        {
            labMsg.Text = "請選擇考評季度！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (txtSdate.Text.Length !=10)
        {
            labMsg.Text = "週期開始日期格式不正確,正确格式为yyyy-MM-dd！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        DateTime chk_sdate;
        try
        {
            chk_sdate = Convert.ToDateTime(txtSdate.Text);
        }
        catch
        {
            labMsg.Text = "週期開始日期格式不正確,正确格式为yyyy-MM-dd！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        
        if (txtEdate.Text.Length !=10)
        {
            labMsg.Text = "週期結束日期格式不正確,正确格式为yyyy-MM-dd！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        DateTime chk_edate;
        try
        {
            chk_edate = Convert.ToDateTime(txtEdate.Text);
        }
        catch
        {
            labMsg.Text = "週期結束日期格式不正確,正确格式为yyyy-MM-dd！！";
            labMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }
}