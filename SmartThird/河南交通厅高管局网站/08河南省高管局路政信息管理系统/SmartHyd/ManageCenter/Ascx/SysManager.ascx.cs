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
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataBindToRepeater("1=1");//绑定部门数据
             BindUserList();   //绑定用户数据
            dataBindRepeater();//绑定日志数据
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
        #endregion
        #region  日志管理
        //使用dataBindRepeater()方法绑定系统日志数据
        private void dataBindRepeater()
        {
            DataTable dt = new DataTable();
            dt = logbll.GetList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptListLog.DataSource = pds; //定义数据源
            this.RptListLog.DataBind(); //绑定数据
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager3_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager3.CurrentPageIndex = e.NewPageIndex;
            dataBindRepeater();
        }
        #endregion

        //添加用户
        protected void btnAddUser_Click(object sender, EventArgs e) {
            Server.Transfer("~/ManageCenter/UserManage.aspx");
        }
    }
}