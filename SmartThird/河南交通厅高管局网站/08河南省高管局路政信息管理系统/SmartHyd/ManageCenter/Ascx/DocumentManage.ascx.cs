using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class DocumentManage : UI.BaseUserControl {
        #region 私有字段
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private BLL.BASE_ARTICLE_TYPE bllType = new BLL.BASE_ARTICLE_TYPE();
        private Utility.UserSession userSession;
        private int inde = 0;
        private int typeId = 0;
        #endregion

        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            //选定节点改变时触发的事件
            TreeView1.OnSelectedNodeChanged += new SmartHyd.Ascx.OnSelectedNodeChanged(TreeView1_OnSelectedNodeChanged);
            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                //绑定发文列表数据
                BindPublichList();
            }
        }
        //绑定发文列表数据
        private void BindPublichList() {
            DataTable dt = new DataTable();
            dt = bll.GetPublishList(Convert.ToInt32(userSession.DEPTID), typeId); //获取发文列表数据

            //初始化分页数据
            AspNetPager2.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager2.PageSize;

            //绑定分页后的数据
            reppublishlist.DataSource = null;
            reppublishlist.DataBind();

            reppublishlist.DataSource = pds;
            reppublishlist.DataBind();
        }
        //选定节点改变时触发的事件
        private void TreeView1_OnSelectedNodeChanged(object sender, object value) {
            typeId = Convert.ToInt32(value.ToString());

            //重新绑定发文列表
            BindPublichList();
        }
        //分页数据列表按钮事件
        protected void reppublishlist_ItemCommand(object source, RepeaterCommandEventArgs e) {
            switch (e.CommandName) {
                //编辑
                case "edit":
                    Response.Redirect(string.Format("DocumentCreate.aspx?id={0}", e.CommandArgument.ToString()));
                    break;
                //删除
                case "delete": break;
                //结贴
                case "checkout":
                    Response.Redirect(string.Format("DocumentCheckOut.aspx?id={0}", e.CommandArgument.ToString()));
                    break;
                //详情
                case "detail":
                    Response.Redirect(string.Format("DocumentDetail.aspx?id={0}", e.CommandArgument.ToString()));
                    break;
            }
        }
        //发文列表分页
        protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager2.CurrentPageIndex = e.NewPageIndex;
            BindPublichList();
        }
        //添加分类
        protected void btnDocumentType_Click(object sender, EventArgs e) {

        }
    }
}