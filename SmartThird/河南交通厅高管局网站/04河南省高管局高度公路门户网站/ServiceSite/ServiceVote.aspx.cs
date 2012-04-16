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
using PubClass;

public partial class ServiceVote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isSelectedService();
            Title = "服务区用户在线满意度调查表-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtRemark.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtRemark.Text == "") {
            CommonFunction.Alert(Literal1, "请留下您的宝贵意见建议");
            return;
        }
        Model.ServiceVote vote = new Model.ServiceVote();
        vote.SV_ZH = rdozh.SelectedValue;
        vote.SV_GY = rdogy.SelectedValue;
        vote.SV_SF = rdosf.SelectedValue;
        vote.SV_HJ = rdohj.SelectedValue;
        vote.SV_TC = rdotc.SelectedValue;
        vote.SV_GL = rdogl.SelectedValue;
        vote.SV_YJ = rdoyj.SelectedValue;
        vote.SV_ZA = rdoza.SelectedValue;
        vote.SV_SS = rdoss.SelectedValue;
        vote.SV_GC = rdogc.SelectedValue;
        vote.SV_CS = rdocs.SelectedValue;
        vote.SV_CY = rdocy.SelectedValue;
        vote.SV_KF = rdokf.SelectedValue;
        vote.SV_JY = rdojy.SelectedValue;
        vote.SV_QX = rdoqx.SelectedValue;
        vote.SV_SID = ((ServiceInfo)Session["serviceinfo"]).S_ID;
        vote.SV_Remark = txtRemark.Text.Trim();
        int result = DataAccess.ServiceVoteService.Insert_ServiceVote(vote);
        if(result>0){
           CommonFunction.Alert(Literal1,"提交成功，谢谢您的参与");
           txtRemark.Text = "";
        }
    }
}
