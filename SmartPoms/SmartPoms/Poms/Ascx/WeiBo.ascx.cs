using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartPoms.Poms.Ascx {
    public partial class WeiBo : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {

        }

        private void BindDataSource() {
            
        }
        protected void dgvResult_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.dgvResult.PageIndex = e.NewPageIndex;
        }
    }
}