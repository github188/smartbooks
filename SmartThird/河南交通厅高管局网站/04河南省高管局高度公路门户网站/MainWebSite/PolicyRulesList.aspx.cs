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

public partial class PolicyRulesList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            int tid = Convert.ToInt32(Request.QueryString["tid"]);
            ViewState["dtType"] = NewsInfoService.Get_TypeInfoByTypeId(tid);
            ViewState["tid"] = tid;
            binddata(tid);
        }
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "rulenav") {
            int tid = Convert.ToInt32(e.CommandArgument);
            ViewState["dtType"] = NewsInfoService.Get_TypeInfoByTypeId(tid);
            ViewState["tid"] = tid;
            binddata(tid);
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(Convert.ToInt32(ViewState["tid"]));
    }
    void binddata(int tid)
    {
        DataTable dt = NewsInfoService.Get_NewsInfoViewList(tid);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptzcfg.DataSource = ps;
            rptzcfg.DataBind();
        }
    }
}
