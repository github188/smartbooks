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
using MainModel;
using MainService;
using PubClass;

public partial class MessageBoard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            binddata();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata();
    }
    void binddata()
    {
        DataTable dt = MessageBoardService.Get_OpenedMessageBoard();
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rpt_Mess.DataSource = ps;
            rpt_Mess.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtUName.Text.Trim() == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入您的姓名");
            return;
        }
        if (txtEMail.Text.Trim() == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入电子邮件");
            return;
        }
        if (txtPhone.Text.Trim() == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入联系电话");
            return;
        }
        if (txtContent.Text.Trim() == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入留言内容");
            return;
        }
        MainModel.MessageBoard mess = new MainModel.MessageBoard();
        mess.M_UName = txtUName.Text.Trim();
        mess.M_Email = txtEMail.Text.Trim();
        mess.M_Phone = txtPhone.Text.Trim();
        mess.M_Content = txtContent.Text.Trim();
        int result = MessageBoardService.Insert_MessageBoard(mess);
        if (result > 0)
        {
            txtUName.Text = "";
            txtEMail.Text = "";
            txtPhone.Text = "";
            txtContent.Text = "";
            CommonFunction.AjaxAlertAndRedirect(UpdatePanel1, "提交成功，我们将会在最短的时间内给您回复", "MessageBoard.aspx");
        }else{
            CommonFunction.AjaxAlert(UpdatePanel1, "提交失败，请检查数据是否规范重新提交");
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtUName.Text = "";
        txtEMail.Text = "";
        txtPhone.Text = "";
        txtContent.Text = "";
    }
}
