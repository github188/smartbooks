using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class adminBack : System.Web.UI.MasterPage {
    protected void Page_Load(object sender, EventArgs e) {
        if (!VerificationLoginUser()) {
            Response.Redirect("~/adminLogin.aspx");
        }
    }

    private bool VerificationLoginUser() {
        try {
            string username = Session["username"].ToString();
            if (string.IsNullOrEmpty(username)) {
                return false;
            }
        } catch {
            return false;
        }
        return true;
    }
}
