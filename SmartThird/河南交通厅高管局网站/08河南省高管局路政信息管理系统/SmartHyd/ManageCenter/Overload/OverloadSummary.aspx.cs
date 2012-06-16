using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Overload {
    public partial class OverloadSummary : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnExport_Click(object sender, EventArgs e) {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "result", "alert(‘通行数据检索结果为空，无法进行导出操作！’)", true);
        }

        protected void btnSummary_Click(object sender, EventArgs e) {
            litHZList.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>暂无相关车辆通信信息!</div>";
        }

        protected void rdoCity_CheckedChanged(object sender, EventArgs e) {

        }

        protected void rdoRK_CheckedChanged(object sender, EventArgs e) {

        }

        protected void ddl_cities_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void ddl_highways_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void ddl_units_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}