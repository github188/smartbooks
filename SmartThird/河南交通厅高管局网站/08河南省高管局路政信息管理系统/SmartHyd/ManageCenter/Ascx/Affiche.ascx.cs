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
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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

      
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="AFFICHEID"></param>
        protected void DEl(decimal AFFICHEID)
        {
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

        protected void btn_ok_Click(object sender, EventArgs e)
        {

        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }

     
    }
}