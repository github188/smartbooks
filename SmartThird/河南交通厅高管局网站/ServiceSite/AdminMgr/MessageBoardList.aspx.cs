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

public partial class AdminMgr_MessageBoardList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            UserInfo info = (UserInfo)Session["ServiceUser"];
           binddata(info.U_SID);
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        UserInfo info = (UserInfo)Session["ServiceUser"];
        if (e.CommandName == "delRecord")
        {
            int mid = Convert.ToInt32(e.CommandArgument);
            MessageBoardService.Delete_MessageBoard(mid);
            binddata(info.U_SID);
        }
        else if (e.CommandName == "updRecord")
        {
            int mid = Convert.ToInt32(e.CommandArgument);
            MessageBoardService.Update_MessageStatus(mid);
            binddata(info.U_SID);
        }
    }
    void binddata(int sid)
    {
        DataTable dt = MessageBoardService.Get_AllMessage(sid);
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
        UserInfo info = (UserInfo)Session["ServiceUser"];
        binddata(info.U_SID);
    }
}
