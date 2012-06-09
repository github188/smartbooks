using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.Patrol {
    public partial class ElectronicPatrol : System.Web.UI.Page {
        private BLL.BASE_OBSERVED bll = new BLL.BASE_OBSERVED();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindDeptLog();
            }
        }

        //绑定后数据
        private void BindDeptLog() {
            //初始化参数
            DateTime beginTime = DateTime.Now.AddDays(-5);
            DateTime endTime = DateTime.Now;
            int deptCode = 4;
            DataTable dt = new DataTable();

            //根据指定时间范围，获取某个部门下的电子巡逻日志数据
            dt = bll.GetDeptLog(beginTime, endTime, deptCode);
            //获取全部电子巡逻日志
            //dt = bll.GetObserved("1=1");
            if (dt != null && dt.Rows.Count > 0) {
                //初始化分页数据
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;


                //绑定分页后的数据

                this.gv_electroniclist.DataSource = pds;
                this.gv_electroniclist.DataBind();
            }
            else {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关巡逻记录!</div>"; 
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindDeptLog();
        }


        /// <summary>
        /// 电子巡逻日志查询
        /// </summary>
        protected void btn_ok_Click(object sender, EventArgs e) {

        }

        protected void gv_electroniclist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                /*跳转到编辑页面*/
                case "edit":
                    Response.Redirect("~/Patrol/ElectronicEdit.aspx?id=" + id.ToString(), true);
                    break;
                /*跳转到详情页面*/
                case "view":
                    Response.Redirect("~/Patrol/ElectronicEdit.aspx?id=" + id.ToString(), true);
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
            //if (bll.del(id))
            //{
            //    Response.Redirect("plan.aspx");
            //}
            Entity.BASE_OBSERVED model = bll.GetModel(id);
            model.STATE = 1;
            if (bll.update(model))
            {
                Response.Redirect("plan.aspx");
            }
        }
    }
}