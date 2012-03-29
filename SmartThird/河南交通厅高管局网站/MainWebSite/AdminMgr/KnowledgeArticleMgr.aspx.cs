﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MainModel;
using MainService;
using PubClass;

public partial class AdminMgr_KnowledgeArticleMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            int kmid = Convert.ToInt32(Request.QueryString["kmid"]);
            DataTable dtModule = KnowledgeModuleService.Get_KnowledgeModuleInfo(kmid);
            ViewState["dtModule"] = dtModule;
            binddata(kmid);
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(Convert.ToInt32(((DataTable)ViewState["dtModule"]).Rows[0]["KM_ID"]));
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            int KAID = Convert.ToInt32(e.CommandArgument);
            KnowledgeArticleService.Delete_KnowledgeArticle(KAID);
            binddata(Convert.ToInt32(((DataTable)ViewState["dtModule"]).Rows[0]["KM_ID"]));
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
            GridView1.DataSource = ps;
            GridView1.DataBind();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddKnowledgeArticle.aspx?action=add&kmid=" + ((DataTable)ViewState["dtModule"]).Rows[0]["KM_ID"].ToString());
    }
}
