using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.admin.ascx {
    public partial class UserGroups : System.Web.UI.UserControl {
        SmartPoms.BLL.BASE_USERGROUP bll = new BLL.BASE_USERGROUP();

        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/Login.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_UserGroups");
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse))//是否有浏览权限
                    {
                        if (!Code.UserHandle.ValidationHandle(Code.Tag.Add)) {
                            ChildPanel.Visible = false;
                        }
                        btn_add.Attributes.Add("onclick", "return CheckAdd()");//加入验证
                        BLL.BASE_USERGROUP ugbll = new BLL.BASE_USERGROUP();
                        DataView dvList = new DataView(ugbll.GetUserGroupList("").Tables[0]);
                        LoadGroupList("0", 0, dvList);
                        gtList.Items.Insert(0, new ListItem("根节点", "0"));
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
            DataSet ds = bll.GetUserGroupList("UG_SuperiorID=" + gtList.SelectedValue);

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = "无记录";
            else
                GridViewMsg.InnerText = "共有" + ds.Tables[0].Rows.Count + "条记录";

            GroupsLists.DataSource = ds;
            GroupsLists.DataBind();
        }

        /// <summary>
        /// 加载用户分组
        /// </summary>
        /// <param name="UG_TID">分类上级ID</param>
        /// <param name="Depth">分类级别深度</param>
        protected void LoadGroupList(string UG_TID, int Depth, DataView dvList) {
            dvList.RowFilter = "UG_SuperiorID=" + UG_TID;  //过滤父节点 
            foreach (DataRowView dv in dvList) {
                string depth = string.Empty;
                for (int i = 0; i < Depth; i++) {
                    depth = depth + "-";
                }
                gtList.Items.Add(new ListItem(depth + dv["UG_Name"].ToString(), dv["UG_ID"].ToString()));

                LoadGroupList(dv["UG_ID"].ToString(), int.Parse(dv["UG_Depth"].ToString()) + 1, dvList);  //递归 
            }
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
                    int ret = bll.DeleteUserGroup(int.Parse(e.CommandArgument.ToString()));
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
            Entity.BASE_USERGROUP model = new Entity.BASE_USERGROUP();
            model.UG_ID = int.Parse(GroupsLists.DataKeys[e.RowIndex].Values[0].ToString());
            model.UG_Name = ((TextBox)GroupsLists.Rows[e.RowIndex].FindControl("txt_name")).Text.Trim();
            model.UG_Description = ((TextBox)GroupsLists.Rows[e.RowIndex].FindControl("txt_Description")).Text.Trim();
            model.UG_Order = int.Parse(((TextBox)GroupsLists.Rows[e.RowIndex].FindControl("txt_order")).Text);

            if (!bll.UpdateUserGroup(model)) {
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
                
                Entity.BASE_USERGROUP model = new Entity.BASE_USERGROUP();

                model.UG_Name = txt_Name.Text.Trim();
                model.UG_Description = txt_Description.Text.Trim();
                model.UG_Order = int.Parse(txt_order.Text.Trim());
                model.UG_SuperiorID = int.Parse(gtList.SelectedValue);

                switch (bll.CreateUserGroup(model)) {
                    case 0:
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("新增操作失败!");
                        strinfo.Visible = true;
                        break;
                    case 1:
                        txt_Name.Text = "";
                        txt_Description.Text = "";
                        txt_order.Text = "";
                        BindOrder();
                        break;
                    case 2:
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("分组已经存在，请更换后重试!");
                        strinfo.Visible = true;
                        break;
                }
            }
        }

        protected void gtList_SelectedIndexChanged(object sender, EventArgs e) {
            BindOrder();
        }
    }
}