using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartHyd.Ascx {
    public partial class Department : System.Web.UI.UserControl {
        public event OnSelectedNodeChanged OnSelectedNodeChanged;
        private BLL.BASE_DEPT dept = new BLL.BASE_DEPT();
        private Utility.UserSession userSession;

        protected void Page_Load(object sender, EventArgs e) {
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                //获取数据源
                DataTable dt = new DataTable();
                dt = dept.GetUserWhereDepartment(userSession.USERNAME, -1);

                //递归部门列表
                ddlDepartment.Items.Clear();
                RecursiveNode(ddlDepartment, dt, Convert.ToInt32(userSession.DEPTID), 0);

                ddlDepartment.SelectedValue = userSession.DEPTID.ToString();
                Session["deptcode"] = userSession.DEPTID;
            }
        }

        private void RecursiveNode(DropDownList ddl, DataTable dt, int rootId, int indent) {
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
                    item.Text += row["DPTNAME"].ToString();
                    item.Value = row["DEPTID"].ToString();
                    ddl.Items.Add(item);

                    RecursiveNode(ddl, dt, Convert.ToInt32(item.Value), indent += 2);
                    indent -= 2;
                }
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            Session["deptcode"] = ddlDepartment.SelectedValue;
            if (OnSelectedNodeChanged != null) {
                OnSelectedNodeChanged(sender, ddlDepartment.SelectedValue);
            }
        }
    }
}