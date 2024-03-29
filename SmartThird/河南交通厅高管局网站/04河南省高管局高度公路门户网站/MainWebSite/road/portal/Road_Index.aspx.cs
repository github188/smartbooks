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
using MainModel;
using MainService;
using PubClass;

public partial class road_Road_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAction();

            //实时路况
            DataTable dtRoadConditon = NewsInfoService.Get_TopNewsInfoViewList("实时路况", 5);
            rptRoadCondition.DataSource = dtRoadConditon;
            rptRoadCondition.DataBind();
        }
    }
    protected void BindTextInfo(Repeater rpt, int ModuleID, int MessageCount)
    {
        DataTable dt = NewsInfoService.Get_TopNewsInfoViewList(ModuleID, MessageCount);
        if (dt.Rows.Count > 0)
        {
            rpt.DataSource = dt;
            rpt.DataBind();
        }
    }
    protected void BindPic(Repeater rpt, int ModuleID, int MessageCount)
    {
        DataTable dt = NewsInfoService.Get_TopAnyPicNews(ModuleID, MessageCount);
        if (dt.Rows.Count > 0)
        {
            rpt.DataSource = dt;
            rpt.DataBind();
        }        
    }
    protected void BindAction()
    {
        BindWorkActiveWithImg();
        BindTextInfo(Repeater_gzdt, 89, 7);
        BindTextInfo(Repeater_gg, 88, 4);
        BindPic(Repeater_dwjs, 91, 7);
        BindPic(Repeater_lzfc, 90, 8);
        BindTextInfo(Repeater_yfxz, 92, 7);
        BindTextInfo(Repeater_dwgl, 93, 7);
        BindTextInfo(Repeater_cxzl, 94, 7);
        BindTextInfo(Repeater_jswm, 95, 7);
    }
    protected void BindWorkActiveWithImg()
    {
        DataTable dt = NewsInfoService.Get_TopAnyPicNews(89, 4);
        for (int i = 0; i < dt.Rows.Count;i++ )
        {
            string path = "../newsimages/" + dt.Rows[i]["N_ImgView"].ToString();
            string intro = Tool.SubString(dt.Rows[i]["N_Title"].ToString(), 18);
            string actionUrl = "Page.aspx?id=" + dt.Rows[i]["N_ID"].ToString();
            if (i == dt.Rows.Count-1)
            {
                Path += path;
                Intro += intro;
                ActionUrl += actionUrl;
            }
            else
            {
                Path += path + "|";
                Intro += intro + "|";
                ActionUrl += actionUrl + "|";
            }
        }      
    }
    string path;

    public string Path
    {
        get { return path; }
        set { path = value; }
    }
    string intro;

    public string Intro
    {
        get { return intro; }
        set { intro = value; }
    }
    string actionUrl;

    public string ActionUrl
    {
        get { return actionUrl; }
        set { actionUrl = value; }
    }
}
