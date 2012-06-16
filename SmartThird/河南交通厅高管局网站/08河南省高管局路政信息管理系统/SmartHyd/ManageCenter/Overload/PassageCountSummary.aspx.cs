using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Overload {
    public partial class PassageCountSummary : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                rdoW_CheckedChanged(null, null);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            BindTJData();
        }

        private void BindTJData() {
            litTJList.Text = "";

            DataTable dt = null;

            if (dt != null && dt.Rows.Count > 0) {

            } else {
                litTJList.Text = "<tr><td colspan=\"2\" class=\"red\">暂无车辆统计信息！</td></tr>";
            }
        }

        protected void btnExport_Click(object sender, EventArgs e) {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "result", "alert(‘通行数据检索结果为空，无法进行导出操作！’)", true);
        }

        protected void rdoW_CheckedChanged(object sender, EventArgs e) {
            if (rdoW.Checked) {
                ddlCompany.Enabled = false;
                ddlCity.Enabled = false;
            } else if (rdoRK.Checked) {
                ddlCompany.Enabled = true;
                ddlCity.Enabled = true;
            } else if (rdoCK.Checked) {
                ddlCompany.Enabled = true;
                ddlCity.Enabled = true;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e) {

        }
    }
}