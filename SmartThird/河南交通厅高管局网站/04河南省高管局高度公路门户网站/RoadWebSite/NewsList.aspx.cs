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

public partial class NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            DataTable dtType = DBHelper.GetDataSet("select T_ID,T_Name from R_NewsType where T_ID='"+Request.QueryString["tid"].ToString()+"'");
            ViewState["tid"] = Request.QueryString["tid"].ToString();
            RoadDepart depart = (RoadDepart)Session["roadinfo"];
            this.Title = dtType.Rows[0]["T_Name"].ToString() + "-" + depart.RD_Name + "门户网站";
            lblNewsType.Text = dtType.Rows[0]["T_Name"].ToString();
            binddata();
        }
    }
    void binddata()
    {
        DataTable dt = NewsInfoService.Get_NewsViewList(((RoadDepart)Session["roadinfo"]).RD_ID, Convert.ToInt32(ViewState["tid"]), 0);
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
        binddata();
    }
}
