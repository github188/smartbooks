using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Official {
    public partial class Reply : System.Web.UI.Page {
        private Utility.UserSession userSession;
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();

        protected void Page_Load(object sender, EventArgs e) {
            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindReplyList();
            }
        }

        //公文列表分页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindReplyList();
        }

        //绑定考评回复列表数据
        private void BindReplyList() {
            DataTable dt = new DataTable();

            /*获取考评回复数据*/
            dt = bll.GetList(string.Format("USERID={0} AND STATUS=0 AND PARENTID<>0 ORDER BY TIMESTAMP DESC", userSession.USERID.ToString()));


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
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>没有公文数据!</div>";
            }
            else {
                litmsg.Visible = false;
            }
        }

        protected void grvAcceptList_RowCommand(object sender, GridViewCommandEventArgs e) {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName) {
                /*跳转到详情页面*/
                case "view":
                    Response.Redirect("~/ManageCenter/Official/Detail.aspx?id=" + id.ToString(), true);
                    break;
            }
        }
    }
}