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
using PubClass;
using MainModel;
using MainService;

public partial class AdminMgr_AddImageNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            ViewState["ImgPath"] = "";
            ViewState["ImgView"] = "";
            ViewState["strAction"] = Request.QueryString["action"];
            int tid = Convert.ToInt32(Request.QueryString["tid"]);
            ViewState["dtType"] = NewsInfoService.Get_TypeInfoByTypeId(tid);
            if (Request.QueryString["nid"] != null)
            {
                int nid = Convert.ToInt32(Request.QueryString["nid"]);
                ViewState["nid"] = nid;
                DataTable dt = NewsInfoService.Get_NewsInfo(nid);
                txtTitle.Text = dt.Rows[0]["N_Title"].ToString();
                txtFrom.Text = dt.Rows[0]["N_From"].ToString();
                txtTime.Text = Convert.ToDateTime(dt.Rows[0]["N_Time"].ToString()).ToShortDateString();
                ViewState["strContent"] = dt.Rows[0]["N_Content"].ToString();
                ViewState["ImgPath"] = dt.Rows[0]["N_ImgPath"].ToString();
                ViewState["ImgView"] = dt.Rows[0]["N_ImgView"].ToString();
            }
            else
            {
                txtTime.Text = DateTime.Now.ToShortDateString();
                txtFrom.Text = "本站原创";
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strContent=Request.Form["t_contents"].ToString();
        if(ViewState["strAction"].ToString() == "add"&&(!FUploadImg.HasFile||!FUploadView.HasFile)){
          CommonFunction.Alert(Literal1,"请上传缩略图和图片！");
            return;
        }
        string fileName=CommonFunction.Get_DynamicString()+FUploadImg.FileName;
        string vfileName=CommonFunction.Get_DynamicString()+FUploadView.FileName;
        string filePath=Server.MapPath("~/newsimages/" + fileName);
        string vfilePath=Server.MapPath("~/newsimages/" + vfileName);
        if(FUploadImg.HasFile){
            if (!CommonFunction.Is_FileUploadSuccessfully(FUploadImg, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ViewState["ImgPath"] =fileName;
        }
        if(FUploadView.HasFile){
            if (!CommonFunction.Is_FileUploadSuccessfully(FUploadView, Literal1, vfilePath, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ViewState["ImgView"]=vfileName;
        }
        NewsInfo news = new NewsInfo();
        news.N_Title = txtTitle.Text;
        news.N_From = txtFrom.Text;
        news.N_Content = PubClass.Tool.CheckStr(strContent);
        news.N_ImgPath = ViewState["ImgPath"].ToString();
        news.N_ImgView = ViewState["ImgView"].ToString();
        news.N_HotIco = "";
        news.N_PicIco = "图片新闻";
        news.N_Time = txtTime.Text;
        news.N_TID = Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]);
        if (ViewState["strAction"].ToString() == "update")
        {
            news.N_ID = Convert.ToInt32(ViewState["nid"]);
            NewsInfoService.Update_NewsInfoWithTime(news);
        }
        else if (ViewState["strAction"].ToString() == "add")
        {
            NewsInfoService.Insert_NewsInfoWithTime(news);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "ImgageNewsMgr.aspx?tid=" + Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]));
    }
}
