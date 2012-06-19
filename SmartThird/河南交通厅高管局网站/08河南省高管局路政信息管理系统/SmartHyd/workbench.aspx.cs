using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd {
    public partial class workbench : System.Web.UI.Page {
        private Utility.UserSession userSession;
        protected void Page_Load(object sender, EventArgs e) {
            userSession = (Utility.UserSession)Session["user"];
            if (!IsPostBack)
            {
                this.Label1.Text = userSession.USERNAME;
                this.LabTime.Text = DateTime.Now.ToString();
            }
        }
    }
}