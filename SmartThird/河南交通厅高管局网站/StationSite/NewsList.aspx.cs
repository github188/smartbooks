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
using StationModel;
using StationService;
using PubClass;

public partial class NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            string strTID = Request.QueryString["tid"].ToString();
            TollStation station = (TollStation)Session["stationinfo"];
            DataTable dtType= DBHelper.GetDataSet("select * from S_NewsType where T_ID='" +strTID + "'");
            this.Title = dtType.Rows[0]["T_Name"].ToString() + "-" + station.TS_Name + "门户网站";
            lblTypeName.Text = dtType.Rows[0]["T_Name"].ToString();
            if (strTID == "1"){
                ViewState["strClass"] = "xinwen";
            } else if(strTID=="2") {
                ViewState["strClass"] = "gonggaonew";
            } else if (strTID == "5") {
                ViewState["strClass"] = "zhanqulist";
            }
            ViewState["tid"] = strTID;
            binddata();
        }
    }
    void binddata()
    {
        DataTable dt = NewsInfoService.Get_NewsViewList(((TollStation)Session["stationinfo"]).TS_ID, Convert.ToInt32(ViewState["tid"]),0);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rptNewsList.DataSource = ps;
            rptNewsList.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata();
    }
}
