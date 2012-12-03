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

public partial class AdminMgr_AddPicNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ViewState["strAction"] = Request.QueryString["action"].ToString();
            if (Request.QueryString["nid"] != null)
            {
                int nid = Convert.ToInt32(Request.QueryString["nid"]);
                ViewState["nid"] = nid;
                DataTable dt = ServiceNewService.Get_News(nid);
                txtTitle.Text = CommonFunction._GetMidInfo(dt.Rows[0]["N_Title"].ToString(), "(", ")");
                txtdate.Text = DateTime.Parse(dt.Rows[0]["N_Time"].ToString()).ToString("yyyy-MM-dd");
                ViewState["strContent"] = dt.Rows[0]["N_Content"].ToString();
                ViewState["VImgURL"] = CommonFunction._GetMidInfo(dt.Rows[0]["N_Title"].ToString(), "[", "]");
                ViewState["VVImgURL"] = CommonFunction._GetMidInfo(dt.Rows[0]["N_Title"].ToString(), "{", "}");
                ImgNews.ImageUrl = "../newsImages/" + CommonFunction._GetMidInfo(dt.Rows[0]["N_Title"].ToString(), "[", "]");
            }
        }
    }
    protected void btnSaveImage_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["strAction"].ToString() == "add" || FileUploadImg.HasFile)
        {
            string fileName = CommonFunction.Get_DynamicString() + FileUploadImg.FileName;
            string vfileName = "v_" + fileName;
            string vvfileName = "vv_" + fileName;
            string filePath = Server.MapPath("~/newsImages/" + fileName);
            string vfilePath = Server.MapPath("~/newsImages/" + vfileName);
            string vvfilePath = Server.MapPath("~/newsImages/" + vvfileName);
            if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadImg, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 150, 112, "W");
            ImgUploadFunction.MakeThumbnail(filePath, vvfilePath, 600, 480, "W");
            System.IO.File.Delete(filePath);
            ViewState["VImgURL"] = vfileName;
            ViewState["VVImgURL"] = vvfileName;

        }
        string strContent = Request.Form["t_contents"].ToString();
        string strTitle = "(" + txtTitle.Text + ")[" + ViewState["VImgURL"].ToString() + "]{" + ViewState["VVImgURL"].ToString() + "}";
        ServiceNews news = new ServiceNews();
        news.N_Title = strTitle;
        news.N_Content = strContent;
        news.N_From = "本站原创";
        news.N_SID = ((UserInfo)Session["ServiceUser"]).U_SID;
        news.N_NewsType = "6";
        news.N_Time = DateTime.Parse(txtdate.Text.Trim());
        if (ViewState["strAction"].ToString() == "update")
        {
            news.N_ID = Convert.ToInt32(ViewState["nid"]);
            ServiceNewService.Update_News(news);
        }
        else if (ViewState["strAction"].ToString() == "add")
        {
            ServiceNewService.Insert_News(news);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "blank.aspx");
    }
}
