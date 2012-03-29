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
using MainModel;
using PubClass;
using MainService;


public partial class AdminMgr_AddDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            txtTime.Text = DateTime.Now.ToShortDateString();
            int ftid = Convert.ToInt32(Request.QueryString["ftid"]);
            ViewState["dtType"] = FileDownloadService.Get_FileTypeInfo(ftid);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (!FileUpload1.HasFile) {
            CommonFunction.Alert(Literal1, "请选择要上传的文件");
            return;
        }
        string fileName = CommonFunction.Get_DynamicString() + FileUpload1.FileName;
        string filePath = Server.MapPath("~/DownLoad/"+fileName);
        int fileSzie = Convert.ToInt32(FileUpload1.PostedFile.ContentLength / 1024);
        FileUpload1.PostedFile.SaveAs(filePath);
        FileDownload download = new FileDownload();
        download.FD_Title = txtTitle.Text;
        download.FD_FTID = Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["FT_ID"]);
        download.FD_Path = fileName;
        download.FD_Size = fileSzie+"KB";
        download.FD_CreateDate = txtTime.Text;
        FileDownloadService.Insert_FileDownload(download);
        CommonFunction.AlertAndRedirect(Literal1, "上传成功", "FileDownloadMgr.aspx?ftid=" + Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["FT_ID"]));
        
    }
}
