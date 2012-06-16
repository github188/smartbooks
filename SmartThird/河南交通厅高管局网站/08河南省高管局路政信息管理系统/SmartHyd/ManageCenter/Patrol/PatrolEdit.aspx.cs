using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.Patrol
{
    public partial class PatrolEdit : System.Web.UI.Page
    {
        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();
        private BLL.BASE_HANDLING handlingbll = new BLL.BASE_HANDLING();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null == Request.QueryString["id"] || "" == Request.QueryString["id"])
                {
                    //添加状态页面
                    this.LabName.Text = "添加人工巡逻日志";
                    ShowTimes();
                }
                else
                {
                    //编辑状态绑定
                    this.LabName.Text = "编辑人工巡逻日志";
                    decimal pid = Convert.ToDecimal(Request.QueryString["id"]);
                    ViewState["id"] = Request.QueryString["id"];
                    Entity.BASE_PATROL model = bll.GetModel(pid);
                    SetPatrolEntity(model);
                }
            }
        }
        /// <summary>
        /// 显示巡逻处理情况的次数
        /// </summary>
        private void ShowTimes()
        {
            //判断第几次巡逻:如果巡逻开始日期不是当前日期为第一次巡逻；
            //如果当前日期下有一条数据则为第二次巡逻；
            //如果当前日期下数据记录总数与巡逻次数相同：显示下班，交接班内容
            string sqlwhere = "1=1 AND PATROLTYPE='人工巡逻' AND to_char(BEGINTIME,'yyyy-MM-dd')=to_char(sysdate,'yyyy-MM-dd')";
            DataTable dt = handlingbll.GetList(sqlwhere);
            if (dt.Rows.Count > 0)
            {
                //巡逻次数
                int times = Convert.ToInt32(dt.Rows[0]["TIMES"]);
                int counts = handlingbll.getCount()+1;//当前记录数的下一记录
                if (counts < times)
                {
                    int count = dt.Rows.Count + 1;
                    this.LabheadName.Text = "第" + count + "次巡查";
                }
                else
                {
                    this.LabheadName.Text = "第" + times + "次巡查";
                    this.divShift.Style.Add("display", "block");
                }
                decimal pid = Convert.ToDecimal(dt.Rows[0]["PID"]);
                Entity.BASE_PATROL model = bll.GetModel(pid);
                SetPatrolEntity(model);
            }
            else
            {
                this.LabheadName.Text = "第1次巡查";
            }
        }
        #region 人工巡逻日志
        /// <summary>
        /// 获取人工巡逻日志实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_PATROL GetPartolEntity()
        {
            Entity.BASE_PATROL model = new Entity.BASE_PATROL();
            model.PATROLID = Convert.ToInt32(hidPrimary.Value);     //id,主键
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            if (ViewState["id"] != null)
            {
                model.DEPTID = 1;//默认单位编号
            }
            else
            {
                model.DEPTID = Convert.ToInt32(ddr.SelectedValue);  //巡查中队
            }
            model.RESPUSER = txtRESPUSER.Text;                      //巡查负责人
            model.PATROLUSER = txtPATROLUSER.Text;                  //巡查人员
            model.BUSNUMBER = txtBUSNUMBER.Text;                    //巡逻车牌号
            model.MILEAGE = Convert.ToInt32(txtMILEAGE.Text);       //巡查里程
            model.WEATHER = txtWEATHER.Text;                        //天气
            // model.LOG = txtLog.Text;                                //巡查处理情况
            model.WITHIN = txtWITHIN.Text;                          //移交内业处理事项
            model.NEXTWITHIN = txtNEXTWITHIN.Text;                  //移交下班处理事项
            model.GOODS = txtGOODS.Text;                            //移交器材
            model.SHIFTCAPTAIN = txtSHIFTCAPTAIN.Text;              //交班中队长
            model.ACCEPTCAPTAIN = txtACCEPTCAPTAIN.Text;            //接班中对长
            model.ACCEPTBUSNUMBER = txtACCEPTBUSNUMBER.Text;        //接班巡逻车牌号            
            //model.BEGINTIME = DateTime.Parse(txtBEGINTIME.Text);    //巡查开始时间
            //model.ENDTIME = DateTime.Parse(txtENDTIME.Text);        //巡查结束时间
            //model.TICKTIME = DateTime.Parse(this.txtTickTime.Text);       //交接班时间
            model.BUSKM = Convert.ToInt32(txtBUSKM.Text);           //接班巡逻车里程表
            // model.ACCEPT = 0;               //接收人
            // model.TRANSFER = 0;             //移交人

            return model;
        }

        private void SetPatrolEntity(Entity.BASE_PATROL model)
        {
            hidPrimary.Value = model.PATROLID.ToString();
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            if (model.DEPTID == 0)
            {
                ddr.SelectedValue = "1";
            }
            else
            {
                ddr.SelectedValue = model.DEPTID.ToString();
            }
            txtRESPUSER.Text = model.RESPUSER;
            txtPATROLUSER.Text = model.PATROLUSER;
            txtBUSNUMBER.Text = model.BUSNUMBER;
            txtMILEAGE.Text = model.MILEAGE.ToString();
            // txtWEATHER.Text = model.LOG;
            // txtLog.Text = model.LOG;
            txtWITHIN.Text = model.WITHIN;
            txtNEXTWITHIN.Text = model.NEXTWITHIN;
            txtGOODS.Text = model.GOODS;
            txtSHIFTCAPTAIN.Text = model.SHIFTCAPTAIN;
            txtACCEPTCAPTAIN.Text = model.ACCEPTCAPTAIN;
            txtACCEPTBUSNUMBER.Text = model.ACCEPTBUSNUMBER;
            //txtBEGINTIME.Text = model.BEGINTIME.ToString("yyyy-MM-dd");
            // txtENDTIME.Text = model.ENDTIME.ToString("yyyy-MM-dd");
            txtBUSKM.Text = model.BUSKM.ToString();

        }
        #endregion
        #region 巡查处理情况
        /// <summary>
        /// 获取处理情况实体数据
        /// </summary>
        /// <param name="pid">巡逻日志编号</param>
        /// <param name="times">巡逻次数</param>
        /// <returns></returns>
        private Entity.BASE_HANDLING GetHandlingEntity(decimal pid, decimal times)
        {
            Entity.BASE_HANDLING model = new Entity.BASE_HANDLING();
            model.HID = -1;//主键，巡查处理情况编号
            model.PATROLTYPE = "人工巡逻";//巡逻类型；
            model.TIMES = times;//巡逻次数；
            TextBox tb1 = (TextBox)this.Handling1.FindControl("txtBEGINTIME");

            model.BEGINTIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + tb1.Text);//开始时间
            TextBox tb2 = (TextBox)this.Handling1.FindControl("txtENDTIME");
            model.ENDTIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + tb2.Text);//结束时间
            TextBox txtLog = (TextBox)this.Handling1.FindControl("txtLog");
            model.CONTENT = txtLog.Text;//处理情况内容；
            model.PID = pid;
            TextBox txtRemark = (TextBox)this.Handling1.FindControl("txtRemark");
            model.REMARK = txtRemark.Text;//备注
            return model;
        }
        private void SetHandlingEntity(Entity.BASE_HANDLING model)
        {
            TextBox tb1 = (TextBox)this.Handling1.FindControl("txtBEGINTIME");

            tb1.Text = model.BEGINTIME.ToString("yyyy-MM-dd hh:mm:ss");//开始时间
            TextBox tb2 = (TextBox)this.Handling1.FindControl("txtENDTIME");
            tb2.Text = model.ENDTIME.ToString("yyyy-MM-dd hh:mm:ss");//结束时间
            TextBox txtLog = (TextBox)this.Handling1.FindControl("txtLog");
            txtLog.Text = model.CONTENT;//处理情况内容；
            TextBox txtRemark = (TextBox)this.Handling1.FindControl("txtRemark");
            txtRemark.Text = model.REMARK;//备注
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entity.BASE_PATROL model = GetPartolEntity();

            if (model != null)
            {
                if (ViewState["id"] == null)
                {
                    PatrolAdd(model);//添加人工巡逻日志
                }
                else
                {
                    bll.update(model);
                }
                Response.Redirect("ArtificialPatrol.aspx", true);
            }
            else
            {
                return;
            }
        }

        private void PatrolAdd(Entity.BASE_PATROL model)
        {
            decimal Pid = Convert.ToDecimal(bll.GetMaxID());//获取最新添加的巡逻日志编号
            string sqlwhere = "1=1 and PID=" + Pid + " and to_char(BEGINTIME,'yyyy-MM-dd')=to_char(sysdate,'yyyy-MM-dd')";//查询当前巡逻日志下是否有巡查处理情况
            if (handlingbll.GetList(sqlwhere).Rows.Count > 0)
            {
                Entity.BASE_HANDLING handlingmodel = GetHandlingEntity(Pid, 3);
                handlingbll.Add(handlingmodel);//添加巡查处理情况

                if (this.divShift.Style.Value == "block")
                {
                    bll.update(model);
                }
            }
            else
            {
                int a = bll.Add(model);//添加人工巡逻日志
                if (a > 0)
                {
                    decimal newPid = Convert.ToDecimal(bll.GetMaxID());//获取最新添加的巡逻日志编号
                    Entity.BASE_HANDLING handlingmodel = GetHandlingEntity(newPid, 3);
                    handlingbll.Add(handlingmodel);//添加巡查处理情况
                }
                else
                {
                    //提示添加巡逻日志失败
                }
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetPatrolEntity(new Entity.BASE_PATROL());
        }
        /// <summary>
        /// 捕获页面处理过程中发生的而没有处理的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    if (ex is HttpRequestValidationException)
        //    {
        //        Response.Write("请您输入合法字符串。<a href='PatrolEdit.aspx'>返回</a>");
        //        Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
        //    }
        //}
    }
}