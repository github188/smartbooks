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
using System.Drawing;
using Model;
using DataAccess;

public partial class AdminMgr_ServiceItemMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            if (Request.QueryString["pid"] != null) {
                int pid = Convert.ToInt32(Request.QueryString["pid"]);
                BindNavData(pid);
            }
            
        }
    }
    void BindNavData(int pid) {
        DataTable dt = ServiceModelService.Get_SonModelListByParent(pid);
        RepeaterNav.DataSource = dt;
        RepeaterNav.DataBind();
        if (dt != null && dt.Rows.Count > 0)
        {
            ViewState["mid"] = Convert.ToInt32(dt.Rows[0]["M_ID"]);
            binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["mid"]));
            lblSelectedModel.Text = dt.Rows[0]["M_Name"].ToString();
            linkAddTitle.NavigateUrl = "AddServiceItemNews.aspx?mid=" + Convert.ToInt32(ViewState["mid"]) + "&action=add";
        }
        else {
            linkAddTitle.Visible = false;
            lblSelectedModel.Visible = false;
        }
    }
    void binddata(int sid,int mid)
    {
        DataTable dt = ServiceItemService.Get_ServiceItemListByType(sid, mid);
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
    protected void RepeaterNav_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName!=null) {
            ViewState["mid"] = Convert.ToInt32(e.CommandArgument);
            binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["mid"]));
            lblSelectedModel.Text = e.CommandName.ToString();
            linkAddTitle.NavigateUrl = "AddServiceItemNews.aspx?mid=" + Convert.ToInt32(ViewState["mid"]) + "&action=add";
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["mid"]));
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            int iid = Convert.ToInt32(e.CommandArgument);
            ServiceItemService.Delete_ServiceItem(iid);
            binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["mid"]));
        }
    }
}
