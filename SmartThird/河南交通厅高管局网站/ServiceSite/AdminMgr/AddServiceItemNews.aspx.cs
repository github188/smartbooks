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

public partial class AdminMgr_AddServiceItemNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            int iid = Convert.ToInt32(Request.QueryString["iid"]);
            int  mid = Convert.ToInt32(Request.QueryString["mid"]);
            ViewState["iid"] = iid;
            ViewState["mid"] = mid;
            string strAction = Request.QueryString["action"];
            ViewState["strAction"] = strAction;
            if (strAction == "update") {
                DataTable dt = ServiceItemService.Get_ServiceItem(iid);
                if (dt != null && dt.Rows.Count > 0) {
                     txtTitle.Text = dt.Rows[0]["I_Title"].ToString();
                     ViewState["strContent"] = dt.Rows[0]["I_Content"].ToString();
                }
            }

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strContent = Request.Form["t_contents"].ToString();
        if (strContent == "") {
            CommonFunction.Alert(Literal1, "文章内容不能为空");
            return;
        }
        ServiceItem item = new ServiceItem();
        item.I_Title = txtTitle.Text;
        item.I_Content = strContent;
        item.I_SID = ((UserInfo)Session["ServiceUser"]).U_SID;
        item.I_MID = ViewState["mid"].ToString();
        if (ViewState["strAction"].ToString() == "add")
        {
            ServiceItemService.Insert_ServiceItem(item);
        }
        else if (ViewState["strAction"].ToString() == "update")
        {
            item.I_ID = Convert.ToInt32(ViewState["iid"]);
            ServiceItemService.Update_ServiceItem(item);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "blank.aspx");
       
    }
}
