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

public partial class AdminMgr_AddMyLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            ViewState["strAction"] = Request.QueryString["action"].ToString();
            if (Request.QueryString["lid"] != null)
            {
                int  lid = Convert.ToInt32(Request.QueryString["lid"]);
                ViewState["lid"] = lid;
                DataTable dt = MyLinkService.Get_MyLink(lid);
                txtTitle.Text = dt.Rows[0]["L_Title"].ToString();
                txtURL.Text = dt.Rows[0]["L_URL"].ToString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        MyLink link = new MyLink();
        link.L_Title = txtTitle.Text;
        link.L_URL = txtURL.Text;
        link.L_SID = ((UserInfo)Session["ServiceUser"]).U_SID;
        if ( ViewState["strAction"].ToString() == "update")
        {
            link.L_ID = Convert.ToInt32(ViewState["lid"]);
            MyLinkService.Update_MyLink(link);
        }
        else if ( ViewState["strAction"].ToString() == "add")
        {
            MyLinkService.Insert_MyLink(link);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "MyLinkMgr.aspx");
    }
}
