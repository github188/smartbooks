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
using System.Drawing;

public partial class GSKnowledge_ViewArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            rptModule.DataSource = KnowledgeModuleService.Get_KnowledgeModuleList();
            rptModule.DataBind();

            int kaid = Convert.ToInt32(Request.QueryString["kaid"]);
            DataTable dtArticle = KnowledgeArticleService.Get_KnowledgeArticleViewInfo(kaid);
            ViewState["dtArticle"] = dtArticle;
            int kmid = Convert.ToInt32(dtArticle.Rows[0]["KM_ID"]);
            foreach (RepeaterItem item in rptModule.Items)
            {
                LinkButton btn = (LinkButton)item.FindControl("btnModule");
                if (Convert.ToInt32(btn.CommandArgument) == kmid)
                {
                    btn.ForeColor = Color.Red;
                    btn.Font.Bold = true;
                }
                else
                {
                    btn.ForeColor = Color.Black;
                    btn.Font.Bold = false;
                }
            }
        }
    }
    protected void rptModule_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int kmid = Convert.ToInt32(e.CommandArgument);
        Response.Redirect("ModuleList.aspx?kmid="+kmid);
    }
}
