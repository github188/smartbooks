﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class Term : UI.BaseUserControl {
        private BLL.BASE_TERM bll = new BLL.BASE_TERM();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();

        //加载
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindTermData();
               
            }
        }
     

        //绑定装备分页数据
        private void BindTermData() {
            DataTable dt = new DataTable();
            int deptId = 0; //当前用户所属部门编号
            dt = bll.GetTermList(deptId);

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            repList.DataSource = pds;
            repList.DataBind();
        }

        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindTermData();
        }
    }
}