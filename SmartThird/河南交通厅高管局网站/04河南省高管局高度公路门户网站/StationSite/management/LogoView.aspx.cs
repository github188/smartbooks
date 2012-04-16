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


public partial class management_LogoView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck("timeout.aspx");
            int TS_ID = Convert.ToInt32(Request.QueryString["tsid"]);
            TollStation station = TollStationService.Get_TollStationEntity(TS_ID);
            Image1.ImageUrl = "../Logo/" + station.TS_Logo ;
        }
    }
}
