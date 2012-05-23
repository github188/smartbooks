using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SmartHyd.Utility;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Empower : UI.BaseUserControl
    {
        private BLL.BASE_USER_ROLE bll = new BLL.BASE_USER_ROLE();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_DEPT deptbll = new BLL.BASE_DEPT();
        private BLL.BASE_ROLE rolebll = new BLL.BASE_ROLE();
        private BLL.BASE_ACTION actionbll = new BLL.BASE_ACTION();
        private BLL.BASE_MENU menubll = new BLL.BASE_MENU();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater();
                GetTreeAction();//动作权限树绑定
                GetTreeMenu();//菜单树绑定
                GetTreeRole();//角色树绑定
            }
        }
        /// <summary>
        /// 角色树绑定(为用户分配角色；每个角色对应一个菜单：menu；每个菜单下有n个动作：action)
        /// </summary>
        public void GetTreeRole()
        {
            DataTable dt = new DataTable();

            dt = rolebll.GetList("1=1");
            #region  单选框列表显示
            ListItem item;
            foreach (DataRow dr in dt.Rows)
            {
                item = new ListItem();
                item.Text = dr["ROLENAME"].ToString();//角色名称
                item.Value = dr["ROLEID"].ToString();//角色编号
                this.RBLRole.Items.Add(item);//rdl RadioButtonList控件名
            }
            #endregion
            #region  复选框显示
            //TreeNode node;
            ////循环添加TreeNode
            //foreach (DataRow dr in dt.Rows)
            //{
            //    node = new TreeNode();
            //    this.TvRole.Nodes.Add(node);
            //    node.Value = dr["ROLEID"].ToString();
            //    node.Text = (string)dr["ROLENAME"];
            //    node.ShowCheckBox = true;

            //}
            #endregion
        }
        /// <summary>
        /// 动作权限树绑定
        /// </summary>
        public void GetTreeAction()
        {
            DataTable dt = new DataTable();

            dt = actionbll.GetList("1=1");
            //填充DataTable

            TreeNode node;
            //循环添加TreeNode
            foreach (DataRow dr in dt.Rows)
            {
                node = new TreeNode();
                this.TvAction.Nodes.Add(node);
                node.Value = dr["ACTIONID"].ToString();
                node.Text = (string)dr["ACTIONNAME"];
                node.ShowCheckBox = true;
            }

        }
        /// <summary>
        /// 菜单树绑定
        /// </summary>
        public void GetTreeMenu()
        {
            DataTable dt = new DataTable();

            dt = menubll.GetList("1=1");
            //填充DataTable

            TreeNode node;
            //循环添加TreeNode
            foreach (DataRow dr in dt.Rows)
            {
                node = new TreeNode();
                this.Tvmenu.Nodes.Add(node);
                node.Value = dr["MENUID"].ToString();
                node.Text = dr["MENUNAME"].ToString();
                node.ShowCheckBox = true;
            }

        }
        //使用dataBindToRepeater()方法绑定用户数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = userbll.GetList("1=1");
            if (dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;


                this.RptList.DataSource = pds; //定义数据源
                this.RptList.DataBind(); //绑定数据
            }

        }
        /// <summary>
        /// 获取用户角色名称
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        protected string GetRole(decimal userid)
        {
            string role = string.Empty;
            if (bll.GetList(userid).Rows.Count > 0)
            {
                int roleid = Convert.ToInt32(bll.GetList(userid).Rows[0]["ROLEID"].ToString());
                role = rolebll.GetEntity(roleid).ROLENAME;
            }
            else
            {
                role = "暂无角色";
            }
            return role;
        }
        /// <summary>
        /// 获取用户所属部门名称
        /// </summary>
        /// <param name="DEPTID">部门编号</param>
        /// <returns>部门名称</returns>
        public string GetDept(decimal DEPTID)
        {

            string deptName = string.Empty;
            if (DEPTID == 0)
            {
                deptName = "暂无数据";
            }
            else
            {
                deptName = deptbll.GetEntity(DEPTID).DPTNAME;
            }
            return deptName;

        }
        //循环遍历TREEVIEW，验证是否设置权限
        public List<string> GetNode(TreeNodeCollection tc)//接收TreeView转过来的节点集合
        {
            List<string> list = new List<string>();
            string id = string.Empty;
            foreach (TreeNode TNode in tc)//循环遍历所有节点包括父节点
            {
                if (TNode.Parent != null)//排除父节点
                {
                    if (TNode.Checked == true)//如果有复选框，被勾选中的节点
                    {
                        id = TNode.Value.ToString();//显示节点的名称（不是显示名称）
                    }
                    list.Add(id);
                }
            }
            return list;
        }


        protected Entity.BASE_USER_ROLE GetModel(decimal userid, decimal ROLEID, decimal MENUID, decimal ACTIONID)
        {
            Entity.BASE_USER_ROLE Model = new Entity.BASE_USER_ROLE();
            // Model.USERROLEID = Convert.ToDecimal(this.hidPrimary.value);//主键，ID
            Model.USERID = userid;// 用户编号；
            Model.ROLEID = ROLEID;//角色编号；
            Model.MENUID = MENUID;//菜单编号；
            Model.ACTIONID = ACTIONID;//动作编号；
            return Model;
        }
        /// <summary>
        /// //分页事件 用户权限分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
        /// <summary>
        /// 按钮事件：授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void BtnEmp_Click(object sender, EventArgs e)
        //{
        //}
        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
        }
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
        public override void BtnGrant_Click(object sender, EventArgs e)
        {
            //获取用户编号（先判断用户是否存在已有权限，如果存在，删除已有权限）


            decimal userid = 0;
            //选择用户
            foreach (RepeaterItem Ritem in this.RptList.Items)
            {
                CheckBox ch = Ritem.FindControl("CheckSingle") as CheckBox;
                Label lb = Ritem.FindControl("LBUSERID") as Label;
                if (null != ch && null != lb)
                {
                    if (ch.Checked)
                        Response.Write("编号：" + lb.Text);
                    // value +=ch.Text;
                }
            }

            //判断用户是否拥有权限
            if (bll.ExistsUserid(userid))
            {
                string strwhere = "USERID=" + userid;
                bll.deletelist(strwhere);//删除已有权限
                PowerAdd(userid);//用户授权
            }
            else
            {
                PowerAdd(userid);//用户授权
            }
        }
        #endregion
        #region 授权代码
        /// <summary>
        /// 给用户循环添加授权
        /// </summary>
        /// <param name="userid"></param>
        private void PowerAdd(decimal userid)
        {
            //获取角色编号
            decimal roleid = -1;
            if (null != this.RBLRole.SelectedValue.ToString() || "" != this.RBLRole.SelectedValue.ToString())
            {
                roleid = Convert.ToDecimal(this.RBLRole.SelectedValue.ToString());
            }

            //获取菜单编号
            List<int> menuID = GetMenuID();
            //获取动作编号
            List<int> ACTIONID = GetActionID();

            int total = menuID.Count * ACTIONID.Count;//要添加数据的总记录数
            if (total > 0)
            {
                for (int i = 0; i < menuID.Count; i++)
                {
                    for (int j = 0; j < ACTIONID.Count; j++)
                    {
                        bll.Add(GetModel(userid, roleid, menuID[i], ACTIONID[j]));
                    }
                }

            }
            // Response.Write("<javascript>alert('添加成功！')</javascript>");
            // Entity.BASE_USER_ROLE model = GetModel();
            // bll.Add(model);
        }
        /// <summary>
        /// 获取菜单编号列表
        /// </summary>
        /// <returns></returns>
        private List<int> GetMenuID()
        {
            List<int> menuID = new List<int>();//菜单编号数组
            foreach (TreeNode tn in this.Tvmenu.Nodes)
            {
                if (tn.Checked && tn.ChildNodes.Count == 0)
                {
                    menuID.Add(Convert.ToInt32(tn.Value));//tn 就是要的节点 
                }
            }
            return menuID;
        }
        /// <summary>
        /// 获取动作编号列表
        /// </summary>
        /// <returns></returns>
        private List<int> GetActionID()
        {
            List<int> ACTIONID = new List<int>();//动作编号数组
            foreach (TreeNode tn in this.TvAction.Nodes)
            {
                if (tn.Checked && tn.ChildNodes.Count == 0)
                {
                    ACTIONID.Add(Convert.ToInt32(tn.Value));//tn 就是要的节点 
                }
            }
            return ACTIONID;
        }
        #endregion
    }
}