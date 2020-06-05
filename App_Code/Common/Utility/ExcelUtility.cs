using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;
using System.Runtime.Remoting.Contexts;

/// <summary>
/// Summary description for ExcelUtility
/// </summary>
namespace Coeno.Common.Utility
{
    public class ExcelUtility
    {
        private static string v_DbconnStr;
        static ExcelUtility()
        {
            Initialize();
        }
        public static void Initialize()
        {
            v_DbconnStr = Coeno.BLL.Data.DbAccess.GetKpiDbConnStr();
        }

      
        public static void DataTableToExcel(DataTable dt)
        {
            string physicPath = HttpContext.Current.Server.MapPath("~/Download/");
            //產生一個臨時檔案  
            string fileName = Guid.NewGuid() + ".xls";
            //把臨時檔案的實體Full路徑  
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + physicPath + fileName + ";Extended Properties=Excel 8.0;";


            //先算出欄位及列數  
            int rows = dt.Rows.Count;
            int cols = dt.Columns.Count;
            //用來建立命令   
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE ");
            sb.Append("Datas" + " ( ");
            //用來做開TABLE的欄名資訊  
            for (int i = 0; i < cols; i++)
            {
                if (i < cols - 1)
                    sb.Append(string.Format("{0} varchar,", dt.Columns[i].ColumnName));
                else
                    sb.Append(string.Format("{0} varchar)", dt.Columns[i].ColumnName));
            }
            //把要開啟的臨時Excel建立起來  
            using (OleDbConnection objConn = new OleDbConnection(connString))
            {
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = sb.ToString();
                objConn.Open();
                //先執行CreateTable的任務  
                objCmd.ExecuteNonQuery();
                //開始處理資料內容的新增  
                #region 開始處理資料內容的新增
                //把之前 CreateTable 清空  
                sb.Remove(0, sb.Length);
                sb.Append("INSERT INTO ");
                sb.Append("Datas" + " ( ");

                //這邊開始組該Excel欄位順序  
                for (int i = 0; i < cols; i++)
                {
                    if (i < cols - 1)
                        sb.Append(dt.Columns[i].ColumnName + ",");
                    else
                        sb.Append(dt.Columns[i].ColumnName + ") values (");
                }

                //這邊組 DataTable裡面的值要給到Excel欄位的  
                for (int i = 0; i < cols; i++)
                {
                    if (i < cols - 1)
                        sb.Append("@" + dt.Columns[i].ColumnName + ",");
                    else
                        sb.Append("@" + dt.Columns[i].ColumnName + ")");
                }

                #endregion
                //建立插入動作的Command  
                objCmd.CommandText = sb.ToString();
                OleDbParameterCollection param = objCmd.Parameters;
                for (int i = 0; i < cols; i++)
                {
                    param.Add(new OleDbParameter("@" + dt.Columns[i].ColumnName, OleDbType.VarChar));
                }
                //使用參數化的方式來給予值  
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < param.Count; i++)
                    {
                        param[i].Value = row[i];
                    }
                    //執行這一筆的給值  
                    objCmd.ExecuteNonQuery();
                }
            }//end using  

            //傳給產生Excel的程式處理 該副程式會把資料填進去           
            HttpContext.Current.Response.Clear();
            //要給的實體路徑  
            HttpContext.Current.Response.WriteFile(physicPath + fileName);
            string httpHeader = "attachment;filename=Doc_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", httpHeader);
            HttpContext.Current.Response.Flush();

            //刪除臨時文件  
            System.IO.File.Delete(physicPath + fileName);
            HttpContext.Current.Response.End();

        }

    }
}