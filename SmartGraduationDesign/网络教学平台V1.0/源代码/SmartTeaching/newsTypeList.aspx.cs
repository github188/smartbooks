using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartTeaching
{
    public partial class newsTypeList : System.Web.UI.Page
    {
        BLL.Base_News bll = new BLL.Base_News();
        int id=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    bindDataSource(id);
                }
                catch { }
            }
        }

        private void bindDataSource(int num)
        {
            DataTable dt = new DataTable();
            dt = bll.GetList(10000, "NewsTypeId=" + num.ToString(), "CreateDate DESC").Tables[0];

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            this.reGsNew.DataSource = pds;
            this.reGsNew.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDataSource(id);
        }
    }
}