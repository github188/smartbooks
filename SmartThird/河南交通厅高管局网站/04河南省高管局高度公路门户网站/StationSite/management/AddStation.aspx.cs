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

public partial class management_AddStation : System.Web.UI.Page
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
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strName = txtName.Text.Trim();
        string strCity = ddlCity.SelectedValue.Trim();
        string strCompany = ddlUnit.SelectedValue.Trim();
        string strHighway = ddlHighway.SelectedValue.Trim();
        string strStar=ddlStar.SelectedValue;
        if (strName == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入收费站名称");
            return;
        }
        if (strHighway == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请选择高速");
            return;
        }
        if (strCompany == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请选择单位");
            return;
        }
        if (strCity == "") {
            CommonFunction.AjaxAlert(UpdatePanel1, "请选择地市");
            return;
        }
        if (DBHelper.IsExistRecord("select count(*) from S_TollStation where TS_Name='"+strName+"'"))
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "该收费站名称已存在");
            return;
        }
        string strStakeNum = "0";
        string strLogo = "banner.jpg";
        string strWelcome=strName+"欢迎您！";
        string sqlStr = "insert into S_TollStation(TS_Name,TS_StakeNum,TS_Star,TS_Highway,TS_City,TS_Company,TS_Logo,TS_Welcome) values('"+strName+"','"+strStakeNum+"','"+strStar+"','"+strHighway+"','"+strCity+"','"+strCompany+"','"+strLogo+"','"+strWelcome+"') select @@identity";
        string strKey = DBHelper.GetStringScalar(sqlStr);
        if (strKey.Length > 0) {
            string sql_User = "insert into S_UserInfo(U_LoginName,U_LoginPwd,U_StationID,U_IsSuper) values('"+strName+"','"+CommonFunction.Encrypt("123","station")+"','"+strKey+"',0)";
            DBHelper.ExecuteCommand(sql_User);
            CommonFunction.AjaxAlertAndRedirect(UpdatePanel1, "添加成功！", "StationMgr.aspx");
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
    private void bindcompanydata() {
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
    private void bindhighwaydata() {
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
    private void bindstardata() {
        ddlStar.Items.Clear();
        ddlStar.Items.Add(new ListItem("",""));
        ddlStar.Items.Add(new ListItem("★", "★"));
        ddlStar.Items.Add(new ListItem("★★", "★★"));
        ddlStar.Items.Add(new ListItem("★★★", "★★★"));
        ddlStar.Items.Add(new ListItem("★★★★", "★★★★"));
        ddlStar.Items.Add(new ListItem("★★★★★", "★★★★★"));
    }
}
