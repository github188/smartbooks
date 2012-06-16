using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.ControlArea {
    public partial class View : System.Web.UI.Page {
        private BLL.BASE_AREA bll = new BLL.BASE_AREA();
        private Entity.BASE_AREA model;

        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["id"] != null) {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                model = bll.GetModel(id);

                InitModelToPage(model);
            }
        }

        private void InitModelToPage(Entity.BASE_AREA model) {
            if (model == null) {
                return;
            }

            txtBeginTime.Text = model.REGTIME.ToString("yyyy-MM-dd");
            txtDETAILED.Text = model.DETAILED;
            txtEndTime.Text = model.COMPTIME.ToString("yyyy-mm-dd");
            txtREMARK.Text = model.REMARK;
            txtSTATUS.Text = model.STATUS;

            lblAreaName.Text = model.AREANAME;
            lblLineName.Text = model.LINENAME;
            lblPoint.Text = string.Format("K:{0} M:{0}", model.STAKEK.ToString(), model.STAKEM.ToString());
            lblPointSummary.Text = model.SUMMARY;

            litPic.Text = string.Format("<img src='http://{0}/{1}' width='500' height='250'/>",
                    Request.Url.Authority,
                    model.PHOTO);

            hidPrimary.Value = model.ID.ToString();
        }

        protected void btnDel_Click(object sender, EventArgs e) {
            if (hidPrimary.Value.Equals("-1")) {
                return;
            }

            int id = Convert.ToInt32(hidPrimary.Value);
            bll.Delete(id);
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("List.aspx", true);
        }
    }
}