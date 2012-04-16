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
using DataAccess;
using Model;

public partial class ServiceItemList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isSelectedService();
            Title = "服务内容-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
            int mid = 1;
            if (Request.QueryString["mid"] != null)
               mid = Convert.ToInt32(Request.QueryString["mid"]);
           ViewState["mid"] = mid;
           ViewState["itemName"] = ServiceModelService.Get_ServiceItemName(mid);
           binddata(((ServiceInfo)Session["serviceinfo"]).S_ID,mid);
        }
    }
    protected void ServiceItem_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "serviceitem")
        {
            int mid = Convert.ToInt32(e.CommandArgument);
            ViewState["mid"] = mid;
            ViewState["itemName"] = ServiceModelService.Get_ServiceItemName(mid);
            binddata(((ServiceInfo)Session["serviceinfo"]).S_ID, mid);
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(((ServiceInfo)Session["serviceinfo"]).S_ID, Convert.ToInt32(ViewState["mid"]));
    }
    void binddata(int sid, int mid)
    {
        DataTable dt = ServiceItemService.Get_ServiceItemListByParentItem(sid, mid);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptServiceItem.DataSource = ps;
            rptServiceItem.DataBind();
        }
    }
}
