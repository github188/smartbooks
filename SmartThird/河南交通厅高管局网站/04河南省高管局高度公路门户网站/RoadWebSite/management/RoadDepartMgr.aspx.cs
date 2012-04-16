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

public partial class management_RoadDepartMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            bindcitydata();
            string sqlStr = "select * from R_RoadDepartView";
            ViewState["sqlStr"] = sqlStr;
            binddata();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sqlStr = "select * from R_RoadDepartView where 1=1 ";
        if (txtName.Text.Trim().Length > 0)
        {
            sqlStr += " and RD_Name like '%" + txtName.Text.Trim() + "%'";
        }
        if (ddlCity.SelectedValue != "0")
        {
            sqlStr += " and RD_City='" + ddlCity.SelectedValue + "'";
        }
        ViewState["sqlStr"] = sqlStr;
        binddata();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            string RD_ID = e.CommandArgument.ToString();
            string sqlStr = "delete from R_RoadDepart where RD_ID='"+RD_ID+"' delete from R_UserInfo where U_RoadID='"+RD_ID+"' and U_RoadID>0 and U_IsSuper=0";
            DBHelper.ExecuteCommand(sqlStr);
            binddata();
        }
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
    private void bindcitydata()
    {
        ddlCity.Items.Clear();
        ListItem item1 = new ListItem("<---全部--->", "0");
        ddlCity.Items.Add(item1);
        string sqlStr = "select * from S_CityInfo";
        DataTable dt = DBHelper.GetDataSet(sqlStr);
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item2 = new ListItem(dt.Rows[i]["CI_Name"].ToString(), dt.Rows[i]["CI_ID"].ToString());
                ddlCity.Items.Add(item2);
            }
        }
    }
}
