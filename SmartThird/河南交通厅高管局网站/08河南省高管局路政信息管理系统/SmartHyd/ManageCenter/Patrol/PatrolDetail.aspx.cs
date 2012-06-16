using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.Patrol
{
    public partial class PatrolDetail : System.Web.UI.Page
    {
        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();
        private BLL.BASE_HANDLING handlingbll = new BLL.BASE_HANDLING();
        private BLL.BASE_DEPT deptbll = new BLL.BASE_DEPT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null != Request.QueryString["id"] || "" != Request.QueryString["id"])
                {
                    decimal Epid = Convert.ToDecimal(Request.QueryString["id"]);
                    ViewState["id"] = Request.QueryString["id"];
                    Entity.BASE_PATROL model = bll.GetModel(Epid);
                    DataTable dt = handlingbll.GetList("1=1 and PID=" + Epid);
                    this.deptname.InnerHtml = getDeptName(model.DEPTID);
                    this.AcceptNumber.InnerHtml = model.ACCEPTBUSNUMBER;//接班巡逻车牌号；
                    this.RespUser.InnerHtml = model.RESPUSER;//巡查负责人
                    this.shiftDeptName.InnerHtml = model.SHIFTCAPTAIN;//交班中队长
                    this.AcceptDeptname.InnerHtml = model.ACCEPTCAPTAIN;//接班中队长
                    this.GOODS.InnerHtml = model.GOODS;//移交器材
                    this.PatrolUser.InnerHtml = model.PATROLUSER;//巡查人员
                    this.Weather.InnerHtml = model.WEATHER;//天气
                    this.WITHIN.InnerHtml = model.WITHIN;//移交内业处理事项
                    this.NEXTWITHIN.InnerHtml = model.NEXTWITHIN;//移交下班处理事项
                    this.Mileage.InnerHtml = model.MILEAGE.ToString();//巡查里程
                    this.busNumber.InnerHtml = model.BUSNUMBER;//巡逻车牌号
                    this.BUSKM.InnerHtml = model.BUSKM.ToString();//接班巡逻车里程表
                    this.starttime.InnerHtml = model.TICKTIME.ToLongTimeString();//交接班时间
                    //this.endtime.InnerHtml = model.ENDTIME.ToShortDateString();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            this.result.InnerHtml += "<br/>第" + i+1 + "次巡逻" + dt.Rows[i]["BEGINTIME"];
                            this.result.InnerHtml += "至" + dt.Rows[i]["ENDTIME"];
                            this.result.InnerHtml += "<br/>" + dt.Rows[i]["CONTENT"];
                            this.result.InnerHtml += "<br/>注：" + dt.Rows[i]["REMARK"]+"<br/>";
                        }
                    }
                }
                else
                {
                    this.result.InnerHtml = "";
                }
            }
        }
        /// <summary>
        /// 根据编号获取巡逻中队名称
        /// </summary>
        /// <param name="DEPTID"></param>
        private string getDeptName(decimal DEPTID)
        {
            string deptname = string.Empty;
            deptname = deptbll.GetEntity(DEPTID).DPTNAME;
            return deptname;
        }
    }
}