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
using MainService;
using MainModel;

public partial class report_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtPwd.Text = "";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
            return;
        if (txtPwd.Text.Trim() == "")
            return;

        UserInfo info = null;
        info = UserInfoService.Get_UserInfo(txtName.Text.Trim());
        if (info != null && CommonFunction.Decrypt(info.U_Pwd, "gsgl") == txtPwd.Text.Trim()&&info.U_DepartId==7)
        {
            Session["reportuser"] = info;
            Response.Redirect("main.aspx");
        }
        else
        {
            CommonFunction.Alert(Literal1, "用户名或密码错误");
            return;
        }
    }
}
