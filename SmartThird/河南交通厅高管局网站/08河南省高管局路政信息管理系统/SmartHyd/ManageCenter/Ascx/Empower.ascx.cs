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
            #region  单选框显示
            RadioButton radio;
            foreach(DataRow dr in dt.Rows)
            {
               radio=new RadioButton();
                radio.GroupName="role";
               radio.Text=(string)dr["ROLENAME"];
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
                this.TvRole.Nodes.Add(node);
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
            if (dt.Rows.Count>0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;


                this.RptAffiche.DataSource = pds; //定义数据源
                this.RptAffiche.DataBind(); //绑定数据
            }
            
        }
        /// <summary>
        /// 获取用户角色名称
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        protected string GetRole(decimal userid)
        {
            string role=string.Empty;
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
            if (DEPTID==0)
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
            List<string> list =new List<string>();
            string id=string.Empty;
            foreach (TreeNode TNode in tc)//循环遍历所有节点包括父节点
            {
                if (TNode.Parent != null)//排除父节点
                {
                    if (TNode.Checked == true)//如果有复选框，被勾选中的节点
                    {
                       id= TNode.Value.ToString();//显示节点的名称（不是显示名称）
                    }
                    list.Add(id);
                }
            }
            return list;
        }


        protected Entity.BASE_USER_ROLE GetModel(decimal userid,decimal ROLEID,decimal MENUID,decimal ACTIONID)
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
        protected void BtnEmp_Click(object sender, EventArgs e)
        {
           // Entity.BASE_USER_ROLE model = GetModel();
           // bll.Add(model);
        }
    }
}