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


namespace Coeno.Common.ExcelUtility
{
    /// <summary>
    /// Class to convert a dataset to an html stream which can be used to display the dataset
    /// in MS Excel
    /// The Convert method is overloaded three times as follows
    ///  1) Default to first table in dataset
    ///  2) Pass an index to tell us which table in the dataset to use
    ///  3) Pass a table name to tell us which table in the dataset to use
    ///  65536 excel row limit handled - 16.06.2006
    /// </summary>
    public static class DataSetToExcel
    {
        static DataSetToExcel()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            Initialize();
        }

        /// <summary>
        /// Initialize function
        /// </summary>
        public static void Initialize()
        {
        }

        public static void Convert(System.Collections.IEnumerable tables, string fileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("content-disposition",
                     "attachment; filename=" + fileName + ".xls");

            using (System.Xml.XmlTextWriter x = new System.Xml.XmlTextWriter(HttpContext.Current.Response.OutputStream, System.Text.Encoding.UTF8))
            {
                int sheetNumber = 0;
                x.WriteRaw("<?xml version=\"1.0\"?><?mso-application progid=\"Excel.Sheet\"?>");
                x.WriteRaw("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
                x.WriteRaw("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
                x.WriteRaw("xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                x.WriteRaw("<Styles><Style ss:ID='sText'>" +
                           "<NumberFormat ss:Format='@'/></Style>");
                x.WriteRaw("<Style ss:ID='sDate'><NumberFormat" +
                           " ss:Format='[$-409]m/d/yy\\ h:mm\\ AM/PM;@'/>");
                x.WriteRaw("</Style></Styles>");
                foreach (DataTable dt in tables)
                {
                    sheetNumber++;
                    string sheetName = !string.IsNullOrEmpty(dt.TableName) ?
                           dt.TableName : "Sheet" + sheetNumber.ToString();
                    x.WriteRaw("<Worksheet ss:Name='" + sheetName + "'>");
                    x.WriteRaw("<Table>");
                    string[] columnTypes = new string[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string colType = dt.Columns[i].DataType.ToString().ToLower();

                        if (colType.Contains("datetime"))
                        {
                            columnTypes[i] = "DateTime";
                            x.WriteRaw("<Column ss:StyleID='sDate'/>");

                        }
                        else if (colType.Contains("string"))
                        {
                            columnTypes[i] = "String";
                            x.WriteRaw("<Column ss:StyleID='sText'/>");

                        }
                        else
                        {
                            x.WriteRaw("<Column />");

                            if (colType.Contains("boolean"))
                            {
                                columnTypes[i] = "Boolean";
                            }
                            else
                            {
                                //default is some kind of number.
                                columnTypes[i] = "Number";
                            }

                        }
                    }
                    //column headers
                    x.WriteRaw("<Row>");
                    foreach (DataColumn col in dt.Columns)
                    {
                        x.WriteRaw("<Cell ss:StyleID='sText'><Data ss:Type='String'>");
                        x.WriteRaw(col.ColumnName);
                        x.WriteRaw("</Data></Cell>");
                    }
                    x.WriteRaw("</Row>");
                    //data
                    bool missedNullColumn = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        x.WriteRaw("<Row>");
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (!row.IsNull(i))
                            {
                                if (missedNullColumn)
                                {
                                    int displayIndex = i + 1;
                                    x.WriteRaw("<Cell ss:Index='" + displayIndex.ToString() +
                                               "'><Data ss:Type='" +
                                               columnTypes[i] + "'>");
                                    missedNullColumn = false;
                                }
                                else
                                {
                                    x.WriteRaw("<Cell><Data ss:Type='" +
                                               columnTypes[i] + "'>");
                                }

                                switch (columnTypes[i])
                                {
                                    case "DateTime":
                                        x.WriteRaw(((DateTime)row[i]).ToString("s"));
                                        break;
                                    case "Boolean":
                                        x.WriteRaw(((bool)row[i]) ? "1" : "0");
                                        break;
                                    case "String":
                                        x.WriteString(row[i].ToString());
                                        break;
                                    default:
                                        x.WriteString(row[i].ToString());
                                        break;
                                }

                                x.WriteRaw("</Data></Cell>");
                            }
                            else
                            {
                                missedNullColumn = true;
                            }
                        }
                        x.WriteRaw("</Row>");
                    }
                    x.WriteRaw("</Table></Worksheet>");
                }
                x.WriteRaw("</Workbook>");
            }
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Convert DataSet To Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="response"></param>
        /// <param name="xlsFileName"></param>
        public static  void Convert(DataSet ds, HttpResponse response, string xlsFileName)
        {
            response.Clear();
            response.AddHeader("content-disposition", "attachment;filename=" + xlsFileName);
            response.Charset = "";
            response.ContentType = "application/vnd.ms-excel";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();

            dg.DataSource = FitDataTableToExcel(ds.Tables[0]);
            dg.DataBind();
            dg.RenderControl(htmlWrite);

            response.Write(stringWrite.ToString());
            response.End();
        }

        /// <summary>
        /// Convert DataSet To Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="TableIndex"></param>
        /// <param name="response"></param>
        /// <param name="xlsFileName"></param>
        public static void Convert(DataSet ds, int TableIndex, HttpResponse response, string xlsFileName)
        {
            // lets make sure a table actually exists at the passed in value
            // if it is not call the base method
            if (TableIndex > ds.Tables.Count - 1)
            {
                Convert(ds, response, xlsFileName);
            }
            // we've got a good table so
            // let's clean up the response.object
            response.Clear();
            response.AddHeader("content-disposition", "attachment;filename=" + xlsFileName);
            response.Charset = "";
            // set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            // create a string writer
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            // create an htmltextwriter which uses the stringwriter
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            // instantiate a datagrid
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
            // set the datagrid datasource to the dataset passed in
            dg.DataSource = FitDataTableToExcel(ds.Tables[TableIndex]);
            // bind the datagrid
            dg.DataBind();
            // tell the datagrid to render itself to our htmltextwriter
            dg.RenderControl(htmlWrite);
            // all that's left is to output the html
            response.Write(stringWrite.ToString());
            response.End();
        }

        /// <summary>
        /// Convert DataSet To Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="TableName"></param>
        /// <param name="response"></param>
        /// <param name="xlsFileName"></param>
        public static void Convert(DataSet ds, string TableName, HttpResponse response, string xlsFileName)
        {
            // let's make sure the table name exists
            // if it does not then call the default method
            if (ds.Tables[TableName] == null)
            {
                Convert(ds, response, xlsFileName);
            }
            // we've got a good table so
            // let's clean up the response.object
            response.Clear();
            response.AddHeader("content-disposition", "attachment;filename=" + xlsFileName);
            response.Charset = "";
            // set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            // create a string writer
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            // create an htmltextwriter which uses the stringwriter
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            //instantiate a datagrid
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
            // set the datagrid datasource to the dataset passed in
            dg.DataSource = Coeno.Common.ExcelUtility.DataSetToExcel.FitDataTableToExcel(ds.Tables[TableName]);
            // bind the datagrid
            dg.DataBind();
            // tell the datagrid to render itself to our htmltextwriter
            dg.RenderControl(htmlWrite);
            // all that's left is to output the html
            response.Write(stringWrite.ToString());
            response.End();
        }

        /// <summary>
        /// Fit DataSet To Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static DataTable FitDataTableToExcel(DataTable dt)
        {
            int ExcelRowLimit = 65534;
            int TotTableRowCounter = 0;
            int TotExcelRowCounter = 0;
            int TempExcelRowCounter = 0;
            int TableCounter = 0;
            DataRow dr;
            DataTable ExcelTempTable = new DataTable();
            DataTable ExcelTable = new DataTable();
            do
            {
                ExcelTempTable = dt.Clone();
                TableCounter += 1;
                // Create Excel Temporary Table
                TempExcelRowCounter = 0;
                do
                {
                    TotTableRowCounter += 1;
                    TempExcelRowCounter += 1;
                    dr = dt.Rows[TotTableRowCounter - 1];
                    ExcelTempTable.NewRow();
                    ExcelTempTable.ImportRow(dr);
                } while (TotTableRowCounter < dt.Rows.Count & TempExcelRowCounter < ExcelRowLimit);
                // Join Excel Temporary Table to Excel Table as columns
                // Create columns of Excel Table
                // Line No column
                ExcelTable.Columns.Add(new DataColumn("No [" + TableCounter.ToString() + "]", typeof(Int32)));
                for (int i = 0; i <= ExcelTempTable.Columns.Count - 1; i++)
                {
                    ExcelTable.Columns.Add(new DataColumn(ExcelTempTable.Columns[i].ColumnName + " [" + TableCounter.ToString() + "]",
                        ExcelTempTable.Columns[i].DataType));
                }
                // Table seperator column
                ExcelTable.Columns.Add(new DataColumn("[*" + TableCounter.ToString() + "*]", typeof(String)));
                // Fill data into Excel Table from Excel Temporary Table
                int ExcelTableRow, ExcelTableCol = 0;
                for (ExcelTableRow = 0; ExcelTableRow <= ExcelTempTable.Rows.Count - 1; ExcelTableRow++)
                {
                    try
                    {
                        ExcelTable.Rows[ExcelTableRow].BeginEdit();
                    }
                    catch
                    {
                        dr = ExcelTable.NewRow();
                        ExcelTable.Rows.Add(dr);
                        ExcelTable.Rows[ExcelTableRow].BeginEdit();
                    }
                    // Row Number value
                    TotExcelRowCounter += 1;
                    ExcelTable.Rows[ExcelTableRow][(TableCounter - 1) + ((TableCounter - 1) * (ExcelTempTable.Columns.Count + 1))] = TotExcelRowCounter;
                    // Data column's value
                    for (ExcelTableCol = 0; ExcelTableCol <= ExcelTempTable.Columns.Count - 1; ExcelTableCol++)
                    {
                        int CurrenColPositon = (ExcelTableCol + 1) + ((TableCounter - 1) * (ExcelTempTable.Columns.Count + 2));
                        ExcelTable.Rows[ExcelTableRow][CurrenColPositon] =
                            ExcelTempTable.Rows[ExcelTableRow].ItemArray[ExcelTableCol];
                    }
                    // Seperator column's value
                    ExcelTable.Rows[ExcelTableRow][(TableCounter - 1) + (((TableCounter - 1) * (ExcelTempTable.Columns.Count + 1)) + ExcelTempTable.Columns.Count + 1)] = " ";

                    ExcelTable.Rows[ExcelTableRow].EndEdit();
                    ExcelTable.Rows[ExcelTableRow].AcceptChanges();
                }
            } while (TotTableRowCounter < dt.Rows.Count);
            return ExcelTable;
        }

        public static void EmportDataTableToExcel2(DataTable dtDevGrpUsers)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// DataSetToExcel
        ///// </summary>
        ///// <param name="ds"></param>
        //public static void EmportDataSetToExcel(DataSet ds)
        //{
        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.Charset = "";
        //    HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter stringWrite = new StringWriter();
        //    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        //    DataGrid dg = new DataGrid();
        //    dg.DataSource = ds.Tables[0];
        //    dg.DataBind();
        //    dg.RenderControl(htmlWrite);
        //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=result.xls");

        //    HttpContext.Current.Response.Write(stringWrite.ToString());
        //    HttpContext.Current.Response.End();
        //}

        /// <summary>
        /// DataSetToExcel
        /// </summary>
        /// <param name="ds"></param>
        public static void EmportDataSetToExcel(DataSet ds)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            DataGrid dg = new DataGrid();
            dg.DataSource = ds.Tables[0];
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            string style = @"<style>td { mso-number-format:\@; }</style>";
            HttpContext.Current.Response.Write(style);
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=result.xls");
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }

        ///// <summary>
        ///// EmportDataSetToExcel
        ///// </summary>
        ///// <param name="dt"></param>
        //public static void EmportDataTableToExcel(DataTable dt)
        //{
        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.Charset = "";
        //    HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter stringWrite = new StringWriter();
        //    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        //    DataGrid dg = new DataGrid();
        //    dg.DataSource = dt;
        //    dg.DataBind();
        //    dg.RenderControl(htmlWrite);
        //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=result.xls");

        //    HttpContext.Current.Response.Write(stringWrite.ToString());
        //    HttpContext.Current.Response.End();
        //}

        /// <summary>
        /// DataTableToExcel
        /// </summary>
        /// <param name="ds"></param>
        /// 
        public static void EmportDataTableToExcel(DataTable ds)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            DataGrid dg = new DataGrid();
            dg.DataSource = ds;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            string style = @"<style>td { mso-number-format:\@; }</style>";
            HttpContext.Current.Response.Write(style);
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=result.xls");
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="FilePath">~/Download/Door/</param>
        public static void DataTableToExcel(DataTable dt, string FilePath)
        {
            string physicPath = HttpContext.Current.Server.MapPath(FilePath);
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

        public static void EmportDataTableToExcel3(DataTable ds)
        {
            string filename = System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            DataGrid dg = new DataGrid();
            dg.DataSource = ds;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            string style = @"<style>td { mso-number-format:\@; }</style>";
            HttpContext.Current.Response.Write(style);
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }
    }


    /// <summary>
    /// Class to convert a web control to an html stream which can be used to display the dataset
    /// in MS Excel
    public static class ContorlToExcel
    {
        /// <summary>
        /// GridToExcel
        /// </summary>
        /// <param name="GVMain"></param>
        public static void FitGridToExcel(System.Web.UI.Control GVMain)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=ecxel.xls");
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF7;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GVMain.RenderControl(htmlWrite);
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ToExcel(Control ctl)
        {
            string filename = System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }
        
    }


}