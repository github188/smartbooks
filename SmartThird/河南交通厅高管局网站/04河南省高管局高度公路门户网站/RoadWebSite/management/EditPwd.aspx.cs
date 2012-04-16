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
using RoadEntity;
using PubClass;
using RoadService;

public partial class management_EditPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck("timeout.aspx");
            UserInfo info = (UserInfo)Session["RoadUser"];
            txtName.Text = info.U_LoginName;
            txtTrueName.Text = info.U_TrueName;
            txtPhone.Text = info.U_Phone;
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UserInfo info = (UserInfo)Session["RoadUser"];
        
        if (txtOldPwd.Text == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入原始密码");
            txtOldPwd.Focus();
            return;
        }
        string strPwd = CommonFunction.Decrypt(info.U_LoginPwd, "roadkey");
        if (txtOldPwd.Text != strPwd) {
            CommonFunction.AjaxAlert(UpdatePanel1, "原始密码输入错误");
            txtOldPwd.Focus();
            return;
        }

        if (txtNewPwd.Text == "") {
            CommonFunction.AjaxAlert(UpdatePanel1,"请输入新密码");
            txtNewPwd.Focus();
            return;
        }
        if (txtNewPwd.Text.Length < 4) {
            CommonFunction.AjaxAlert(UpdatePanel1, "密码过于简单,长度应为4位数以上");
            txtNewPwd.Focus();
            return;
        }
        if (txtRNewPwd.Text != txtNewPwd.Text) {
            CommonFunction.AjaxAlert(UpdatePanel1, "密码不一致");
            txtRNewPwd.Focus();
            return;
        }
        strPwd = CommonFunction.Encrypt(txtNewPwd.Text, "roadkey");
        string strTrueName = txtTrueName.Text.Trim();
        string strPhone = txtPhone.Text.Trim();
        string sqlStr = "update R_UserInfo set U_LoginPwd='"+strPwd+"',U_TrueName='"+strTrueName+"',U_Phone='"+strPhone+"' where U_ID="+info.U_ID;
        if (DBHelper.ExecuteCommand(sqlStr) > 0) { 
            info.U_LoginPwd=strPwd;
            info.U_TrueName=strTrueName;
            info.U_Phone=strPhone;
            Session["RoadUser"] = info;
            Session.Timeout = 600;
            CommonFunction.AjaxAlertAndRedirect(UpdatePanel1, "保存成功", "default.aspx");
        }

    }
    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {
        txtOldPwd.Text = "";
        txtNewPwd.Text = "";
        txtRNewPwd.Text = "";
        txtTrueName.Text = "";
        txtPhone.Text = "";
    }
}
