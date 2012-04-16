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

public partial class AdminMgr_AddNewsPaper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            ViewState["strAction"] = Request.QueryString["action"];
            ViewState["strAImg"] = "";
            ViewState["strAImgView"] = "";
            ViewState["strBImg"] = "";
            ViewState["strBImgView"] = "";
            ViewState["strCImg"] = "";
            ViewState["strCImgView"] = "";
            ViewState["strDImg"] = "";
            ViewState["strDImgView"] = "";
            if (Request.QueryString["nid"] != null)
            {
                int nid = Convert.ToInt32(Request.QueryString["nid"]);
                ViewState["nid"] = nid;
                NewsPaper paper = NewsPaperService.Get_NewsPaperModel(nid);
                txtTitle.Text = paper.N_Title;
                txtTime.Text = Convert.ToDateTime(paper.N_Time).ToShortDateString();
                ImgA.ImageUrl = "../newspaper/" + paper.N_AImgView;
                ImgB.ImageUrl = "../newspaper/" + paper.N_BImgView;
                ImgC.ImageUrl = "../newspaper/" + paper.N_CImgView;
                ImgD.ImageUrl = "../newspaper/" + paper.N_DImgView;
                ViewState["strAImg"] = paper.N_AImg;
                ViewState["strAImgView"] = paper.N_AImgView;
                ViewState["strBImg"] = paper.N_BImg;
                ViewState["strBImgView"] = paper.N_BImgView;
                ViewState["strCImg"] = paper.N_CImg;
                ViewState["strCImgView"] = paper.N_CImgView;
                ViewState["strDImg"] = paper.N_DImg;
                ViewState["strDImgView"] = paper.N_DImgView;
            }
            else
            {
                txtTime.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUploadImgA.HasFile)
        {
            string fileName = CommonFunction.Get_DynamicString() + FileUploadImgA.FileName;
            string vfileName = "v_" + fileName;
            string file_Path = Server.MapPath("~/newspaper/" + fileName);
            string vfile_Path = Server.MapPath("~/newspaper/" + vfileName);
            if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadImgA, Literal1, file_Path, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ImgUploadFunction.MakeThumbnail(file_Path, vfile_Path, 152, 225, "HW");
            ViewState["strAImg"] = fileName;
            ViewState["strAImgView"] = vfileName;
        }
        if (FileUploadImgB.HasFile)
        {
            string fileName = CommonFunction.Get_DynamicString() + FileUploadImgB.FileName;
            string vfileName = "v_" + fileName;
            string file_Path = Server.MapPath("~/newspaper/" + fileName);
            string vfile_Path = Server.MapPath("~/newspaper/" + vfileName);
            if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadImgB, Literal1, file_Path, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ImgUploadFunction.MakeThumbnail(file_Path, vfile_Path, 152, 225, "HW");
            ViewState["strBImg"] = fileName;
            ViewState["strBImgView"] = vfileName;
        }
        if (FileUploadImgC.HasFile)
        {
            string fileName = CommonFunction.Get_DynamicString() + FileUploadImgC.FileName;
            string vfileName = "v_" + fileName;
            string file_Path = Server.MapPath("~/newspaper/" + fileName);
            string vfile_Path = Server.MapPath("~/newspaper/" + vfileName);
            if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadImgC, Literal1, file_Path, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ImgUploadFunction.MakeThumbnail(file_Path, vfile_Path, 152, 225, "HW");
            ViewState["strCImg"] = fileName;
            ViewState["strCImgView"] = vfileName;
        }
        if (FileUploadImgD.HasFile)
        {
            string fileName = CommonFunction.Get_DynamicString() + FileUploadImgD.FileName;
            string vfileName = "v_" + fileName;
            string file_Path = Server.MapPath("~/newspaper/" + fileName);
            string vfile_Path = Server.MapPath("~/newspaper/" + vfileName);
            if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadImgD, Literal1, file_Path, new string[] { ".gif", ".jpg", ".jpeg" }))
                return;
            ImgUploadFunction.MakeThumbnail(file_Path, vfile_Path, 152, 225, "HW");
            ViewState["strDImg"] = fileName;
            ViewState["strDImgView"] = vfileName;
        }
        NewsPaper paper = new NewsPaper();
        paper.N_Title = txtTitle.Text;
        paper.N_Time = txtTime.Text;
        paper.N_AImg = ViewState["strAImg"].ToString();
        paper.N_AImgView = ViewState["strAImgView"].ToString();
        paper.N_BImg=ViewState["strBImg"].ToString();
        paper.N_BImgView=ViewState["strBImgView"].ToString();
        paper.N_CImg=ViewState["strCImg"].ToString();
        paper.N_CImgView=ViewState["strCImgView"].ToString();
        paper.N_DImg=ViewState["strDImg"].ToString();
        paper.N_DImgView=ViewState["strDImgView"].ToString();
        if (ViewState["strAction"].ToString() == "update")
        {
            paper.N_ID = Convert.ToInt32(ViewState["nid"]);
            NewsPaperService.Update_NewsPaper(paper);
        }
        else if (ViewState["strAction"].ToString() == "add")
        {
            NewsPaperService.Insert_NewsPaper(paper);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "NewsPaperMgr.aspx");
    }
}
