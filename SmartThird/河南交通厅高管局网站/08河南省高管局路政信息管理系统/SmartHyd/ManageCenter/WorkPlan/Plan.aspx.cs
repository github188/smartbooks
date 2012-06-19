using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.WorkPlan
{
    public partial class Plan : System.Web.UI.Page
    {
        private BLL.BASE_PLAN bll = new BLL.BASE_PLAN();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater("1=1");
            }
        }
        //使用dataBindToRepeater()方法绑定公文数据
        private void dataBindToRepeater(string sqlwhere)
        {
            DataTable dt = new DataTable();
            dt = bll.GetPlanList(sqlwhere);
            if (dt != null && dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                this.gv_log.DataSource = pds; //定义数据源
                this.gv_log.DataBind(); //绑定数据
            }
            else
            {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关事务记录!</div>";
            }
        }

        private void delplan(decimal planid)
        {
            Entity.BASE_PLAN model = new Entity.BASE_PLAN();
            model.CALENDARID = planid;
            model.STATE = 1;//更改事务状态为删除
            bll.update(model);
            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        /// <summary>
        /// 按钮事件：查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            string strwhere = string.Empty;

            if ("" == this.txt_Time.Text)
            { //根据事务类型查询
                strwhere = "CALENDARTYPE='" + this.DDLType.SelectedItem.Text + "'";
            }
            else
            {
                strwhere = "CALENDARTYPE='" + this.DDLType.SelectedItem.Text + "' and START_DATE=to_date('" + this.txt_Time.Text + "','yyyy-MM-dd')";
            }
            dataBindToRepeater(strwhere);
        }
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater("1=1");
        }

        protected void gv_log_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                /*跳转到编辑页面*/
                case "edit":
                    Response.Redirect("PlanEdit.aspx?planid=" + id.ToString(), true);
                    break;
                /*执行删除操作*/
                case "del":
                    del(id);
                    // Response.Redirect("~/ManageCenter/DocumentDetail.aspx?id=" + id.ToString(), true);
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
                Response.Redirect("plan.aspx");
            }
            //Entity.BASE_PLAN model = bll.GetModel(id);
            //model.STATE = 1;
            //if (bll.update(model))
            //{
            //    Response.Redirect("plan.aspx");
            //}
        }
    }
}