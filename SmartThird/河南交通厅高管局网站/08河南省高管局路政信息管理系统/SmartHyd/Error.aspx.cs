using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd {
    public partial class Error : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                try {
                    Exception ex = (Exception)Session["error"];
                    lblError.Text = ex.Message;
                } catch { }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e) {
            try {
                string refUrl = Session["referer"].ToString();
                if (!string.IsNullOrEmpty(refUrl)) {
                    Response.Redirect(refUrl);
                }
            } catch { }
        }
    }
}