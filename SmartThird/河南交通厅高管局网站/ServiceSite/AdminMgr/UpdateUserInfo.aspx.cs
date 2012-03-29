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

public partial class AdminMgr_UpdateUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
               UserInfo info = (UserInfo)Session["ServiceUser"];
                txtName.Text = info.U_Name;
                txtRemark.Text = info.U_Remark;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
      UserInfo  info = (UserInfo)Session["ServiceUser"];
        if (txtOldPwd.Text.Trim() != info.U_Pwd) {
            CommonFunction.Alert(Literal1,"原始密码不正确");
            return;
        }
        info.U_Pwd = txtNewPwd.Text.Trim();
        info.U_Remark = txtRemark.Text;
        UserInfoService.Update_User(info);
        CommonFunction.Alert(Literal1,"修改成功");
        Session["ServiceUser"] = info;
    }
}
