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

public partial class road_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Table = NewsInfoService.Get_NewsInfo(id);
            this.Panel_img.Visible = Property.HaveImg(id);
            BindTitleAndMenu(id);
        }
    }
    /// <summary>
    /// 绑定菜单栏和二级页面的导航菜单
    /// </summary>
    /// <param name="id"></param>
    protected void BindTitleAndMenu(int id)
    {
        DataTable dt = NewsInfoService.Get_NewsInfoView(Convert.ToInt32(Request.QueryString["id"]));
        if (dt != null)
        {
            ViewState["TName"] = dt.Rows[0]["T_Name"];
            ViewState["Remark"] = dt.Rows[0]["T_Remark"];
            this.Page.Title = Table.Rows[0]["N_Title"] + "-" + ViewState["TName"] + "-" + ViewState["Remark"] + "-" + "河南省交通运输厅高速公路管理局门户网站";
            int tid = Convert.ToInt32(dt.Rows[0]["N_TID"]);
            if (tid != 90 && tid != 91)
            {
                ViewState["Url"] = "NewsList.aspx?tid=" + tid;
            }
            else
            {
                ViewState["Url"] = "PicList.aspx?tid=" + tid;
            }
        }
    }
    private DataTable table;

    public DataTable Table
    {
        get { return table; }
        set { table = value; }
    }
}
