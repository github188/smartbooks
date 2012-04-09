using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.admin.ascx {
    public partial class ListUsers : System.Web.UI.UserControl {
        SmartPoms.BLL.BASE_USER bll = new BLL.BASE_USER();

        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/Login.aspx");
                } else {
                    Code.UserHandle.InitModule("admin_ListUsers");
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse))//是否有浏览权限
                    {
                        btn_search.Attributes.Add("onclick", "return Btn_Search();");

                        BindGroup();
                        BindOrder();
                    } else {
                        Session["ErrorNum"] = "0";
                        Response.Redirect("~/Error.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// 绑定用户组数据
        /// </summary>
        protected void BindGroup() {
            BLL.BASE_USERGROUP ugbll = new BLL.BASE_USERGROUP();
            DataView dvList = new DataView(ugbll.GetUserGroupList("").Tables[0]);
            LoadGroupList("0", 0, dvList);

            GroupList.Items.Insert(0, new ListItem("全部", "all"));
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
                GroupList.Items.Add(new ListItem(depth + dv["UG_Name"].ToString(), dv["UG_ID"].ToString()));

                LoadGroupList(dv["UG_ID"].ToString(), int.Parse(dv["UG_Depth"].ToString()) + 1, dvList);  //递归 
            }
        }

        /// <summary>
        /// 绑定用户数据
        /// </summary>
        protected void BindOrder() {
            string strWhere = "(Base_User.UserGroup <> 0) and Base_User.UserName<>'" + Code.SessionBox.GetUserSession().LoginName + "' and IsLimit<>1 ";
            if (txt_name.Text == "") {
                if (GroupList.SelectedValue != "all") {
                    strWhere = strWhere + " and Base_User.UserGroup=" + GroupList.SelectedValue;
                }
            } else {
                strWhere = "";
                strWhere = "Base_User.UserName='" + txt_name.Text + "'";
            }

            DataSet ds = bll.GetUserList(strWhere, " ORDER BY Base_User.CreateTime DESC");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = "无记录";
            else
                GridViewMsg.InnerText = "共有" + ds.Tables[0].Rows.Count + "条记录";

            UserList.DataSource = ds;
            UserList.DataBind();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        protected void UserList_RowCommand(object sender, GridViewCommandEventArgs e) {
            switch (e.CommandName.ToString()) {
                case "Del":
                    if (bll.DeleteUser(int.Parse(e.CommandArgument.ToString()))) {
                        BindOrder();
                    } else {
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("删除操作失败!");
                        strinfo.Visible = true;
                    }
                    break;
                case "Grant":
                    string[] s = e.CommandArgument.ToString().Split(',');
                    Response.Redirect("UserGrant.aspx?uid=" + s[0] + "&name=" + s[1]);
                    break;
            }
        }

        /// <summary>
        /// 数据绑定到表格
        /// </summary>
        protected void UserList_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffcd',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");

                LinkButton btnDel = (LinkButton)e.Row.FindControl("btn_del");
                Label Lab_state = (Label)e.Row.FindControl("Lab_state");

                btnDel.Attributes.Add("onclick", "return confirm('您确认要删除该记录吗?')");

                Lab_state.Text = Code.UserHandle.ReturnState(int.Parse(Lab_state.Text));

                #region 显示角色
                Label Lab_RoleName = (Label)e.Row.FindControl("Lab_RoleName");
                DataSet ds = bll.GetUserRole(int.Parse(UserList.DataKeys[e.Row.RowIndex].Values[0].ToString()));
                string r = string.Empty;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                    r += ds.Tables[0].Rows[i]["RoleName"].ToString() + ",";
                }
                if (r != "") {
                    Lab_RoleName.Text = r.Substring(0, r.Length - 1);
                } else {
                    Lab_RoleName.Text = "";
                }
                #endregion

                if (!Code.UserHandle.ValidationHandle(Code.Tag.Grant))//是否有授权权限
                {
                    UserList.Columns[7].Visible = false;
                }

                if (!Code.UserHandle.ValidationHandle(Code.Tag.View))//是否有查看权限
                {
                    UserList.Columns[8].Visible = false;
                }

                if (!Code.UserHandle.ValidationHandle(Code.Tag.Delete))//是否有删除权限
                {
                    UserList.Columns[9].Visible = false;
                }
            }
        }

        /// <summary>
        /// 根据分类排序
        /// </summary>
        protected void GroupList_SelectedIndexChanged(object sender, EventArgs e) {
            txt_name.Text = "";
            BindOrder();
        }

        protected void btn_search_Click(object sender, EventArgs e) {
            if (txt_name.Text != "") {
                BindOrder();
            }
        }
    }
}