using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartPoms.Ascx {
    public partial class AdminError : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                UI.BaseException ex = (UI.BaseException)Session["ERROR"];
                if (ex != null) {
                    this.panelError.GroupingText = ex.ErrorTitle;
                    this.lblErrorMessage.Text = ex.ErrorContent;
                }
            }
        }

        protected void btnGoHome_Click(object sender, EventArgs e) {
            Response.Redirect("~/Default.aspx", true);
        }
    }
}