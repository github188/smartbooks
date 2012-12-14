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

public partial class AdminMgr_AddServiceNotice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck();
            int nid = Convert.ToInt32(Request.QueryString["nid"]);
            txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string strAction = Request.QueryString["action"];
            ViewState["nid"] = nid;
            ViewState["strAction"] = strAction;
            if (strAction == "update")
            {
                DataTable dt = ServiceNewService.Get_News(nid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtNotice.Text = dt.Rows[0]["N_Content"].ToString();
                    txtdate.Text = DateTime.Parse(dt.Rows[0]["N_Time"].ToString()).ToString("yyyy-MM-dd");
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        ServiceNews news = new ServiceNews();
        news.N_Title = "";
        news.N_Content = txtNotice.Text;
        news.N_SID = ((UserInfo)Session["ServiceUser"]).U_SID;
        news.N_NewsType = "2";
        news.N_From = "本站原创";
        news.N_Time = DateTime.Parse(txtdate.Text);
        if (ViewState["strAction"].ToString() == "add")
        {
            ServiceNewService.Insert_News(news);
        }
        else if (ViewState["strAction"].ToString() == "update")
        {
            news.N_ID = Convert.ToInt32(ViewState["nid"]);
            ServiceNewService.Update_News(news);
        }
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "blank.aspx");
    }
}
