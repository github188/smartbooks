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
            //初始化数据
            DateTime beginTime = DateTime.Now.AddDays(-10);
            DateTime endTime = DateTime.Now;
            int deptCode = 0;
            DataTable dt = new DataTable();
            dt = bll.GetDeptLog(beginTime, endTime, deptCode);
            //获取全部人工巡逻日志
            //dt = bll.GetPatrol("1=1");
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

        /// <summary>
        /// 人工巡逻日志查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ok_Click(object sender, EventArgs e) {
            string strwhere = string.Empty;
            
            if (this.txt_vehicleLicense.Text == "" && this.txt_startTime.Text == "" && this.txt_endTime.Text == "")
            {
                //按单位查询
                strwhere = "";
            }
            else
            { 
                //综合查询
                strwhere = "";
            }
            
            if (this.txt_startTime.Text == "" && this.txt_endTime.Text == "")
            {
                //按巡逻单位+车牌号查询
                strwhere = "";
            }
            else
            {
                //按巡逻单位+车牌号查询
                strwhere = "";
            }
            //按巡逻单位+起始时间查询
            //按截止时间查询
            
        }
    }
}