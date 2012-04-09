using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.admin.ascx {
    public partial class ConfigPage : System.Web.UI.UserControl {
        SmartPoms.BLL.BASE_CONFIGURATION bll = new BLL.BASE_CONFIGURATION();

        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/AdminLogin.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_ConfigPage");
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse))//是否有浏览权限
                    {
                        BindOrder();
                    } else {
                        Session["ErrorNum"] = "0";
                        Response.Redirect("~/AdminError.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// 将数据绑定到DataSet
        /// </summary>
        public void BindOrder() {
            DataSet ds = bll.GetItemList("");
            ConfigList.DataSource = ds;
            ConfigList.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        protected void ConfigList_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            ConfigList.PageIndex = e.NewPageIndex;
            BindOrder(); //重新绑定GridView数据的函数 
        }

        /// <summary>
        /// 退出编辑状态
        /// </summary>
        protected void ConfigList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            ConfigList.EditIndex = -1;
            BindOrder();
        }

        /// <summary>
        /// 变更到编辑状态
        /// </summary>
        protected void ConfigList_RowEditing(object sender, GridViewEditEventArgs e) {
            ConfigList.EditIndex = e.NewEditIndex;
            BindOrder();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        protected void ConfigList_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            int id = int.Parse(ConfigList.DataKeys[e.RowIndex].Values[0].ToString());
            string s = ((TextBox)ConfigList.Rows[e.RowIndex].FindControl("txt_value")).Text.Trim();

            if (!bll.UpdateItem(id, s)) {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("记录更新失败!");
                strinfo.Visible = true;
            }
            //返回浏览狀態
            ConfigList.EditIndex = -1;
            BindOrder();

        }

        /// <summary>
        /// 数据绑定到表格
        /// </summary>
        protected void ConfigList_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffcd',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");

                if (!Code.UserHandle.ValidationHandle(Code.Tag.Edit))//是否有删除权限
                {
                    ConfigList.Columns[4].Visible = false;
                }
            }
        }
    }
}