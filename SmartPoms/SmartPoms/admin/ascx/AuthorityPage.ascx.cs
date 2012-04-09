using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.admin.ascx {
    public partial class AuthorityPage : System.Web.UI.UserControl {

        SmartPoms.BLL.BASE_AUTHORITYDIR bll = new BLL.BASE_AUTHORITYDIR();

        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/Login.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_AuthorityPage");
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse))//是否有浏览权限
                    {
                        if (!Code.UserHandle.ValidationHandle(Code.Tag.Add)) {
                            ChildPanel.Visible = false;
                            btn_add.Attributes.Add("onclick", "return CheckAdd()");//加入验证
                        }
                        BindOrder();
                    } else {
                        Session["ErrorNum"] = "0";
                        Response.Redirect("~/Error.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// 将数据绑定到DataSet
        /// </summary>
        public void BindOrder() {
            DataSet ds = bll.GetAuthorityList("", "order by AuthorityOrder asc");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = "无记录";
            else
                GridViewMsg.InnerText = "共有" + ds.Tables[0].Rows.Count + "条记录";

            AuthorityLists.DataSource = ds;
            AuthorityLists.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        protected void AuthorityLists_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            AuthorityLists.PageIndex = e.NewPageIndex;
            BindOrder(); //重新绑定GridView数据的函数 
        }

        /// <summary>
        /// 退出编辑状态
        /// </summary>
        protected void AuthorityLists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            AuthorityLists.EditIndex = -1;
            BindOrder();
        }

        /// <summary>
        /// 执行事件（删除操作）
        /// </summary>
        protected void AuthorityLists_RowCommand(object sender, GridViewCommandEventArgs e) {
            switch (e.CommandName.ToString()) {
                case "Del":
                    if (bll.DeleteAuthority(int.Parse(e.CommandArgument.ToString()))) {
                        BindOrder();

                    } else {
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("删除操作失败!");
                        strinfo.Visible = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// 变更到编辑状态
        /// </summary>
        protected void AuthorityLists_RowEditing(object sender, GridViewEditEventArgs e) {
            AuthorityLists.EditIndex = e.NewEditIndex;
            BindOrder();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        protected void AuthorityLists_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            Entity.BASE_AUTHORITYDIR model = new Entity.BASE_AUTHORITYDIR();
            model.AuthorityID = int.Parse(AuthorityLists.DataKeys[e.RowIndex].Values[0].ToString());
            model.AuthorityName = ((TextBox)AuthorityLists.Rows[e.RowIndex].FindControl("txt_name")).Text.Trim();
            model.AuthorityTag = ((TextBox)AuthorityLists.Rows[e.RowIndex].FindControl("txt_tag")).Text.Trim().ToUpper();
            model.AuthorityDescription = ((TextBox)AuthorityLists.Rows[e.RowIndex].FindControl("txt_Description")).Text.Trim();
            model.AuthorityOrder = int.Parse(((TextBox)AuthorityLists.Rows[e.RowIndex].FindControl("txt_order")).Text);

            if (!bll.UpdateAuthority(model)) {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("记录更新失败!");
                strinfo.Visible = true;
            }
            //返回浏览狀態
            AuthorityLists.EditIndex = -1;
            BindOrder();
        }

        /// <summary>
        /// 数据绑定到表格
        /// </summary>
        protected void AuthorityLists_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffcd',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");

                LinkButton btnDel = (LinkButton)e.Row.FindControl("btn_del");

                btnDel.Attributes.Add("onclick", "return confirm('您确认要删除该记录吗?')");

                if (!Code.UserHandle.ValidationHandle(Code.Tag.Edit))//是否有编辑权限
                {
                    AuthorityLists.Columns[5].Visible = false;
                }
                if (!Code.UserHandle.ValidationHandle(Code.Tag.Delete))//是否有删除权限
                {
                    AuthorityLists.Columns[6].Visible = false;
                }
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        protected void btn_add_Click(object sender, EventArgs e) {
            if (txt_Name.Text.Trim() != "" || txt_Tag.Text.Trim() != "" || txt_order.Text.Trim() != "" || Smart.Utility.TypeParse.IsUnsign(txt_order.Text.Trim())) {
                
                Entity.BASE_AUTHORITYDIR model = new Entity.BASE_AUTHORITYDIR();

                model.AuthorityName = txt_Name.Text.Trim();
                model.AuthorityTag = txt_Tag.Text.Trim().ToUpper();
                model.AuthorityDescription = txt_Description.Text.Trim();
                model.AuthorityOrder = int.Parse(txt_order.Text.Trim());

                if (!bll.Exists(txt_Tag.Text.Trim())) {
                    if (bll.CreateAuthority(model)) {
                        txt_Name.Text = "";
                        txt_Tag.Text = "";
                        txt_Description.Text = "";
                        txt_order.Text = "";
                        BindOrder();
                    } else {
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("新增操作失败!");
                        strinfo.Visible = true;
                    }
                } else {
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("标识已经存在，请更换后重试!");
                    strinfo.Visible = true;
                }
            }
        }
    }
}