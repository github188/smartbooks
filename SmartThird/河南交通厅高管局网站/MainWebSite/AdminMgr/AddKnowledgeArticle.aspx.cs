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
using MainService;
using MainModel;
using PubClass;

public partial class AdminMgr_AddKnowledgeArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            ViewState["action"] = Request.QueryString["action"].ToString();
            int kmid = Convert.ToInt32(Request.QueryString["kmid"]);
            ViewState["dtModule"] = KnowledgeModuleService.Get_KnowledgeModuleInfo(kmid);
            if (Request.QueryString["kaid"] != null)
            {
                int kaid = Convert.ToInt32(Request.QueryString["kaid"]);
                DataTable dt = KnowledgeArticleService.Get_KnowledgeArticleViewInfo(kaid);
                ViewState["kaid"] = kaid;
                txtTitle.Text = dt.Rows[0]["KA_Title"].ToString();
                txtTime.Text = Convert.ToDateTime(dt.Rows[0]["KA_CreateDate"].ToString()).ToShortDateString();
                ViewState["strContent"] = dt.Rows[0]["KA_Content"].ToString();
            }
            else {
                txtTime.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        KnowledgeArticle article = new KnowledgeArticle();
        article.KA_Title = txtTitle.Text.Trim();
        article.KA_CreateDate = txtTime.Text;
        article.KA_KMID = Convert.ToInt32(((DataTable)ViewState["dtModule"]).Rows[0]["KM_ID"]);
        article.KA_Content=Request.Form["t_contents"].ToString();
        if (ViewState["action"].ToString() == "add") {
            KnowledgeArticleService.Insert_KnowledgeArticle(article);
        }
        else if (ViewState["action"].ToString()=="update")
        {
            article.KA_ID = Convert.ToInt32(ViewState["kaid"]);
            KnowledgeArticleService.Update_KnowledgeArticle(article);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "KnowledgeArticleMgr.aspx?kmid=" + Convert.ToInt32(((DataTable)ViewState["dtModule"]).Rows[0]["KM_ID"]));
    }
}
