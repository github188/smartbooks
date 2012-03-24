

namespace SmartPoms {
    using System;
    using SmartPoms.Entity;
    using Smart.Utility;

    public partial class AdminLogin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                ResultControleDefaultValue();
            }
            if (VerificationLoginUser()) {
                Response.Redirect("~/Default.aspx", true);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            /*用户输入校验*/
            if (CheckInput()) {
                string user = this.txtUserName.Text.Trim().Replace("'", "\"");
                string pwd = Smart.Security.MD5.MD5Encrypt(this.txtPassword.Text.Trim()).ToUpper();
                BLL.BASE_USER bllUser = new BLL.BASE_USER();

                /*监测用户登录*/
                if (bllUser.CheckLogin(user, pwd)) {
                    BASE_USER entity = bllUser.GetUserModel(user);
                    if (entity.RoleID.Count != 0 || entity.IsLimit == true) {
                        if (entity.Status != 0) {
                            /*更新用户最后一次登录时间*/
                            bllUser.UpdateLoginTime(entity.UserID);
                            /*用户角色信息加入Session*/
                            SmartPoms.Code.SessionBox.CreateUserSession(new Code.UserSession(
                                entity.UserID,
                                entity.UserName,
                                entity.RoleID,
                                entity.UserGroup,
                                entity.IsLimit,
                                entity.Status));
                            /*跳转到后台主页*/
                            Response.Redirect("~/poms/NegativeComments.aspx", true);
                        } else {
                            ResultControleDefaultValue();
                            this.lblError.Text = "用户或密码错误!";
                        }
                    } else {
                        ResultControleDefaultValue();
                        this.lblError.Text = "用户还未激活,请与管理员联系!";
                    }
                } else {
                    ResultControleDefaultValue();
                    this.lblError.Text = "用户或密码错误!";
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e) {
            ResultControleDefaultValue();
        }

        private void ResultControleDefaultValue() {
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtCaptche.Text = string.Empty;
            this.lblError.Text = string.Empty;
        }

        private bool CheckInput() {
            if (Request.Cookies["captche"] == null) {
                JScript.Alert("您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtUserName.Text)) {
                this.lblError.Text = "用户名不允许为空。";
                this.txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text)) {
                this.lblError.Text = "密码不允许为空。";
                this.txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtCaptche.Text)) {
                this.lblError.Text = "验证码不允许为空。";
                this.txtCaptche.Focus();
                return false;
            }
            if (this.txtCaptche.Text.Length < 4) {
                this.lblError.Text = "验证码位数错误。";
                this.txtCaptche.Focus();
                return false;
            }
            if (this.Request.Cookies["captche"].Value == null ||
                this.Request.Cookies["captche"].Value != this.txtCaptche.Text) {
                this.lblError.Text = "验证码错误。";
                this.txtCaptche.Text = "";
                this.txtCaptche.Focus();
                return false;
            }
            return true;
        }

        private bool VerificationLoginUser() {
            try {
                string username = Session["USER"].ToString();
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