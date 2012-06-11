using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd {
    public partial class AdminLogin : System.Web.UI.Page {
        private BLL.BASE_USER bll = new BLL.BASE_USER();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
            }
        }

        /// <summary>
        /// 验证提交
        /// </summary>
        /// <returns>true通过,false不通过</returns>
        private bool CheckFormSubmit() {
            litMessage.Text = string.Empty;

            //空值校验
            if (string.IsNullOrEmpty(txtUserName.Text.Trim())) {                
                litMessage.Text = "用户名不能为空!";
                txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim())) {
                litMessage.Text = "密码不能为空!";
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCode.Text.Trim())) {
                litMessage.Text = "验证码不能为空!";
                txtCode.Focus();
                return false;
            }

            //非法字符校验
            if (txtUserName.Text.Trim().Contains("'")) {
                litMessage.Text = "用户名包含非法字符!";
                ResetForm();
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Contains("'")) {
                litMessage.Text = "密码包含非法字符!";
                ResetForm();
                txtPassword.Focus();
                return false;
            }

            //长度校验
            if (txtUserName.Text.Length > 18) {
                litMessage.Text = "超出用户名允许的最大长度!";
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text.Length > 18) {
                litMessage.Text = "超出密码允许的最大长度!";
                txtPassword.Focus();
                return false;
            }
            if (txtCode.Text.Length != 4) {
                litMessage.Text = "验证码要求由4位数字组成!";
                txtCode.Focus();
                return false;
            }

            //验证码正确性校验
            if (Request.Cookies["code"] != null) {
                if (!Request.Cookies["code"].Value.ToUpper().Equals(txtCode.Text.Trim().ToUpper())) {
                    litMessage.Text = "验证码错误!";
                    txtCode.Text = string.Empty;
                    txtCode.Focus();                   
                    return false;
                }
            } else {
                litMessage.Text = "无法检测到您的会话验证码!";
                txtCode.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 重置文本框
        /// </summary>
        private void ResetForm() {
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtCode.Text = string.Empty;

            txtUserName.Focus();
        }

        //提交
        protected void btnSubmit_Click(object sender, EventArgs e) {
            //校验输入            
            if (CheckFormSubmit()) {
                string username = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();

                password = Smart.Security.Encrypter.Encrypt(password, ConfigurationManager.AppSettings["EncryptKey"]);

                Entity.BASE_USER entity = bll.GetUser(username, password);
                if (entity != null) {
                    //登录成功
                    //加入Session
                    Utility.UserSession session = new Utility.UserSession(Convert.ToInt32(entity.USERID));

                    Session["user"] = session;

                    //放入cookie
                    Response.Cookies.Add(new HttpCookie("uid", session.USERID.ToString()));
                    Response.Cookies.Add(new HttpCookie("dpt", session.DEPTID.ToString()));

                    //301页面跳转
                    Response.Redirect("~/AdminDefault.aspx", true);
                } else {
                    //登录失败
                    ResetForm();

                    litMessage.Text = "用户名或密码错误！";
                }
            }
        }
        //重置
        protected void btnReset_Click(object sender, EventArgs e) {
            ResetForm();
        }
    }
}