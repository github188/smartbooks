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

public partial class AdminMgr_CertificateMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            binddata();
        }
    }
    private void binddata() { 
        DataTable dt=ServiceNewService.GetNewsViewByType(((UserInfo)Session["ServiceUser"]).U_SID,9);
        GridView1.DataSource=dt;
        GridView1.DataKeyNames = new string[] { "N_ID" };//主键
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int nId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        ServiceNewService.Delete_News(nId);
        binddata();
    }
}
