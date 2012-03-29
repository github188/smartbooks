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

public partial class EventList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            int year = DateTime.Now.Year;
            ViewState["year"] = year;
            binddata(64,year);
            ViewState["dtType"] = NewsInfoService.Get_TypeInfoByTypeId(64);
        }
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "eventlist") {
            int year = Convert.ToInt32(e.CommandArgument);
            ViewState["year"] = year;
            binddata(64, year);
        }
    }
    void binddata(int tid,int year)
    {
        DataTable dt = NewsInfoService.Get_NewsInfoViewListByYear(tid, year);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptEventList.DataSource = ps;
            rptEventList.DataBind();
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(64, Convert.ToInt32(ViewState["year"]));
    }
}
