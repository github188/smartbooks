using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class MenuManage : System.Web.UI.UserControl {
        private BLL.BASE_MENU bllMenu = new BLL.BASE_MENU();
        private int inde = 0;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindingParentMenuNode();
            }
        }


        private Entity.BASE_MENU GetModel() {
            Entity.BASE_MENU model = new Entity.BASE_MENU();
            model.ICON = txtMenuIco.Text.Trim();
            model.MENUID = Convert.ToInt32(hidPrimary.Value);
            model.MENUINFO = txtSummary.Text.Trim();
            model.MENUNAME = txtMenuName.Text.Trim();
            model.MENUURL = txtMenuUrl.Text.Trim();
            model.PARENTID = Convert.ToInt32(ddlMenuParentNode.SelectedValue);
            model.STATUS = Convert.ToInt32(ddlState.SelectedValue);

            return model;
        }

        private void SetModel(Entity.BASE_MENU model) {
            txtMenuIco.Text = model.ICON;
            hidPrimary.Value = model.MENUID.ToString();
            txtSummary.Text = model.MENUINFO;
            txtMenuName.Text = model.MENUNAME;
            txtMenuUrl.Text = model.MENUURL;
            ddlMenuParentNode.SelectedValue = model.PARENTID.ToString();
            ddlState.SelectedValue = model.STATUS.ToString();
        }

        //绑定父级菜单
        private void BindingParentMenuNode() {
            DataTable dt = new DataTable();
            dt = bllMenu.GetList("1=1");
            ddlMenuParentNode.Items.Clear();
            ddlMenuParentNode.Items.Add(new ListItem("根节点分类", "0"));
            InitTreeNodes(ddlMenuParentNode, 0, dt, 0);
        }
        //递归绑定父级节点
        private void InitTreeNodes(DropDownList ddl, int parentId, DataTable dt, int indent) {
            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENTID"].ToString() == parentId.ToString()) {
                    inde += indent;
                    ListItem item = new ListItem();
                    for (int i = 0; i < inde; i++) {
                        item.Text += "-";
                    }
                    item.Text += dr["MENUNAME"].ToString();
                    item.Value = dr["MENUID"].ToString();
                    ddl.Items.Add(item);
                    InitTreeNodes(ddl, Convert.ToInt32(dr["MENUID"].ToString()), dt, 2);
                    inde -= 2;
                }
            }
        }
        //submit
        protected void btnSubmit_Click(object sender, EventArgs e) {
            Entity.BASE_MENU model = new Entity.BASE_MENU();
            model = GetModel();

            bllMenu.Add(model);

            Response.Redirect(Request.UrlReferrer.AbsoluteUri, true);
        }
    }
}