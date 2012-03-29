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
using MainService;
using MainModel;

public partial class AdminMgr_ReplyMessageBoard : System.Web.UI.Page
{
    public static int mid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            if (Request.QueryString["mid"] != null) {
                mid = Convert.ToInt32(Request.QueryString["mid"]);
               DataTable dt = MessageBoardService.Get_MessageBoard(mid);
                txtUName.Text = dt.Rows[0]["M_UName"].ToString();
                txtEmail.Text = dt.Rows[0]["M_Email"].ToString();
                txtPhone.Text = dt.Rows[0]["M_Phone"].ToString();
                txtTime.Text = dt.Rows[0]["M_Time"].ToString();
                txtContent.Text = dt.Rows[0]["M_Content"].ToString();
                txtReply.Text = dt.Rows[0]["M_Reply"].ToString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        MessageBoardService.Reply_MessageBoard(mid, txtReply.Text);
        CommonFunction.AlertAndRedirect(Literal1, "操作成功", "MessageBoardMgr.aspx");
    }
}
