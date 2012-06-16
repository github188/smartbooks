using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.ControlArea {
    public partial class List : System.Web.UI.Page {
        private Utility.UserSession session;
        private BLL.BASE_AREA bll = new BLL.BASE_AREA();

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BingList();
            }
        }

        private void BingList() {
            DataTable dt = new DataTable();

            dt = bll.GetDept(Convert.ToInt32(session.DEPTID));

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //清空现有数据源
            dgvList.DataSource = null;
            dgvList.DataBind();

            //绑定分页后的数据
            dgvList.DataSource = pds;
            dgvList.DataBind();

            litmsg.Visible = false;
            if (dt == null || dt.Rows.Count == 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>查询无数据!</div>";
            }
        }

        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BingList();
        }

        protected void dgvList_RowCommand(object sender, GridViewCommandEventArgs e) {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName) {
                case "view":
                    Response.Redirect(string.Format("View.aspx?id={0}", id.ToString()), true);
                    break;
                case "del":
                    bll.Delete(id);
                    break;
            }

            /*重新绑定数据*/
            BingList();
        }
    }
}