using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Official {
    public partial class CheckOut : System.Web.UI.Page {
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private Utility.UserSession userSession;
        private int sendId = -1;
        private Entity.BASE_ARTICLE model;

        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                if (Request.QueryString["id"] != null) {
                    sendId = Convert.ToInt32(Request.QueryString["id"]);
                }

                //获取发文实体
                model = bll.GetEntity(sendId);

                //绑定回文列表数据
                BindingReplyList();
            }
        }

        //绑定回文列表
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
            grvList.DataSource = pds;
            grvList.DataBind();
        }

        //校验表单
        private bool CheckSubmitFrom() {
            /*校验回文列表*/
            if (grvList.Rows.Count <= 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>回文列表为空!</div>";
                return false;
            }
            return true;
        }

        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindingReplyList();
        }

        //结贴
        protected void btnCheckOut_Click(object sender, EventArgs e) {
            /*校验表单*/
            if (!CheckSubmitFrom()) {
                return;
            }

            /*
             * 1.校验页面帖子分值合法性
             * 2.取出ID、score值
             * 3.逐条更新回帖状态和分值
             */
            //取出帖子ID和分值
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            //foreach (RepeaterItem item in grvList.Items) {
            //    int id = Convert.ToInt32(((DataRowView)item.DataItem)["id"].ToString());  //取出键
            //    int value = Convert.ToInt32(((DataRowView)item.DataItem)["score"].ToString()); //取出值
            //    dictionary.Add(id, value);
            //}

            //checkout operation,update this is reply list state.
            bll.CheckOut(dictionary);

            //update publish article state as 'checkout'.
            //0已审核，1未审核，2草稿，3已删除，4隐藏，5结贴
            bll.UpdateState(5, sendId);

            //back to Previous.
            //Response.Redirect("~/Official/OfficialIndex.aspx", true);
        }

        protected void grvList_RowCommand(object sender, GridViewCommandEventArgs e) {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName) {
                /*更新*/
                case "up":
                    /*更新发文状态为结贴 和 分数*/
                    break;
            }

            /*重新绑定数据*/
            //BindingReplyList();
        }
    }
}