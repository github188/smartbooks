using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.Patrol
{
    public partial class PatrolDetail : System.Web.UI.Page
    {
        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();
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
                    this.deptname.InnerHtml = getDeptName(model.DEPTID);
                   this.AcceptNumber.InnerHtml= model.ACCEPTBUSNUMBER;//接班巡逻车牌号；
                   this.RespUser.InnerHtml = model.RESPUSER;//巡查负责人
                   this.shiftDeptName.InnerHtml = model.SHIFTCAPTAIN;//交班中队长
                        this.AcceptDeptname.InnerHtml=model.ACCEPTCAPTAIN;//接班中队长
                   this.GOODS.InnerHtml= model.GOODS;//移交器材
                   this.PatrolUser.InnerHtml= model.PATROLUSER;//巡查人员
                    this.Weather.InnerHtml = model.WEATHER;//天气
                    this.WITHIN.InnerHtml = model.WITHIN;//移交内业处理事项
                    this.NEXTWITHIN.InnerHtml = model.NEXTWITHIN;//移交下班处理事项
                    this.Mileage.InnerHtml = model.MILEAGE.ToString();//巡查里程
                    this.busNumber.InnerHtml = model.BUSNUMBER;//巡逻车牌号
                    this.BUSKM.InnerHtml=model.BUSKM.ToString();//接班巡逻车里程表
                    this.starttime.InnerHtml = model.BEGINTIME.ToShortDateString();
                    this.endtime.InnerHtml = model.ENDTIME.ToShortDateString();
                    this.result.InnerHtml = model.LOG;
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