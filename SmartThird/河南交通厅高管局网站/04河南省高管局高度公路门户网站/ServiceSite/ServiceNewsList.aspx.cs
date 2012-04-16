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

public partial class ServiceNewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isSelectedService();
            this.Title = "驿站新闻-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
            binddata(((ServiceInfo)Session["serviceinfo"]).S_ID);
        }
    }
    void binddata(int sid)
    {
        DataTable dt = DBHelper.GetDataSet("select * from V_ServiceNewsInfo where N_SID='" +sid+ "' and N_NewsType in (1,6) order by N_Time desc");
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptNewsList.DataSource = ps;
            rptNewsList.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(((ServiceInfo)Session["serviceinfo"]).S_ID);
    }
}
