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
using DataAccess;
using Model;

public partial class MessageBoardList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isSelectedService();
            Title = "留言信息列表-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
            binddata(((ServiceInfo)Session["serviceinfo"]).S_ID);
        }
    }
    void binddata(int sid)
    {
        DataTable dt = MessageBoardService.Get_OpenMessage(sid);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptMessageList.DataSource = ps;
            rptMessageList.DataBind();
            lblCount.Text = dt.Rows.Count.ToString();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(((ServiceInfo)Session["serviceinfo"]).S_ID);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtUName.Text = "";
        txtContent.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtUName.Text.Trim() == "")
            return;
        if (txtContent.Text.Trim() == "")
            return;
        MessageBoard mess = new MessageBoard();
        mess.M_UName = txtUName.Text.Trim();
        mess.M_Content = txtContent.Text.Trim();
        mess.M_SID = ((ServiceInfo)Session["serviceinfo"]).S_ID;
        mess.M_Emotion = "";
        int result=MessageBoardService.Insert_MessageBoard(mess);
        if (result > 0) {
            txtUName.Text = "";
            txtContent.Text = "";
            CommonFunction.Alert(Literal1, "提交成功，谢谢您的参与！");
        }
    }
}
