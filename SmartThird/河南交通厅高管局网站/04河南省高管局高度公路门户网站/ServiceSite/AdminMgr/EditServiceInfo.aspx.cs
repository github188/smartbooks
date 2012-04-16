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

public partial class AdminMgr_EditServiceInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            if (Request.QueryString["sid"] != null)
            {
                ViewState["S_ID"] = Convert.ToInt32(Request.QueryString["sid"]);
            }
            else {
                ViewState["S_ID"] = ((UserInfo)Session["ServiceUser"]).U_SID;
            }
            ServiceInfo dtInfo = ServiceInfoService.Get_ServiceInfo(Convert.ToInt32(ViewState["S_ID"]));
            ViewState["dtInfo"] = dtInfo;
            txtName.Text = dtInfo.S_Name;
            ddlStar.Text = dtInfo.S_Star;
            BindingServices();
            ddlGs.SelectedValue = dtInfo.S_HID.ToString();
            ddlType.Text = dtInfo.S_Type;
            txtStake.Text = dtInfo.S_Stake;
            txtPhone.Text = dtInfo.S_Phone;
            txtServices.Text = dtInfo.S_Service;
            txtStakeNum.Text = dtInfo.S_StakeNum.ToString();
            ddlCity.Text = dtInfo.S_City;
            txtWelcome.Text = dtInfo.S_Welcome;



            txtRemark.Text = dtInfo.S_Remark;
            txtCYRemark.Text = dtInfo.S_CYRemark;
            txtCSRemark.Text = dtInfo.S_CSRemark;
            txtZSRemark.Text = dtInfo.S_ZSRemark;
            txtJYZRemark.Text = dtInfo.S_JYZRemark;
            txtQXRemark.Text = dtInfo.S_QXRemark;
            txtTCSRemark.Text = dtInfo.S_TCSRemark;
            txtWSJRemark.Text = dtInfo.S_WSJRemark;
            txtFWDWRemark.Text = dtInfo.S_FWDWRemark;


            ImgService.ImageUrl ="../ServiceImg/"+ dtInfo.S_Image;
            ImgCY.ImageUrl = "../ServiceImg/" + dtInfo.S_CYImage;
            ImgCS.ImageUrl = "../ServiceImg/" + dtInfo.S_CSImage;
            ImgZS.ImageUrl = "../ServiceImg/" + dtInfo.S_ZSImage;
            ImgJYZ.ImageUrl = "../ServiceImg/" + dtInfo.S_JYZImage;
            ImgQX.ImageUrl = "../ServiceImg/" + dtInfo.S_QXImage;
            ImgTCS.ImageUrl = "../ServiceImg/" + dtInfo.S_TCSImage;
            ImgWSJ.ImageUrl = "../ServiceImg/" + dtInfo.S_WSJImage;
            ImgFWDW.ImageUrl = "../ServiceImg/" + dtInfo.S_FWDWImage;
           
            
 
        }
    }
    /// <summary>
    /// 绑定高速公路信息
    /// </summary>
    private void BindingServices() {
        DataTable dt = HighWayInfoService.Get_AllHighWayInfo();
        ddlGs.DataSource = dt;
        ddlGs.DataValueField = "H_ID";
        ddlGs.DataTextField = "H_Name";
        ddlGs.DataBind();

        DataTable dtCity = PubClass.DBHelper.GetDataSet("select * from S_CityInfo");
        ddlCity.DataSource = dtCity;
        ddlCity.DataTextField = "CI_Name";
        ddlCity.DataValueField = "CI_Name";
        ddlCity.DataBind();
    }
    /// <summary>
    /// 保存服务区基本信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveInfo_Click(object sender, ImageClickEventArgs e)
    {
        if (txtStake.Text.Trim() == "") {
            CommonFunction.Alert(Literal1, "请输入里程桩号");
            return;
        }
        if (txtStakeNum.Text.Trim() == "") {
            CommonFunction.Alert(Literal1, "请输入里程数");
            return;
        }
        if(!CommonFunction.Is_Nonnegative(txtStakeNum.Text.Trim())){
            CommonFunction.Alert(Literal1, "里程数为非负值");
            return;
        }
        ServiceInfo dtInfo = (ServiceInfo)ViewState["dtInfo"];
        dtInfo.S_Star = ddlStar.Text;
        dtInfo.S_HID = Convert.ToInt32(ddlGs.SelectedValue);
        dtInfo.S_Type = ddlType.Text;
        dtInfo.S_Stake = txtStake.Text;
        dtInfo.S_Phone = txtPhone.Text;
        dtInfo.S_Service = txtServices.Text;
        dtInfo.S_StakeNum = Convert.ToDouble(txtStakeNum.Text);
        dtInfo.S_City = ddlCity.Text;
        dtInfo.S_Welcome = txtWelcome.Text.Trim();


        dtInfo.S_Remark = txtRemark.Text;
        dtInfo.S_CYRemark = txtCYRemark.Text;
        dtInfo.S_CSRemark = txtCSRemark.Text;
        dtInfo.S_ZSRemark = txtZSRemark.Text;
        dtInfo.S_JYZRemark = txtJYZRemark.Text;
        dtInfo.S_QXRemark = txtQXRemark.Text;
        dtInfo.S_TCSRemark = txtTCSRemark.Text;
        dtInfo.S_WSJRemark = txtWSJRemark.Text;
        dtInfo.S_FWDWRemark = txtFWDWRemark.Text;

        ServiceInfoService.Update_ServiceBasicInfo(dtInfo);
        ViewState["dtInfo"] = dtInfo;
        CommonFunction.Alert(Literal1, "修改成功");

    }
    /// <summary>
    /// 上传服务区图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveImage_Click(object sender, ImageClickEventArgs e)
    {
        string fileName=CommonFunction.Get_DynamicString()+FileUploadService.FileName;
        string vfileName = "v_" + fileName;
        string filePath=Server.MapPath("~/ServiceImg/"+fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadService, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_Image", vfileName);
        ImgService.ImageUrl = "../ServiceImg/"+vfileName;

    }
    /// <summary>
    /// 上传餐饮图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCY_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadCY.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadCY, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_CYImage", vfileName);
        ImgCY.ImageUrl = "../ServiceImg/" + vfileName;
    }
    /// <summary>
    /// 上传超市图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCS_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadCS.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadCS, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_CSImage", vfileName);
        ImgCS.ImageUrl = "../ServiceImg/" + vfileName;
    }
    /// <summary>
    /// 上传加油站图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnJYZ_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadJYZ.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadJYZ, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_JYZImage", vfileName);
        ImgJYZ.ImageUrl = "../ServiceImg/" + vfileName;
    }
    /// <summary>
    /// 上传住宿图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnZS_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadZS.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadZS, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_ZSImage", vfileName);
        ImgZS.ImageUrl = "../ServiceImg/" + vfileName;
    }
    /// <summary>
    /// 上传汽修图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQX_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadQX.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadQX, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_QXImage", vfileName);
        ImgQX.ImageUrl = "../ServiceImg/" + vfileName;
    }
    /// <summary>
    /// 上传停车场图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTCS_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadTCS.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadTCS, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_TCSImage", vfileName);
        ImgTCS.ImageUrl = "../ServiceImg/" + vfileName;
    }
    /// <summary>
    /// 上传卫生间图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWSJ_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadWSJ.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadWSJ, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_WSJImage", vfileName);
        ImgWSJ.ImageUrl= "../ServiceImg/" + vfileName;
    }
    /// <summary>
    /// 上传服务队伍图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFWDW_Click(object sender, ImageClickEventArgs e)
    {
        string fileName = CommonFunction.Get_DynamicString() + FileUploadFWDW.FileName;
        string vfileName = "v_" + fileName;
        string filePath = Server.MapPath("~/ServiceImg/" + fileName);
        string vfilePath = Server.MapPath("~/ServiceImg/" + vfileName);
        if (!CommonFunction.Is_FileUploadSuccessfully(FileUploadFWDW, Literal1, filePath, new string[] { ".gif", ".jpg", ".jpeg" }))
            return;
        ImgUploadFunction.MakeThumbnail(filePath, vfilePath, 600, 480, "W");
        System.IO.File.Delete(filePath);
        ServiceInfoService.Update_ServiceImage(Convert.ToInt32(ViewState["S_ID"]), "S_FWDWImage", vfileName);
        ImgFWDW.ImageUrl = "../ServiceImg/" + vfileName;
    }
}
