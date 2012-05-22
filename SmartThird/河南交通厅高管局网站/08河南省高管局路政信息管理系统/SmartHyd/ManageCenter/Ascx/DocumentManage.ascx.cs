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
        #endregion

        #region 页面事件
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindData();     //绑定一个公文ID 
                //获取用户Session
                userSession = (Utility.UserSession)Session["user"];
            }
        }
        //详细模式分页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        //预览模式分页
        protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager2.CurrentPageIndex = e.NewPageIndex;
        }
        #endregion

        #region 方法定义
        //绑定数据
        private void BindData() {
            DataTable dt = new DataTable();
            dt = bll.GetArticle(0);

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            repList.DataSource = pds;
            repList.DataBind();
        }

        /// <summary>
        /// 获取部门下文章
        /// </summary>
        /// <param name="dptCode">部门编号</param>
        /// <param name="typeCode">分类编号</param>
        /// <param name="stateCode">状态:0已审核1未审核2草稿3已删除4隐藏5结贴</param>
        private void BindArticleDept(int dptCode, int typeCode, int stateCode) {
            DataTable dt = new DataTable();
            dt = bll.GetArticleDept(dptCode, typeCode, stateCode);

            //初始化分页数据
            AspNetPager2.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager2.PageSize;

            //绑定分页后的数据
            repArticleList.DataSource = pds;
            repArticleList.DataBind();
        }

        #endregion

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