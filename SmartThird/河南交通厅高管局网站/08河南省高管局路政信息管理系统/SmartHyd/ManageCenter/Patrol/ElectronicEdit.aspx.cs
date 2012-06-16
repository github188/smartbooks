using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.Patrol
{
    public partial class ElectronicEdit : System.Web.UI.Page
    {
        private BLL.BASE_OBSERVED bll = new BLL.BASE_OBSERVED();
        private BLL.BASE_HANDLING handlingbll = new BLL.BASE_HANDLING();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null == Request.QueryString["id"] || "" == Request.QueryString["id"])
                {
                    //添加状态页面
                    this.LabName.Text = "添加巡逻日志";
                    ShowTimes();
                }
                else
                {
                    //编辑状态绑定
                    this.LabName.Text = "编辑电子巡逻日志";
                    decimal Epid = Convert.ToDecimal(Request.QueryString["id"]);
                    ViewState["id"] = Request.QueryString["id"];
                    Entity.BASE_OBSERVED model = bll.GetModel(Epid);
                    SetEntity(model);
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
            string sqlwhere = "1=1 AND PATROLTYPE='电子巡逻' AND to_char(BEGINTIME,'yyyy-MM-dd')=to_char(sysdate,'yyyy-MM-dd')";
            DataTable dt = handlingbll.GetList(sqlwhere);
            if (dt.Rows.Count > 0)
            {
                //巡逻次数
                int times = Convert.ToInt32(dt.Rows[0]["TIMES"]);
                int counts = handlingbll.getCount();//当前记录数
                if (counts < times)
                {
                    int count = dt.Rows.Count + 1;
                    this.LabheadName.Text = "第" + count + "次巡查";
                }
                else
                {
                    this.LabheadName.Text = "第" + times + "次巡查";
                }
            }
            else
            {
                this.LabheadName.Text = "第1次巡查";
            }
        }
        //获取实体
        private Entity.BASE_OBSERVED GetEntity()
        {
            Entity.BASE_OBSERVED model = new Entity.BASE_OBSERVED();
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            model.DEPTID = Convert.ToInt32(ddr.SelectedValue);
            model.PATROLUSER = txtPATROLUSER.Text.Trim();
            //model.BEGINTIME = DateTime.Parse(txtBEGINTIME.Text.Trim());
            //model.ENDDATE = DateTime.Parse(txtENDTIME.Text.Trim());
            //model.LOG = txtLog.Text.Trim();
            model.WEATHER = txtWEATHER.Text.Trim();

            return model;
        }
        //将实体赋值到页面
        private void SetEntity(Entity.BASE_OBSERVED model)
        {
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            if (model.DEPTID == 0)
            {
                ddr.SelectedValue = "1";
            }
            else
            {
                ddr.SelectedValue = model.DEPTID.ToString();
            }
            txtPATROLUSER.Text = model.PATROLUSER;
            //txtBEGINTIME.Text = model.BEGINTIME.ToString("yyyy-MM-dd");
            //txtENDTIME.Text = model.ENDDATE.ToString("yyyy-MM-dd");
            //txtLog.Text = model.LOG;
            txtWEATHER.Text = model.WEATHER;
        }

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
            model.PATROLTYPE = "电子巡逻";//巡逻类型；
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
        /// <summary>
        /// 验证提交
        /// </summary>
        /// <returns>true通过,false不通过</returns>
        private bool CheckFormSubmit()
        {

            //空值校验
            if (string.IsNullOrEmpty(this.txtPATROLUSER.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "巡查人员不能为空!", true);
                this.txtPATROLUSER.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(this.txtLog.Text.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "请填写巡查处理情况!", true);
            //    txtLog.Focus();
            //    return false;
            //}
            return true;
        }
        /// <summary>
        /// 按钮事件：提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entity.BASE_OBSERVED model = GetEntity();
            if (CheckFormSubmit())
            {
                if (ViewState["id"] == null)
                {
                    PatrolAdd(model);//添加人工巡逻日志
                }
                else
                {
                    bll.update(model);
                }
                Response.Redirect("ElectronicPatrol.aspx", true);
            }
            else
            {
                return;
            }
        }

        private void PatrolAdd(Entity.BASE_OBSERVED model)
        {
            decimal Pid = Convert.ToDecimal(bll.GetMaxID());//获取最新添加的巡逻日志编号
            string sqlwhere = "1=1 and PID=" + Pid + " and to_char(BEGINTIME,'yyyy-MM-dd')=to_char(sysdate,'yyyy-MM-dd')";//查询当前巡逻日志下是否有巡查处理情况
            if (handlingbll.GetList(sqlwhere).Rows.Count > 0)
            {
                Entity.BASE_HANDLING handlingmodel = GetHandlingEntity(Pid, 3);
                handlingbll.Add(handlingmodel);//添加巡查处理情况

            }
            else
            {
                int a = bll.Add(model);//添加电子巡逻日志
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_OBSERVED());
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
                Response.Write("请您输入合法字符串。<a href='ElectronicEdit.aspx'>返回</a>");
                Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
            }
        }

    }
}