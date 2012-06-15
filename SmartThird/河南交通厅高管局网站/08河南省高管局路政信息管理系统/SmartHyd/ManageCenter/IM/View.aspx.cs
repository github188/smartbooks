using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.IM {
    public partial class View : System.Web.UI.Page {
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();

        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["id"] != null) {
                Entity.BASE_MESSAGE m = new Entity.BASE_MESSAGE();
                m = bll.GetEntity(Convert.ToInt32(Request.QueryString["id"]));

                txtContent.Text = m.MESSAGEBODY;
                litTime.Text = m.SENDDATE.ToString();
                hidPrimary.Value = m.MESSAGEID.ToString();
            }
        }

        protected void btnReply_Click(object sender, EventArgs e) {
            string url = string.Format("Add.aspx?id={0}", hidPrimary.Value);
            Response.Redirect(url, true);
        }
    }
}