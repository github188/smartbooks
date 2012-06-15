using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


/* 人工巡逻日志列表页 */
namespace SmartHyd.Patrol {
    public partial class ArtificialPatrol : System.Web.UI.Page {

        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                ////初始化数据
                if (null == Request.QueryString["deptid"] || "" == Request.QueryString["deptid"])
                {
                    ViewState["id"] = 0;
                    bindDeptLog(0);
                   // BindAcceptUnit();//绑定单位信息
                }
                else
                {
                    decimal id = Convert.ToDecimal(Request.QueryString["deptid"]);
                    ViewState["id"] = Request.QueryString["deptid"];
                    bindDeptLog(id);
                   // BindAcceptUnit();//绑定单位信息
                }
               
            }
        }

        private void bindDeptLog(decimal id)
        {
            string sqlwhere = "1=1 AND DEPTID=" + id + " AND STATE=0 order by PATROLID desc ";
            DataTable dt = new DataTable();
           // dt = bll.GetDeptLog(deptCode, state);
            //获取全部人工巡逻日志
            dt = bll.GetPatrol(sqlwhere);
            if (dt != null && dt.Rows.Count > 0) {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                this.gv_patrollist.DataSource = pds;
                this.gv_patrollist.DataBind();
            }
            else {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关巡逻记录!</div>"; 
            }
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            if (ViewState["id"] != null)
            {
                decimal id = Convert.ToDecimal(ViewState["id"]);
                bindDeptLog(id);
            }
        }

        /// <summary>
        /// 人工巡逻日志查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ok_Click(object sender, EventArgs e) {
           // int deptCode = 0;
           // int state = 0;
           // DateTime beginTime = DateTime.Now.AddDays(-100);
           // DateTime endTime = DateTime.Now;
           // DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
           //// if (this.txt_vehicleLicense.Text == "" && this.txt_startTime.Text == "" && this.txt_endTime.Text == "")
           // if (this.txt_startTime.Text == "" && this.txt_endTime.Text == "")
           // {
           //     //按单位查询
           //     deptCode = Convert.ToInt32(ddr.SelectedValue);

           // }
           // else
           // { 
           //     //综合查询
           //     deptCode = Convert.ToInt32(ddr.SelectedValue);
           //     beginTime = Convert.ToDateTime(this.txt_startTime.Text);
           //     endTime = Convert.ToDateTime(this.txt_endTime.Text);
           // }
           // bindDeptLog(beginTime, endTime, deptCode, state);
        }

        protected void gv_patrollist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                /*跳转到编辑页面*/
                case "edit":
                    Response.Redirect("PatrolEdit.aspx?id=" + id.ToString(), true);
                    break;
                /*跳转到详情页面*/
                case "view":
                    Response.Redirect("PatrolDetail.aspx?id=" + id.ToString(), true);
                    break;
                /*执行删除操作*/
                case "del":
                    del(id);
                    break;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="?"></param>
        private void del(decimal id)
        {
            if (bll.del(id))
            {
                Response.Redirect("ArtificialPatrol.aspx");
            }
            //Entity.BASE_PATROL model = bll.GetModel(id);
            //model.STATE = 1;
            //if (bll.update(model))
            //{
            //    Response.Redirect("ArtificialPatrol.aspx");
            //}
        }
    }
}