using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SmartHyd.UI {
    public class BaseUserControl : System.Web.UI.UserControl {

        #region 私有字段变量定义
        #region 发布模式按钮初始化代码
        /*
        private Button _BtnAdd = new Button() { Text = "添加", Visible = false };      //添加
        private Button _BtnDelete = new Button() { Text = "删除", Visible = false };   //删除
        private Button _BtnUpdate = new Button() { Text = "修改", Visible = false };   //修改
        private Button _BtnView = new Button() { Text = "查看", Visible = false };     //查看
        private Button _BtnSearch = new Button() { Text = "查询", Visible = false };   //查询
        private Button _BtnImport = new Button() { Text = "导入", Visible = false };   //导入
        private Button _BtnExport = new Button() { Text = "导出", Visible = false };   //导出
        private Button _BtnPrint = new Button() { Text = "打印", Visible = false };    //打印
        private Button _BtnMove = new Button() { Text = "移动", Visible = false };     //移动
        private Button _BtnDownload = new Button() { Text = "下载", Visible = false }; //下载
        private Button _BtnBackup = new Button() { Text = "备份", Visible = false };   //备份
        private Button _BtnVerify = new Button() { Text = "审核", Visible = false };   //审核
        private Button _BtnGrant = new Button() { Text = "授权", Visible = false };    //授权
        private Button _BtnCancel = new Button() { Text = "重置", Visible = false };   //重置
        private Button _BtnSend = new Button() { Text = "发布", Visible = false  };    //发布
        private Button _BtnReply = new Button() { Text = "回复", Visible = false  };   //回复
        */
        #endregion

        #region 开发模式按钮初始化代码
        private Button _BtnAdd = new Button() { Text = "添加" };      //添加
        private Button _BtnDelete = new Button() { Text = "删除" };   //删除
        private Button _BtnUpdate = new Button() { Text = "修改" };   //修改
        private Button _BtnView = new Button() { Text = "查看" };     //查看
        private Button _BtnSearch = new Button() { Text = "查询" };   //查询
        private Button _BtnImport = new Button() { Text = "导入" };   //导入
        private Button _BtnExport = new Button() { Text = "导出" };   //导出
        private Button _BtnPrint = new Button() { Text = "打印" };    //打印
        private Button _BtnMove = new Button() { Text = "移动" };     //移动
        private Button _BtnDownload = new Button() { Text = "下载" }; //下载
        private Button _BtnBackup = new Button() { Text = "备份" };   //备份
        private Button _BtnVerify = new Button() { Text = "审核" };   //审核
        private Button _BtnGrant = new Button() { Text = "授权" };    //授权
        private Button _BtnCancel = new Button() { Text = "重置" };   //重置
        private Button _BtnSend = new Button() { Text = "发布" };     //发布
        private Button _BtnReply = new Button() { Text = "回复" };     //回复
        #endregion
        #endregion

        #region 公共属性定义
        /// <summary>
        /// 添加
        /// </summary>
        public Button BtnAdd {
            get { return _BtnAdd; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public Button BtnDelete {
            get { return _BtnDelete; }
        }
        /// <summary>
        /// 更新
        /// </summary>
        public Button BtnUpdate {
            get { return _BtnUpdate; }
        }
        /// <summary>
        /// 查看
        /// </summary>
        public Button BtnView {
            get { return _BtnView; }
        }
        /// <summary>
        /// 查询
        /// </summary>
        public Button BtnSearch {
            get { return _BtnSearch; }
        }
        /// <summary>
        /// 导入
        /// </summary>
        public Button BtnImport {
            get { return _BtnImport; }
        }
        /// <summary>
        /// 导出
        /// </summary>
        public Button BtnExport {
            get { return _BtnExport; }
        }
        /// <summary>
        /// 打印
        /// </summary>
        public Button BtnPrint {
            get { return _BtnPrint; }
        }
        /// <summary>
        /// 移动
        /// </summary>
        public Button BtnMove {
            get { return _BtnMove; }
        }
        /// <summary>
        /// 下载
        /// </summary>
        public Button BtnDownload {
            get { return _BtnDownload; }
        }
        /// <summary>
        /// 备份
        /// </summary>
        public Button BtnBackup {
            get { return _BtnBackup; }
        }
        /// <summary>
        /// 审核
        /// </summary>
        public Button BtnVerify {
            get { return _BtnVerify; }
        }
        /// <summary>
        /// 授权
        /// </summary>
        public Button BtnGrant {
            get { return _BtnGrant; }
        }
        /// <summary>
        /// 重置
        /// </summary>
        public Button BtnCancel {
            get { return _BtnCancel; }
        }
        /// <summary>
        /// 发布
        /// </summary>
        public Button BtnSend
        {
            get { return _BtnSend; }
        }
        /// <summary>
        /// 回复
        /// </summary>
        public Button BtnReply
        {
            get { return _BtnReply; }
        }
        #endregion

        #region 公共方法        
        /// <summary>
        /// 初始化页面功能按钮元素
        /// </summary>
        public BaseUserControl() {
            /*
             * 定义页面功能按钮容器面板
             */
            Panel funPanel = new Panel();
            funPanel.CssClass = "ui-state-highlight ui-corner-all panel";

            funPanel.Controls.Add(_BtnAdd);
            funPanel.Controls.Add(_BtnDelete);
            funPanel.Controls.Add(_BtnUpdate);
            funPanel.Controls.Add(_BtnView);
            funPanel.Controls.Add(_BtnSearch);
            funPanel.Controls.Add(_BtnImport);
            funPanel.Controls.Add(_BtnExport);
            funPanel.Controls.Add(_BtnPrint);
            funPanel.Controls.Add(_BtnMove);
            funPanel.Controls.Add(_BtnDownload);
            funPanel.Controls.Add(_BtnBackup);
            funPanel.Controls.Add(_BtnVerify);
            funPanel.Controls.Add(_BtnGrant);
            funPanel.Controls.Add(_BtnCancel);
            funPanel.Controls.Add(_BtnSend);       //发布
            funPanel.Controls.Add(_BtnReply);      //回复

            InitFunction(); //订阅按钮事件

            this.Controls.Add(funPanel);        //页面功能按钮容器
        }

        /// <summary>
        /// 为用户分配页面操作权限
        /// </summary>
        /// <param name="userSession">当前登录用户Session信息</param>
        /// <param name="pageUrl">页面地址</param>
        public void PermissionsDistribution(Utility.UserSession userSession, string pageUrl) {
            /*//遍历角色
            foreach (Utility.UserRole role in userSession.UserRole) {
                //遍历菜单
                foreach (Utility.UserMenu menu in role.UserMenu) {
                    //判断是否拥有此页面的操作权限
                    if (menu.MENUURL.Equals(pageUrl)) {
                        //遍历action
                        foreach (Entity.BASE_ACTION action in menu.UserAction) {
                            #region 功能按钮授权
                            switch (action.ACTIONNAME) {
                                case "添加": _BtnAdd.Visible = true; break;
                                case "删除": _BtnDelete.Visible = true; break;
                                case "修改": _BtnUpdate.Visible = true; break;
                                case "查看": _BtnView.Visible = true; break;
                                case "查询": _BtnSearch.Visible = true; break;
                                case "导入": _BtnImport.Visible = true; break;
                                case "导出": _BtnExport.Visible = true; break;
                                case "打印": _BtnPrint.Visible = true; break;
                                case "移动": _BtnMove.Visible = true; break;
                                case "下载": _BtnDownload.Visible = true; break;
                                case "备份": _BtnBackup.Visible = true; break;
                                case "审核": _BtnVerify.Visible = true; break;
                                case "授权": _BtnGrant.Visible = true; break;
                                case "重置": _BtnCancel.Visible = true; break;
                            }
                            #endregion
                        }
                    }
                }
            }*/
        }

        //添加
        public virtual void BtnAdd_Click(object sender, EventArgs e) { }
        //删除
        public virtual void BtnDelete_Click(object sender, EventArgs e) { }
        //重置
        public virtual void BtnCancel_Click(object sender, EventArgs e) { }
        //修改
        public virtual void BtnUpdate_Click(object sender, EventArgs e) { }
        //查看
        public virtual void BtnView_Click(object sender, EventArgs e) { }
        //查询
        public virtual void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        public virtual void BtnImport_Click(object sender, EventArgs e) { }
        //导出
        public virtual void BtnExport_Click(object sender, EventArgs e) { }
        //打印
        public virtual void BtnPrint_Click(object sender, EventArgs e) { }
        //移动
        public virtual void BtnMove_Click(object sender, EventArgs e) { }
        //下载
        public virtual void BtnDownload_Click(object sender, EventArgs e) { }
        //备份
        public virtual void BtnBackup_Click(object sender, EventArgs e) { }
        //审核
        public virtual void BtnVerify_Click(object sender, EventArgs e) { }
        //授权
        public virtual void BtnGrant_Click(object sender, EventArgs e) { }
        //发布
        public virtual void BtnSend_Click(object sender, EventArgs e) { }
        //回复
        public virtual void BtnReply_Click(object sender, EventArgs e) { }
        #endregion

        #region 私有方法
        //订阅按钮事件
        private void InitFunction() {
            this.BtnAdd.Click += new EventHandler(BtnAdd_Click);        //添加
            this.BtnDelete.Click += new EventHandler(BtnDelete_Click);  //删除
            this.BtnCancel.Click += new EventHandler(BtnCancel_Click);   //重置
            this.BtnUpdate.Click += new EventHandler(BtnUpdate_Click);   //修改
            this.BtnView.Click += new EventHandler(BtnView_Click);   //查看
            this.BtnSearch.Click += new EventHandler(BtnSearch_Click);    //查询
            this.BtnImport.Click += new EventHandler(BtnImport_Click);   //导入
            this.BtnExport.Click += new EventHandler(BtnExport_Click);   //导出
            this.BtnPrint.Click += new EventHandler(BtnPrint_Click); //打印
            this.BtnMove.Click += new EventHandler(BtnMove_Click);    //移动
            this.BtnDownload.Click += new EventHandler(BtnDownload_Click); //下载
            this.BtnBackup.Click += new EventHandler(BtnBackup_Click);   //备份
            this.BtnVerify.Click += new EventHandler(BtnVerify_Click);//审核
            this.BtnGrant.Click += new EventHandler(BtnGrant_Click); //授权
            this.BtnSend.Click += new EventHandler(BtnSend_Click); //发布
            this.BtnReply.Click += new EventHandler(BtnReply_Click); //回复

        }
        #endregion
    }
}
