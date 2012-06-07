using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace SmartHyd.ManageCenter.UserManager {
    public partial class UserCenter : System.Web.UI.Page {

        private BLL.BASE_USER bll = new BLL.BASE_USER();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (null == Request.QueryString["deptid"] || "" == Request.QueryString["deptid"]) {

                    BindUserList(4);//绑定用户列表

                } else {
                    decimal deptid = Convert.ToDecimal(Request.QueryString["deptid"]);//获取部门编号
                    if (null == Request.QueryString["userid"] || "" == Request.QueryString["userid"]) {
                        BindUserList(deptid);//绑定用户列表
                    } else {
                        decimal userid = Convert.ToDecimal(Request.QueryString["userid"]);
                        DelUser(userid);//删除用户
                        BindUserList(deptid);//绑定用户列表
                    }
                }
            }
        }
        

    /// <summary>
        /// 用户数据绑定
        /// </summary>
        private void BindUserList(decimal DEPTID) {
            DataTable dt = new DataTable();

            dt = bll.GetList("DEPTID=" + DEPTID);//获取部门下用户
            if (dt != null && dt.Rows.Count > 0) {
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                //绑定分页后的数据
                repList.DataSource = pds;
                repList.DataBind();
            } else {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关巡逻记录!</div>"; 
            }
        }

        /// <summary>
        /// //分页事件 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindUserList(4);
        }


        #region 删除用户：Update()修改用户；DelUser()从用户表中删除用户
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool Update(Entity.BASE_USER model) {
            return bll.Update(model);
        }
        /// <summary>
        /// 从用户表中根据用户编号删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private bool DelUser(decimal userId) {
            return bll.Del(userId);
        }
        #endregion
    }
}