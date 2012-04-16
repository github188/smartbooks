using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using StationModel;
using PubClass;

public partial class management_EditPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck("timeout.aspx");
            UserInfo info = (UserInfo)Session["StationUser"];
            txtName.Text = info.U_LoginName;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       UserInfo info = (UserInfo)Session["StationUser"];
        if (txtOldPwd.Text == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入原始密码");
            txtOldPwd.Focus();
            return;
        }
        string strPwd = CommonFunction.Encrypt(txtOldPwd.Text, "station");
        if (strPwd != info.U_LoginPwd) {
            CommonFunction.AjaxAlert(UpdatePanel1, "原始密码错误");
            txtOldPwd.Focus();
            return;
        }
        if (txtNewPwd.Text == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入新密码");
            txtNewPwd.Focus();
            return;
        }
        if (txtNewPwd.Text.Length < 4) {
            CommonFunction.AjaxAlert(UpdatePanel1, "密码过于简单,长度应为4位数以上。");
            txtNewPwd.Focus();
            return;
        }
        if (txtRNewPwd.Text != txtNewPwd.Text) {
            CommonFunction.AjaxAlert(UpdatePanel1, "密码不一致");
            txtRNewPwd.Focus();
            return;
        }
        strPwd = CommonFunction.Encrypt(txtNewPwd.Text, "station");
        string sqlStr = "update S_UserInfo set U_LoginPwd='"+strPwd+"' where U_ID="+info.U_ID;
        if (DBHelper.ExecuteCommand(sqlStr) > 0) {
            info.U_LoginPwd = strPwd;
            Session["StationUser"] = info;
            Session.Timeout = 30;
            CommonFunction.AjaxAlertAndRedirect(UpdatePanel1, "密码修改成功", "default.aspx");
        }

    }
}
