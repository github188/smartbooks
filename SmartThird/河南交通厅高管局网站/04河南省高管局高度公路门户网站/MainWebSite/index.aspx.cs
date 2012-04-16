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
using PubClass;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
           //文件下载
            rptDownLoad.DataSource = FileDownloadService.Get_TopFileDownloadView(1, 6);
            rptDownLoad.DataBind();

            //政策法规
            rptRuleList.DataSource = NewsInfoService.Get_TopNewsInfoViewList("政策法规", 6);
            rptRuleList.DataBind();

            //工作动态
            rptWorkexpress.DataSource = NewsInfoService.Get_TopNewsInfoViewList(1,6);
            rptWorkexpress.DataBind();

            //高速新闻
            rptGsNews.DataSource = NewsInfoService.Get_TopNewsInfoViewList(2, 6);
            rptGsNews.DataBind();

            //公告公示
            rptSiteNotice.DataSource = NewsInfoService.Get_TopNewsInfoViewList(63,5);
            rptSiteNotice.DataBind();

            //头2-4条政务信息
            rptTop2_4NewsList.DataSource = NewsInfoService.Get_Top2To5NewsInfoViewList(62);
            rptTop2_4NewsList.DataBind();

            //头1条政务信息
            rptTop1_NewsList.DataSource = NewsInfoService.Get_Top1NewsInfoView(62);
            rptTop1_NewsList.DataBind();

            //高速风采
            rptGsFengCai.DataSource = NewsInfoService.Get_TopAnyPicNews(4,0);
            rptGsFengCai.DataBind();

            //实时路况
            DataTable dtCurrentRoadCondition = NewsInfoService.Get_TopNewsInfoViewList(80, 0);
            rptCurrentRoadConditon.DataSource = dtCurrentRoadCondition;
            rptCurrentRoadConditon.DataBind();
            lblLJZHZX.Text = "您通行高速公路前可拨打高速交警路况查询电话：0371-68208110查询最新路况。<br><br>";

            //路政单位信息列表
            DataTable dtLZ = DBHelper.GetDataSet("select RD_ID,RD_Name from R_RoadDepart");
            rptLZ.DataSource = dtLZ;
            rptLZ.DataBind();
          
        }
    }
}
