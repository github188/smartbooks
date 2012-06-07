using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class SysLog : UI.BaseUserControl
    {
        private BLL.BASE_LOG bll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater();
            }
        }

        //使用dataBindToRepeater()方法绑定系统日志数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetList("1=1");
            if (dt != null && dt.Rows.Count > 0) {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                this.gv_log.DataSource = pds; //定义数据源
                this.gv_log.DataBind(); //绑定数据
            }
            else {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关系统日志记录!</div>"; 
            }
        }
    
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }

        //数据查询
        protected void btn_ok_Click(object sender, EventArgs e) {
            
        }
    }
}