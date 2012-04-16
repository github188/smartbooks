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
using MainModel;
using MainService;

public partial class report_menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            if (Session["reportuser"] == null) {
                Response.Redirect("login.aspx");
            }

            rptReportList.DataSource = NewsInfoService.Get_NewsInfoViewList(6);
            rptReportList.DataBind();
        }
    }
}
