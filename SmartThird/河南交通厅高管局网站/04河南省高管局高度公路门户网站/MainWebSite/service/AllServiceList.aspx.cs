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

public partial class service_AllServiceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            DataTable dt = DBHelper.GetDataSet("select * from T_ServiceInfo order by S_QuarterRank asc,S_Star desc");
            rptServices.DataSource = dt;
            rptServices.DataBind();
        }
    }
}
