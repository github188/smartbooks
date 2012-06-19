using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Document {
    public partial class View : System.Web.UI.Page {
        private BLL.BASE_DOCUMENT bll = new BLL.BASE_DOCUMENT();

        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["id"] != null) {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                Entity.BASE_DOCUMENT model = new Entity.BASE_DOCUMENT();
                model = bll.GetEntity(id);
                SetEntity(model);
            }
        }

        private void SetEntity(Entity.BASE_DOCUMENT model) {
            txtBeginTime.Text = model.BEGINTIME.ToString("yyyy-MM-dd");
            txtCASEFILENUMBER.Text = model.CASEFILENUMBER;
            txtCATALOGNUMBER.Text = model.CATALOGNUMBER;
            txtEndTime.Text = model.ENDTIME.ToString("yyyy-MM-dd");
            txtFONDSNO.Text = model.FONDSNO;
            hidPrimary.Value = model.ID.ToString();
            txtNUMBEROFCOPIES.Text = model.NUMBEROFCOPIES.ToString();
            txtRETENTION.Text = model.RETENTION.ToString();
            txtTitle.Text = model.TIELE;
            txtUnit.Text = model.UNIT;
            txtYear.Text = model.YEAR.ToString();

            if (model.ANNEX.Substring(model.ANNEX.Length - 1, 1).Equals(",")) {
                model.ANNEX = model.ANNEX.Substring(0, model.ANNEX.Length - 1);
            }
            hidAnnex.Value = model.ANNEX;
        }
    }
}