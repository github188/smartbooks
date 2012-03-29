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

public partial class AdminMgr_ServiceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            DataTable dt = ServiceInfoService.Get_AllServiceInfo();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtName.Text.Trim() != "")
        {
            DataTable dt = ServiceInfoService.Get_ServiceInfoByName(txtName.Text);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        else {
            DataTable dt = ServiceInfoService.Get_AllServiceInfo();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}
