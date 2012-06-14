using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.OfficialType {
    public partial class List : System.Web.UI.Page {
        private Utility.UserSession userSession;
        private BLL.BASE_ARTICLE_TYPE bll = new BLL.BASE_ARTICLE_TYPE();

        protected void Page_Load(object sender, EventArgs e) {
            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                Binging();
            }
        }

        private void Binging() {
            DataTable dt = new DataTable();

            /*当前用户部门下分类*/
            dt = bll.GetList(string.Format("DEPTID={0} AND STATUS=0", userSession.DEPTID.ToString()));

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            grvAcceptList.DataSource = null;
            grvAcceptList.DataBind();

            grvAcceptList.DataSource = pds;
            grvAcceptList.DataBind();

            /*查询结果提示信息*/
            if (dt == null || dt.Rows.Count <= 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>没有公文分类数据!</div>";
            }
            else {
                litmsg.Visible = false;
            }
        }

        protected void grvAcceptList_RowCommand(object sender, GridViewCommandEventArgs e) {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName) {
                /*删除*/
                case "del":
                    bll.Delete(id);
                    break;
            }

            /*重新绑定数据*/
            Binging();
        }
    }
}