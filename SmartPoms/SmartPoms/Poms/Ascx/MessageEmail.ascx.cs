using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace SmartPoms.Poms.Ascx {
    public partial class MessageEmail : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.lblError.Text = "";
            }
        }

        protected void btnSend_Click(object sender, EventArgs e) {
            this.lblError.Text = "";

            /*校验输入*/
            if (!CheckInput()) {
                //设置邮件内容
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("", "超级管理员"); //发件人地址
                mail.To.Add(txtEmailAddress.Text);  //收件人
                mail.Subject = "新邮件通知:" + DateTime.Now.ToLongDateString();  //标题
                mail.Body = txtEmailContent.Text; //正文
                

                /*发送邮件*/
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("user", "pwd");
                smtp.Host = "";
                smtp.Port = 21;
                smtp.Send(mail);
            }
        }

        private bool CheckInput() {
            if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
                this.lblError.Text = "邮件接收地址不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(txtEmailContent.Text)) {
                this.lblError.Text = "邮件内容不能为空";
                return false;
            }

            return true;
        }
    }
}