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

public partial class AdminMgr_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgbtn_login_Click(object sender, ImageClickEventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            Response.Write("<script language=javascript>alert('请输入用户名!')</script>");
            Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
            return;
        }
        if (txtPwd.Text.Trim() == "")
        {
            Response.Write("<script language=javascript>alert('请输入密码!')</script>");
            Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
            return;
        }
        if (Session["CheckCode"].ToString() != txtCode.Text)
        {
            Response.Write("<script language=javascript>alert('验证码输入有误!')</script>");
            Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
            return;
        }
        UserInfo info = null;
        info = UserInfoService.Get_UserInfo(txtName.Text.Trim());
        if (info != null && info.U_Pwd == txtPwd.Text.Trim())
        {
            Session["ServiceUser"] = info;
            Response.Write("<script language=javascript>alert('您好,"+info.U_Name+"!')</script>");
            Response.Write("<script language=javascript>window.location.href='MainMgr.aspx'</script>");
            //CommonFunction.AlertAndRedirect(this.Literal1, "登陆成功", "MainMgr.aspx");
        }
        else
        {
            Response.Write("<script language=javascript>alert('您输入的用户名或密码有误，请重新输入!')</script>");
            Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
            return;
        }
    }
    protected void imgbtn_reset_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
        txtName.Focus();
    }
}
