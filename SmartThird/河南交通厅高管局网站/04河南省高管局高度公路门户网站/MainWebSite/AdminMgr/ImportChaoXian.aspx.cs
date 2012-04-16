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
using System.Data.OleDb;
using PubClass;
using MainModel;
using MainService;

public partial class AdminMgr_ImportChaoXian : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (FUploadXls.HasFile == false)
        {
            CommonFunction.Alert(Literal1, "请您选择Excel文件");
            return;
        }
        string IsXls = System.IO.Path.GetExtension(FUploadXls.FileName).ToString().ToLower();
        if (IsXls != ".xls")
        {
            CommonFunction.Alert(Literal1, "只可以选择Excel文件");
            return;
        }
        string filename = CommonFunction.Get_DynamicString() + ".xls";
        string filePath = Server.MapPath("~/AdminMgr/xls/"+filename);
        FUploadXls.PostedFile.SaveAs(filePath);
        DataSet ds = ExcelSqlConnection(filePath, filename);
        DataTable dt = ds.Tables[0];
        if (dt == null || dt.Rows.Count == 0) {
            CommonFunction.Alert(Literal1, "'Excel表为空表,无数据!");
            return;
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][1] == null || dt.Rows[i][1].ToString().Trim() == "")
                continue;
            string sqlStr = "INSERT INTO Main_OverRunInfo"
                             + "([OI_LicencePlate]"
                             + ",[OI_Length]"
                            + " ,[OI_Width]"
                            + " ,[OI_Heigth]"
                            + " ,[OI_GoodsName]"
                            + " ,[OI_Weight]"
                            + " ,[OI_Path]"
                            + " ,[OI_CreateDate]"
                            + " ,[OI_PassDate]"
                            + " ,[OI_TransUnit]"
                            + " ,[OI_PassCode]"
                            + " ,[OI_Remark])"
                      + " VALUES("
                            + " '" + dt.Rows[i][1] + "'"
                            + " ,'" + dt.Rows[i][2] + "'"
                            + " ,'" + dt.Rows[i][3] + "'"
                            + " ,'" + dt.Rows[i][4] + "'"
                            + " ,'" + dt.Rows[i][5] + "'"
                            + " ,'" + dt.Rows[i][6] + "'"
                            + " ,'" + dt.Rows[i][7] + "'"
                            + " ,'" + dt.Rows[i][8] + "'"
                            + " ,'" + dt.Rows[i][9] + "'"
                            + " ,'" + dt.Rows[i][10] + "'"
                            + " ,'" + dt.Rows[i][11] + "'"
                            + " ,'" + dt.Rows[i][12] + "')";
            DBHelper.ExecuteCommand(sqlStr);
        }
        CommonFunction.AlertAndRedirect(Literal1, "导入完毕", "ChaoXianMgr.aspx");

    }
    public static System.Data.DataSet ExcelSqlConnection(string filepath, string tableName)
    {
        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
        OleDbConnection ExcelConn = new OleDbConnection(strCon);
        try
        {
            string strCom = string.Format("SELECT * FROM [Sheet1$]");
            ExcelConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, ExcelConn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "[" + tableName + "$]");
            ExcelConn.Close();
            return ds;
        }
        catch
        {
            ExcelConn.Close();
            return null;
        }
    }

}
