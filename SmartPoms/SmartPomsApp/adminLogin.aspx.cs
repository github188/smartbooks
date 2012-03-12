using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartPomsApp {
    public partial class adminLogin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void imgBtnReset_Click(object sender, ImageClickEventArgs e) {
            this.txtUserName.Text = string.Empty;
            this.txtUserPwd.Text = string.Empty;
            this.txtCaptche.Text = string.Empty;
        }

        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e) {

        }
    }
}