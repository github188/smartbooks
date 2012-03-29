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

public partial class WorkExpressList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            string startDate = DateTime.Now.Year + "-1-1";
            string endDate = (DateTime.Now.Year + 1) + "-1-1";
            ViewState["startDate"] = startDate;
            ViewState["endDate"] = endDate;
            binddata(1,startDate,endDate);
        }
    }
    protected void LinkButton3_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "menunav") {
            string strDate = e.CommandArgument.ToString();
            string startDate = (PubClass.Tool.Get_DateInQuarterByDate(strDate))[0];
            string endDate = (PubClass.Tool.Get_DateInQuarterByDate(strDate))[1];
            ViewState["startDate"] = startDate;
            ViewState["endDate"] = endDate;
            binddata(1, startDate, endDate);
        }
    }
    void binddata(int tid,string startDate,string endDate)
    {
        DataTable dt = NewsInfoService.Get_NewsInfoViewList(tid, startDate, endDate);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptWorkExpress.DataSource = ps;
            rptWorkExpress.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(1, ViewState["startDate"].ToString(), ViewState["endDate"].ToString());
    }
}
