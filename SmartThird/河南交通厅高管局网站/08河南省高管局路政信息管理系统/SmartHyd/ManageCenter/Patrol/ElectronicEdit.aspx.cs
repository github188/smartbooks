using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.Patrol
{
    public partial class ElectronicEdit : System.Web.UI.Page
    {
        private BLL.BASE_OBSERVED bll = new BLL.BASE_OBSERVED();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null == Request.QueryString["id"] || "" == Request.QueryString["id"])
                {
                    //添加状态页面
                    this.LabName.Text = "添加巡逻日志";
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
                ddr.SelectedValue = "4";
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
            if (string.IsNullOrEmpty(this.txtLog.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "请填写巡查处理情况!", true);
                txtLog.Focus();
                return false;
            }
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
                    bll.Add(model);
                }
                else
                {
                    bll.update(model);
                }
                Response.Redirect("ElectronicPatrol.aspx", true);
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