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
using StationService;
using PubClass;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            TollStation station = (TollStation)Session["stationinfo"];
            this.Title = station.TS_Name + "门户网站首页";


            DataTable dtZQWH = NewsInfoService.Get_NewsViewList(station.TS_ID, 5, 6);
            rptZQWH.DataSource = dtZQWH;
            rptZQWH.DataBind();

            DataTable dtTZGG = NewsInfoService.Get_NewsViewList(station.TS_ID, 2, 5);
            rptTZGG.DataSource = dtTZGG;
            rptTZGG.DataBind();

            DataTable dtZXDT = NewsInfoService.Get_NewsViewList(station.TS_ID, 1, 5);
            rptZXDT.DataSource = dtZXDT;
            rptZXDT.DataBind();

            DataTable dtRongYu = NewsInfoService.Get_NewsViewList(station.TS_ID, 3, 0);
            rptRongYu.DataSource = dtRongYu;
            rptRongYu.DataBind();

            DataTable dtFengCai = NewsInfoService.Get_NewsViewList(station.TS_ID, 6, 0);
            rptFengCai.DataSource = dtFengCai;
            rptFengCai.DataBind();

            DataTable dtFWZX = NewsInfoService.Get_NewsViewList(station.TS_ID, 4, 1);
            rptStar.DataSource = dtFWZX;
            rptStar.DataBind();
        }
    }
}
