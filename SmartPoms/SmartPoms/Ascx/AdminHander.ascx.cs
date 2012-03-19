using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartPoms.Ascx {
    public partial class AdminHander : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnQuit_Click(object sender, EventArgs e) {
            SmartPoms.Code.SessionBox.RemoveUserSession();
            this.Response.Redirect("~/AdminLogin.aspx");
        }

        protected void btnGoHome_Click(object sender, EventArgs e) {
            this.Response.Redirect("~/Default.aspx");
        }

        protected void btnGoBack_Click(object sender, EventArgs e) {
            this.Response.Redirect(this.Request.UrlReferrer.ToString());
        }

        protected void btnGo_Click(object sender, EventArgs e) {

        }

        protected void btnRefresh_Click(object sender, EventArgs e) {

        }
    }
}