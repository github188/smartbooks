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
using Wuqi.Webdiyer;

public partial class road_PicList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTitleAndMenu();
            Bind();
        }
    }
    /// <summary>
    /// 绑定菜单栏和二级页面的导航菜单
    /// </summary>
    /// <param name="id"></param>
    protected void BindTitleAndMenu()
    {
        DataTable dt = NewsInfoService.Get_TypeInfoByTypeId(Convert.ToInt32(Request.QueryString["tid"]));
        if (dt != null)
        {
            ViewState["TName"] = dt.Rows[0]["T_Name"];
            ViewState["Remark"] = dt.Rows[0]["T_Remark"];
            ViewState["tid"] = Request.QueryString["tid"].ToString();
            this.Page.Title = ViewState["TName"] +"-"+ ViewState["Remark"] + "-" + "河南省交通运输厅高速公路管理局门户网站";
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    protected void Bind()
    {
        DataTable dt = NewsInfoService.Get_NewsInfoViewList(Convert.ToInt32(Request.QueryString["tid"].ToString()));
        Paging.BindPageData(dt, Repeater_Pic, AspNetPager1);
    }
}
