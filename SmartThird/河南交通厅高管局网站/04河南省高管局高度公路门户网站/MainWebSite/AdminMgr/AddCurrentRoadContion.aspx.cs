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

public partial class AdminMgr_AddCurrentRoadContion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            ViewState["strAction"] = Request.QueryString["action"];
            int tid = Convert.ToInt32(Request.QueryString["tid"]);
            ViewState["dtType"] = NewsInfoService.Get_TypeInfoByTypeId(tid);
            if (Request.QueryString["nid"] != null)
            {
                int nid = Convert.ToInt32(Request.QueryString["nid"]);
                ViewState["nid"] = nid;
                DataTable dt = NewsInfoService.Get_NewsInfo(nid);
                txtTime.Text = Convert.ToDateTime(dt.Rows[0]["N_Time"].ToString()).ToShortDateString();
                txtContent.Text = dt.Rows[0]["N_Content"].ToString();
                txtTitle.Text = dt.Rows[0]["N_Title"].ToString();
            }
            else
            {
                txtTime.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        NewsInfo news = new NewsInfo();
        news.N_Title = txtTitle.Text.Trim();
        news.N_From = "河南省高速公路路警联合指挥中心";
        news.N_Content = txtContent.Text;
        news.N_ImgPath = "";
        news.N_ImgView = "";
        news.N_HotIco = "";
        news.N_PicIco = "";
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
        if (Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]) == 80)
        {
            CommonFunction.AlertAndRedirect(Literal1, "操作成功", "CurrentRoadContion.aspx?tid=" + Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]));
        }
        else if (Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]) == 81)
        {
            CommonFunction.AlertAndRedirect(Literal1, "操作成功", "HistoryRoadCondition.aspx?tid=" + Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]));
        }
       
    }
}
