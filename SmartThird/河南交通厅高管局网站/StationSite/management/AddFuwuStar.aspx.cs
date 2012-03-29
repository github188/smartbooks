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

public partial class management_AddFuwuStar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            ViewState["dtType"] = DBHelper.GetDataSet("select * from S_NewsType where T_ID='" + Request.QueryString["tid"].ToString() + "'");
            ViewState["strAction"] = Request.QueryString["action"];
            if (Request.QueryString["nid"] != null)
            {
                int nid = Convert.ToInt32(Request.QueryString["nid"]);
                ViewState["nid"] = nid;
                DataTable dt = DBHelper.GetDataSet("select * from S_NewsView where N_ID='" + nid + "'");
                txtTitle.Text = dt.Rows[0]["N_Title"].ToString();
                txtFrom.Text = dt.Rows[0]["N_From"].ToString();
                txtDate.Text = Convert.ToDateTime(dt.Rows[0]["N_Date"].ToString()).ToShortDateString();
                string strContent=dt.Rows[0]["N_Content"].ToString();
                ViewState["strContent"] = strContent.Substring(strContent.IndexOf("<$$>") + 4);
                txtShortRemark.Text =  strContent.Substring(0, strContent.IndexOf("<$$>"));
                ViewState["ImgPath"] = dt.Rows[0]["N_ImgPath"].ToString();
                ViewState["ImgView"] = dt.Rows[0]["N_ImgView"].ToString();
            }
            else
            {
                ViewState["ImgPath"] = "";
                ViewState["ImgView"] = "";
                txtDate.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strContent = txtShortRemark.Text.Trim() + "<$$>" + PubClass.Tool.CheckStr(Request.Form["t_contents"].ToString());
        string strAction = ViewState["strAction"].ToString();
        if (strAction == "add" && !FileUpload1.HasFile)
            return;
        if (FileUpload1.HasFile)
        {
            string fileName = FileUpload1.FileName;
            string strExtent = fileName.Substring(fileName.LastIndexOf("."));
            fileName = CommonFunction.Get_DynamicString() + strExtent;
            string fileName1 = "v_" + fileName;
            string fileName2 = "vv_" + fileName;
            string filePath = Server.MapPath("~/NewsImg/" + fileName);
            string filePath1 = Server.MapPath("~/NewsImg/" + fileName1);
            string filePath2 = Server.MapPath("~/NewsImg/" + fileName2);
            FileUpload1.PostedFile.SaveAs(filePath);
            ImgFunction.MakeThumbnail(filePath, filePath1, 600, 480, "W");
            ImgFunction.MakeThumbnail(filePath, filePath2, 120, 90, "W");
            System.IO.File.Delete(filePath);
            ViewState["ImgPath"] = fileName1;
            ViewState["ImgView"] = fileName2;
        }
        string sqlStr = "";
        if (strAction == "add")
        {
            sqlStr = "insert into S_NewsInfo(N_Title,N_Content,N_From,N_Date,N_TSID,N_TID,N_ImgPath,N_ImgView) values('" + txtTitle.Text.Trim() + "','" + strContent + "','" + txtFrom.Text.Trim() + "','" + txtDate.Text.Trim() + "','" + ((UserInfo)Session["StationUser"]).U_TollStation.TS_ID + "','" + ((DataTable)ViewState["dtType"]).Rows[0]["T_ID"].ToString() + "','" + ViewState["ImgPath"].ToString() + "','" + ViewState["ImgView"].ToString() + "')";
        }
        else if (strAction == "update")
        {
            sqlStr = "update S_NewsInfo set N_Title='" + txtTitle.Text.Trim() + "',N_Content='" + strContent + "',N_From='" + txtFrom.Text.Trim() + "',N_Date='" + txtDate.Text.Trim() + "',N_ImgPath='" + ViewState["ImgPath"].ToString() + "',N_ImgView='" + ViewState["ImgView"].ToString() + "'  where N_ID='" + ViewState["nid"].ToString() + "'";
        }
        if (DBHelper.ExecuteCommand(sqlStr) > 0)
        {
            Response.Redirect(((DataTable)ViewState["dtType"]).Rows[0]["SelectURL"].ToString());
        }
    }
}
