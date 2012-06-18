using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Assess {
    public partial class List : System.Web.UI.Page {
        private BLL.BASE_ASSESS bll = new BLL.BASE_ASSESS();
        private BLL.BASE_ASSESS_TYPE bllType = new BLL.BASE_ASSESS_TYPE();
        private Utility.UserSession session;

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {                
                BindType();

                txtBeginTime.Text = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");
                txtEndTime.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                
                BindDataSource();
            }
        }

        private void BindDataSource() {
            System.Data.DataTable dt = new System.Data.DataTable();

            //获取数据
            decimal deptCode = Convert.ToDecimal(session.DEPTID);
            if (!string.IsNullOrWhiteSpace(Department1.ddlDepartment.SelectedValue)) {
                deptCode = Convert.ToDecimal(Department1.ddlDepartment.SelectedValue);
            }
            decimal typeCode = Convert.ToDecimal(ddlParentType.SelectedValue);
            DateTime beginTime = DateTime.Parse(txtBeginTime.Text.Trim());
            DateTime endTime = DateTime.Parse(txtEndTime.Text.Trim());

            dt = bll.GetList(deptCode, typeCode, beginTime, endTime);

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //清空现有数据源
            grvList.DataSource = null;
            grvList.DataBind();

            //绑定分页后的数据
            grvList.DataSource = pds;
            grvList.DataBind();

            litmsg.Visible = false;
            if (dt == null || dt.Rows.Count == 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>查询无数据!</div>";
            }
        }

        private void BindType() {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = bllType.GetBelongDepartmentData(Convert.ToInt32(session.DEPTID));

            ddlParentType.Items.Clear();
            RecursiveNode(ddlParentType, dt, 0, 0);
        }

        private void RecursiveNode(DropDownList ddl, DataTable dt, decimal rootId, int indent) {
            foreach (DataRow row in dt.Rows) {
                if (row["PARENTID"].ToString().Equals(rootId.ToString())) {
                    ListItem item = new ListItem();
                    for (int i = 0; i < indent; i++) {
                        if (i % 2 == 0) {
                            item.Text += "◆";
                        }
                        else {
                            item.Text += "--";
                        }
                    }
                    item.Text += row["NAME"].ToString();
                    item.Value = row["ID"].ToString();
                    ddl.Items.Add(item);

                    RecursiveNode(ddl, dt, Convert.ToDecimal(item.Value), indent += 2);
                    indent -= 2;
                }
            }
        }

        protected void grvList_RowCommand(object sender, GridViewCommandEventArgs e) {
            decimal id = Convert.ToDecimal(e.CommandArgument.ToString());
            switch (e.CommandName) {
                case "edit":
                    Response.Redirect(string.Format("Add.aspx?id={0}", id.ToString()), true);
                    break;
                case "del":
                    bll.UpdateStatusAsDelete(id);
                    break;
            }

            /*重新绑定数据*/
            BindDataSource();
        }
                
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindDataSource();
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            BindDataSource();
        }
    }
}