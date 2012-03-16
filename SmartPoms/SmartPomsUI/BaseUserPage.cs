

namespace SmartPoms.UI {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Configuration;

    public class BaseUserPage : System.Web.UI.Page {
        public BaseUserPage() {
            ErrorPage = "~/AdminError.aspx";
        }

        public void ThrowException(BaseException ex) {
            Session["ERROR"] = ex;
            Response.Redirect(ErrorPage, true);
        }
    }
}