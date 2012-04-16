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
using StationModel;
using StationService;
using PubClass;

public partial class StarInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int nid = Convert.ToInt32(Request.QueryString["nid"]);
            TollStation station = (TollStation)Session["stationinfo"];
            DataTable dtNews = NewsInfoService.Get_NewsView(nid);
            ViewState["dtNews"] = dtNews;
            this.Title = dtNews.Rows[0]["N_Title"].ToString() + "-" + dtNews.Rows[0]["T_Name"].ToString() + "-" + station.TS_Name + "门户网站";
        }
    }
}
