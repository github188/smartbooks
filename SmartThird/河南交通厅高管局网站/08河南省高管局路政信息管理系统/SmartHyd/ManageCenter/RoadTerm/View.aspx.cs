using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.RoadTerm {
    public partial class View : System.Web.UI.Page {
        private Utility.UserSession session;
        private Entity.BASE_ROAD_TERM Model;
        private BLL.BASE_ROAD_TERM bll = new BLL.BASE_ROAD_TERM();

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (Request.QueryString["id"] != null) {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Model = bll.GetModel(id);

                //init model to page
                lblRoadName.Text = Model.LINENAME;
                lblDriverName.Text = Model.ROADNAME;
                lblPoint.Text = string.Format("K:{0} M:{1}", Model.STAKEK.ToString(), Model.STAKEM.ToString());
                lblPointSummary.Text = Model.SUMMARY;
                txtBeginTime.Text = Model.REGTIME.ToString();
                txtEndTime.Text = Model.COMPTIME.ToString();
                litPic.Text = string.Format("<img src='http://{0}/{1}' width='500' height='250'/>",
                    Request.Url.Authority,
                    Model.PHOTO);
            }
        }

        protected void btnDel_Click(object sender, EventArgs e) {
            bll.UpdateStatusAsDelete(Convert.ToInt32(Model.ID));
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("RoadTermList.aspx", true);
        }
    }
}