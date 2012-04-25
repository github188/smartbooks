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

public partial class AdminMgr_AddServiceNewsInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
           int tid = Convert.ToInt32(Request.QueryString["tid"]);
           int nid = Convert.ToInt32(Request.QueryString["nid"]);
           string strAction = Request.QueryString["action"];
           ViewState["tid"] = tid;
           ViewState["nid"] = nid;
           ViewState["strAction"] = strAction;
            if (strAction == "update")
            {
                DataTable dt = ServiceNewService.Get_News(nid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtTitle.Text = dt.Rows[0]["N_Title"].ToString();
                    txtForm.Text = dt.Rows[0]["N_Frorm"].ToString();
                    ViewState["strContent"] = dt.Rows[0]["N_Content"].ToString();
                }
            }
            else {
                txtForm.Text = "本站原创";
            }

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string  strContent = Request.Form["t_contents"].ToString();
        if (strContent == "")
        {
            CommonFunction.Alert(Literal1, "文章内容不能为空");
            return;
        }
        ServiceNews news = new ServiceNews();
        news.N_Title = txtTitle.Text;
        news.N_Content= strContent;
        news.N_SID = ((UserInfo)Session["ServiceUser"]).U_SID;
        news.N_NewsType = ViewState["tid"].ToString();
        news.N_From = txtForm.Text;
        if (ViewState["strAction"].ToString()== "add")
        {
            ServiceNewService.Insert_News(news);
        }
        else if (ViewState["strAction"].ToString()== "update")
        {
            news.N_ID = Convert.ToInt32(ViewState["nid"]);
            ServiceNewService.Update_News(news);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "blank.aspx");
    }
}
