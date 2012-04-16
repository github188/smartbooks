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
using RoadEntity;
using RoadService;
using PubClass;

public partial class management_LogoView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int RD_ID = Convert.ToInt32(Request.QueryString["rdid"]);
            RoadDepart depart = RoadDepartService.Get_RoadDepartEntity(RD_ID);
            Image1.ImageUrl = "../Logo/" + depart.RD_Logo;
        }
    }
}
