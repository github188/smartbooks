using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartTeaching
{
    public partial class jiaoxuehudong : System.Web.UI.Page
    {
        BLL.Base_BBS bllbbs = new BLL.Base_BBS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
            }
        }

        private void bindDataSource()
        {
            DataTable dt = new DataTable();
            string sec = "select a.username,c.username as tousername, b.newscontent,b.createdate from base_user a,base_bbs b,base_user c where a.userid = b.userid and c.userid = b.touserid order by createdate desc";
            dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            this.bbsList.DataSource = pds;
            this.bbsList.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDataSource();
        }
    }
}