using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class userAdd : System.Web.UI.Page
    {
        private BLL.Base_User user = new BLL.Base_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoles();
                BindFunctionl();
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Entity.Base_User model = new Entity.Base_User();
                    model = user.GetModel(id);
                    txtnum.Text = model.UserId.ToString();
                    txtusername.Text = model.UserName;
                    //txtpwd.Text = model.Userpwd;
                }
                catch { }
            }
        }

        private void BindRoles()
        {
            BLL.Base_Role roles = new BLL.Base_Role();
            DataTable dt = new DataTable();
            dt = roles.GetAllList().Tables[0];
            this.rdoRoles.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                rdoRoles.Items.Add(new ListItem(r["RoleName"].ToString(), r["RoleId"].ToString()));
            }
            if (rdoRoles.Items.Count != 0)
            {
                rdoRoles.SelectedIndex = 0;
            }
        }

        private void BindFunctionl()
        {
            //BLL.Base_NewsType ts = new BLL.Base_NewsType();
            //DataTable dt = new DataTable();
            //dt = ts.GetAllList().Tables[0];
            //chkFunctionList.Items.Clear();
            //foreach (DataRow r in dt.Rows)
            //{
            //    chkFunctionList.Items.Add(new ListItem(r["NewsTypeName"].ToString(), r["NewsTypeId"].ToString()));
            //}
            //for (int i = 0; i < chkFunctionList.Items.Count; i++)
            //{
            //    chkFunctionList.Items[i].Selected = true;
            //}
        }

        private bool checkinput()
        {
            lblmsg.Text = "";
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                txtusername.Focus();
                lblmsg.Text = "用户名不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(txtpwd.Text))
            {
                txtpwd.Focus();
                lblmsg.Text = "密码不能为空";
                return false;
            }

            return true;
        }

        private Entity.Base_User GetEntity()
        {
            Entity.Base_User e = new Entity.Base_User();
            e.UserId = Convert.ToInt32(txtnum.Text.Trim());
            e.UserName = txtusername.Text.Trim();
            e.Userpwd = Smart.Security.MD5.MD5Encrypt(txtpwd.Text.Trim()).ToUpper();
            e.RoleId = Convert.ToInt32(rdoRoles.SelectedValue);
            return e;
        }

        private Entity.Base_User GetEntity(int num)
        {
            return user.GetModel(num);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (checkinput())
            {
                Entity.Base_User entity = GetEntity();
                if (entity.UserId < 0)
                {
                    //添加
                    if (user.Add(entity) > 0)
                    {
                        //设定角色和功能模块权限
                        //DataTable dt = new DataTable();
                        //dt = user.GetList(string.Format("UserName='{0}' AND Userpwd='{1}'", entity.UserName, entity.Userpwd)).Tables[0];
                        //BLL.Base_UserRole userRole = new BLL.Base_UserRole();
                        //for (int i = 0; i < chkFunctionList.Items.Count; i++)
                        //{
                        //    if (chkFunctionList.Items[i].Selected)
                        //    {
                        //        Entity.Base_UserRole model = new Entity.Base_UserRole();
                        //        model.NewsTypeId = Convert.ToInt32(chkFunctionList.Items[i].Value);
                        //        model.RoleId = Convert.ToInt32(rdoRoles.SelectedValue);
                        //        model.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                                
                        //        BLL.Base_UserRole bllRole = new BLL.Base_UserRole();
                        //        bllRole.Add(model);
                        //    }
                        //}

                        //成功
                        Response.Redirect("userList.aspx");
                    }
                    else
                    {
                        //失败
                        lblmsg.Text = "添加失败";
                    }
                }
                else
                {
                    //修改
                    if (user.Update(entity))
                    {
                        //设定角色和功能模块权限
                        //BLL.Base_UserRole userRole = new BLL.Base_UserRole();
                        //for (int i = 0; i < chkFunctionList.Items.Count; i++)
                        //{
                        //    if (chkFunctionList.Items[i].Selected)
                        //    {
                        //        Entity.Base_UserRole model = new Entity.Base_UserRole();
                        //        model.NewsTypeId = Convert.ToInt32(chkFunctionList.Items[i].Value);
                        //        model.RoleId = Convert.ToInt32(rdoRoles.SelectedValue);
                        //        model.UserId = entity.UserId;

                        //        BLL.Base_UserRole bllRole = new BLL.Base_UserRole();
                        //        bllRole.Update(model);
                        //    }
                        //}

                        //成功
                        Response.Redirect("userList.aspx");
                    }
                    else
                    {
                        //失败
                        lblmsg.Text = "修改失败";
                    }
                }
            }
        }
    }
}