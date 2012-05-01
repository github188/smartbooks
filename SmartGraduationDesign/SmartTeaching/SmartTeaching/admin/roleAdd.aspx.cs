using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartTeaching.admin
{
    public partial class roleAdd : System.Web.UI.Page
    {
        BLL.Base_NewsType blltype = new BLL.Base_NewsType();
        BLL.Base_Role bllRole = new BLL.Base_Role();
        BLL.Base_UserRole bllUserRole = new BLL.Base_UserRole();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFunction();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                //add role
                string rolename = txtRoleName.Text.Trim();
                string summary = txtRoleSummary.Text.Trim();
                Entity.Base_Role roleModel = new Entity.Base_Role();
                roleModel.RoleName = rolename;
                roleModel.Description = summary;
                bllRole.Add(roleModel);

                //set user roles
                DataTable dt = new DataTable();
                dt = bllRole.GetList(string.Format("RoleName='{0}' and Description='{1}'", rolename, summary)).Tables[0];
                roleModel.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"].ToString());
                //roleModel.RoleName = dt.Rows[0]["RoleName"].ToString();
                //roleModel.Description = dt.Rows[0]["Description"].ToString();
                                
                for (int i = 0; i < chkFunctionList.Items.Count; i++)
                {
                    if (chkFunctionList.Items[i].Selected)
                    {
                        Entity.Base_UserRole userRoleModel = new Entity.Base_UserRole();
                        userRoleModel.UserId = 0;
                        userRoleModel.RoleId = roleModel.RoleId;
                        userRoleModel.NewsTypeId = Convert.ToInt32(chkFunctionList.Items[i].Value);

                        bllUserRole.Add(userRoleModel);
                    }
                }

                Response.Redirect("roleList.aspx", true);
            }
        }

        private bool CheckInput()
        {
            lblmsg.Text = "";

            if (string.IsNullOrEmpty(txtRoleName.Text))
            {
                lblmsg.Text = "角色名称不能为空";
                txtRoleName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtRoleSummary.Text))
            {
                lblmsg.Text = "角色描述不能为空";
                txtRoleSummary.Focus();
                return false;
            }

            return true;
        }

        private void BindFunction()
        {
            DataTable dt = new DataTable();
            dt = blltype.GetAllList().Tables[0];
            chkFunctionList.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                chkFunctionList.Items.Add(new ListItem(r["NewsTypeName"].ToString(),
                    r["NewsTypeId"].ToString()));
            }
        }
    }
}