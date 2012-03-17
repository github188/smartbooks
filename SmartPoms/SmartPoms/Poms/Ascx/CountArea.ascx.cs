using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.Poms.Ascx {
    public partial class CountArea : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            for (int i = 0; i < 10; i++) {
                dt.Columns.Add(i.ToString());
            }
            for (int i = 0; i < 10; i++) {
                dt.Rows.Add(new object[] { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" });
            }

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

            this.GridView2.DataSource = dt;
            this.GridView2.DataBind();
        }
    }
}