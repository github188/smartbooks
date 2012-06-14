using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.OfficialType {
    public partial class Create : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        private Entity.BASE_ARTICLE_TYPE GetModel() {
            return null;
        }

        private void SetModel(Entity.BASE_ARTICLE_TYPE model) {
            txtTitle.Text = model.TYPENAME;
            txtSummary.Text = model.SUMMARY;
            txtSort.Text = model.SORT.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e) {

        }

        protected void btnCancel_Click(object sender, EventArgs e) {

        }
    }
}