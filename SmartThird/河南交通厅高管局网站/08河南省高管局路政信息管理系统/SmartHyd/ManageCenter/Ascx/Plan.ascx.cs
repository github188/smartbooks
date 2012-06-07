using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Plan : UI.BaseUserControl
    {
        
        private BLL.BASE_PLAN bll = new BLL.BASE_PLAN();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化参数
                DateTime beginTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddDays(5);
                this.txtStartTIME.Text = beginTime.ToString("yyyy-MM-dd");
                this.txtEndTIME.Text = endTime.ToString("yyyy-MM-dd");
                dataBindToRepeater();    
            }
            
        }
        //使用dataBindToRepeater()方法绑定公文数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetPlanList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.repList.DataSource = pds; //定义数据源
            this.repList.DataBind(); //绑定数据
        }
        /// <summary>
        /// 获取日志信息实体
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_PLAN GetEntity()
        {
            Entity.BASE_PLAN model = new Entity.BASE_PLAN();
            model.CALENDARID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.CALENDARTYPE = this.DdrType.SelectedItem.Text;                      //事务类型
            model.START_DATE = DateTime.Parse(this.txtStartTIME.Text);            //开始时间
            model.END_DATE = DateTime.Parse(this.txtEndTIME.Text);         //结束时间
            model.CALENDARREMIND = DateTime.Parse(this.txtPrompt.Text);                  //提醒时间
            model.CALENDARCONTENT = this.txtContent.Text;//日程内容
            model.USERID=Convert.ToInt32(this.TxtUser.Text);//用户编号
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
            this.DdrType.SelectedItem.Text=model.CALENDARTYPE ;                      //事务类型
            this.txtStartTIME.Text=model.START_DATE.ToString();            //开始时间
            this.txtEndTIME.Text=model.END_DATE.ToString();         //结束时间
            this.txtPrompt.Text=model.CALENDARREMIND.ToString();                  //提醒时间
            this.txtContent.Text=model.CALENDARCONTENT;//日程内容
            this.TxtUser.Text = usersession.USERID.ToString();//用户编号

        }
        private void delplan(decimal planid)
        {
            Entity.BASE_PLAN model = new Entity.BASE_PLAN();
            model.CALENDARID=planid;
            model.STATE=1;//更改事务状态为删除
            bll.update(model);
            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_PLAN model = GetEntity();

            //添加数据
            bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_PLAN());

            Smart.Utility.Alerts.Alert("test");
        }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) { }
        //查看
        public override void BtnView_Click(object sender, EventArgs e) { }
        //查询
        public override void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        public override void BtnImport_Click(object sender, EventArgs e) { }
        //导出
        public override void BtnExport_Click(object sender, EventArgs e) { }
        //打印
        public override void BtnPrint_Click(object sender, EventArgs e) { }
        //移动
        public override void BtnMove_Click(object sender, EventArgs e) { }
        //下载
        public override void BtnDownload_Click(object sender, EventArgs e) { }
        //备份
        public override void BtnBackup_Click(object sender, EventArgs e) { }
        //审核
        public override void BtnVerify_Click(object sender, EventArgs e) { }
        //授权
        public override void BtnGrant_Click(object sender, EventArgs e) { }
      

        /// <summary>
        /// //分页事件 公告管理分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
        #endregion
        /// <summary>
        /// 按钮事件：添加事务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SmartHyd.Utility.UserSession usersession = (SmartHyd.Utility.UserSession)Session["user"];
            //获取实体
            Entity.BASE_PLAN model = GetEntity();

            //添加数据
            bll.Add(model);
            //日志..............添加事务
            Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
            logmodel.LOGID = -1;                        //id,主键
            logmodel.LOGTYPE = "事务提醒";                     //日志类型
            logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
            logmodel.DESCRIPTION = "添加事务";                             //日志信息内容
            logmodel.OPERATORID = usersession.USERID;                    //操作人编号
            logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
            logbll.Add(logmodel);
            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
    }
}