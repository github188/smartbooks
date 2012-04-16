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

public partial class AdminMgr_PicNewsMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            if (Request.QueryString["tid"] != null)
            {
                int tid = Convert.ToInt32(Request.QueryString["tid"]);
                ViewState["tid"] = tid;
                binddata(((UserInfo)Session["ServiceUser"]).U_SID, tid);
            }
        }
    }
    void binddata(int sid, int tid)
    {
        DataTable dt = ServiceNewService.GetNewsViewByType(sid, tid);
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
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["tid"]));
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            int nid = Convert.ToInt32(e.CommandArgument);
            ServiceNewService.Delete_News(nid);
            binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["tid"]));
        }
    }
}
