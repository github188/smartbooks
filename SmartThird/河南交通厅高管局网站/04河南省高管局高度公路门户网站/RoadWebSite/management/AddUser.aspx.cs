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
using RoadEntity;
using RoadService;

public partial class management_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            bindroaddepart();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strName = txtName.Text.Trim();
        string strPwd = txtPwd.Text;
        string strDepart = ddlRoad.SelectedValue;
        if (strName == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入用户名");
            txtName.Focus();
            return;
        }
        if (DBHelper.IsExistRecord("select count(*) from R_UserInfo where U_LoginName='" + strName + "'"))
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "该用户名已存在");
            txtName.Focus();
            return;
        }
        if (strPwd == "")
        {
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
        if (strDepart == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请选择所属单位");
            return;
        }
        strPwd = CommonFunction.Encrypt(strPwd, "roadkey");
        string sqlStr = "insert into R_UserInfo(U_LoginName,U_LoginPwd,U_RoadID,U_IsSuper) values('" + strName + "','" + strPwd + "','" + strDepart + "',0)";
        if (DBHelper.ExecuteCommand(sqlStr) > 0)
        {
            CommonFunction.AjaxAlertAndRedirect(UpdatePanel1, "添加成功", "UserMgr.aspx");
        }
    }
    private void bindroaddepart()
    {
        string sqlStr = "select RD_ID,RD_Name from R_RoadDepart";
        DataTable dt = DBHelper.GetDataSet(sqlStr);
        ddlRoad.DataSource = dt;
        ddlRoad.DataTextField = "RD_Name";
        ddlRoad.DataValueField = "RD_ID";
        ddlRoad.DataBind();
    }
}
