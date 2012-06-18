using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.AssessType {
    public partial class Add : System.Web.UI.Page {
        private Utility.UserSession session;
        private BLL.BASE_ASSESS_TYPE bll = new BLL.BASE_ASSESS_TYPE();

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindDataSource();

                if (Request.QueryString["id"] != null) {
                    Entity.BASE_ASSESS_TYPE model = new Entity.BASE_ASSESS_TYPE();
                    model = bll.GetEntity(Convert.ToDecimal(Request.QueryString["id"]));
                    this.SetEntity(model);
                }
            }
        }

        private void BindDataSource() {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = bll.GetBelongDepartmentData(Convert.ToInt32(session.DEPTID));

            ddlParentType.Items.Clear();
            ddlParentType.Items.Add(new ListItem("根节点", "0"));
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

        private void SetEntity(Entity.BASE_ASSESS_TYPE model) {
            txtName.Text = model.NAME;
            txtSummary.Text = model.SUMMARY;
            txtScore.Text = model.SCORE.ToString();
            txtSort.Text = model.SORT.ToString();
            ddlParentType.SelectedValue = model.PARENTID.ToString();
        }

        private Entity.BASE_ASSESS_TYPE GetEntity() {
            Entity.BASE_ASSESS_TYPE model = new Entity.BASE_ASSESS_TYPE();

            model.NAME = txtName.Text;
            model.SUMMARY = txtSummary.Text;
            model.SCORE = Convert.ToDecimal(txtScore.Text);
            model.SORT = Convert.ToDecimal(txtSort.Text);
            model.PARENTID = Convert.ToDecimal(ddlParentType.SelectedValue);

            model.DEPTCODE = session.DEPTID;
            model.ID = Convert.ToDecimal(hidPrimary.Value);
            model.STATUS = 0;

            return model;
        }

        private bool CheckEntity(Entity.BASE_ASSESS_TYPE model) {
            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            litmsg.Visible = false;

            Entity.BASE_ASSESS_TYPE model = new Entity.BASE_ASSESS_TYPE();
            model = this.GetEntity();

            if (this.CheckEntity(model)) {
                if (model.ID < 0) {
                    bll.Add(model);

                    this.SetEntity(new Entity.BASE_ASSESS_TYPE());

                    this.BindDataSource();

                    litmsg.Visible = true;
                    litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>添加成功!</div>";
                }
                else {
                    if (bll.Update(model)) {
                        litmsg.Visible = true;
                        litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>更新成功!</div>";
                    }
                    else {
                        litmsg.Visible = true;
                        litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>更新失败!</div>";
                    }

                }
            }
        }
    }
}