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
using RoadEntity;
using RoadService;

public partial class management_UserMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            ViewState["sqlStr"] = "select * from R_RoadUserView";
            binddata();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sqlStr = "select * from R_RoadUserView where 1=1 ";
        if (txtName.Text.Trim() != "")
        {
            sqlStr += " and RD_Name like '%" + txtName.Text.Trim() + "%'";
        }
        ViewState["sqlStr"] = sqlStr;
        binddata();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            string U_ID = e.CommandArgument.ToString();
            string sqlStr = "delete from R_UserInfo where U_ID='" + U_ID + "'";
            DBHelper.ExecuteCommand(sqlStr);
            binddata();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata();
    }
    void binddata()
    {
        string sqlStr = ViewState["sqlStr"].ToString();
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
}
