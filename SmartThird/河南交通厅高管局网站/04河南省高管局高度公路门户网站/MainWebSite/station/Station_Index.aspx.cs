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
using MainService;
using MainModel;

public partial class station_Station_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
           //基层资讯
            DataTable dtJCZX = NewsInfoService.Get_TopNewsInfoViewList(109, 5);
            rptJCZX.DataSource = dtJCZX;
            rptJCZX.DataBind();

            //收费站文化
            DataTable dtSFZWH = NewsInfoService.Get_TopNewsInfoViewList(110, 5);
            rptSFZWH.DataSource = dtSFZWH;
            rptSFZWH.DataBind();

            //工作动态
            DataTable dtGZDT = NewsInfoService.Get_TopNewsInfoViewList(101, 9);
            rptGZDT.DataSource = dtGZDT;
            rptGZDT.DataBind();

            //规章制度
            DataTable dtZCFG = NewsInfoService.Get_TopNewsInfoViewList(100, 6);
            rptZCFG.DataSource = dtZCFG;
            rptZCFG.DataBind();

            //管理之窗
            DataTable dtGLZC = NewsInfoService.Get_TopNewsInfoViewList(102, 6);
            rptGLZC.DataSource = dtGLZC;
            rptGLZC.DataBind();

            //收费站风采
            DataTable dtStationMien = NewsInfoService.Get_TopNewsInfoViewList(111, 0);
            rptStationMien.DataSource = dtStationMien;
            rptStationMien.DataBind();

            //星级收费站
            DataTable dtStarStation = NewsInfoService.Get_TopNewsInfoViewList(103, 1);
            rptStarStation.DataSource = dtStarStation;
            rptStarStation.DataBind();

            //服务之星
            DataTable dtStationStar = NewsInfoService.Get_TopNewsInfoViewList(105, 1);
            rptStationStar.DataSource = dtStationStar;
            rptStationStar.DataBind();

            //站内公告
            DataTable dtZNGG = NewsInfoService.Get_TopNewsInfoViewList(104, 6);
            rptZNGG.DataSource = dtZNGG;
            rptZNGG.DataBind();
        }
    }
}
