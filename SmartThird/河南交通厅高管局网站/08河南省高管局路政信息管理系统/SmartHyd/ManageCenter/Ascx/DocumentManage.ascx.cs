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
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private Utility.UserSession userSession;
        private int typeId = 0;

        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            //选定节点改变时触发的事件
            TreeView1.OnSelectedNodeChanged += new SmartHyd.Ascx.OnSelectedNodeChanged(TreeView1_OnSelectedNodeChanged);

            if (!IsPostBack) {
                //获取用户Session
                userSession = (Utility.UserSession)Session["user"];

                //绑定发文列表数据
                BindPublichList();

                
            }
        }
        //发文列表分页
        protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager2.CurrentPageIndex = e.NewPageIndex;
            BindPublichList();
        }

        //绑定发文列表数据
        private void BindPublichList() {
            DataTable dt = new DataTable();
            dt = bll.GetPublishList(13, typeId); //获取发文列表数据

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

        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e) { }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e) { }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e) { }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) { }
        //查看
        public override void BtnView_Click(object sender, EventArgs e) { }
        //查询
        public override void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        public override void BtnImport_Click(object sender, EventArgs e) { }
        //导出
        public override void BtnExport_Click(object sender, EventArgs e) { }
        //打印
        public override void BtnPrint_Click(object sender, EventArgs e) { }
        //移动
        public override void BtnMove_Click(object sender, EventArgs e) { }
        //下载
        public override void BtnDownload_Click(object sender, EventArgs e) { }
        //备份
        public override void BtnBackup_Click(object sender, EventArgs e) { }
        //审核
        public override void BtnVerify_Click(object sender, EventArgs e) { }
        //授权
        public override void BtnGrant_Click(object sender, EventArgs e) { }
        #endregion
    }
}