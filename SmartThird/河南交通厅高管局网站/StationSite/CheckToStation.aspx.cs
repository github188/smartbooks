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

public partial class CheckToStation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["stationid"] != null)
            {
                int StationId = Convert.ToInt32(Request.QueryString["stationid"]);
                TollStation station = TollStationService.Get_TollStationEntity(StationId);
                if (station != null)
                {
                    Session["stationinfo"] = station;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Redirect("StationList.aspx");
                }
            }
            else
            {
                Response.Redirect("StationList.aspx");
            }
        }
    }
}
