using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd {
    public partial class AdminTop : System.Web.UI.Page {
        //private Utility.UserSession userSession;

        protected void Page_Load(object sender, EventArgs e) {
            //if (!IsPostBack) {
            //    if (Session["user"] == null) {
            //        Response.Redirect("~/AdminLogin.aspx", true);
            //    }
            //}
        }
        //Login Out.
        //protected void linkBtnLoginOut_Click(object sender, EventArgs e) {
        //    //Remove current user session.
        //    Session["user"] = null;

        //    //Redirect 301 to Login Page.
        //    Response.Redirect("~/AdminLogin.aspx", true);
        //}
    }
}