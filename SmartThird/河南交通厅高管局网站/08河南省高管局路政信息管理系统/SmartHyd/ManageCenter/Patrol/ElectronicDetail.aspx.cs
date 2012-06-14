using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.Patrol
{
    public partial class ElectronicDetail : System.Web.UI.Page
    {
        private BLL.BASE_OBSERVED bll = new BLL.BASE_OBSERVED();
        private BLL.BASE_DEPT deptbll = new BLL.BASE_DEPT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null!=Request.QueryString["id"]||""!=Request.QueryString["id"])
                {
                     decimal Epid = Convert.ToDecimal(Request.QueryString["id"]);
                    ViewState["id"] = Request.QueryString["id"];
                    Entity.BASE_OBSERVED model = bll.GetModel(Epid);
                    this.deptname.InnerHtml=getDeptName(model.DEPTID);
                    this.divuser.InnerHtml = model.PATROLUSER;
                    this.weather.InnerHtml = model.WEATHER;
                    //this.starttime.InnerHtml = model.BEGINTIME.ToShortDateString();
                    //this.endtime.InnerHtml = model.ENDDATE.ToShortDateString();
                    //this.result.InnerHtml = model.LOG;
                }
            }
        }
        /// <summary>
        /// 根据编号获取巡逻中队名称
        /// </summary>
        /// <param name="DEPTID"></param>
        private string getDeptName(decimal DEPTID)
        {
            string deptname=string.Empty;
            deptname = deptbll.GetEntity(DEPTID).DPTNAME;
            return deptname;
        }
    }
}