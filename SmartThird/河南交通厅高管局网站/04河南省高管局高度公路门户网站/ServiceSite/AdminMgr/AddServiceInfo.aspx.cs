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

public partial class AdminMgr_AddServiceInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
           CommonFunction.isLoginCheck();
           BindDropDownList();
        }
    }
    private void BindDropDownList() {
        DataTable dt = HighWayInfoService.Get_AllHighWayInfo();
        ddlGs.DataSource = dt;
        ddlGs.DataTextField = "H_Name";
        ddlGs.DataValueField = "H_ID";
        ddlGs.DataBind();

        DataTable dtCity = PubClass.DBHelper.GetDataSet("select * from S_CityInfo");
        ddlCity.DataSource = dtCity;
        ddlCity.DataTextField = "CI_Name";
        ddlCity.DataValueField="CI_Name";
        ddlCity.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtName.Text == "") {
            CommonFunction.Alert(Literal1,"请输入服务区名称");
            return;
        }
        if (ServiceInfoService.IsExist_ServiceInfo(txtName.Text)) {
            CommonFunction.Alert(Literal1, "该服务区名称已经存在");
            return;
        }

        ServiceInfo info = new ServiceInfo();
        info.S_Name = txtName.Text;
        info.S_Star = ddlStar.Text;
        info.S_Type = ddlType.Text;
        info.S_City = ddlCity.Text;
        info.S_Welcome = txtName.Text + " 欢迎您！";
        info.S_HID = Convert.ToInt32(ddlGs.SelectedValue);

        ServiceInfoService.Insert_ServiceInfo(info);
        CommonFunction.Alert(Literal1,"添加成功");
        txtName.Text = "";
    }
}
