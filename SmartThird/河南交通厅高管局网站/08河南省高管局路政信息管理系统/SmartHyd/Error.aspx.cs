using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd {
    public partial class Error : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void btnBack_Click(object sender, EventArgs e) {
            //Response.Redirect(Session["referer"].ToString());
        }
    }
}