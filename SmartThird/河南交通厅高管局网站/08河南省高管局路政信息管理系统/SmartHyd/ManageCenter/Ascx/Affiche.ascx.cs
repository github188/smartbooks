using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Affiche : UI.BaseUserControl
    {
        private BLL.BASE_AFFICHE bll = new BLL.BASE_AFFICHE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ("" == Request.QueryString["aid"] || null == Request.QueryString["aid"])
                {
                    if (this.hidPrimary.Value == "-1")
                    {
                        this.LbTabName.Text = "新建电子公告";//设置选项卡名称
                        this.LbHeadName.Text = "新建电子公告";//设置标题头名称
                        this.TxtTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        this.LbTabName.Text = "编辑电子公告";//设置选项卡名称
                        this.LbHeadName.Text = "编辑电子公告";//设置标题头名称
                        decimal AFFICHEID = Convert.ToDecimal(this.hidPrimary.Value);
                        Entity.BASE_AFFICHE model = bll.Getmodel(AFFICHEID);
                        SetEntity(model);
                    }
                }
                else
                {
                    this.LbTabName.Text = "编辑电子公告";//设置选项卡名称
                    this.LbHeadName.Text = "编辑电子公告";//设置标题头名称
                    decimal AFFICHEID = Convert.ToDecimal(Request.QueryString["aid"]);
                    Entity.BASE_AFFICHE model = bll.Getmodel(AFFICHEID);
                    SetEntity(model);
                }
                dataBindToRepeater();//绑定电子公告数据
            }
        }
        //使用dataBindToRepeater()方法绑定电子公告数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetAfficheList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptAffiche.DataSource = pds; //定义数据源
            this.RptAffiche.DataBind(); //绑定数据
        }
        #region 公告数据添加
        /// <summary>
        /// 获得公告实体数据
        /// </summary>
        /// <param name="states">公告状态</param>
        /// <returns></returns>
        private Entity.BASE_AFFICHE GetEntity(decimal states)
        {
            Entity.BASE_AFFICHE model = new Entity.BASE_AFFICHE();
            model.AFFICHEID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.AFFICHETITLE = this.TxtTitle.Text;                      //公告标题
            model.AFFICHER = "admin";                                     //公告发布人
            model.AFFICHEDATE = DateTime.Parse(this.TxtTime.Text);         //公告发布时间
            model.AFFICHECONTENTS = this.TxtContent.Text;                  //公告内容
            model.STATES = states;                                              //公告状态0:已保存；1：已发布；2：已删除；

            return model;
        }
        /// <summary>
        /// 设置公告数据
        /// </summary>
        /// <param name="model">公告实体</param>
        private void SetEntity(Entity.BASE_AFFICHE model)
        {
            this.hidPrimary.Value = model.AFFICHEID.ToString();        //id,主键
            this.TxtTitle.Text = model.AFFICHETITLE;                    //公告标题
            //model.AFFICHER = "admin";                                //公告发布人
            this.TxtTime.Text = model.AFFICHEDATE.ToString("yyyy-MM-dd");             //公告发布时间
            this.TxtContent.Text = model.AFFICHECONTENTS;                  //公告内容
            //model.STATES = 0;                                   //公告状态0:已保存；1：已发布；2：已删除；

        }
        #endregion

        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_AFFICHE model = GetEntity(0);

            //添加数据
            bll.Add(model);
            //日志..............添加
             Entity.BASE_LOG logmodel = new Entity.BASE_LOG();

            logmodel.LOGID = -1;                        //id,主键
            logmodel.LOGTYPE = "电子公告";                     //日志类型
            logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
            logmodel.DESCRIPTION = "添加公告";                             //日志信息内容
            logmodel.OPERATORID = 23;                    //操作人
            logmodel.IPADDRESS = Smart.Utility.IpAddress.getIP();                 //ip地址
            
            logbll.Add(logmodel);
            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri+"#tabs-2", true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {

        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_AFFICHE());

            Smart.Utility.Alerts.Alert("test");
        }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) {
            //获取实体
            Entity.BASE_AFFICHE model = GetEntity(0);

            //修改公告
            if (bll.update(model))
            {
                //重新加载当前页
                Response.Redirect("Affiche.aspx#tabs-2", true);
            }
            else
            {
                Response.Redirect(Request.Url.AbsoluteUri, false);
            }
        }
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
        //发布
        /// <summary>
        /// 发布公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void BtnSend_Click(object sender, EventArgs e) {
            Entity.BASE_AFFICHE model = GetEntity(1);
            bll.Add(model);
            Response.Redirect("Affiche.aspx#tabs-2");
        }
        
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
        /// 删除公告
        /// </summary>
        /// <param name="AFFICHEID"></param>
        protected void DEl(decimal AFFICHEID)
        {
            Response.Write("<script type='text/javascript'>alert('进入！');</script>");
            Entity.BASE_AFFICHE model=bll.Getmodel(AFFICHEID);
            model.STATES=2;//设置状态为已删除
            if (bll.update(model))
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('删除失败！');</script>");
            }
        }
    }
}