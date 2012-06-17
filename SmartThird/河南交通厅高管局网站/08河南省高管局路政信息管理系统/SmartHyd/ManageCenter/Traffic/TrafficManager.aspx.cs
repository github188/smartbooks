using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Traffic {
    public partial class TrafficManager : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            litmsg.Visible = true;
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {

        }
    }
}