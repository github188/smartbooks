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
    protected DataTable dtISO = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站首页";

            //友情链接
            DataTable dtlink = new DataTable();
            dtlink = MyLinkService.Get_AllLinks(((ServiceInfo)Session["serviceinfo"]).S_ID);
            if (dtlink.Rows.Count > 0)
            {
                rptMyLink.DataSource = dtlink;
                rptMyLink.DataBind();
            }


            //公告公示
            DataTable dtnotice = new DataTable();
            dtnotice = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 10, 2);
            if (dtnotice.Rows.Count > 0)
            {
                rptSiteNotice.DataSource = dtnotice;
                rptSiteNotice.DataBind();
            }


            //管理制度
            DataTable dtGLZD = new DataTable();
            dtGLZD = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 6, 3);
            if (dtGLZD.Rows.Count > 0)
            {
                rptGLZD.DataSource = dtGLZD;
                rptGLZD.DataBind();

            }


            //ISO国际标准化认证

              dtISO = new DataTable();

            dtISO = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 3, 9);
            if (dtISO.Rows.Count > 0)
            {
                rptISO.DataSource = dtISO;
                rptISO.DataBind();
            }



            //驿站新闻
            DataTable dtYzNews = new DataTable();
            dtYzNews = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 5, 1);
            if (dtYzNews.Rows.Count > 0)
            {
                rptYzNews.DataSource = dtYzNews;
                rptYzNews.DataBind();
            }


            //图片新闻

            DataTable dtPicNews = new DataTable();
            dtPicNews = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 5, 6);
            if (dtPicNews.Rows.Count > 0)
            {
                rptPicNews.DataSource = dtPicNews;

                rptPicNews.DataBind();
                ViewState["rptPicNews"] = dtPicNews;

            }



            /**
              餐厅服务
             */
            //经营品种

            DataTable dtdiv1 = new DataTable();
            dtdiv1 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(41, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv1.Rows.Count > 0)
            {
                rptitem1div1.DataSource = dtdiv1;
                rptitem1div1.DataBind();
            }

            //收费标准

            DataTable dtdiv2 = new DataTable();

            dtdiv2 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(42, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv2.Rows.Count > 0)
            {
                rptitem1div2.DataSource = dtdiv2;
                rptitem1div2.DataBind();
            }

            //提供餐别

            DataTable dtdiv3 = new DataTable();
            dtdiv3 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(43, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv3.Rows.Count > 0)
            {
                rptitem1div3.DataSource = dtdiv3;
                rptitem1div3.DataBind();
            }

            //服务承诺

            DataTable dtdiv4 = new DataTable();
            dtdiv4 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(44, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv4.Rows.Count > 0)
            {
                rptitem1div4.DataSource = dtdiv4;
                rptitem1div4.DataBind();
            }

            //自助餐标准

            DataTable dtdiv5 = new DataTable();
            dtdiv5 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(45, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv5.Rows.Count > 0)
            {
                rptitem1div5.DataSource = dtdiv5;
                rptitem1div5.DataBind();
            }

            //会议培训用餐

            DataTable dtdiv6 = new DataTable();
            dtdiv6 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(46, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv6.Rows.Count > 0)
            {
                rptitem1div6.DataSource = dtdiv6;
                rptitem1div6.DataBind();
            }

            //特色菜品

            DataTable dtdiv7 = new DataTable();
            dtdiv7 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(47, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv7.Rows.Count > 0)
            {
                rptitem1div7.DataSource = dtdiv7;
                rptitem1div7.DataBind();
            }




            /**
              超市服务
             */
            //经营品种
            DataTable dt2div1 = new DataTable();
            dt2div1 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(28, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt2div1.Rows.Count > 0)
            {
                rptitem2div1.DataSource = dt2div1;

                rptitem2div1.DataBind();
            }

            //特产专柜

            DataTable dt2div2 = new DataTable();
            dt2div2 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(29, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt2div2.Rows.Count > 0)
            {
                rptitem2div2.DataSource = dt2div2;
                rptitem2div2.DataBind();
            }

            //急救药品

            DataTable dt2div3 = new DataTable();
            dt2div3 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(30, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt2div3.Rows.Count > 0)
            {
                rptitem2div3.DataSource = dt2div3;
                rptitem2div3.DataBind();
            }

            //工艺品

            DataTable dt2div4 = new DataTable();

            dt2div4 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(31, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt2div4.Rows.Count > 0)
            {
                rptitem2div4.DataSource = dt2div4;
                rptitem2div4.DataBind();
            }



            /**
             客房服务
            */
            //供房类型

            DataTable dt3div1 = new DataTable();
            dt3div1 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(38, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt3div1.Rows.Count > 0)
            {
                rptitem3div1.DataSource = dt3div1;
                rptitem3div1.DataBind();
            }

            //收费标准
            DataTable dt3div2 = new DataTable();
            dt3div2 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(39, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt3div2.Rows.Count > 0)
            {
                rptitem3div2.DataSource = dt3div2;
                rptitem3div2.DataBind();

            }

            //供房数量

            DataTable dt3div3 = new DataTable();

            dt3div3 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(40, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dtdiv3.Rows.Count > 0)
            {
                rptitem3div3.DataSource = dt3div3;
                rptitem3div3.DataBind();
            }




            /**
             加油服务
            */
            //供应油品

            DataTable dt4div1 = new DataTable();
            dt4div1 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(35, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt4div1.Rows.Count > 0)
            {
                rptitem4div1.DataSource = dt4div1;
                rptitem4div1.DataBind();
            }

            //油品价格
            DataTable dt4div2 = new DataTable();

            dt4div2 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(36, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt4div2.Rows.Count > 0)
            {
                rptitem4div2.DataSource = dt4div2;
                rptitem4div2.DataBind();
            }

            //加油机数量
            DataTable dt4div3 = new DataTable();
            dt4div3 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(37, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt4div3.Rows.Count > 0)
            {
                rptitem4div3.DataSource = dt4div3;
                rptitem4div3.DataBind();
            }






            /**
             汽修服务
            */
            //维修范围
            DataTable dt5div1 = new DataTable();

            dt5div1 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(32, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt5div1.Rows.Count > 0)
            {
                rptitem5div1.DataSource = dt5div1;
                rptitem5div1.DataBind();
            }

            //收费标准
            DataTable dt5div2 = new DataTable();

            dt5div2 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(33, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt5div2.Rows.Count > 0)
            {
                rptitem5div2.DataSource = dt5div2;
                rptitem5div2.DataBind();
            }

            //资质类别
            DataTable dt5div3 = new DataTable();

            dt5div3 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(34, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);

            if (dt5div3.Rows.Count > 0)
            {
                rptitem5div3.DataSource = dt5div3;
                rptitem5div3.DataBind();
            }






            /**
             停车服务
            */
            //停车分区
            DataTable dt6div1 = new DataTable();

            dt6div1 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(48, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt6div1.Rows.Count > 0)
            {
                rptitem6div1.DataSource = dt6div1;
                rptitem6div1.DataBind();
            }

            //停车位数量
            DataTable dt6div2 = new DataTable();

            dt6div2 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(49, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt6div2.Rows.Count > 0)
            {
                rptitem6div2.DataSource = dt6div2;
                rptitem6div2.DataBind();
            }

            //危险品专属区
            DataTable dt6div3 = new DataTable();

            dt6div3 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(50, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt6div3.Rows.Count > 0)
            {
                rptitem6div3.DataSource = dt6div3;
                rptitem6div3.DataBind();
            }

            //降温加水服务

            DataTable dt6div4 = new DataTable();
            dt6div4 = ServiceItemService.Get_ServiceItemListByMIdAdnSId(51, ((ServiceInfo)Session["serviceinfo"]).S_ID, 7);
            if (dt6div4.Rows.Count > 0)
            {
                rptitem6div4.DataSource = dt6div4;
                rptitem6div4.DataBind();
            }

        }
    }
}
