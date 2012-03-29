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
using StationService;

public partial class management_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["CheckCode"].ToString() != txtCode.Text.Trim())
        {
            CommonFunction.Alert(Literal1, "验证码错误");
            txtCode.Focus();
            return;
        }
        UserInfo info = null;
        info = UserInfoService.Get_UserInfoEntity(txtName.Text.Trim());
        if (info != null && CommonFunction.Decrypt(info.U_LoginPwd, "station") == txtPwd.Text)
        {
            Session["StationUser"] = info;
            Session.Timeout = 30;
            Response.Redirect("MainMgr.aspx");
        }
        else
        {
            CommonFunction.Alert(Literal1, "用户名或密码错误，请重新输入");
            txtPwd.Focus();
            return;
        }
    }
}
