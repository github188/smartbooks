using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class SysManager :UI.BaseUserControl
    {
        private BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_MENU menubll = new BLL.BASE_MENU();
        private BLL.BASE_ROLE rolebll = new BLL.BASE_ROLE();
        private BLL.BASE_ACTION actionbll = new BLL.BASE_ACTION();
        private BLL.BASE_USER_ROLE userRolebll = new BLL.BASE_USER_ROLE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataBindToRepeater("1=1");//绑定部门数据
            BindUserList();   //绑定用户数据
            dataBindRepeater("1=1");//绑定日志数据
            UserBind();//授权用户绑定
            RoleBind();//角色绑定
            MenuBind();// 菜单绑定
            ActionBind(); // 动作绑定
        }
        #region 部门管理
        //使用dataBindToRepeater()方法绑定部门数据
        private void dataBindToRepeater(string strwhere)
        {
            DataTable dt = new DataTable();
            dt = bll.GetAllDep(strwhere);

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptList.DataSource = pds; //定义数据源
            this.RptList.DataBind(); //绑定数据
        }
        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/ManageCenter/Dept.aspx");
        }
         /// <summary>
         /// 按钮事件：查询
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        protected void btnSearchDept_Click(object sender, EventArgs e)
        {
            string strwhere = "DPTNAME='" + this.TxtDeptName.Text + "'";
            dataBindToRepeater(strwhere);
        }
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater("1=1");
        }
        /// <summary>
        /// 状态转为文字
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string TransState(decimal status)
        {
            if (status == 0)
            {
                return "正常";
            }
            else
            {
                return "关闭";
            }

        }
        #endregion
        #region 用户管理
        /// <summary>
        /// 用户数据绑定
        /// </summary>
        private void BindUserList()
        {
            DataTable dt = new DataTable();
            dt = userbll.GetAllUser();
            //dt = bll.GetList("1=1");
            //初始化分页数据
            AspNetPager2.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager2.PageSize;

            //绑定分页后的数据
            repList.DataSource = pds;
            repList.DataBind();
        }
        //添加用户
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/ManageCenter/UserManage.aspx");
        }
        //按钮事件：搜索用户
        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strwhere = "USERNAME='"+this.Txtuser.Text+"'";
           dt= userbll.GetList(strwhere);
           // 重新绑定分页数据
            AspNetPager2.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager2.PageSize;

            //绑定分页后的数据
            repList.DataSource = pds;
            repList.DataBind();
            Response.Redirect("~/ManageCenter/SysManager.aspx#tabs-2");
        }
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager2.CurrentPageIndex = e.NewPageIndex;
            BindUserList();
        }
        #endregion
        #region  用户授权
         /// <summary>
        /// 授权用户绑定
        /// </summary>
        private void UserBind()
        {
            SmartHyd.Utility.UserSession userSession = (SmartHyd.Utility.UserSession)Session["user"];
            DataTable dt = new DataTable();
            string strwhere = "USERID!=" + userSession.USERID;
            dt = userbll.GetList(strwhere);
            //绑定方法一：
            this.CBLUser.DataSource = dt;
            this.CBLUser.DataTextField = "USERNAME";
            this.CBLUser.DataValueField = "USERID";
            this.CBLUser.DataBind();
            foreach (ListItem item in CBLUser.Items)//追加用户编号绑定到页面
            {
                item.Attributes.Add("valu", item.Value);
            }


            //方法二：
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //node = new TreeNode();
            //    //this.ListUser.Items.Add(node);
            //    //node.Value = dr["USERID"].ToString();
            //    //node.Text = (string)dr["USERNAME"];
            //    //node.ShowCheckBox = true;

            //    this.CBLUser.Items.Add(dr["USERNAME"].ToString());
            //}
           



        }
        /// <summary>
        /// 角色绑定
        /// </summary>
        private void RoleBind()
        {
            DataTable dt = new DataTable();
            dt = rolebll.GetList("1=1");
            this.ChBLRole.DataSource = dt;
            this.ChBLRole.DataTextField = "ROLENAME";
            this.ChBLRole.DataValueField = "ROLEID";
            this.ChBLRole.DataBind();
        }
        /// <summary>
        /// 菜单绑定
        /// </summary>
        private void MenuBind()
        {
            DataTable dt = new DataTable();
            dt = menubll.GetList("1=1");
            this.ChBLMenu.DataSource = dt;
            this.ChBLMenu.DataTextField ="MENUNAME";
            this.ChBLMenu.DataValueField ="MENUID";
            this.ChBLMenu.DataBind();
        }
        /// <summary>
        /// 动作绑定
        /// </summary>
        private void ActionBind()
        {
            DataTable dt = new DataTable();
            dt = actionbll.GetList("1=1");
            this.ChBLAction.DataSource = dt;
            this.ChBLAction.DataTextField = "ACTIONNAME";
            this.ChBLAction.DataValueField ="ACTIONID";
            this.ChBLAction.DataBind();
        }
        /// <summary>
        /// 按钮事件：授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEmpower_Click(object sender, EventArgs e)
        {
            //获取授权用户编号
            string str_username ="";//获取文本框中所有的用户名
            string[] sArray = str_username.Split(',');
            decimal userid = 0;
            //判断用户是否拥有权限;如果已有权限，删除已有权限
            if (userRolebll.ExistsUserid(userid))
            {
                string strwhere = "USERID=" + userid;
                userRolebll.deletelist(strwhere);//删除已有权限
                PowerAdd(userid);//用户授权
            }
            else
            {
                PowerAdd(userid);//用户授权
            }
        }
        /// <summary>
        /// 用户授权
        /// </summary>
        /// <param name="userid"></param>
        private void PowerAdd(decimal userid)
        {
            //获取角色编号
            //decimal roleid = -1;
            //if (null != this.RBLRole.SelectedValue.ToString() || "" != this.RBLRole.SelectedValue.ToString())
            //{
            //    roleid = Convert.ToDecimal(this.RBLRole.SelectedValue.ToString());
            //}

            ////获取菜单编号
            //List<int> menuID = GetMenuID();
            ////获取动作编号
            //List<int> ACTIONID = GetActionID();

            //int total = menuID.Count * ACTIONID.Count;//要添加数据的总记录数
            //if (total > 0)
            //{
            //    for (int i = 0; i < menuID.Count; i++)
            //    {
            //        for (int j = 0; j < ACTIONID.Count; j++)
            //        {
            //            bll.Add(GetModel(userid, roleid, menuID[i], ACTIONID[j]));
            //        }
            //    }

            //}
        }
        #endregion
        #region  日志管理
        //使用dataBindRepeater()方法绑定系统日志数据
        private void dataBindRepeater(string strwhere)
        {
            DataTable dt = new DataTable();
            dt = logbll.GetList(strwhere);

            AspNetPager3.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager3.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager3.PageSize;


            this.RptListLog.DataSource = pds; //定义数据源
            this.RptListLog.DataBind(); //绑定数据
        }
        /// <summary>
        /// 按钮事件：查询日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchLog_Click(object sender, EventArgs e)
        {
            string strwhere = "CREATEDATE>=to_date('" + this.TxtDate.Text + "','yyyy-MM-dd')";
            dataBindRepeater(strwhere);
            //DataTable dt = new DataTable();
            //dt = logbll.GetList(strwhere);
            //AspNetPager3.RecordCount = dt.Rows.Count;

            //PagedDataSource pds = new PagedDataSource();
            //pds.DataSource = dt.DefaultView;
            //pds.AllowPaging = true;
            //pds.CurrentPageIndex = AspNetPager3.CurrentPageIndex - 1;
            //pds.PageSize = AspNetPager3.PageSize;


            //this.RptListLog.DataSource = pds; //定义数据源
            //this.RptListLog.DataBind(); //绑定数据
            //Response.Redirect("~/ManageCenter/SysManager.aspx#tabs-4");
        }
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager3_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager3.CurrentPageIndex = e.NewPageIndex;
            dataBindRepeater("1=1");
        }
        #endregion
       
     
       

       
    }
}