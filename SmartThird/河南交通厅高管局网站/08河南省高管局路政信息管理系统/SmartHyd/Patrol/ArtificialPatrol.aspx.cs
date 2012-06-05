using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


/* 人工巡逻日志列表页 */
namespace SmartHyd.Patrol {
    public partial class ArtificialPatrol : System.Web.UI.Page {

        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                bindDeptLog();
            }
        }

        private void bindDeptLog() {
            DateTime beginTime = DateTime.Now.AddDays(-5);
            DateTime endTime = DateTime.Now;
            int deptCode = 0;
            DataTable dt = new DataTable();
            dt = bll.GetDeptLog(beginTime, endTime, deptCode);

            if (dt != null && dt.Rows.Count > 0) {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;


                this.gv_patrollist.DataSource = pds;
                this.gv_patrollist.DataBind();
            }
            else {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关巡逻记录!</div>"; 
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDeptLog();
        }
    }
}