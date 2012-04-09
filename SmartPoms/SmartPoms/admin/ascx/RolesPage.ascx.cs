using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.admin.ascx {
    public partial class RolesPage : System.Web.UI.UserControl {
        SmartPoms.BLL.BASE_ROLE bll = new BLL.BASE_ROLE();

        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/Login.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_RolesPage");
                    //是否有浏览权限
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse)) {
                        if (!Code.UserHandle.ValidationHandle(Code.Tag.Add)) {
                            addpanel.Visible = false;
                        }

                        btn_add.Attributes.Add("onclick", "return CheckAdd()");//加入验证
                        //绑定组信息
                        BLL.BASE_GROUP Groupbll = new BLL.BASE_GROUP();
                        GroupList.DataSource = Groupbll.GetGroupList("GroupType=1", "order by GroupOrder asc");
                        GroupList.DataTextField = "GroupName";
                        GroupList.DataValueField = "GroupID";
                        GroupList.DataBind();
                        GroupList.Items.Insert(0, new ListItem("全部", "all"));

                        BindOrder();
                    }
                }
            }
        }

        /// <summary>
        /// 将数据绑定到DataSet
        /// </summary>
        public void BindOrder() {
            string strwhere = string.Empty;
            if (GroupList.SelectedValue == "all") {
                strwhere = "";
            } else {
                strwhere = "RoleGroupID=" + GroupList.SelectedValue;
            }
            DataSet ds = bll.GetRoleList(strwhere, "");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = "无记录";
            else
                GridViewMsg.InnerText = "共有" + ds.Tables[0].Rows.Count + "条记录";

            RolesLists.DataSource = ds;
            RolesLists.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary> 
        protected void RolesLists_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            RolesLists.PageIndex = e.NewPageIndex;
            BindOrder(); //重新绑定GridView数据的函数 
        }

        /// <summary>
        /// 退出编辑状态
        /// </summary>
        protected void RolesLists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            RolesLists.EditIndex = -1;
            BindOrder();
        }

        /// <summary>
        /// 执行事件（删除操作）
        /// </summary>
        protected void RolesLists_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName.ToString() == "Del") {
                int ret = bll.DeleteRole(int.Parse(e.CommandArgument.ToString()));
                switch (ret) {
                    case 1:
                        BindOrder();
                        break;
                    case 2:
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("角色下还有用户存在，不能进行删除操作!");
                        strinfo.Visible = true;
                        break;
                    default:
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("删除操作失败!");
                        strinfo.Visible = true;
                        break;
                }

            }
        }

        /// <summary>
        /// 变更到编辑状态
        /// </summary>
        protected void RolesLists_RowEditing(object sender, GridViewEditEventArgs e) {
            RolesLists.EditIndex = e.NewEditIndex;
            BindOrder();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        protected void RolesLists_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            Entity.BASE_ROLE model = new Entity.BASE_ROLE();
            model.RoleID = int.Parse(RolesLists.DataKeys[e.RowIndex].Values[0].ToString());
            model.RoleName = ((TextBox)RolesLists.Rows[e.RowIndex].FindControl("txt_name")).Text.Trim();
            model.RoleDescription = ((TextBox)RolesLists.Rows[e.RowIndex].FindControl("txt_Description")).Text.Trim();
            model.RoleGroupID = int.Parse(((DropDownList)RolesLists.Rows[e.RowIndex].FindControl("GroupID")).SelectedValue);
            model.RoleOrder = int.Parse(((TextBox)RolesLists.Rows[e.RowIndex].FindControl("txt_order")).Text);
            if (!bll.UpdateRole(model)) {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("记录更新失败!");
                strinfo.Visible = true;
            }
            //返回浏览狀態
            RolesLists.EditIndex = -1;
            BindOrder();
        }

        /// <summary>
        /// 数据绑定到表格
        /// </summary>
        protected void RolesLists_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
            {
                BLL.BASE_GROUP Groupbll = new BLL.BASE_GROUP();
                DataSet Groups1 = Groupbll.GetGroupList("GroupType=1", "order by GroupOrder asc");
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffcd',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");

                LinkButton btnDel = ((LinkButton)e.Row.FindControl("btn_del"));
                Label Lab_GroupID = ((Label)e.Row.FindControl("Lab_GroupID"));
                Label hid_GroupID = ((Label)e.Row.FindControl("hid_GroupID"));
                for (int i = 0; i < Groups1.Tables[0].Rows.Count; i++) {
                    if (Groups1.Tables[0].Rows[i]["GroupID"].ToString() == hid_GroupID.Text) {
                        Lab_GroupID.Text = Groups1.Tables[0].Rows[i]["GroupName"].ToString();
                    }
                }

                btnDel.Attributes.Add("onclick", "return confirm('您确认要删除该记录吗?')");

                if (!Code.UserHandle.ValidationHandle(Code.Tag.Edit))//是否有编辑权限
                {
                    RolesLists.Columns[5].Visible = false;
                }
                if (!Code.UserHandle.ValidationHandle(Code.Tag.Delete))//是否有删除权限
                {
                    RolesLists.Columns[6].Visible = false;
                }
            }

            if ((e.Row.RowState & DataControlRowState.Edit) != 0) {
                BLL.BASE_GROUP Groupbll = new BLL.BASE_GROUP();
                DataSet Groups2 = Groupbll.GetGroupList("GroupType=1", "order by GroupOrder asc");

                Label hid_GroupID = ((Label)e.Row.FindControl("hid_GroupID"));
                DropDownList GroupID = ((DropDownList)e.Row.FindControl("GroupID"));

                for (int i = 0; i < Groups2.Tables[0].Rows.Count; i++) {
                    string s = Groups2.Tables[0].Rows[i]["GroupName"].ToString();

                    GroupID.Items.Add(new ListItem(s, Groups2.Tables[0].Rows[i]["GroupID"].ToString()));

                }

                GroupID.SelectedValue = hid_GroupID.Text;
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        protected void btn_add_Click(object sender, EventArgs e) {
            if (txt_Name.Text.Trim() != "") {
                if (GroupList.SelectedValue != "all") {
                    
                    Entity.BASE_ROLE model = new Entity.BASE_ROLE();

                    model.RoleName = txt_Name.Text.Trim();
                    model.RoleDescription = txt_Description.Text.Trim();
                    model.RoleGroupID = int.Parse(GroupList.SelectedValue.ToString());
                    model.RoleOrder = int.Parse(txt_order.Text.Trim());

                    switch (bll.CreateRole(model)) {
                        case 1:
                            txt_Name.Text = "";
                            txt_Description.Text = "";
                            BindOrder();
                            break;
                        case 2:
                            strinfo.InnerHtml = Smart.Utility.JScript.errinfo("分组已经存在，请更换后重试!");
                            strinfo.Visible = true;
                            break;
                        default:
                            strinfo.InnerHtml = Smart.Utility.JScript.errinfo("新增操作失败!");
                            strinfo.Visible = true;
                            break;
                    }
                } else {
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("请选择角色分组!");
                    strinfo.Visible = true;
                }
            }
        }

        /// <summary>
        /// 选择分类
        /// </summary>
        protected void GroupList_SelectedIndexChanged(object sender, EventArgs e) {
            BindOrder();
        }
    }
}