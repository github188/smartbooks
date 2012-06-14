using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.MenuManage {
    public partial class List : System.Web.UI.Page {
        private BLL.BASE_MENU bllMenu = new BLL.BASE_MENU();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                //绑定菜单分类
                //BindingParentMenuNode();

                //绑定菜单列表
                GetMenuList();
            }
        }
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetMenuList();
        }

        private void GetMenuList() {
            DataTable dt = new DataTable();
            dt = bllMenu.GetList("1=1");

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
    }
}