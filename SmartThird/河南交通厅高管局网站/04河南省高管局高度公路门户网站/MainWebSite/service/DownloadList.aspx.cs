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

public partial class service_DownloadList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata();
    }
    void binddata()
    {
        DataTable dt = FileDownloadService.Get_TopFileDownloadView(2, 0);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptDownload.DataSource = ps;
            rptDownload.DataBind();
        }
    }
}
