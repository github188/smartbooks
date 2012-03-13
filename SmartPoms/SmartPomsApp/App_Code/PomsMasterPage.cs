namespace SmartPomsApp {
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;

    public class PomsMasterPage : System.Web.UI.Page {
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
}