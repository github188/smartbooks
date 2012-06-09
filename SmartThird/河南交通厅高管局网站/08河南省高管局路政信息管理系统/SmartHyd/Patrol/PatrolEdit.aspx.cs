using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.Patrol {
    public partial class PatrolEdit : System.Web.UI.Page {
        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                if (null == Request.QueryString["id"] || "" == Request.QueryString["id"])
                {
                    //添加状态页面
                    this.LabName.Text = "添加人工巡逻日志";
                }
                else
                {
                    //编辑状态绑定
                    this.LabName.Text = "编辑人工巡逻日志";
                    decimal pid = Convert.ToDecimal(Request.QueryString["id"]);
                    ViewState["id"] = Request.QueryString["id"];
                    Entity.BASE_PATROL model = bll.GetModel(pid);
                    SetEntity(model);
                }
            }
        }
        private Entity.BASE_PATROL GetEntity()
        {
            Entity.BASE_PATROL model = new Entity.BASE_PATROL();
            model.PATROLID = Convert.ToInt32(hidPrimary.Value);     //id,主键
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            
            model.DEPTID = Convert.ToInt32(ddr.SelectedValue);  //巡查中队
            model.RESPUSER = txtRESPUSER.Text;                      //巡查负责人
            model.PATROLUSER = txtPATROLUSER.Text;                  //巡查人员
            model.BUSNUMBER = txtBUSNUMBER.Text;                    //巡逻车牌号
            model.MILEAGE = Convert.ToInt32(txtMILEAGE.Text);       //巡查里程
            model.WEATHER = txtWEATHER.Text;                        //天气
            model.LOG = txtLog.Text;                                //巡查处理情况
            model.WITHIN = txtWITHIN.Text;                          //移交内业处理事项
            model.NEXTWITHIN = txtNEXTWITHIN.Text;                  //移交下班处理事项
            model.GOODS = txtGOODS.Text;                            //移交器材
            model.SHIFTCAPTAIN = txtSHIFTCAPTAIN.Text;              //交班中队长
            model.ACCEPTCAPTAIN = txtACCEPTCAPTAIN.Text;            //接班中对长
            model.ACCEPTBUSNUMBER = txtACCEPTBUSNUMBER.Text;        //接班巡逻车牌号            
            model.BEGINTIME = DateTime.Parse(txtBEGINTIME.Text);    //巡查开始时间
            model.ENDTIME = DateTime.Parse(txtENDTIME.Text);        //巡查结束时间
            model.TICKTIME = DateTime.Parse(txtENDTIME.Text);       //交接班时间
            model.BUSKM = Convert.ToInt32(txtBUSKM.Text);           //接班巡逻车里程表
            model.ACCEPT = 0;               //接收人
            model.TRANSFER = 0;             //移交人

            return model;
        }

        private void SetEntity(Entity.BASE_PATROL model)
        {
            hidPrimary.Value = model.PATROLID.ToString();
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件

            ddr.SelectedValue = model.DEPTID.ToString();
            txtRESPUSER.Text = model.RESPUSER;
            txtPATROLUSER.Text = model.PATROLUSER;
            txtBUSNUMBER.Text = model.BUSNUMBER;
            txtMILEAGE.Text = model.MILEAGE.ToString();
            txtWEATHER.Text = model.LOG;
            txtLog.Text = model.LOG;
            txtWITHIN.Text = model.WITHIN;
            txtNEXTWITHIN.Text = model.NEXTWITHIN;
            txtGOODS.Text = model.GOODS;
            txtSHIFTCAPTAIN.Text = model.SHIFTCAPTAIN;
            txtACCEPTCAPTAIN.Text = model.ACCEPTCAPTAIN;
            txtACCEPTBUSNUMBER.Text = model.ACCEPTBUSNUMBER;
            txtBEGINTIME.Text = model.BEGINTIME.ToString("yyyy-MM-dd");
            txtENDTIME.Text = model.ENDTIME.ToString("yyyy-MM-dd");
            txtBUSKM.Text = model.BUSKM.ToString();

        }
        protected void btnSubmit_Click(object sender, EventArgs e) {
            Entity.BASE_PATROL model = GetEntity();
            if (ViewState["id"] == null)
            {
                bll.Add(model);
            }
            else
            {
                bll.update(model);
            }
            Response.Redirect("ArtificialPatrol.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            SetEntity(new Entity.BASE_PATROL());
        }
        /// <summary>
        /// 捕获页面处理过程中发生的而没有处理的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                Response.Write("请您输入合法字符串。");
                Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
            }
        }
    }
}