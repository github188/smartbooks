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

public partial class road_NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTitleAndMenu();
            BindData();
        }
    }
    /// <summary>
    /// 绑定标题和二级导航菜单
    /// </summary>
    protected void BindTitleAndMenu()
    {
        DataTable dt = NewsInfoService.Get_TypeInfoByTypeId(Convert.ToInt32(Request.QueryString["tid"]));
        if (dt != null)
        {
            ViewState["TName"] = dt.Rows[0]["T_Name"];
            ViewState["Remark"] = dt.Rows[0]["T_Remark"];
            this.Page.Title = ViewState["TName"] + "-" + ViewState["Remark"] + "-" + "河南省交通运输厅高速公路管理局门户网站";
            ViewState["tid"] = Request.QueryString["tid"].ToString();
        }
    }
    /// <summary>
    /// 绑定新闻列表
    /// </summary>
    protected void BindData()
    {
        DataTable dt = NewsInfoService.Get_NewsInfoViewList(Convert.ToInt32(Request.QueryString["tid"].ToString()));
        Paging.BindPageData(dt, Repeater_dwgl, AspNetPager1);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}
