using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.AssessType {
    public partial class List : System.Web.UI.Page {
        private Utility.UserSession session;
        private BLL.BASE_ASSESS_TYPE bll = new BLL.BASE_ASSESS_TYPE();

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindDataSource();
            }
        }

        private void BindDataSource() {
            System.Data.DataTable dt = new System.Data.DataTable();

            //获取数据
            dt = bll.GetBelongDepartmentData(Convert.ToInt32(session.DEPTID));

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //清空现有数据源
            grvList.DataSource = null;
            grvList.DataBind();


            //绑定分页后的数据
            grvList.DataSource = pds;
            grvList.DataBind();

            litmsg.Visible = false;
            if (dt == null || dt.Rows.Count == 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>查询无数据!</div>";
            }
        }

        protected void grvList_RowCommand(object sender, GridViewCommandEventArgs e) {
            decimal id = Convert.ToDecimal(e.CommandArgument.ToString());
            switch (e.CommandName) {
                case "edit":
                    Response.Redirect(string.Format("Add.aspx?id={0}", id.ToString(), true));
                    break;
                case "del":
                    bll.UpdateStatusAsDelete(id);
                    break;
            }

            /*重新绑定数据*/
            BindDataSource();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindDataSource();
        }
    }
}