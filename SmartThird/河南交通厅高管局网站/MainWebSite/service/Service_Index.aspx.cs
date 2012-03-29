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

public partial class service_Service_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

            //行业规章
            DataTable dtHYGZ = NewsInfoService.Get_TopNewsInfoViewList(20, 6);
            rptHYGZ.DataSource = dtHYGZ;
            rptHYGZ.DataBind();

            //经验交流
            DataTable dtJYJL = NewsInfoService.Get_TopNewsInfoViewList(21, 6);
            rptJYJL.DataSource = dtJYJL;
            rptJYJL.DataBind();

            //资料下载
            DataTable dtDownload = FileDownloadService.Get_TopFileDownloadView(2, 6);
            rptDownLoad.DataSource = dtDownload;
            rptDownLoad.DataBind();

            //ISO国际标准化认证
            DataTable dtISO = NewsInfoService.Get_TopNewsInfoViewList(24, 6);
            rptISO.DataSource = dtISO;
            rptISO.DataBind();

            //通知公告
            DataTable dtTZGG = NewsInfoService.Get_TopNewsInfoViewList(25, 6);
            rptTZGG.DataSource = dtTZGG;
            rptTZGG.DataBind();

            //驿站新闻
            DataTable dtServiceNews = NewsInfoService.Get_TopNewsInfoViewList(26, 8);
            rptServiceNews.DataSource = dtServiceNews;
            rptServiceNews.DataBind();

            //驿站文化
            DataTable dtYZWH = NewsInfoService.Get_TopNewsInfoViewList(27, 6);
            rptYZWH.DataSource = dtYZWH;
            rptYZWH.DataBind();

            //行业报刊
            DataTable dtNewsPaper = NewsPaperService.Get_NewsPaperList(4);
            rptNewsPaper.DataSource = dtNewsPaper;
            rptNewsPaper.DataBind();

            //所有服务区列表
            DataTable dtServices = PubClass.DBHelper.GetDataSet("select top 36 * from T_ServiceInfo order by S_QuarterRank asc,S_Star desc");
            rptServices.DataSource = dtServices;
            rptServices.DataBind();

            //特色服务区
            DataTable dtTSFWQ = NewsInfoService.Get_TopNewsInfoViewList(130, 10);
            rptTSFWQ.DataSource = dtTSFWQ;
            rptTSFWQ.DataBind();

            //开图走四方
            DataTable dtKTZSF = NewsInfoService.Get_TopNewsInfoViewList(131, 10);
            rptKTZSF.DataSource = dtKTZSF;
            rptKTZSF.DataBind();

            //精品旅游线路
            DataTable dtJPLYXL = NewsInfoService.Get_TopNewsInfoViewList(132, 10);
            rptJPLYXL.DataSource = dtJPLYXL;
            rptJPLYXL.DataBind();

            //吃住行游
            DataTable dtCZXY = NewsInfoService.Get_TopNewsInfoViewList(133, 10);
            rptCZXY.DataSource = dtCZXY;
            rptCZXY.DataBind();

            //古道遗风
            DataTable dtGDYF = NewsInfoService.Get_TopNewsInfoViewList(134, 10);
            rptGDYF.DataSource = dtGDYF;
            rptGDYF.DataBind();
        }
    }
}
