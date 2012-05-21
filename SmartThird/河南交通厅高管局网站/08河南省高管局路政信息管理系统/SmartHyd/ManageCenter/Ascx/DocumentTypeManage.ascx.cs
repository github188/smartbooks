using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class DocumentTypeManage : UI.BaseUserControl {

        #region 方法定义
        //绑定数据
        private void BindData() {
        }
        //获取实体
        private Entity.BASE_ARTICLE_TYPE GetEntity() {
            return null;
        }
        //设置实体
        private void SetEntity(Entity.BASE_ARTICLE_TYPE model) {
        }
        protected void Page_Load(object sender, EventArgs e) {
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
        }
        #endregion

        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e) {
            //Entity.BASE_ARTICLE model;
            //model = this.GetEntity();

            ////此处实现上传附件

            //bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
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