using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class Term : UI.BaseUserControl {
        private BLL.BASE_TERM bll = new BLL.BASE_TERM();

        //加载
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindTermData();
                BinfTermTypeData();
            }
        }

        //从页面获取实体
        private Entity.BASE_TERM GetEntity() {
            return null;
        }

        //初始化实体到页面
        private void SetEntity(Entity.BASE_TERM model) {
        }

        //绑定装备类型数据
        private void BinfTermTypeData() {
            DataTable dt = new DataTable();
            ddlTermType.Items.Clear();
            foreach (DataRow dr in dt.Rows) {
                ddlTermType.Items.Add(new ListItem(
                    dr["TYPENAME"].ToString(),
                    dr["TYPEID"].ToString()));
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

        //提交
        protected void btnSubmit_Click(object sender, EventArgs e) {

        }

        //取消
        protected void btnCancel_Click(object sender, EventArgs e) {
            SetEntity(new Entity.BASE_TERM());
        }

        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindTermData();
        }
    }
}