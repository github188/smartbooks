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

public partial class SiteNoticeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isSelectedService();
            int tid = Convert.ToInt32(Request.QueryString["tid"]);
            ViewState["tid"] = tid;
            ViewState["typeName"] = DBHelper.GetStringScalar("select TypeName from  T_ServiceNewsType where TypeID=" + tid);
            this.Title = ViewState["typeName"].ToString() + "-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
            binddata(((ServiceInfo)Session["serviceinfo"]).S_ID, tid);
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(((ServiceInfo)Session["serviceinfo"]).S_ID, Convert.ToInt32(ViewState["tid"]));
    }
    void binddata(int sid, int tid)
    {
        DataTable dt = ServiceNewService.Get_AllNews(sid, 0, tid);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptSiteNoticeList.DataSource = ps;
            rptSiteNoticeList.DataBind();
        }
    }
}
