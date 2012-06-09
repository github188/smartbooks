using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace SmartHyd.ManageCenter.UserManager
{
    public partial class UserCenter : System.Web.UI.Page
    {
        private BLL.BASE_USER bll = new BLL.BASE_USER();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // string aa = Request.QueryString["action"];
                if (null == Request.QueryString["deptid"] || "" == Request.QueryString["deptid"])
                {
                    //初始化用户列表：默认4代表河南省交通运输厅高速公路管理局下的用户
                    BindUserList(4);//绑定用户列表
                    ViewState["deptid"] = 4;//用于存储当前部门编号
                }
                else
                {
                    decimal deptid = Convert.ToDecimal(Request.QueryString["deptid"]);//获取部门编号
                    ViewState["deptid"] = deptid;//用于存储当前部门编号
                    if (null == Request.QueryString["userid"] || "" == Request.QueryString["userid"])
                    {
                        //判读用户编号是否为空；
                        BindUserList(deptid);//绑定用户列表
                    }
                    else
                    {//不为空执行删除操作
                        if (Request.QueryString["action"] == "del")
                        {

                            int userid = Convert.ToInt32(Request.QueryString["userid"]);
                            Updatestate(userid);//删除用户
                            BindUserList(deptid);//绑定用户列表
                        }
                        BindUserList(deptid);//绑定用户列表
                    }
                }
            }
        }


        /// <summary>
        /// 用户数据绑定
        /// </summary>
        private void BindUserList(decimal DEPTID)
        {
            DataTable dt = new DataTable();

            dt = bll.GetList("DEPTID=" + DEPTID);//获取部门下用户
            if (dt != null && dt.Rows.Count > 0)
            {
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
            else
            {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关单位用户!</div>";
            }
        }

        /// <summary>
        /// //分页事件 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindUserList(4);
        }
        /// <summary>
        /// 按钮事件：跳转到添加用户页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            //传递当前部门编号
            // Response.Redirect("UserEdit.aspx?deptid=" + ViewState["deptid"]);
            Response.Redirect("UserEdit.aspx");
        }
        public void AjaxAlert(UpdatePanel uPanel, string strMsg)
        {
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "", "alert('" + strMsg + "');", true);
        }
        #region 删除用户：Update()修改用户；DelUser()从用户表中删除用户
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private void Updatestate(int id)
        {
            Entity.BASE_USER model = bll.GetUser(id);
            model.STSTUS = 1;
            if (bll.Update(model))
            {
                AjaxAlert(this.UpdatePanel1, "删除成功！");
            }
            else
            {
                AjaxAlert(this.UpdatePanel1, "删除失败！");
            }
        }
        /// <summary>
        /// 从用户表中根据用户编号删除用户
        /// </summary>
        /// <param name="userId"></param>
        private void DelUser(decimal userId)
        {
            if (bll.Del(userId))
            {
                AjaxAlert(this.UpdatePanel1, "删除成功！");
            }
            else
            {
                AjaxAlert(this.UpdatePanel1, "删除失败！");
            }
        }
        #endregion

    }
}