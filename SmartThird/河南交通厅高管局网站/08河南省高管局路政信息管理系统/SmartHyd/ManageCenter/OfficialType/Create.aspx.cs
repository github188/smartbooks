using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.OfficialType {
    public partial class Create : System.Web.UI.Page {
        private Utility.UserSession userSession;
        private BLL.BASE_ARTICLE_TYPE bll = new BLL.BASE_ARTICLE_TYPE();

        protected void Page_Load(object sender, EventArgs e) {
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindingType();
            }
        }

        private void BindingType() {
            DataTable dt = new DataTable();
            dt = bll.GetList(string.Format("DEPTID={0}", userSession.DEPTID.ToString()));

            RecursiveTree(ddlTypeId, dt, 0);
        }

        private void RecursiveTree(DropDownList dropDownControl, DataTable dt, int rootId) {
            foreach (DataRow row in dt.Rows) {
                if(row["PARENT"].ToString().Equals(rootId.ToString())){
                    dropDownControl.Items.Add(new ListItem(
                    row["TYPENAME"].ToString(),
                    row["ID"].ToString()));

                    RecursiveTree(dropDownControl, dt, Convert.ToInt32(row["ID"].ToString()));
                }
            }
        }

        private Entity.BASE_ARTICLE_TYPE GetModel() {
            Entity.BASE_ARTICLE_TYPE model = new Entity.BASE_ARTICLE_TYPE();

            model.DEPTID = userSession.DEPTID;
            model.ID = Convert.ToInt32(hidPrimary.Value);
            model.PARENT = Convert.ToInt32(ddlTypeId.SelectedValue);
            model.SORT = Convert.ToInt32(txtSort.Text.Trim());
            model.STATUS = 0;
            model.SUMMARY = txtSummary.Text.Trim();
            model.TYPENAME = txtTitle.Text.Trim();
            return model;
        }

        private void SetModel(Entity.BASE_ARTICLE_TYPE model) {
            txtTitle.Text = model.TYPENAME;
            txtSummary.Text = model.SUMMARY;
            txtSort.Text = model.SORT.ToString();
            hidPrimary.Value = model.ID.ToString();
            ddlTypeId.SelectedValue = model.PARENT.ToString();
        }

        private bool CheckModel(Entity.BASE_ARTICLE_TYPE model) {
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>标题不能为空!</div>";
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSummary.Text)) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>描述不能为空!</div>";
                txtSummary.Focus();
                return false;
            }

            return true;
        }

        protected void btnAdd_Click(object sender, EventArgs e) {
            Entity.BASE_ARTICLE_TYPE model = new Entity.BASE_ARTICLE_TYPE();
            model = GetModel();

            if (CheckModel(model)) {

                if (model.ID < 0) {
                    bll.Add(model);
                }
                else {
                    bll.Update(model);
                }

                Response.Redirect("List.aspx", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("List.aspx", true);
        }
    }
}