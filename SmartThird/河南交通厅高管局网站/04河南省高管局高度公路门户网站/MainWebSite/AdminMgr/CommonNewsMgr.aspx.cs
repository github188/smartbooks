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

public partial class AdminMgr_CommonNewsMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            int tid = Convert.ToInt32(Request.QueryString["tid"]);
            ViewState["dtType"] = NewsInfoService.Get_TypeInfoByTypeId(tid);
            binddata(tid);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddCommonNewsInfo.aspx?action=add&tid=" + Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]));
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            int nid = Convert.ToInt32(e.CommandArgument);
            NewsInfoService.Delete_NewsInfo(nid);
            binddata(Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]));
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["T_ID"]));
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
            GridView1.DataSource = ps;
            GridView1.DataBind();
        }
    }
}
