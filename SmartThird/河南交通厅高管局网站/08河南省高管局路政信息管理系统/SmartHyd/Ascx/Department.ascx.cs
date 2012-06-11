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
        private int inde = 0;

        protected void Page_Load(object sender, EventArgs e) {
            Utility.UserSession session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                DataTable dt = new DataTable();
                dt = dept.GetUserWhereDepartment(session.USERNAME, 0);
                BindingControl(this.ddlDepartment, dt);
                ddlDepartment.SelectedValue = session.DEPTID.ToString();
                Session["deptcode"] = session.DEPTID;
            }
        }

        private void BindingControl(DropDownList ddl, DataTable dt) {
            ddl.Items.Clear();
            InitTreeNodes(ddl, 0, dt, 0);
            if (ddlDepartment.Items.Count != 0) {
                ddlDepartment.SelectedIndex = 0;
                Session["deptcode"] = ddlDepartment.SelectedValue;
            }
        }

        private void InitTreeNodes(DropDownList ddl, int parentId, DataTable dt, int indent) {            
            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENTID"].ToString() == parentId.ToString()) {
                    inde += indent;
                    ListItem item = new ListItem();
                    for (int i = 0; i < inde; i++) {
                        item.Text += "-";
                    }
                    item.Text += dr["DPTNAME"].ToString();
                    item.Value = dr["DEPTID"].ToString();
                    ddl.Items.Add(item);
                    InitTreeNodes(ddl, Convert.ToInt32(dr["DEPTID"].ToString()), dt, 2);
                    inde -= 2;
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