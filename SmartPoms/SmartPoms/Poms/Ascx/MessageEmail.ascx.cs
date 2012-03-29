using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SmartPoms.Poms.Ascx {
    public partial class MessageEmail : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.lblError.Text = "";
                this.txtEmailAddress.Text = "";
                this.txtEmailContent.Text = "";
            }
        }

        protected void btnSend_Click(object sender, EventArgs e) {
            this.lblError.Text = "";

            /*校验输入*/
            if (CheckInput()) {
                try {
                    //设置邮件内容
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("771516041@qq.com", "舆情邮局管理员", Encoding.BigEndianUnicode); //发件人地址
                    mail.To.Add(txtEmailAddress.Text);  //收件人
                    mail.Subject = "舆情系统新邮件通知:" + DateTime.Now.ToLongDateString();  //标题
                    mail.Body = txtEmailContent.Text; //正文
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;

                    /*发送邮件*/
                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new NetworkCredential("771516041", "hyw_2007008*");
                    smtp.Host = "smtp.qq.com";
                    smtp.Port = 25;
                    smtp.Send(mail);

                    this.lblError.Text = "邮件已发送到对方邮箱，请注意查收！";
                } catch (Exception ex) {
                    this.lblError.Text = "发送失败：" + ex.Message;
                }
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