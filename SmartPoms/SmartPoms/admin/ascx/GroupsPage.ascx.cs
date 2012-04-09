using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.admin.ascx {
    public partial class GroupsPage : System.Web.UI.UserControl {
        SmartPoms.BLL.BASE_GROUP bll = new BLL.BASE_GROUP();

        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/Login.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_GroupsPage");
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse))//是否有浏览权限
                    {
                        if (!Code.UserHandle.ValidationHandle(Code.Tag.Add)) {
                            ChildPanel.Visible = false;
                        }
                        btn_add.Attributes.Add("onclick", "return CheckAdd()");//加入验证
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
            DataSet ds = bll.GetGroupList("GroupType=" + gtList.SelectedValue, "order by GroupOrder asc");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = "无记录";
            else
                GridViewMsg.InnerText = "共有" + ds.Tables[0].Rows.Count + "条记录";

            GroupsLists.DataSource = ds;
            GroupsLists.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        protected void GroupsLists_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GroupsLists.PageIndex = e.NewPageIndex;
            BindOrder(); //重新绑定GridView数据的函数 
        }

        /// <summary>
        /// 退出编辑状态
        /// </summary>
        protected void GroupsLists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GroupsLists.EditIndex = -1;
            BindOrder();
        }

        /// <summary>
        /// 执行事件（删除操作）
        /// </summary>
        protected void GroupsLists_RowCommand(object sender, GridViewCommandEventArgs e) {
            switch (e.CommandName.ToString()) {
                case "Del":
                    int ret = bll.DeleteGroup(int.Parse(e.CommandArgument.ToString()));
                    switch (ret) {
                        case 1:
                            BindOrder();
                            break;
                        case 2:
                            strinfo.InnerHtml = Smart.Utility.JScript.errinfo("分组下还有角色存在，不能进行删除操作!");
                            strinfo.Visible = true;
                            break;
                        default:
                            strinfo.InnerHtml = Smart.Utility.JScript.errinfo("删除操作失败!");
                            strinfo.Visible = true;
                            break;
                    }
                    break;
            }

        }

        /// <summary>
        /// 变更到编辑状态
        /// </summary>
        protected void GroupsLists_RowEditing(object sender, GridViewEditEventArgs e) {
            GroupsLists.EditIndex = e.NewEditIndex;
            BindOrder();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        protected void GroupsLists_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            Entity.BASE_GROUP model = new Entity.BASE_GROUP();
            model.GroupID = int.Parse(GroupsLists.DataKeys[e.RowIndex].Values[0].ToString());
            model.GroupName = ((TextBox)GroupsLists.Rows[e.RowIndex].FindControl("txt_name")).Text.Trim();
            model.GroupDescription = ((TextBox)GroupsLists.Rows[e.RowIndex].FindControl("txt_Description")).Text.Trim();
            model.GroupOrder = int.Parse(((TextBox)GroupsLists.Rows[e.RowIndex].FindControl("txt_order")).Text);

            if (!bll.UpdateGroup(model)) {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("记录更新失败!");
                strinfo.Visible = true;
            }
            //返回浏览狀態
            GroupsLists.EditIndex = -1;
            BindOrder();
        }

        /// <summary>
        /// 数据绑定到表格
        /// </summary>
        protected void GroupsLists_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffcd',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");

                LinkButton btnDel = ((LinkButton)e.Row.FindControl("btn_del"));

                btnDel.Attributes.Add("onclick", "return confirm('您确认要删除该记录吗?')");

                if (!Code.UserHandle.ValidationHandle(Code.Tag.Edit))//是否有编辑权限
                {
                    GroupsLists.Columns[4].Visible = false;
                }
                if (!Code.UserHandle.ValidationHandle(Code.Tag.Delete))//是否有删除权限
                {
                    GroupsLists.Columns[5].Visible = false;
                }
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        protected void btn_add_Click(object sender, EventArgs e) {
            if (txt_Name.Text.Trim() != "" || txt_order.Text.Trim() != "" || Smart.Utility.TypeParse.IsUnsign(txt_order.Text.Trim())) {
                
                Entity.BASE_GROUP model = new Entity.BASE_GROUP();

                model.GroupName = txt_Name.Text.Trim();
                model.GroupDescription = txt_Description.Text.Trim();
                model.GroupOrder = int.Parse(txt_order.Text.Trim());
                model.GroupType = int.Parse(gtList.SelectedValue);

                if (!bll.Exists(txt_Name.Text.Trim(), int.Parse(gtList.SelectedValue))) {
                    if (bll.CreateGroup(model)) {
                        //strinfo.InnerHtml = Smart.Utility.JScript.errinfo("新增成功!");
                        //strinfo.Visible = true;  
                        BindOrder();
                    } else {
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("新增操作失败!");
                        strinfo.Visible = true;
                    }
                    txt_Name.Text = "";
                    txt_Description.Text = "";
                    txt_order.Text = "";
                    BindOrder();
                } else {
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("分组已经存在，请更换后重试!");
                    strinfo.Visible = true;
                }
            }
        }

        protected void gtList_SelectedIndexChanged(object sender, EventArgs e) {
            BindOrder();
        }
    }
}