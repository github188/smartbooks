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

public partial class AdminMgr_AddServiceModel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            BindModelData();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtName.Text == "")
        {
            CommonFunction.Alert(Literal1,"请输入模块名称");
            return;
        }
        ServiceModel model = new ServiceModel();
        model.M_Name = txtName.Text;
        model.M_ParentID = Convert.ToInt32(ddlModel.SelectedValue);
        ServiceModelService.Insert_ServiceModel(model);
        CommonFunction.Alert(Literal1,"添加成功");
        txtName.Text = "";
    }
    private void BindModelData()
    {
        DataTable dt = ServiceModelService.Get_ParentModelList();

       
        ddlModel.DataSource = dt;

       

        ddlModel.DataValueField = "M_ID";
        ddlModel.DataTextField = "M_Name";

       
        ddlModel.DataBind();
    }
}
