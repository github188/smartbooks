using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class DocumentReply : System.Web.UI.UserControl {
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private Utility.UserSession userSession;
        private int sendId = 0;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                //获取用户Session
                userSession = (Utility.UserSession)Session["user"];

                if (Request.QueryString["id"] != null) {
                    sendId = Convert.ToInt32(Request.QueryString["id"]);
                }

                //绑定回文列表数据
                BindingReplyList();
            }
        }

        /// <summary>
        /// 绑定回文列表
        /// </summary>
        private void BindingReplyList() {
            DataTable dt = new DataTable();

            dt = bll.GetReplyList(sendId);   //获取回文数据列表

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            repReplyList.DataSource = pds;
            repReplyList.DataBind();
        }

        //回文列表分页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindingReplyList();
        }
    }
}