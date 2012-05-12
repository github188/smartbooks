﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater();
            }
        }
        //使用dataBindToRepeater()方法绑定公文数据
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
        /// <summary>
        /// 公告管理分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
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
            model.AFFICHEDATE =DateTime.Parse(this.TxtTime.Text);         //公告发布时间
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
            this.TxtContent.Text=model.AFFICHECONTENTS;                  //公告内容
            //model.STATES = 0;                                   //公告状态0:已保存；1：已发布；2：已删除；

        }
        /// <summary>
        /// 按钮事件：保存公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Entity.BASE_AFFICHE model = GetEntity(0);
            bll.Add(model);
            Response.Redirect("Affiche.aspx#tabs-1");
        }
        #endregion
        /// <summary>
        /// 按钮事件：发布公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSend_Click(object sender, EventArgs e)
        {
            Entity.BASE_AFFICHE model = GetEntity(1);
            bll.Add(model);
            Response.Redirect("Affiche.aspx#tabs-1");
        }
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
        /// <summary>
        /// 按钮事件：返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBack_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Affiche.aspx#tabs-1");
        }
    }
}