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

public partial class management_AddRoadDepart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            bindcitydata();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strName = txtName.Text.Trim();
        string strCity = ddlCity.SelectedValue.Trim();
        if (strName == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请输入路政单位名称");
            return;
        }
        if (strCity == "")
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "请选择地市");
            return;
        }
        if (DBHelper.IsExistRecord("select count(*) from R_RoadDepart where RD_Name='" + strName + "'"))
        {
            CommonFunction.AjaxAlert(UpdatePanel1, "该路政单位名称已存在");
            return;
        }
        string strLogo = "banner.jpg";
        string strSlogon = strName + "欢迎您！";
        string sqlStr = "insert into R_RoadDepart(RD_Name,RD_City,RD_Logo,RD_Slogon) values('" + strName + "','" + strCity + "','" + strLogo + "','" + strSlogon + "')";
        if (DBHelper.ExecuteCommand(sqlStr)>0)
        {
            CommonFunction.AjaxAlertAndRedirect(UpdatePanel1, "添加成功！", "RoadDepartMgr.aspx");
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
}
