using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


/* 人工巡逻日志列表页 */
namespace SmartHyd.Patrol
{
    public partial class ArtificialPatrol : System.Web.UI.Page
    {

        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();
        private BLL.BASE_HANDLING handlingbll = new BLL.BASE_HANDLING();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////初始化数据
                
                if (null == Request.QueryString["deptid"] || "" == Request.QueryString["deptid"])
                {
                    ViewState["id"] = 1;
                    string sqlwhere = "1=1 AND DEPTID=1 AND STATE=0 order by PATROLID desc ";
                    bindDeptLog(sqlwhere);
                    // BindAcceptUnit();//绑定单位信息
                }
                else
                {
                    decimal id = Convert.ToDecimal(Request.QueryString["deptid"]);
                    ViewState["id"] = Request.QueryString["deptid"];
                    string sqlwhere = "1=1 AND DEPTID=" + id + " AND STATE=0 order by PATROLID desc ";
                    bindDeptLog(sqlwhere);
                    // BindAcceptUnit();//绑定单位信息
                }

            }
        }
        private void bindDeptLog(string sqlwhere)
        {
           
            DataTable dt = new DataTable();
            // dt = bll.GetDeptLog(deptCode, state);
            //获取全部人工巡逻日志
            dt = bll.GetPatrol(sqlwhere);
            if (dt != null && dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                this.gv_patrollist.DataSource = pds;
                this.gv_patrollist.DataBind();
            }
            else
            {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关巡逻记录!</div>";
            }
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            if (ViewState["id"] != null)
            {
                decimal id = Convert.ToDecimal(ViewState["id"]);
                string sqlwhere = "1=1 AND DEPTID=" + id + " AND STATE=0 order by PATROLID desc ";
                bindDeptLog(sqlwhere);
            }
        }
        /// <summary>
        /// 人工巡逻日志查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            string sqlwhere = string.Empty;
            if (ViewState["id"] != null)
            {
                decimal id = Convert.ToDecimal(ViewState["id"]);
                if (this.txt_startTime.Text == "")
                {
                    sqlwhere = "1=1 AND DEPTID=" + id + " AND STATE=0 order by PATROLID desc ";
                }
                else
                {
                    sqlwhere = "TICKTIME>=to_date('" + this.txt_startTime.Text + "','yyyy-MM-dd') AND DEPTID=" + id + " AND STATE=0 order by PATROLID desc ";
                }
            }
            bindDeptLog(sqlwhere);
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
        /// 删除巡逻日志
        /// </summary>
        /// <param name="?"></param>
        private void del(decimal id)
        {
            if (handlingbll.ExistsPid(id)) //判断日志编号下是否有巡查情况记录
            {
                //先删除该编号下巡查情况记录
                if (handlingbll.DelByPID(id))
                {
                    if (bll.del(id))
                    {
                        Response.Redirect("ArtificialPatrol.aspx");
                    }
                    else
                    {
                        //提示删除失败
                    }
                }
                else
                {
                    //提示删除失败
                }
            }
            else
            {
                if (bll.del(id))
                {
                    Response.Redirect("ArtificialPatrol.aspx");
                }
                else
                {
                    //提示删除失败
                }
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