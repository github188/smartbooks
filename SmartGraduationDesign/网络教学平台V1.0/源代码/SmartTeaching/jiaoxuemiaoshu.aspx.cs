﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching
{
    public partial class jiaoxuemiaoshu : System.Web.UI.Page
    {
        BLL.Base_News bll = new BLL.Base_News();
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
            string sec = "select * from base_news c where c.newstypeid in ( select a.newstypeid from base_newstype a where a.parentid = 1) order by createdate desc";
            dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            this.Repjiaoxuemiaoshu.DataSource = pds;
            this.Repjiaoxuemiaoshu.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDataSource();
        }
    }
}