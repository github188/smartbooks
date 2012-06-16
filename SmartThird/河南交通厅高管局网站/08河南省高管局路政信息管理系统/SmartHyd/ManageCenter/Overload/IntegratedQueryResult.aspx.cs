using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Overload {
    public partial class IntegratedQueryResult : System.Web.UI.Page {

        BLL.BASE_BUS_OVERRUN overloadManager = new BLL.BASE_BUS_OVERRUN();

        protected void Page_Load(object sender, EventArgs e) {


            if (!IsPostBack) {

                LoadData();
            }

        }

        /// <summary>
        /// 数据列表绑定
        /// </summary>
        /// <param name="condition"></param>
        public void LoadData() {
            string lx = Request.QueryString["lx"].ToString();
            string sqlStr = "";
            if (lx == "1") {
                sqlStr += " from BASE_BUS_OVERRUN where 1=1";
            } else if (lx == "2" || lx == "3") {
                if (lx == "2") {
                    sqlStr += " from V_OVERLOADREATE_DETAIL where 1=1";
                } else if (lx == "3") {
                    sqlStr += " from V_OVERLOADREATE_DETAIL_EXITS where 1=1";
                }
                if (Request.QueryString["gl"] != null) {
                    sqlStr += " and TS_COMPANY='" + HttpUtility.UrlDecode(Request.QueryString["gl"].ToString()) + "'";
                }
                if (Request.QueryString["ds"] != null) {
                    sqlStr += " and TS_CITY='" + HttpUtility.UrlDecode(Request.QueryString["ds"].ToString()) + "'";
                }
                if (Request.QueryString["gs"] != null) {
                    sqlStr += " and TS_HIGHWAY='" + HttpUtility.UrlDecode(Request.QueryString["gs"].ToString()) + "'";
                }
            }
            if (Request.QueryString["cp"] != null) {
                sqlStr += " and VEHICLELICENSE like '%" + HttpUtility.UrlDecode(Request.QueryString["cp"].ToString()) + "%'";
            }
            if (Request.QueryString["rk"] != null) {
                sqlStr += " and ENTRYSTATIONNAME like '%" + HttpUtility.UrlDecode(Request.QueryString["rk"].ToString()) + "%'";
            }
            if (Request.QueryString["ck"] != null) {
                sqlStr += " and EXITSTATIONNAME like '%" + HttpUtility.UrlDecode(Request.QueryString["ck"].ToString()) + "%'";
            }
            if (Request.QueryString["zs"] != null) {
                sqlStr += " and AXISNUM=" + Request.QueryString["zs"].ToString();
            }
            if (Request.QueryString["sw"] != null) {
                sqlStr += " and TOTALWEIGHT>=" + Request.QueryString["sw"].ToString();
            }
            if (Request.QueryString["ew"] != null) {
                sqlStr += " and TOTALWEIGHT<=" + Request.QueryString["ew"].ToString();
            }
            if (Request.QueryString["cl"] != null) {
                string cl = Request.QueryString["cl"].ToString();
                if (cl == "1") {
                    sqlStr += " and OVERLOADRATE<=30";
                } else if (cl == "2") {
                    sqlStr += " and OVERLOADRATE>30 and OVERLOADRATE<=50";
                } else if (cl == "3") {
                    sqlStr += " and OVERLOADRATE>50 and OVERLOADRATE<=100";
                } else if (cl == "4") {
                    sqlStr += " and OVERLOADRATE>100";
                }
            }

            if (Request.QueryString["sd"] != null && Request.QueryString["ed"] != null) {
                DateTime startDate = Convert.ToDateTime(Request.QueryString["sd"]);
                DateTime endDate = Convert.ToDateTime(Request.QueryString["ed"]);
                if (startDate == endDate) {
                    sqlStr += " AND ENTRYTIME='" + startDate + "'";
                } else {
                    sqlStr += " AND (ENTRYTIME BETWEEN '" + startDate + "' AND '" + endDate.AddDays(1) + "')";
                }
            }

            string pay = Request.QueryString["pay"];
            if (pay != null) {
                sqlStr += " AND PAYTYPE like '%" + pay + "%'";
            }

            if (Request.QueryString["smoney"] != null && Request.QueryString["emoney"] != null) {
                string smoney = Request.QueryString["smoney"];
                string emoney = Request.QueryString["emoney"];

                if (smoney == emoney) {
                    sqlStr += " AND TOTALTOLL=" + int.Parse(smoney);
                } else {
                    sqlStr += " AND (TOTALTOLL>=" + int.Parse(smoney) + " AND TOTALTOLL<=" + int.Parse(emoney) + ")";
                }
            }

            if (Request.QueryString["smileage"] != null && Request.QueryString["emileage"] != null) {
                string smileage = Request.QueryString["smileage"];
                string emileage = Request.QueryString["emileage"];

                if (smileage == emileage) {
                    sqlStr += " AND DISTANCE=" + int.Parse(smileage);
                } else {
                    sqlStr += " AND (DISTANCE>=" + decimal.Parse(smileage) + " AND DISTANCE<=" + decimal.Parse(emileage) + ")";
                }
            }

            ViewState["sqlStr"] = sqlStr;

            DataTable dt = null;

            dt = overloadManager.GetOverloadRate(sqlStr); ;


            if (dt != null && dt.Rows.Count > 0) {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                this.gv_overload.DataSource = pds;
                this.gv_overload.DataBind();

            } else {
                litMsg.Visible = true;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e) {
            LoadData();
        }
    }
}