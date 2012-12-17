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
using Model;
using DataAccess;

public partial class AdminMgr_AddCertificate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
        }
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
            string fileName = fileName = CommonFunction.Get_DynamicString() + FileUploadImg.FileName;
            string vfileName = "v_" + fileName;
            string vvfileName = "vv_" + fileName;
            string file_Path = Server.MapPath("~/CertificateImg/" + fileName);
            string vfile_Path = Server.MapPath("~/CertificateImg/" + vfileName);
            string vvfile_Path = Server.MapPath("~/CertificateImg/" + vvfileName);
            if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadImg, Literal1, file_Path, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ImgUploadFunction.MakeThumbnail(file_Path, vfile_Path, 120, 90, "W");
            ImgUploadFunction.MakeThumbnail(file_Path, vvfile_Path, 600, 450, "W");
            System.IO.File.Delete(file_Path);

            ServiceNews news = new ServiceNews();
            news.N_Title ="["+vfileName+"]{"+vvfileName+"}";
            news.N_Content = txtRemark.Text;
            news.N_SID = ((UserInfo)Session["ServiceUser"]).U_SID;
            news.N_Time = DateTime.Now;
            news.N_NewsType = "9";
            news.N_From = "本站原创";
            ServiceNewService.Insert_News(news);
            CommonFunction.AlertAndRedirect(Literal1, "操作成功", "CertificateMgr.aspx");
    }
}
