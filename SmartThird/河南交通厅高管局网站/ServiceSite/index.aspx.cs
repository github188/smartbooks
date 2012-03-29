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
using DataAccess;
using Model;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           this.Title = ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站首页";

            //友情链接
           rptMyLink.DataSource = MyLinkService.Get_AllLinks(((ServiceInfo)Session["serviceinfo"]).S_ID);
           rptMyLink.DataBind();

            //公告公示
            rptSiteNotice.DataSource=ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID,10,2);
            rptSiteNotice.DataBind();

            //管理制度
            rptGLZD.DataSource = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 6, 3);
            rptGLZD.DataBind();

            //ISO国际标准化认证
            rptISO.DataSource = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 3, 9);
            rptISO.DataBind();


            //驿站新闻
            rptYzNews.DataSource = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 5, 1);
            rptYzNews.DataBind();

            //图片新闻
            rptPicNews.DataSource = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 5, 6);
            rptPicNews.DataBind();
            ViewState["rptPicNews"] = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 5, 6);


            /**
              餐厅服务
             */
            //经营品种
            rptitem1div1.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(41, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem1div1.DataBind();
            //收费标准
            rptitem1div2.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(42, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem1div2.DataBind();
            //提供餐别
            rptitem1div3.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(43, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem1div3.DataBind();
            //服务承诺
            rptitem1div4.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(44, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem1div4.DataBind();
            //自助餐标准
            rptitem1div5.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(45, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem1div5.DataBind();
            //会议培训用餐
            rptitem1div6.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(46, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem1div6.DataBind();
            //特色菜品
            rptitem1div7.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(47, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem1div7.DataBind();



            /**
              超市服务
             */
            //经营品种
            rptitem2div1.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(28, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem2div1.DataBind();
            //特产专柜
            rptitem2div2.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(29, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem2div2.DataBind();
            //急救药品
            rptitem2div3.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(30, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem2div3.DataBind();
            //工艺品
            rptitem2div4.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(31, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem2div4.DataBind();


            /**
             客房服务
            */
            //供房类型
            rptitem3div1.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(38, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem3div1.DataBind();
            //收费标准
            rptitem3div2.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(39, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem3div2.DataBind();
            //供房数量
            rptitem3div3.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(40, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem3div3.DataBind();



            /**
             加油服务
            */
            //供应油品
            rptitem4div1.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(35, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem4div1.DataBind();
            //油品价格
            rptitem4div2.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(36, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem4div2.DataBind();
            //加油机数量
            rptitem4div3.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(37, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem4div3.DataBind();





            /**
             汽修服务
            */
            //维修范围
            rptitem5div1.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(32, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem5div1.DataBind();
            //收费标准
            rptitem5div2.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(33, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem5div2.DataBind();
            //资质类别
            rptitem5div3.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(34, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem5div3.DataBind();





            /**
             停车服务
            */
            //停车分区
            rptitem6div1.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(48, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem6div1.DataBind();
            //停车位数量
            rptitem6div2.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(49, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem6div2.DataBind();
            //危险品专属区
            rptitem6div3.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(50, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem6div3.DataBind();
            //降温加水服务
            rptitem6div4.DataSource = ServiceItemService.Get_ServiceItemListByMIdAdnSId(51, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            rptitem6div4.DataBind();
        }
    }
}
