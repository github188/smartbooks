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

public partial class management_loginout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            string strAction = Request.QueryString["action"].ToString();
            Session["RoadUser"] = null;
            if (strAction == "login") {
                Response.Redirect("login.aspx");
            }
            else if (strAction == "index") {
                Response.Redirect("../RoadDepartList.aspx");
            }
        }
    }
}
