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

public partial class management_AddArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck("timeout.aspx");
            ViewState["dtType"] = DBHelper.GetDataSet("select * from S_NewsType where T_ID='" + Request.QueryString["tid"].ToString() + "'");
            ViewState["strAction"] = Request.QueryString["action"];
            if (Request.QueryString["nid"] != null){
                int nid = Convert.ToInt32(Request.QueryString["nid"]);
                ViewState["nid"] = nid;
                DataTable dt = DBHelper.GetDataSet("select * from S_NewsView where N_ID='"+nid+"'");
                txtTitle.Text = dt.Rows[0]["N_Title"].ToString();
                txtFrom.Text = dt.Rows[0]["N_From"].ToString();
                txtDate.Text = Convert.ToDateTime(dt.Rows[0]["N_Date"].ToString()).ToShortDateString();
                ViewState["strContent"] = dt.Rows[0]["N_Content"].ToString();
            }else{
                txtFrom.Text = "本站原创";
                txtDate.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strContent = PubClass.Tool.CheckStr(Request.Form["t_contents"].ToString());
        string strAction = ViewState["strAction"].ToString();
        string sqlStr = "";
        if (strAction == "add") {
            sqlStr = "insert into S_NewsInfo(N_Title,N_Content,N_From,N_Date,N_TSID,N_TID) values('" + txtTitle.Text.Trim() + "','" + strContent + "','" + txtFrom.Text.Trim() + "','" + txtDate.Text.Trim() + "','" + ((UserInfo)Session["StationUser"]).U_TollStation.TS_ID + "','" + ((DataTable)ViewState["dtType"]).Rows[0]["T_ID"].ToString() + "')";
        }else if(strAction=="update"){
            sqlStr = "update S_NewsInfo set N_Title='" + txtTitle.Text.Trim() + "',N_Content='" + strContent + "',N_From='" + txtFrom.Text.Trim() + "',N_Date='" + txtDate.Text.Trim() + "' where N_ID='" + ViewState["nid"].ToString()+ "'";
        }
        if (DBHelper.ExecuteCommand(sqlStr) > 0) {
            Response.Redirect(((DataTable)ViewState["dtType"]).Rows[0]["SelectURL"].ToString());
        }
    }
}
