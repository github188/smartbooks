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

public partial class AdminMgr_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            DataTable dt = ServiceInfoService.Get_AllServiceInfo();
            ddlService.DataSource = dt;
            ddlService.DataValueField = "S_ID";
            ddlService.DataTextField = "S_Name";
            ddlService.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (UserInfoService.IsExistUserInfo(txtName.Text.Trim())) {
            CommonFunction.Alert(Literal1,"该用户名已存在");
            return;
        }
        UserInfo info = new UserInfo();
        info.U_Name = txtName.Text.Trim();
        info.U_Pwd = txtPwd.Text.Trim();
        info.U_Remark = txtRemark.Text;
        info.U_Power = 1;
        info.U_SID = Convert.ToInt32(ddlService.SelectedValue);
        UserInfoService.Insert_User(info);
        CommonFunction.Alert(Literal1,"添加成功");
        txtName.Text = "";
        txtRemark.Text = "";
    }
}
