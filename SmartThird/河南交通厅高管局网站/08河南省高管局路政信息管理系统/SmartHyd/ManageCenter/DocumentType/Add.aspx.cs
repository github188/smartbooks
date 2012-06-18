using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.DocumentType {
    public partial class Add : System.Web.UI.Page {
        private Utility.UserSession session;
        private BLL.BASE_DOCUMENT_TYPE bll = new BLL.BASE_DOCUMENT_TYPE();

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindType();

                if (Request.QueryString["id"] != null) {
                    Entity.BASE_DOCUMENT_TYPE model = new Entity.BASE_DOCUMENT_TYPE();
                    model = bll.GetEntity(Convert.ToDecimal(Request.QueryString["id"]));
                    this.SetEntity(model);
                }
            }
        }

        private void BindType() {
            DataTable dt = new DataTable();

            //get data
            dt = bll.GetList(session.DEPTID);

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

        private void SetEntity(Entity.BASE_DOCUMENT_TYPE model) {
            hidPrimary.Value = model.ID.ToString();
            ddlShare.SelectedValue = model.ISSHARE.ToString();
            txtName.Text = model.NAME;
            txtSort.Text = model.SORT.ToString();
            txtSummary.Text = model.SUMMARY;
            ddlParentType.SelectedValue = model.PARENTID.ToString();
        }

        private Entity.BASE_DOCUMENT_TYPE GetEntity() {
            Entity.BASE_DOCUMENT_TYPE model = new Entity.BASE_DOCUMENT_TYPE();
            model.DEPTCODE = session.DEPTID;
            model.ID = Convert.ToDecimal(hidPrimary.Value);
            model.ISSHARE = Convert.ToDecimal(ddlShare.SelectedValue);
            model.NAME = txtName.Text.Trim();
            model.SORT = Convert.ToDecimal(txtSort.Text.Trim());
            model.STATUS = 0;
            model.SUMMARY = txtSummary.Text.Trim();
            model.PARENTID = Convert.ToDecimal(ddlParentType.SelectedValue);
            return model;
        }

        private bool CheckModel(Entity.BASE_DOCUMENT_TYPE model) {
            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            Entity.BASE_DOCUMENT_TYPE model = new Entity.BASE_DOCUMENT_TYPE();
            model = this.GetEntity();

            if (this.CheckModel(model)) {
                if (model.ID < 0) {
                    bll.Add(model);

                    this.SetEntity(new Entity.BASE_DOCUMENT_TYPE());

                    this.BindType();

                    litmsg.Visible = true;
                    litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>添加成功!</div>";
                }
                else {
                    bll.Update(model);

                    Response.Redirect("List.aspx", true);
                }
            }
        }
    }
}