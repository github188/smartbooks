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
using MainModel;
using MainService;
using PubClass;

public partial class maintenance_MainTenance_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           //规章制度
            DataTable dtGZZD = NewsInfoService.Get_TopNewsInfoViewList(33, 8);
            rptGZZD.DataSource = dtGZZD;
            rptGZZD.DataBind();

            //文明创建
            DataTable dtWMCJ = NewsInfoService.Get_TopNewsInfoViewList(34, 8);
            rptWMCJ.DataSource = dtWMCJ;
            rptWMCJ.DataBind();

            //养护交流
            DataTable dtYHJL = NewsInfoService.Get_TopNewsInfoViewList(35, 12);
            rptYHJL.DataSource = dtYHJL;
            rptYHJL.DataBind();

            //养护新技术、新材料、新设备
            DataTable dtYHXJS = NewsInfoService.Get_TopNewsInfoViewList(36, 4);
            rptYHXJS.DataSource = dtYHXJS;
            rptYHXJS.DataBind();
            //养护管理
            DataTable dtYHGL = NewsInfoService.Get_TopNewsInfoViewList(37, 4);
            rptYHGL.DataSource = dtYHGL;
            rptYHGL.DataBind();
            //施工公告
            DataTable dtSGGG = NewsInfoService.Get_TopNewsInfoViewList(38, 4);
            rptSGGG.DataSource = dtSGGG;
            rptSGGG.DataBind();
            //公路技术状况评定
            DataTable dtJSPD = NewsInfoService.Get_TopNewsInfoViewList(39, 4);
            rptJSPD.DataSource = dtJSPD;
            rptJSPD.DataBind();

            //办事指南
            DataTable dtBSZN = NewsInfoService.Get_TopNewsInfoViewList(31, 6);
            rptBSZN.DataSource = dtBSZN;
            rptBSZN.DataBind();

            //养护动态
            DataTable dtYHDT = NewsInfoService.Get_TopNewsInfoViewList(30, 6);
            rptYHDT.DataSource = dtYHDT;
            rptYHDT.DataBind();

            //基层资讯
            DataTable dtJCZX = NewsInfoService.Get_TopNewsInfoViewList(32, 7);
            rptJCZX.DataSource = dtJCZX;
            rptJCZX.DataBind();

            //通知公告
            DataTable dtTZGG = NewsInfoService.Get_TopNewsInfoViewList(41, 5);
            rptTZGG.DataSource = dtTZGG;
            rptTZGG.DataBind();

            //资料下载
            DataTable dtDownLoad = FileDownloadService.Get_TopFileDownloadView(3, 7);
            rptDownLoad.DataSource = dtDownLoad;
            rptDownLoad.DataBind();

            //养护掠影
            DataTable dtYHMien = NewsInfoService.Get_TopNewsInfoViewList(40, 0);
            rptYHMien.DataSource = dtYHMien;
            rptYHMien.DataBind();


        }
    }
}
