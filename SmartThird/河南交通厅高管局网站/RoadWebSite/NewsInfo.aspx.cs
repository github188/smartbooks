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
using RoadService;
using PubClass;
using RoadEntity;

public partial class NewsInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            DataTable dtNews = NewsInfoService.Get_NewsView(Convert.ToInt32(Request.QueryString["nid"]));
            ViewState["dtNews"] = dtNews;
            RoadDepart depart=(RoadDepart)Session["roadinfo"];
            this.Title=dtNews.Rows[0]["N_Title"].ToString()+"-"+dtNews.Rows[0]["T_Name"].ToString()+"-"+depart.RD_Name+"门户网站";
        }
    }
}
