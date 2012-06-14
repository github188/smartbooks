﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Official {
    public partial class Trash : System.Web.UI.Page {
        private Utility.UserSession userSession;
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();

        protected void Page_Load(object sender, EventArgs e) {
            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindTrashList();
            }
        }

        //分页列表按钮反升命令事件
        protected void grvAcceptList_RowCommand(object sender, GridViewCommandEventArgs e) {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName) {
                /*还原*/
                case "back":
                    /*还原为未审核*/
                    bll.UpdateState(1, id);                    
                    break;
                /*彻底删除*/
                case "del":
                    /*不做删除，修改为隐藏*/
                    bll.UpdateState(4, id); 
                    break;
            }

            /*重新绑定数据*/
            BindTrashList();
        }

        //公文列表分页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindTrashList();
        }

        //绑定垃圾箱列表数据
        private void BindTrashList() {
            DataTable dt = new DataTable();

            /*发文列表数据*/
            //dt = bll.GetPublishList(Convert.ToInt32(userSession.DEPTID), typeId);

            /*收文列表数据(部门下收文数据)*/
            dt = bll.GetAcceptList(Convert.ToInt32(userSession.DEPTID));
            /*获取当前用户的草稿数据*/
            dt = bll.GetList(string.Format("USERID={0} AND STATUS=3 ORDER BY TIMESTAMP DESC", userSession.USERID.ToString()));


            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            grvAcceptList.DataSource = null;
            grvAcceptList.DataBind();

            grvAcceptList.DataSource = pds;
            grvAcceptList.DataBind();

            /*查询结果提示信息*/
            if (dt == null || dt.Rows.Count <= 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>没有公文数据!</div>";
            }
            else {
                litmsg.Visible = false;
            }
        }
    }
}