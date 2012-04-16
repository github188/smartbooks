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


public partial class RoadConditionDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int nid = Convert.ToInt32(Request.QueryString["nid"]);
            DataTable dtNews = NewsInfoService.Get_NewsInfoView(nid);
            ViewState["dtNews"] = dtNews;
        }
    }
}
