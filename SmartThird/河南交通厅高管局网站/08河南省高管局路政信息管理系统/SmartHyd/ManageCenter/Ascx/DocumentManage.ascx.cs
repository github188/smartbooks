using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class DocumentManage : UI.BaseUserControl {
        #region 私有字段
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private Utility.UserSession userSession;
        #endregion

        #region 页面事件
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindData();     //绑定一个公文ID
                BindType();     //绑定公文分类

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
        //绑定公文类别
        private void BindType() {
            DataTable dt = new DataTable();

            ddlTypeId.Items.Clear();
            foreach (DataRow row in dt.Rows) {
                ddlTypeId.Items.Add(new ListItem(
                    row["TYPENAME"].ToString(),
                    row["ID"].ToString()));
            }
            if (ddlTypeId.Items.Count != 0) {
                ddlTypeId.SelectedIndex = 0;
            }
        }
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
        //获取实体
        private Entity.BASE_ARTICLE GetEntity() {
            Entity.BASE_ARTICLE model = new Entity.BASE_ARTICLE();            
            model.CONTENT = txtContent.Text;    //内容            
            model.ISREPLY = Convert.ToInt32(rdoIsReply.SelectedValue);  //允许回复            
            model.SCORE = Convert.ToInt32(txtSCORE.Text);   //分值
            model.SENDCODE = txtSendCode.Text;  //发文字号
            model.STATUS = Convert.ToInt32(ddlStatus.SelectedValue);    //发文状态            
            model.TITLE = txtTitle.Text;        //标题
            model.TYPEID = Convert.ToInt32(ddlTypeId.SelectedValue);    //公文类别
            model.PARENTID = 0;                 //父发文编号
            model.TIMESTAMP = DateTime.Now;     //时间戳

            model.USERID = userSession.USERID;  //用户编号
            model.DEPTID = userSession.Department[0].DEPTID;    //部门
            model.ANNEX = "";                   //附件

            return model;
        }
        //设置实体
        private void SetEntity(Entity.BASE_ARTICLE model) {
            txtContent.Text = model.CONTENT;                        //内容
            rdoIsReply.SelectedValue = model.ISREPLY.ToString();    //允许回复
            txtSCORE.Text = model.SCORE.ToString();                 //分值
            txtSendCode.Text = model.SENDCODE;                      //发文字号
            ddlStatus.SelectedValue = model.STATUS.ToString();      //发文状态
            txtTitle.Text = model.TITLE;                            //标题
            ddlTypeId.SelectedValue = model.TYPEID.ToString();      //公文类别

            //model.PARENTID = 0;                 //父发文编号
            //model.TIMESTAMP = DateTime.Now;     //时间戳
            //model.USERID = userSession.USERID;  //用户编号
            //model.DEPTID = userSession.Department[0].DEPTID;    //部门
            //model.ANNEX = "";                   //附件
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
        public override void BtnAdd_Click(object sender, EventArgs e) {
            Entity.BASE_ARTICLE model;
            model = this.GetEntity();

            //此处实现上传附件
            
            bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e) {}
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e) {}
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