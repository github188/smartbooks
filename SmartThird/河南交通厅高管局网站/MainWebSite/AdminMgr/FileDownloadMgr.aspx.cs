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
using MainModel;
using PubClass;
using MainService;

public partial class AdminMgr_FileDownloadMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            int ftid = Convert.ToInt32(Request.QueryString["ftid"]);
            ViewState["dtType"] = FileDownloadService.Get_FileTypeInfo(ftid);
            binddata(ftid);
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord") {
            int fd_Id = Convert.ToInt32(e.CommandArgument);
            FileDownloadService.Delete_FileDownload(fd_Id);
            binddata(Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["FT_ID"]));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddDownload.aspx?ftid=" + Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["FT_ID"]));
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(Convert.ToInt32(((DataTable)ViewState["dtType"]).Rows[0]["FT_ID"]));
    }
    void binddata(int ftid)
    {
        DataTable dt = FileDownloadService.Get_TopFileDownloadView(ftid, 0);
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
