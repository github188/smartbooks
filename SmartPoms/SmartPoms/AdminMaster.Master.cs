
namespace SmartPoms {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class AdminMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            /*监测用户登录状态*/
            if (!Code.SessionBox.CheckUserSession()) {
                Response.Redirect("~/AdminLogin.aspx", true);
            } else {
                if (!IsPostBack) {

                }
            }
        }
    }
}