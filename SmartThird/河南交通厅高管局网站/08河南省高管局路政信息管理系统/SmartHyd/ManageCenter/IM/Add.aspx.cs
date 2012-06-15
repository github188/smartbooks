using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SmartHyd.ManageCenter.IM {
    public partial class Add : System.Web.UI.Page {
        private Utility.UserSession userSession;
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();
        private BLL.BASE_USER bllUser = new BLL.BASE_USER();

        protected void Page_Load(object sender, EventArgs e) {
            userSession = (Utility.UserSession)Session["user"];

            if (Request.QueryString["id"] != null) {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Entity.BASE_MESSAGE m = new Entity.BASE_MESSAGE();
                m = bll.GetEntity(id);

                Entity.BASE_USER userModel = new Entity.BASE_USER();
                userModel = bllUser.GetUser(Convert.ToInt32(m.SENDER));

                txtAccept.Text = userModel.USERNAME;
            }
        }

        private bool CheckInput() {
            if (string.IsNullOrWhiteSpace(txtContent.Text.Trim())) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>不能发送空消息!</div>";
                txtContent.Focus();
                return false;
            }

            if (txtContent.Text.Length > 500) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>内容过长!</div>";
                txtContent.Focus();
                return false;
            }

            string reg = @"[^0-9a-zA-Z,]";
            if (Regex.Matches(txtAccept.Text, reg).Count > 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>消息接收者用户名错误!</div>";
                txtAccept.Focus();
                return false;
            }

            return true;
        }

        protected void btnSend_Click(object sender, EventArgs e) {
            litmsg.Visible = false;
            if (!CheckInput()) {
                return;
            }
            //split 接收者
            string[] acceptUser = txtAccept.Text.Split(',');

            //发送
            for (int i = 0; i < acceptUser.Length; i++) {
                Entity.BASE_MESSAGE m = new Entity.BASE_MESSAGE();
                m.MESSAGEBODY = txtContent.Text.Trim();
                m.SENDDATE = DateTime.Now;
                m.SENDER = userSession.USERID;
                m.STATE = 0;

                //根据用户ID获取Model
                Entity.BASE_USER userModel = new Entity.BASE_USER();
                userModel = bllUser.GetUser(acceptUser[i].ToString());

                m.TOUSER = userModel.USERID;    //接收者

                bll.Add(m);

                //短信提醒
                if (chkSMSAlert.Checked) {
                    string smsContent = "";
                    if (txtContent.Text.Length > 70) {
                        smsContent = txtContent.Text.Substring(0, 65) + "...";
                    }
                    Smart.Sms.SendSms.Send1086Com(userModel.PHONE, smsContent);
                }
            }
            //提示发送成功
            litmsg.Visible = true;
            litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>消息发送成功!</div>";
            txtAccept.Focus();

            txtAccept.Text = "";
            txtContent.Text = "";
            chkSMSAlert.Checked = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("List.aspx", true);
        }
    }
}