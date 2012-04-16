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
using DataAccess;
using Model;

public partial class AdminMgr_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            binddata(txtName.Text);
        }
    }
    void binddata(string strName)
    {
        DataTable dt;
        if (strName != "")
        {
            dt = UserInfoService.Get_UserViewByName(strName);
        }
        else {
            dt = UserInfoService.Get_UserView();
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord") {
            int uid = Convert.ToInt32(e.CommandArgument);
            UserInfoService.Delete_User(uid);
            binddata(txtName.Text);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        binddata(txtName.Text);
    }
}
