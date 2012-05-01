using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (checkinput())
            {
                //判断用户是否存在
                string u = txtUserName.Text.Trim();
                string p = txtPwd.Text.Trim();
                p = Smart.Security.MD5.MD5Encrypt(p).ToUpper();
                BLL.Base_User user = new BLL.Base_User();
                DataSet ds = new DataSet();
                ds = user.GetList(string.Format("UserName='{0}' and Userpwd='{1}'", u, p));

                //跳转到主页面
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    //setSession
                    Session["username"] = u;
                    Session["pwd"] = p;
                    Session["ssid"] = Session.SessionID;
                    Session["uid"] = ds.Tables[0].Rows[0]["UserId"];
                    Session["roleid"] = ds.Tables[0].Rows[0]["RoleId"];

                    Response.Cookies.Add(new HttpCookie("username", u));
                    Response.Cookies.Add(new HttpCookie("pwd", p));
                    Response.Cookies.Add(new HttpCookie("ssid", Session.SessionID));
                    Response.Cookies.Add(new HttpCookie("roleid", ds.Tables[0].Rows[0]["RoleId"].ToString()));
                    Response.Cookies.Add(new HttpCookie("uid", ds.Tables[0].Rows[0]["UserId"].ToString()));

                    //跳转
                    Response.Redirect("Default.aspx", true);
                }
                else
                {
                    lblmsg.Text = "用户名或密码错误";
                    txtUserName.Text = "";
                    txtPwd.Text = "";
                    txtUserName.Focus();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPwd.Text = "";
            lblmsg.Text = "";
        }

        private bool checkinput()
        {
            lblmsg.Text = "";
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                lblmsg.Text = "用户名不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                lblmsg.Text = "密码不能为空";
                return false;
            }

            return true;
        }
    }
}