using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Overload {
    public partial class IntegratedQuery : System.Web.UI.Page {

        BLL.BASE_BUS_OVERRUN overloadManager = new BLL.BASE_BUS_OVERRUN();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                
                BindChaoZaiLv_Search(ddlChaoZaiLv);
                Bind_TrafficStationCity_Search(ddlCity);
                Bind_TrafficStationCompany_Search(ddlCompany);
                Bind_TrafficStationHighWay_Search(ddlHighWay);


                rdoW_CheckedChanged(null, null);
            }
        }

        /// <summary>
        /// 设定查询规则：常规；按入口站查询；按出口站查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdoW_CheckedChanged(object sender, EventArgs e) {
            if (rdoW.Checked) {

                ddlCompany.Enabled = false;
                ddlCity.Enabled = false;
                ddlHighWay.Enabled = false;

            } else if (rdoRK.Checked) {

                ddlCompany.Enabled = true;
                ddlCity.Enabled = true;
                ddlHighWay.Enabled = true;

            } else if (rdoCK.Checked) {

                ddlCompany.Enabled = true;
                ddlCity.Enabled = true;
                ddlHighWay.Enabled = true;

            }
        }

        /// <summary>
        /// 执行信息检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            string param = "";
            if (rdoRK.Checked || rdoCK.Checked) {
                if (rdoRK.Checked) {
                    param += "lx=2";//入口查询设定
                } else if (rdoCK.Checked) {
                    param += "lx=3";//出口查询设定
                }
                if (ddlCompany.SelectedValue != "0") {
                    param += "&gl=" + HttpUtility.UrlEncode(ddlCompany.SelectedValue);
                }
                if (ddlCity.SelectedValue != "0") {
                    param += "&ds=" + HttpUtility.UrlEncode(ddlCity.SelectedValue);
                }
                if (ddlHighWay.SelectedValue != "0") {
                    param += "&gs=" + HttpUtility.UrlEncode(ddlHighWay.SelectedValue);
                }
            } else {
                param += "lx=1";//常规查询
            }
            if (txtVehicleLicense.Text.Trim() != "") {
                param += "&cp=" + HttpUtility.UrlEncode(txtVehicleLicense.Text.Trim());
            }
            if (txtEnterStation.Text.Trim() != "") {
                param += "&rk=" + HttpUtility.UrlEncode(txtEnterStation.Text.Trim());
            }
            if (txtOutStation.Text.Trim() != "") {
                param += "&ck=" + HttpUtility.UrlEncode(txtOutStation.Text.Trim());
            }
            if (txtVehicleAxle.Text.Trim() != "") {
                param += "&zs=" + txtVehicleAxle.Text.Trim();
            }
            if (txtStartTotalWeight.Text.Trim() != "") {
                param += "&sw=" + txtStartTotalWeight.Text.Trim();
            }
            if (txtEndTotalWeight.Text.Trim() != "") {
                param += "&ew=" + txtEndTotalWeight.Text.Trim();
            }
            if (ddlChaoZaiLv.SelectedValue != "0") {
                param += "&cl=" + ddlChaoZaiLv.SelectedValue;
            }
            if (txt_startDate.Text != "" && txt_endDate.Text != "") {
                param += "&sd=" + txt_startDate.Text + "&ed=" + txt_endDate.Text;
            }

            ///增加支付形式、金额、里程三个查询条件设置
            if (txt_pay.Text.Trim() != "" && txt_pay.Text.Trim() != null) {
                param += "&pay=" + txt_pay.Text;
            }
            if (txt_smoney.Text.Trim() != "" && txt_smoney.Text.Trim() != null) {
                param += "&smoney=" + txt_smoney.Text;
            }
            if (txt_emoney.Text.Trim() != "" && txt_emoney.Text.Trim() != null) {
                param += "&emoney=" + txt_emoney.Text;
            }
            if (txt_smileage.Text.Trim() != "" && txt_smileage.Text.Trim() != null) {
                param += "&smileage=" + txt_smileage.Text;
            }
            if (txt_emileage.Text.Trim() != "" && txt_emileage.Text.Trim() != null) {
                param += "&emileage=" + txt_emileage.Text;
            }


            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "result", "window.location.href='IntegratedQueryResult.aspx?" + param + "'", true);
        }

        /// <summary>
        /// 导出Excel数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e) {

        }


        #region 基础数据绑定
        /// <summary>
        /// 绑定超载率下拉列表
        /// </summary>
        /// <param name="ddlChaoZaiLv"></param>
        public void BindChaoZaiLv_Search(System.Web.UI.WebControls.DropDownList ddlChaoZaiLv) {
            ddlChaoZaiLv.Items.Clear();
            ddlChaoZaiLv.Items.Add(new ListItem("", "0"));
            ddlChaoZaiLv.Items.Add(new ListItem("0%-30%", "1"));
            ddlChaoZaiLv.Items.Add(new ListItem("30%-50%", "2"));
            ddlChaoZaiLv.Items.Add(new ListItem("50%-100%", "3"));
            ddlChaoZaiLv.Items.Add(new ListItem("100%以上", "4"));
            ddlChaoZaiLv.SelectedValue = "0";
        }

        /// <summary>
        /// 绑定车辆通行记录中收费站所隶属管理公司下拉列表(供查询时使用)
        /// </summary>
        /// <param name="ddlCompany"></param>
        public  void Bind_TrafficStationCompany_Search(System.Web.UI.WebControls.DropDownList ddlCompany) {
            ddlCompany.Items.Clear();
            DataTable dt = null;
            dt = overloadManager.GetUnitList();
            if (dt != null) {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    ddlCompany.Items.Add(new ListItem(dt.Rows[i]["TS_COMPANY"].ToString(), dt.Rows[i]["TS_COMPANY"].ToString()));
                }
            }
            ddlCompany.Items.Add(new ListItem("", "0"));
            ddlCompany.SelectedValue = "0";
        }
        /// <summary>
        /// 绑定车辆通行记录中收费站所隶属地市下拉列表(供查询时使用)
        /// </summary>
        /// <param name="ddlCompany"></param>
        public  void Bind_TrafficStationCity_Search(System.Web.UI.WebControls.DropDownList ddlCity) {
            ddlCity.Items.Clear();
            DataTable dt = null;
            dt = overloadManager.GetCityList();
            if (dt != null) {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    ddlCity.Items.Add(new ListItem(dt.Rows[i]["TS_CITY"].ToString(), dt.Rows[i]["TS_CITY"].ToString()));
                }
            }
            ddlCity.Items.Add(new ListItem("", "0"));
            ddlCity.SelectedValue = "0";
        }
        /// <summary>
        /// 绑定车辆通行记录中收费站所隶属高速公路下拉列表(供查询时使用)
        /// </summary>
        /// <param name="ddlHighWay"></param>
        public void Bind_TrafficStationHighWay_Search(System.Web.UI.WebControls.DropDownList ddlHighWay) {
            ddlHighWay.Items.Clear();
            DataTable dt = null;
            dt = overloadManager.GetHighwayList();
            if (dt != null) {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    ddlHighWay.Items.Add(new ListItem(dt.Rows[i]["TS_HIGHWAY"].ToString(), dt.Rows[i]["TS_HIGHWAY"].ToString()));
                }
            }
            ddlHighWay.Items.Add(new ListItem("", "0"));
            ddlHighWay.SelectedValue = "0";
        }
        #endregion 
    }
}