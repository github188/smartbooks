using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartPoms.Poms.Ascx {
    public partial class WeiBo : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindDataSource();
            }
        }

        private void BindDataSource() {
            DataTable dt = new DataTable();
            /*获取数据源*/

            /*加入一空行*/
            if (dt.Rows.Count == 0) {
                dt.Rows.Add(dt.NewRow());
            }
                        
            //填充数据集
            this.dgvResult.DataSource = dt;
            this.dgvResult.DataBind();
        }

        //切换分页数据
        protected void dgvResult_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.dgvResult.PageIndex = e.NewPageIndex;
            BindDataSource();
        }
    }
}