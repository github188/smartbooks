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
using RoadEntity;
using RoadService;

public partial class management_EditRoadDepart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            bindcitydata();
            if (Request.QueryString["rdid"] == null)
            {
                ViewState["rdid"] = ((UserInfo)Session["RoadUser"]).U_RoadDepart.RD_ID;
            }
            else
            {
                ViewState["rdid"] = Request.QueryString["rdid"].ToString();
            }
            RoadDepart depart = RoadDepartService.Get_RoadDepartEntity(Convert.ToInt32(ViewState["rdid"]));
            txtName.Text = depart.RD_Name;
            txtFax.Text = depart.RD_Fax;
            txtRen.Text = depart.RD_Manager;
            txtPhone.Text = depart.RD_Phone;
            txtEmail.Text = depart.RD_Email;
            txtPostCode.Text = depart.RD_PostCode;
            txtReport.Text = depart.RD_Report;
            txtHonour.Text = depart.RD_Honour;
            txtAddress.Text = depart.RD_Address;
            txtSlogon.Text = depart.RD_Slogon;
            txtQQ.Text = depart.RD_QQ;
            txtRemark.Text = depart.RD_Remark;
            ddlCity.SelectedValue = depart.RD_City.CI_ID.ToString();
            Image1.ImageUrl = "../RoadPhoto/" + depart.RD_MainPhoto;
        }
    }
    /// <summary>
    /// 编辑部门信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveInfo_Click(object sender, ImageClickEventArgs e)
    {
        string sqlStr = "update R_RoadDepart set RD_Manager='" + txtRen.Text.Trim() + "',RD_Phone='" + txtPhone.Text.Trim() + "',RD_Fax='" + txtFax.Text.Trim() + "',RD_Email='" + txtEmail.Text.Trim() + "',RD_PostCode='" + txtPostCode.Text.Trim() + "',RD_QQ='" + txtQQ.Text.Trim() + "',RD_City='" + ddlCity.SelectedValue + "',RD_Address='" + txtAddress.Text.Trim() + "',RD_Honour='" + txtHonour.Text + "',RD_Slogon='" + txtSlogon.Text.Trim() + "',RD_Remark='" + txtRemark.Text + "',RD_Report='"+txtReport.Text+"' where RD_ID='" + ViewState["rdid"].ToString() + "'";
        if (DBHelper.ExecuteCommand(sqlStr) > 0)
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "信息修改成功");
        }
        else
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "操作失败，请检查数据是否录入规范");
        }
    }
    protected void btnSavePhoto_Click(object sender, ImageClickEventArgs e)
    {
        if (!FileUpload1.HasFile)
            return;
        string fileName = FileUpload1.FileName;
        string strExtent = fileName.Substring(fileName.LastIndexOf("."));
        fileName = CommonFunction.Get_DynamicString() + strExtent;
        string fileName1 = "m_" + fileName;
        string fileName2 = "v_" + fileName;
        string filePath = Server.MapPath("~/RoadPhoto/" + fileName);
        string filePath1 = Server.MapPath("~/RoadPhoto/" + fileName1);
        string filePath2 = Server.MapPath("~/RoadPhoto/" + fileName2);
        FileUpload1.PostedFile.SaveAs(filePath);
        ImgFunction.MakeThumbnail(filePath, filePath1, 600, 480, "W");
        ImgFunction.MakeThumbnail(filePath, filePath2, 150, 120, "W");
        System.IO.File.Delete(filePath);
        Image1.ImageUrl = "../RoadPhoto/" + fileName1;
        string sqlStr = "update R_RoadDepart set RD_MainPhoto='" + fileName1 + "',RD_ViewPhoto='" + fileName2 + "' where RD_ID='" + ViewState["rdid"].ToString() + "'";
        DBHelper.ExecuteCommand(sqlStr);
    }
    private void bindcitydata()
    {
        ddlCity.Items.Clear();
        string sqlStr = "select * from S_CityInfo";
        DataTable dt = DBHelper.GetDataSet(sqlStr);
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dt.Rows[i]["CI_Name"].ToString(), dt.Rows[i]["CI_ID"].ToString());
                ddlCity.Items.Add(item);
            }
        }
    }
}
