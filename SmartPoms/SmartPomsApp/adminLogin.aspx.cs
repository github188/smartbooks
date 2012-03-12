
namespace SmartPomsApp {
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Smart.ServiceFactory;
    using SmartPoms.ServiceInterfaces;
    using SmartPoms.Entity;

    public partial class adminLogin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                ResultControleDefaultValue();                
            }
            if (VerificationLoginUser()) {
                Response.Redirect("~/adminMain.aspx", true);
            }
        }
        //重置
        protected void imgBtnReset_Click(object sender, ImageClickEventArgs e) {
            ResultControleDefaultValue();
        }
        //登录
        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e) {
            if (CheckInput()) {
                string user = this.txtUserName.Text.Trim().Replace("'", "\"");
                string pwd = Smart.Security.MD5.MD5Encrypt(this.txtUserPwd.Text.Trim()).ToUpper();
                string captche = this.txtCaptche.Text.Trim();

                ILoginService loginService = ComponentFactory<ILoginService>.GetBLLPlugin();
                BASE_USER base_user = loginService.login(user, pwd);
                if (base_user != null) {
                    Session["username"] = base_user.USERNAME;
                    Session["pwd"] = base_user.USERPWD;
                    Session["uid"] = base_user.USERID;
                    Session["role"] = base_user.ROLEID;

                    Response.Redirect("adminMain.aspx", true);
                } else {
                    this.lblError.Text = "提示：登录失败!";
                    ResultControleDefaultValue();
                }
            }
        }

        private void ResultControleDefaultValue() {
            this.txtUserName.Text = string.Empty;
            this.txtUserPwd.Text = string.Empty;
            this.txtCaptche.Text = string.Empty;
            this.lblError.Text = string.Empty;
        }

        private bool CheckInput() {
            if (string.IsNullOrEmpty(this.txtUserName.Text)) {
                this.lblError.Text = "用户名不允许为空。";
                this.txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtUserPwd.Text)) {
                this.lblError.Text = "密码不允许为空。";
                this.txtUserPwd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtCaptche.Text)) {
                this.lblError.Text = "验证码不允许为空。";
                this.txtCaptche.Focus();
                return false;
            }
            return true;
        }

        private bool VerificationLoginUser() {
            try {
                string username = Session["username"].ToString();
                if (string.IsNullOrEmpty(username)) {
                    return false;
                }
            } catch {
                return false;
            }
            return true;
        }
    }
}