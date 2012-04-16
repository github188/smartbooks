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
using Model;
using DataAccess;

public partial class AdminMgr_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "") {
            this.Literal1.Text = "<script>alert('请输入用户名');</script>";
            return;
        }
        if (txtPwd.Text.Trim() == "") {
            this.Literal1.Text = "<script>alert('请输入密码');</script>";
            return;
        }
        if (Session["CheckCode"].ToString() != txtCode.Text)
        {
            this.Literal1.Text = "<script>alert('验证码错误');</script>";
            return;
        }
        UserInfo info = null;
        info = UserInfoService.Get_UserInfo(txtName.Text.Trim());
        if (info != null && info.U_Pwd == txtPwd.Text.Trim())
        {
            Session["ServiceUser"] = info;
            CommonFunction.AlertAndRedirect(this.Literal1, "登陆成功", "MainMgr.aspx");
        }
        else {
            this.Literal1.Text = "<script>alert('用户名或密码错误');</script>";
            return;
        }
        
    }
}
