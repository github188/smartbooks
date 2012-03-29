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
using StationService;
using StationModel;
using Wuqi.Webdiyer;

public partial class station_Sue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindStationList();
            binddata();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata();
    }
    void binddata()
    {
        DataTable dt = new S_StationComplaintSev().GetS_StationComplaintList(true);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rpt_Complain.DataSource = ps ;
            rpt_Complain.DataBind();
        }
    }
    void bindStationList() {
        //ListItem item1 = new ListItem("——请选择——", "0");
        //ddlStation.Items.Add(item1);
        //DataTable dt = new StationInfoService().GetStation();
        //if (dt != null) {
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ListItem item2 = new ListItem(dt.Rows[i]["TS_Name"].ToString(),dt.Rows[i]["TS_ID"].ToString());
        //        ddlStation.Items.Add(item2);
        //    }
        //}
        //ddlStation.SelectedIndex = 0;
    }
    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        ddlStation.SelectedIndex = 0;
        txtRen.Text = "";
        txtPhone.Text = "";
        txtContent.Text = "";
        txtAddress.Text = "";
    }
    protected void Button__Submit_Click(object sender, EventArgs e)
    {
        if (ddlStation.SelectedIndex == 0) {
            CommonFunction.AjaxAlert(UpdatePanel1, "请选择您要投诉的收费站");
            return;
        }
        if (txtRen.Text.Trim() =="")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请填写您的姓名");
            return;
        }
        if (txtContent.Text == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请填写投诉内容");
            return;
        }
        if (txtPhone.Text == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请填写您的电话");
            return;
        }
        if (txtAddress.Text == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请填写您的地址");
            return;
        }
        S_StationComplaint complain = new S_StationComplaint();
        complain.SC_CptName = txtRen.Text.Trim();
        complain.SC_CptContent = txtContent.Text.Trim();
        complain.SC_Phone = txtPhone.Text.Trim();
        complain.SC_Address = txtAddress.Text;
        complain.SC_TSID = Convert.ToInt32(ddlStation.SelectedValue);
        new S_StationComplaintSev().AddS_StationComplaint(complain);
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('提交成功，我们会在最短的时间内给您答复！');window.location.reload();", true);
    }
}
