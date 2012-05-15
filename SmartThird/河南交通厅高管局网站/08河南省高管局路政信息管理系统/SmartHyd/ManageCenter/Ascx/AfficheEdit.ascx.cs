using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class AfficheEdit : UI.BaseUserControl
    {
        private BLL.BASE_AFFICHE bll = new BLL.BASE_AFFICHE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ("" != Request.QueryString["aid"] || null != Request.QueryString["aid"])
                {
                    decimal AFFICHEID = Convert.ToDecimal(Request.QueryString["aid"]);
                    Entity.BASE_AFFICHE model = bll.Getmodel(AFFICHEID);
                     SetEntity(model);
                }
            }
        }
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
        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e)
        {

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
        public override void BtnUpdate_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_AFFICHE model = GetEntity(0);

            //添加数据
            if (bll.update(model))
            {
                //重新加载当前页
                Response.Redirect("Affiche.aspx#tabs-1", true);
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
        public override void BtnSend_Click(object sender, EventArgs e) {
            Entity.BASE_AFFICHE model = GetEntity(1);
            if (bll.update(model))
            {
                Response.Redirect("Affiche.aspx#tabs-1");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
            }
        }

        #endregion
        ///// <summary>
        ///// 按钮事件：发布
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void BtnSend_Click(object sender, EventArgs e)
        //{
        //    Entity.BASE_AFFICHE model = GetEntity(1);
        //    if (bll.update(model))
        //    {
        //        Response.Redirect("Affiche.aspx#tabs-1");
        //    }
        //    else
        //    {
        //        Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
        //    }
        //}
        ///// <summary>
        ///// 按钮事件：保存
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void BtnSave_Click(object sender, EventArgs e)
        //{
        //    Entity.BASE_AFFICHE model = GetEntity(0);
        //    if (bll.update(model))
        //    {
        //        Response.Redirect("");
        //    }
        //    else
        //    {
        //        Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
        //    }
        //}
        ///// <summary>
        ///// 按钮事件：返回
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void BtnBack_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Affiche.aspx#tabs-1");
        //}
    }
}