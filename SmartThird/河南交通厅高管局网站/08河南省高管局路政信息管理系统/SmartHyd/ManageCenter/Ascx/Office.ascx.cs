using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Office : UI.BaseUserControl
    {
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_PLAN planbll = new BLL.BASE_PLAN();
        private BLL.BASE_AFFICHE affichebll = new BLL.BASE_AFFICHE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserBind();//绑定用户
                dataBindToRepeater();//绑定事务信息
                dataBindRepeater();//绑定电子公告信息
            }
        }
        #region 即时通讯
        /// <summary>
        /// 用户绑定
        /// </summary>
        public void UserBind()
        {
            DataTable dt = new DataTable();

            dt = userbll.GetList("1=1");
            this.CBLUser.DataSource = dt;
            this.CBLUser.DataTextField = "USERNAME";
            this.CBLUser.DataValueField = "USERID";
            this.CBLUser.DataBind();
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
        #endregion
        #region  事务提醒
        //使用dataBindToRepeater()方法绑定事务数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = planbll.GetPlanList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.repList.DataSource = pds; //定义数据源
            this.repList.DataBind(); //绑定数据
        }
        /// <summary>
        /// //分页事件 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
        #endregion
        #region  电子公告
        //使用dataBindRepeater()方法绑定电子公告数据
        private void dataBindRepeater()
        {
            DataTable dt = new DataTable();
            dt = affichebll.GetAfficheList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptAffiche.DataSource = pds; //定义数据源
            this.RptAffiche.DataBind(); //绑定数据
        }
        /// <summary>
        /// //分页事件 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager2.CurrentPageIndex = e.NewPageIndex;
            dataBindRepeater();
        }
        #endregion
    }
}