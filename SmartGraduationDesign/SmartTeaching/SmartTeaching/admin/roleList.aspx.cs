using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class RoleList : System.Web.UI.Page
    {
        BLL.Base_Role bllRole = new BLL.Base_Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDataSource();
        }

        private void bindDataSource()
        {
            DataTable dt = new DataTable();
            dt = bllRole.GetAllList().Tables[0];

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            this.dlAdmin.DataSource = pds;
            this.dlAdmin.DataBind();
        }
    }
}