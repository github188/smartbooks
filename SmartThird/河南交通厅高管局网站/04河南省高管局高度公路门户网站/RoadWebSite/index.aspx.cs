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

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
          RoadDepart depart=(RoadDepart)Session["roadinfo"];
          this.Title = "网站首页-" + depart.RD_Name + "门户网站";

          DataTable dtLZFG = NewsInfoService.Get_NewsViewList(depart.RD_ID, 2, 7);
          rptLZFG.DataSource = dtLZFG;
          rptLZFG.DataBind();

          DataTable dtGZDT = NewsInfoService.Get_NewsViewList(depart.RD_ID, 1, 7);
          rptGZDT.DataSource = dtGZDT;
          rptGZDT.DataBind();

          DataTable dtDWRY = NewsInfoService.Get_NewsViewList(depart.RD_ID, 3, 0);
          rptRongYu.DataSource = dtDWRY;
          rptRongYu.DataBind();
        }
    }
}
