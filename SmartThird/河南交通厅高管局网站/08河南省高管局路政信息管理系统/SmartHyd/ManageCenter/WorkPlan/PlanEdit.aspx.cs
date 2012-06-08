using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.WorkPlan
{
    public partial class PlanEdit : System.Web.UI.Page
    {
        BLL.BASE_PLAN planbll = new BLL.BASE_PLAN();
        BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null == Request.QueryString["planid"] || "" == Request.QueryString["planid"])
                {
                    //添加页面
                    this.LabName.Text = "新建事务";
                }
                else
                { 
                    //编辑页面
                    decimal planid = Convert.ToDecimal(Request.QueryString["planid"]);
                    ViewState["planid"] = Request.QueryString["planid"];
                    this.LabName.Text = "编辑事务";
                    Entity.BASE_PLAN model = planbll.GetModel(planid);
                    SetEntity(model);
                }
            }
        }
        /// <summary>
        /// 按钮事件：提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (null == ViewState["planid"])
            {
                //获取实体
                Entity.BASE_PLAN model = GetEntity();

                //添加数据
                planbll.Add(model);

                //重新加载当前页
                Response.Redirect("Plan.aspx", true);

            }
            else
            {
                //获取实体
                Entity.BASE_PLAN model = GetEntity();
                //添加数据
                planbll.update(model);

                //重新加载当前页
                Response.Redirect("Plan.aspx", true);
            }
        }
        /// <summary>
        /// 获取事务信息实体
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_PLAN GetEntity()
        {
            SmartHyd.Utility.UserSession usersession = (SmartHyd.Utility.UserSession)Session["user"];
            Entity.BASE_PLAN model = new Entity.BASE_PLAN();
            model.CALENDARID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.CALENDARTYPE = this.DdrType.SelectedItem.Text;                      //事务类型
            model.START_DATE = DateTime.Parse(this.txt_startTime.Text);            //开始时间
            model.END_DATE = DateTime.Parse(this.txt_endTime.Text);         //结束时间
            model.CALENDARREMIND = DateTime.Parse(this.txtPrompt.Text);                  //提醒时间
            model.CALENDARCONTENT = this.txtContent.Text;//日程内容
            model.USERID = Convert.ToInt32(usersession.USERID);//用户编号
            model.TITLE = this.TxtTitle.Text;//事务标题
            model.STATE = 0;//事务状态（0：正常；1，删除）
            return model;
        }
        /// <summary>
        /// 设置公告数据
        /// </summary>
        /// <param name="model">公告实体</param>
        private void SetEntity(Entity.BASE_PLAN model)
        {
            SmartHyd.Utility.UserSession usersession = (SmartHyd.Utility.UserSession)Session["user"];
            this.hidPrimary.Value = model.CALENDARID.ToString();        //id,主键
            this.DdrType.SelectedItem.Text = model.CALENDARTYPE;                      //事务类型
            this.txt_startTime.Text = model.START_DATE.ToString();            //开始时间
            this.txt_endTime.Text = model.END_DATE.ToString();         //结束时间
            this.txtPrompt.Text = model.CALENDARREMIND.ToString();                  //提醒时间
            this.txtContent.Text = model.CALENDARCONTENT;//日程内容
            this.TxtTitle.Text = model.TITLE;//事务标题
            
        }
    }
}