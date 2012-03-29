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
using MainModel;
using MainService;
using PubClass;

public partial class AdminMgr_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DBHelper.ExecuteCommand("insert into Main_UserInfo(U_Name,U_Pwd,U_DepartId)  values('wangning','" + CommonFunction.Encrypt("87166644", "gsgl") + "','8')");
    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            CommonFunction.Alert(Literal1, "请输入用户名");
            return;
        }
        if (txtPwd.Text.Trim() == "")
        {
            CommonFunction.Alert(Literal1, "请输入密码");
            return;
        }
        if (Session["CheckCode"].ToString() != txtCode.Text)
        {
            CommonFunction.Alert(Literal1, "验证码错误");
            return;
        }
        UserInfo info = null;
        info = UserInfoService.Get_UserInfo(txtName.Text.Trim());
        if (info != null && CommonFunction.Decrypt(info.U_Pwd,"gsgl") == txtPwd.Text.Trim()&&info.U_DepartId!=7)
        {
            Session["GsglInfo"] = info;
            Response.Redirect("MainMgr.aspx");
        }
        else
        {
            CommonFunction.Alert(Literal1, "用户名或密码错误");
            return;
        }
    }
}
