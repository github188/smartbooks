using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Assess {
    public partial class Add : System.Web.UI.Page {
        private Utility.UserSession session;
        private BLL.BASE_ASSESS_TYPE bllType = new BLL.BASE_ASSESS_TYPE();
        private BLL.BASE_ASSESS bll = new BLL.BASE_ASSESS();

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindDataSource();

                if (Request.QueryString["id"] != null) {
                    Entity.BASE_ASSESS model = new Entity.BASE_ASSESS();
                    model = bll.GetEntity(Convert.ToDecimal(Request.QueryString["id"]));
                    this.SetEntity(model);
                }
            }
        }

        private void BindDataSource() {
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

        private void SetEntity(Entity.BASE_ASSESS model) {
            Department1.ddlDepartment.SelectedValue = model.DEPTCODE.ToString();
            ddlParentType.SelectedValue = model.TYPEID.ToString();
            txtScore.Text = model.SCORE.ToString();
            txtREASON.Text = model.REASON;
            hidPrimary.Value = model.ID.ToString();
        }

        private Entity.BASE_ASSESS GetEntity() {
            Entity.BASE_ASSESS model = new Entity.BASE_ASSESS();

            model.DEPTCODE = Convert.ToDecimal(Department1.ddlDepartment.SelectedValue);
            model.TYPEID = Convert.ToDecimal(ddlParentType.SelectedValue);
            model.SCORE = Convert.ToDecimal(txtScore.Text);
            model.REASON = txtREASON.Text.Trim();
            model.ID = Convert.ToDecimal(hidPrimary.Value);

            model.STATUS = 0;
            model.TICKTIME = DateTime.Now;

            return model;
        }

        private bool CheckModel(Entity.BASE_ASSESS model) {

            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            Entity.BASE_ASSESS model = new Entity.BASE_ASSESS();
            model = this.GetEntity();

            if (this.CheckModel(model)) {
                if (model.ID < 0) {
                    //create
                    bll.Add(model);

                    txtREASON.Text = string.Empty;
                    txtScore.Text = "1"; 

                    litmsg.Visible = true;
                    litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>添加成功!</div>";
                }
                else {
                    //edit
                    bll.Update(model);

                    Response.Redirect("List.aspx", true);
                }
            }
        }
    }
}