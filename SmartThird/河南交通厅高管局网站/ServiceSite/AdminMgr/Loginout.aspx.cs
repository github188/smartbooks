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

public partial class AdminMgr_Loginout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ServiceUser"] = null;
        Response.Write("<script>location.href='Login.aspx';</script>");
    }
}
