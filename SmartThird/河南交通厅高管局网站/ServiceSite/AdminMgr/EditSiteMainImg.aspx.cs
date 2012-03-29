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

public partial class AdminMgr_EditSiteMainImg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            int sid = Convert.ToInt32(Request.QueryString["sid"]);
            ServiceInfo info = ServiceInfoService.Get_ServiceInfo(sid);
            SiteImg.ImageUrl = "../ServiceImg/+" + info.S_HeaderImg;
            ViewState["SID"] = sid;
        }
    }
    protected void btnSaveImage_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUploadImg.HasFile)
        {
            string fileName = CommonFunction.Get_DynamicString() + FileUploadImg.FileName;
            string filePath = Server.MapPath("~/ServiceImg/" + fileName);
            if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadImg, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
           int result= ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["SID"]), "S_HeaderImg", fileName);
            CommonFunction.AlertAndRedirect(Literal1, "操作成功", "SiteMainImg.aspx");
        }
       
       
    }
}
