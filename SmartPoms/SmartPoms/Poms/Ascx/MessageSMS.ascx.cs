using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartPoms.Poms.Ascx {
    public partial class MessageSMS : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.lblError.Text = "";
            }
        }

        protected void btnSend_Click(object sender, EventArgs e) {
            this.lblError.Text = "";
            /*校验输入*/
            if (CheckInput()) {
                string phones = txtPhones.Text;
                string content = txtSmsContent.Text.Trim();
                string res = Smart.Sms.SendSms.SendKxcomcn(phones, content);
                if (res.Equals("0")) {
                    lblError.Text = "发送成功";
                } else {
                    lblError.Text = "发送失败，请重新发送！";
                }
            }
        }

        private bool CheckInput() {
            if (string.IsNullOrEmpty(txtPhones.Text)) {
                this.lblError.Text = "手机号码不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(txtSmsContent.Text)) {
                this.lblError.Text = "短信内容不能为空";
                return false;
            }

            return true;
        }
    }
}