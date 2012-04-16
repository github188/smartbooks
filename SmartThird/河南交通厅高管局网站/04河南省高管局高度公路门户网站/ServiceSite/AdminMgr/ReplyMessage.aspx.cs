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

public partial class AdminMgr_ReplyMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
           int mid = Convert.ToInt32(Request.QueryString["mid"]);
           ViewState["mid"] = mid;
            DataTable dt = MessageBoardService.Get_MessageBoard(mid);
            if (dt != null && dt.Rows.Count > 0) {
                lblName.Text = dt.Rows[0]["M_UName"].ToString();
                lblTime.Text = dt.Rows[0]["M_Time"].ToString();
                lblContent.Text = dt.Rows[0]["M_Content"].ToString();
                lblReply.Text = dt.Rows[0]["M_Reply"].ToString();
            }
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        MessageBoardService.Reply_MessageBoard(Convert.ToInt32(ViewState["mid"]), lblReply.Text);
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "MessageBoardList.aspx");
    }
}
