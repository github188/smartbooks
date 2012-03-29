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
using PubClass;

public partial class management_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck("timeout.aspx");
            bindstationdata();
        }
    }

    private void bindstationdata() {
        string sqlStr = "select TS_ID,TS_Name from S_TollStation";
        DataTable dt = DBHelper.GetDataSet(sqlStr);
        ddlStation.DataSource = dt;
        ddlStation.DataTextField = "TS_Name";
        ddlStation.DataValueField = "TS_ID";
        ddlStation.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strName = txtName.Text.Trim();
        string strPwd = txtPwd.Text;
        if (strName == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入用户名");
            txtName.Focus();
            return;
        }
        if (DBHelper.IsExistRecord("select count(*) from S_UserInfo where U_LoginName='"+strName+"'"))
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "该用户名已存在");
            txtName.Focus();
            return;
        }
        if (strPwd == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入密码");
            txtPwd.Focus();
            return;
        }
        if (strPwd.Length < 4)
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "密码过于简单,长度应为4位数以上。");
            txtPwd.Focus();
            return;
        }
        strPwd = CommonFunction.Encrypt(strPwd, "station");
        string sqlStr = "insert into S_UserInfo(U_LoginName,U_LoginPwd,U_StationID,U_IsSuper) values('"+strName+"','"+strPwd+"','"+ddlStation.SelectedValue+"',0)";
        if (DBHelper.ExecuteCommand(sqlStr) > 0) {
            CommonFunction.AjaxAlertAndRedirect(UpdatePanel1, "添加成功", "UserMgr.aspx");
        }
    }
}
