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

public partial class GSKnowledge_ModuleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            rptModule.DataSource = KnowledgeModuleService.Get_KnowledgeModuleList();
            rptModule.DataBind();

            int kmid = Convert.ToInt32(Request.QueryString["kmid"]);
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
            DataTable dtModule = KnowledgeModuleService.Get_KnowledgeModuleInfo(kmid);
            lblModule.Text = PubClass.Tool.SubString(dtModule.Rows[0]["KM_Name"].ToString(), 25) ;
            ViewState["kmid"] = kmid;
            binddata(kmid); 
        }
    }
    void binddata(int kmid)
    {
        DataTable dt = KnowledgeArticleService.Get_KnowledgeArticleViewList(kmid);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptArticle.DataSource = ps;
            rptArticle.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(Convert.ToInt32(ViewState["kmid"]));
    }
    protected void rptModule_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
          int kmid = Convert.ToInt32(e.CommandArgument);
          lblModule.Text = PubClass.Tool.SubString(e.CommandName, 25);
          ViewState["kmid"] = kmid;
          binddata(kmid);
          foreach(RepeaterItem item in rptModule.Items){
               LinkButton btn = (LinkButton)item.FindControl("btnModule");
               if(Convert.ToInt32(btn.CommandArgument)==kmid){
                   btn.ForeColor = Color.Red;
                   btn.Font.Bold = true;
               }else{
                   btn.ForeColor = Color.Black;
                   btn.Font.Bold = false;
               }
           }
    }
}
