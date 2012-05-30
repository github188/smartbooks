using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd {
    public partial class AdminTop : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["user"] == null) {
                    Response.Redirect("~/AdminLogin.aspx", true);
                }
            }
        }
    }
}