using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// FileFunction 的摘要说明
/// </summary>
public class FileFunction
{
        /// <summary>
        /// 把DataTable内容导出Excel并返回客户端 
        /// </summary>
        /// <param name="dtData">DataTable</param>
        /// <param name="strName">自定义DataTable列名数组(把数据库表字段名转换为用户实际需要的字段名)</param>
        /// <param name="strCaption">导出XLS文件头部标题(根据需要自定义)</param>
        /// <param name="strFileName">导出XLS文件名(不包含后缀名)</param>
        public static void DataToExcel(DataTable dtData, string[] strName, string strCaption, string strFileName)
        {
            System.Web.UI.WebControls.GridView dgExport = null;
            // 当前对话 
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            // IO用于导出并返回excel文件 
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                string attachment = "attachment; filename=" + System.Web.HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8) + ".xls";
                // 设置编码和附件格式 
                HttpResponse Response = HttpContext.Current.Response;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                //Response.ContentType = "application/ms-excel";
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.UTF7;
                Response.Charset = "";

                // 导出excel文件 
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                // 为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid 
                dgExport = new System.Web.UI.WebControls.GridView();
                dgExport.Caption = strCaption;
                dgExport.RowStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                dgExport.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                dgExport.HeaderStyle.Font.Bold = false;
                dgExport.DataSource = dtData.DefaultView;

                if (strName.Length > 0)
                {
                    int i;
                    for (i = 0; i < strName.Length; i++)
                    {
                        dtData.Columns[i].ColumnName = strName[i];
                    }
                }
                dgExport.AllowPaging = false;
                dgExport.DataBind();

                // 返回客户端 
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }
        }
}
