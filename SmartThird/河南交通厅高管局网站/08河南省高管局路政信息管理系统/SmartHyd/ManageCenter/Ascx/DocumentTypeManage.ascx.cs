using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {

    public partial class DocumentTypeManage : UI.BaseUserControl {
        private BLL.BASE_ARTICLE_TYPE bll = new BLL.BASE_ARTICLE_TYPE();
        private Utility.UserSession userSession;
        private int inde = 0;
        private int deptCode = 0;   //部门ID编号

        #region 方法定义
        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            //按分类浏览部门下档案分类数据
            Department2.OnSelectedNodeChanged +=new SmartHyd.Ascx.OnSelectedNodeChanged(Department2_OnSelectedNodeChanged);

            userSession = (Utility.UserSession)Session["user"];
            deptCode = Convert.ToInt32(userSession.DEPTID);

            if (!IsPostBack) {
                BindData();

               
            }
        }

        

        //绑定数据(分类节点)
        private void BindData() {
            DataTable dt = new DataTable();
            dt = bll.GetDeptNodeData(deptCode);

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            
            this.RptList.DataSource = pds; //定义数据源
            this.RptList.DataBind(); //绑定数据
        }
        
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

      

        //分页按钮事件
        protected void RptList_ItemCommand(object source, RepeaterCommandEventArgs e) {
            switch (e.CommandName) {                
                //删除
                case "delete":
                    bll.Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    break;
            }

            Response.Redirect("DocumentTypeManage.aspx", true);
        }
        //按部门浏览分类数据
        private void Department2_OnSelectedNodeChanged(object sender, object value) {
            deptCode = Convert.ToInt32(value);
            BindData();
        }

        protected void btn_addDtype_Click(object sender, ImageClickEventArgs e) {
            Response.Redirect("../Official/DocumentEdit.aspx");
        }
    }
}