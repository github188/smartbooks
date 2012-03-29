﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class management_EditLogo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            ViewState["rdid"] = Request.QueryString["rdid"].ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (!FileUpload1.HasFile)
            return;
        string fileName = FileUpload1.FileName;
        string strExtent = fileName.Substring(fileName.LastIndexOf("."));
        fileName = CommonFunction.Get_DynamicString() + strExtent;
        string filePath = Server.MapPath("~/Logo/" + fileName);
        FileUpload1.PostedFile.SaveAs(filePath);
        string sqlStr = "update R_RoadDepart set RD_Logo='" + fileName + "' where RD_ID='" + ViewState["rdid"].ToString() + "'";
        PubClass.DBHelper.ExecuteCommand(sqlStr);
        Response.Redirect("RoadDepartMgr.aspx");
    }
}
