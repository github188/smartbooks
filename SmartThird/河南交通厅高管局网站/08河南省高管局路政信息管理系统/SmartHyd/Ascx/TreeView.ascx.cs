using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartHyd.Ascx {
    public delegate void OnSelectedNodeChanged(object sender, object value);

    public partial class TreeView : System.Web.UI.UserControl {
        /// <summary>
        /// 选定节点改变时触发的事件
        /// </summary>
        public event OnSelectedNodeChanged OnSelectedNodeChanged;
        /// <summary>
        /// 当前树类型
        /// 默认：部门树
        /// </summary>
        private Utility.TreeEnum _TreeEnum;

        #region 方法定义
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {                
            }
        }
        /// <summary>
        /// 绑定树控件数据源
        /// </summary>
        /// <param name="treeEnum">树类型</param>
        private void BindingDataSource(Utility.TreeEnum treeEnum) {
            switch (treeEnum) {
                //部门树
                case Utility.TreeEnum.Department:
                    DepartmentDataSource();
                    break;
                //部门员工树
                case Utility.TreeEnum.DepartmentAndEmployees:
                    DepartmentAndEmployeesDataSource();
                    break;
                //文档类别树
                case Utility.TreeEnum.DocuemntClass:
                    DocuemntClassDataSource();
                    break;
                //菜单树
                case Utility.TreeEnum.Menu:
                    MenuDataSource();
                    break;
            }
        }
        /// <summary>
        /// 绑定部门树 数据源
        /// </summary>
        private void DepartmentDataSource() {
            DataTable dt = new DataTable();
            //获取部门数据源
            BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
            dt = bll.GetAllDep("1=1");

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "部门树";
            rootNode.Value = "0";
            rootNode.Expanded = true;
            InitTreeView(rootNode, dt);
            this.trvControl.Nodes.Add(rootNode);
        }
        /// <summary>
        /// 绑定部门员工树 数据源
        /// </summary>
        private void DepartmentAndEmployeesDataSource() {
            DataTable dt = new DataTable();
            //获取部门数据源
            BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
            dt = bll.GetAllDep("1=1");

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "部门用户树";
            rootNode.Value = "0";
            rootNode.Expanded = true;
            InitTreeView(rootNode, dt);
            this.trvControl.Nodes.Add(rootNode);
        }
        /// <summary>
        /// 绑定文档类别树树 数据源
        /// </summary>
        private void DocuemntClassDataSource() {
            DataTable dt = new DataTable();
            //获取部门数据源
            Utility.UserSession _userSession = (Utility.UserSession)Session["user"];
            BLL.BASE_ARTICLE_TYPE bll = new BLL.BASE_ARTICLE_TYPE();
            dt = bll.GetList(string.Format("DEPTID={0}", _userSession.DEPTID.ToString()));

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "档案分类树";
            rootNode.Value = "0";
            rootNode.Expanded = true;

            if (dt != null && dt.Rows.Count != 0) {
                InitTreeView(rootNode, dt);
            }

            this.trvControl.Nodes.Add(rootNode);
        }
        /// <summary>
        /// 绑定菜单树树 数据源
        /// </summary>
        private void MenuDataSource() {
            DataTable dt = new DataTable();
            //获取部门数据源
            BLL.BASE_MENU bll = new BLL.BASE_MENU();
            dt = bll.GetList("1=1");

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "菜单树";
            rootNode.Value = "0";
            rootNode.Expanded = true;
            InitTreeView(rootNode, dt);
            this.trvControl.Nodes.Add(rootNode);
        }
        /// <summary>
        /// 使用数据源初始化树节点
        /// </summary>
        /// <param name="node">树节点</param>
        /// <param name="dt">数据源</param>
        private void InitTreeView(TreeNode node, DataTable dt) {
            /*
             * Text属性存储Name值
             * Value存储Id值
             * ToolTipText属性存储描述信息
             * 
             * Session["treetype"]存放TreeEnum枚举值
             * Session["treetext"]存放当前选定节点Name值
             * Session["treevalue"]存放当前当定节点Id值
             */
            foreach (DataRow dr in dt.Rows) {
                TreeNode subNode = new TreeNode();
                //subNode.ShowCheckBox = true;    //显示CheckBox
                subNode.Expanded = false;       //节点折叠起来
                switch (_TreeEnum) {
                    //部门树
                    case Utility.TreeEnum.Department:
                        if (dr["PARENTID"].ToString().Equals(node.Value)) {
                            subNode.Text = dr["DPTNAME"].ToString();
                            subNode.Value = dr["DEPTID"].ToString();
                            subNode.ToolTip = dr["DPTINFO"].ToString();

                            //加入节点，继续递归循环
                            node.ChildNodes.Add(subNode);
                            InitTreeView(subNode, dt);
                        }
                        break;
                    //部门员工树
                    case Utility.TreeEnum.DepartmentAndEmployees:
                        if (dr["PARENTID"].ToString().Equals(node.Value)) {
                            subNode.Text = dr["DPTNAME"].ToString();
                            subNode.Value = dr["DEPTID"].ToString();
                            subNode.ToolTip = dr["DPTINFO"].ToString();

                            //获取部门DEPTID下员工并加入节点树(循环加入当前节点)
                            DataTable empdt = new DataTable();
                            BLL.BASE_USER user = new BLL.BASE_USER();
                            empdt = user.GetList(string.Format("DEPTID={0}", subNode.Value));
                            foreach (DataRow userdr in empdt.Rows) {
                                TreeNode userNode = new TreeNode();
                                userNode.Text = userdr["USERNAME"].ToString();
                                userNode.Value = userdr["USERID"].ToString();
                                userNode.ToolTip = userdr["PHONE"].ToString();

                                //用户加入部门节点
                                subNode.ChildNodes.Add(userNode);
                            }

                            //加入节点，继续递归循环
                            InitTreeView(subNode, dt);
                            node.ChildNodes.Add(subNode);
                        }
                        break;
                    //档案分类树
                    case Utility.TreeEnum.DocuemntClass:
                        if (dr["PARENT"].ToString().Equals(node.Value)) {
                            subNode.Text = dr["TYPENAME"].ToString();
                            subNode.Value = dr["ID"].ToString();
                            subNode.ToolTip = dr["SUMMARY"].ToString();

                            //加入节点，继续递归循环
                            InitTreeView(subNode, dt);
                            node.ChildNodes.Add(subNode);
                        }
                        break;
                    //菜单树
                    case Utility.TreeEnum.Menu:
                        if (dr["PARENTID"].ToString().Equals(node.Value)) {
                            subNode.Text = dr["MENUNAME"].ToString();
                            subNode.Value = dr["MENUID"].ToString();
                            subNode.ToolTip = dr["MENUINFO"].ToString();

                            //加入节点，继续递归循环
                            InitTreeView(subNode, dt);
                            node.ChildNodes.Add(subNode);
                        }
                        break;
                }
            }
        }
        #endregion

        #region 属性定义
        /// <summary>
        /// 当前树类型
        /// </summary>
        public Utility.TreeEnum TreeEnum {
            get { return _TreeEnum; }
            set {
                _TreeEnum = value;
                //重新绑定数据源
                BindingDataSource(_TreeEnum);
            }
        }
        #endregion

        protected void trvControl_SelectedNodeChanged(object sender, EventArgs e) {
            /*
             * Text属性存储Name值
             * Value存储Id值
             * ToolTipText属性存储描述信息
             * 
             * Session["treetype"]存放TreeEnum枚举值
             * Session["treetext"]存放当前选定节点Name值
             * Session["treevalue"]存放当前当定节点Id值
             */
            Session["treetype"] = this._TreeEnum;
            Session["treetext"] = this.trvControl.SelectedNode.Text;
            Session["treevalue"] = this.trvControl.SelectedNode.Value;

            if (OnSelectedNodeChanged != null) {
                OnSelectedNodeChanged(this.trvControl, this.trvControl.SelectedNode.Value);
            }
        }
    }
}