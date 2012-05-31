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
            dataBindRepeater("1=1");//绑定日志数据
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