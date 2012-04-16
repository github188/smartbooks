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

public partial class CheckToRoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["roadid"] != null)
            {
                int RoadId = Convert.ToInt32(Request.QueryString["roadid"]);
                RoadDepart depart = RoadDepartService.Get_RoadDepartEntity(RoadId);
                if (depart != null)
                {
                    Session["roadinfo"] = depart;
                    Session.Timeout = 600;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Redirect("RoadDepartList.aspx");
                }
            }
            else
            {
                Response.Redirect("RoadDepartList.aspx");
            }
        }
    }
}
