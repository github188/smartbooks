using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class DocumentCheckOut : System.Web.UI.UserControl {
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

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindingReplyList();
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

        //结贴
        protected void btnCheckOut_Click(object sender, EventArgs e) {
            /*
             * 1.校验页面帖子分值合法性
             * 2.取出ID、score值
             * 3.逐条更新回帖状态和分值
             */
            if (repReplyList.Items.Count != 0) {

                //取出帖子ID和分值
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                foreach (RepeaterItem item in repReplyList.Items) {
                    int id = Convert.ToInt32(((DataRowView)item.DataItem)["id"].ToString());  //取出键
                    int value = Convert.ToInt32(((DataRowView)item.DataItem)["score"].ToString()); //取出值
                    dictionary.Add(id, value);
                }

                //checkout operation,update this is reply list state.
                bll.CheckOut(dictionary);

                //update publish article state as 'checkout'.
                //0已审核，1未审核，2草稿，3已删除，4隐藏，5结贴
                bll.UpdateState(5, sendId);

                //back to Previous.
                Response.Redirect(Request.UrlReferrer.AbsoluteUri, true);
            } else {
                Smart.Utility.Alerts.Alert("回文列表时空的");
            }
        }
        //返回
        protected void btnBacktrack_Click(object sender, EventArgs e) {
            Response.Redirect(Request.UrlReferrer.AbsoluteUri, true);
        }
    }
}