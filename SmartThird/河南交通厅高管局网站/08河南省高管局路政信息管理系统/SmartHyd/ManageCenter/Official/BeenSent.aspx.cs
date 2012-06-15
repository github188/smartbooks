using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Official {
    public partial class BeenSent : System.Web.UI.Page {
        private Utility.UserSession userSession;
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private int typeId = -1;


        protected void Page_Load(object sender, EventArgs e) {
            //选定节点改变时触发的事件
            TreeView1.OnSelectedNodeChanged += new SmartHyd.Ascx.OnSelectedNodeChanged(TreeView1_OnSelectedNodeChanged);
            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                //绑定发文列表数据
                BindPublichList();
            }
        }

        //绑定发文列表数据
        private void BindPublichList() {
            DataTable dt = new DataTable();

            /*初始化档案分类编号,-1获取全部分类下数据*/
            if (typeId <= 0) {
                typeId = -1;
            }

            /*发文列表数据*/
            dt = bll.GetPublishList(Convert.ToInt32(userSession.DEPTID), typeId);


            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            grvPublishList.DataSource = null;
            grvPublishList.DataBind();

            grvPublishList.DataSource = pds;
            grvPublishList.DataBind();

            /*查询结果提示信息*/
            if (dt == null || dt.Rows.Count <= 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无公文数据!</div>";
            }
            else {
                litmsg.Visible = false;
            }
        }

        //发文列表分页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindPublichList();
        }

        //选定节点改变时触发的事件
        private void TreeView1_OnSelectedNodeChanged(object sender, object value) {
            typeId = Convert.ToInt32(value.ToString());

            //重新绑定发文列表
            BindPublichList();
        }

        protected void grvPublishList_RowCommand(object sender, GridViewCommandEventArgs e) {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName) {                
                /*更新公文状态为删除*/
                case "delete":
                    bll.UpdateState(3, id);
                    Response.Redirect("~/ManageCenter/Official/Trash.aspx", true);/*垃圾箱*/
                    break;                
                /*跳转到详情页面*/
                case "detail":
                    Response.Redirect("~/ManageCenter/Official/Detail.aspx?id=" + id.ToString(), true);
                    break;
                /*跳转到结贴页面*/
                case "checkout":
                    Response.Redirect("~/ManageCenter/Official/CheckOut.aspx?id=" + id.ToString(), true);
                    break;
            }
        }
    }
}