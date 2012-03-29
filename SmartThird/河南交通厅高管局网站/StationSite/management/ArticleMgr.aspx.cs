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
using StationModel;

public partial class management_ArticleMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck("timeout.aspx");
            ViewState["dtType"] = DBHelper.GetDataSet("select * from S_NewsType where T_ID='"+Request.QueryString["tid"].ToString()+"'");
            binddata();
        }
    }
    void binddata()
    {
        string sqlStr = "select * from S_NewsView where T_ID='" + ((DataTable)ViewState["dtType"]).Rows[0]["T_ID"].ToString()+ "' and N_TSID='"+((UserInfo)Session["StationUser"]).U_TollStation.TS_ID+"' order by N_Date desc,N_ID desc";
        DataTable dt = DBHelper.GetDataSet(sqlStr);
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
        binddata();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            string strNID = e.CommandArgument.ToString();
            DBHelper.ExecuteCommand("delete from S_NewsInfo where N_ID='"+strNID+"'");
            binddata();
        }
    }
}
