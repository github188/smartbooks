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
using StationModel;
using PubClass;
using StationService;

public partial class management_EditStation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            bindcitydata();
            bindcompanydata();
            bindhighwaydata();
            bindstardata();

            if (Request.QueryString["tsid"] == null)
            {
                ViewState["tsid"] = ((UserInfo)Session["StationUser"]).U_TollStation.TS_ID ;
            }
            else {
                ViewState["tsid"] = Request.QueryString["tsid"].ToString();
            }
            TollStation station = TollStationService.Get_TollStationEntity(Convert.ToInt32(ViewState["tsid"]));
            txtName.Text = station.TS_Name;
            txtPinYin.Text = station.TS_PinYin;
            txtStake.Text = station.TS_Stake;
            txtStakeNum.Text = station.TS_StakeNum.ToString();
            txtRen.Text = station.TS_Manager;
            txtPhone.Text = station.TS_Phone;
            txtHonour.Text = station.TS_Honour;
            txtWelcome.Text = station.TS_Welcome;
            ddlHighway.SelectedValue = station.TS_Highway.H_ID.ToString();
            ddlUnit.SelectedValue = station.TS_Company.C_ID.ToString();
            ddlCity.SelectedValue = station.TS_City.CI_ID.ToString();
            ddlStar.SelectedValue = station.TS_Star;
            txtLaneNum.Text = station.TS_LaneNum;
            txtExitToRoad.Text = station.TS_ExitToRoad;
            txtRemark.Text = station.TS_Remark;
            Image1.ImageUrl = "../StationPhoto/"+station.TS_MainPhoto;
        }
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
    private void bindcompanydata()
    {
        ddlUnit.Items.Clear();
        string sqlStr = "select C_ID,C_Name from T_CompanyInfo";
        DataTable dt = DBHelper.GetDataSet(sqlStr);
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dt.Rows[i]["C_Name"].ToString(), dt.Rows[i]["C_ID"].ToString());
                ddlUnit.Items.Add(item);
            }
        }
    }
    private void bindhighwaydata()
    {
        ddlHighway.Items.Clear();
        string sqlStr = "select H_ID,H_Name from T_HighWayInfo";
        DataTable dt = DBHelper.GetDataSet(sqlStr);
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dt.Rows[i]["H_Name"].ToString(), dt.Rows[i]["H_ID"].ToString());
                ddlHighway.Items.Add(item);
            }
        }
    }
    private void bindstardata()
    {
        ddlStar.Items.Clear();
        ddlStar.Items.Add(new ListItem("", ""));
        ddlStar.Items.Add(new ListItem("★", "★"));
        ddlStar.Items.Add(new ListItem("★★", "★★"));
        ddlStar.Items.Add(new ListItem("★★★", "★★★"));
        ddlStar.Items.Add(new ListItem("★★★★", "★★★★"));
        ddlStar.Items.Add(new ListItem("★★★★★", "★★★★★"));
    }
    protected void btnSaveInfo_Click(object sender, ImageClickEventArgs e)
    {
        string sqlStr = "update S_TollStation set TS_PinYin='" + txtPinYin.Text.Trim() + "',TS_Stake='" + txtStake.Text.Trim() + "',TS_StakeNum='" + txtStakeNum.Text.Trim() + "',TS_Manager='" + txtRen.Text.Trim() + "',TS_Phone='" + txtPhone.Text.Trim() + "',TS_Honour='" + txtHonour.Text.Trim() + "',TS_Welcome='" + txtWelcome.Text.Trim() + "',TS_Highway='" + ddlHighway.SelectedValue + "',TS_City='" + ddlCity.SelectedValue + "',TS_Company='" + ddlUnit.SelectedValue + "',TS_Star='" + ddlStar.SelectedValue + "',TS_LaneNum='" + txtLaneNum.Text.Trim() + "',TS_ExitToRoad='" + txtExitToRoad.Text.Trim() + "',TS_Remark='" + txtRemark.Text.Trim() + "' where TS_ID='" + ViewState["tsid"].ToString() + "'";
        if (DBHelper.ExecuteCommand(sqlStr) > 0)
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "信息修改成功");
        }
        else {
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
        string filePath = Server.MapPath("~/StationPhoto/"+fileName);
        string filePath1 = Server.MapPath("~/StationPhoto/" + fileName1);
        string filePath2 = Server.MapPath("~/StationPhoto/" + fileName2);
        FileUpload1.PostedFile.SaveAs(filePath);
        ImgFunction.MakeThumbnail(filePath, filePath1, 600, 480, "W");
        ImgFunction.MakeThumbnail(filePath, filePath2, 160, 120, "W");
        System.IO.File.Delete(filePath);
        Image1.ImageUrl = "../StationPhoto/"+fileName1;
        string sqlStr = "update S_TollStation set TS_MainPhoto='" + fileName1 + "',TS_ViewPhoto='" + fileName2 + "' where TS_ID='" + ViewState["tsid"].ToString() +"'";
        DBHelper.ExecuteCommand(sqlStr);

    }
}
