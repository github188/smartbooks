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

public partial class AdminMgr_QuarterRank : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            binddata();
        }
    }
    private void binddata()
    {
        DataTable dt = ServiceInfoService.Get_AllServiceInfo();
        GridView1.DataSource = dt;
        GridView1.DataKeyNames = new string[] { "S_ID" };//主键
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        binddata();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        binddata();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int sId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        int rankId = Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text);
        ServiceInfoService.Update_QuarterRank(sId, rankId);
        GridView1.EditIndex = -1;
        binddata();
    }
}
