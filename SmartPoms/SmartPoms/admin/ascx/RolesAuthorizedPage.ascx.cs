using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace SmartPoms.admin.ascx {
    public partial class RolesAuthorizedPage : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/Login.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_RolesAuthorizedPage");
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse))//是否有浏览权限
                    {
                        BindGroups();
                        BindModuleType("0", 0);
                        BindRoles();
                    } else {
                        Session["ErrorNum"] = "0";
                        Response.Redirect("~/Error.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        protected void BindRoles() {
            BLL.BASE_ROLE Rolsebll = new BLL.BASE_ROLE();
            DataSet ds = Rolsebll.GetRoleList("RoleGroupID=" + GroupList.SelectedValue, "");
            RoleView.DataSource = ds;
            RoleView.DataBind();
        }

        /// <summary>
        /// 获取模块权限列表
        /// </summary>
        protected void BindModules() {
            if (Rid.Text != "") {
                BLL.BASE_MODULE Mbll = new BLL.BASE_MODULE();
                DataSet ds = Mbll.GetModuleList2(ModuleTypeList.SelectedValue);
                ModuleView.DataSource = ds;
                ModuleView.DataBind();

                if (ds.Tables[0].Rows.Count == 0) {
                    btn_AllSave.Visible = false;
                } else {
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Grant)) {
                        btn_AllSave.Visible = true;
                    } else {
                        btn_AllSave.Visible = false;
                    }
                }
            } else {
                btn_AllSave.Visible = false;
                ModuleView.DataSource = null;
                ModuleView.DataBind();
            }
        }

        /// <summary>
        /// 绑定分组数据
        /// </summary>
        protected void BindGroups() {
            BLL.BASE_GROUP Groupbll = new BLL.BASE_GROUP();
            DataSet ds = Groupbll.GetGroupList("GroupType=1", "order by GroupOrder asc");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                string s = ds.Tables[0].Rows[i]["GroupName"].ToString();

                GroupList.Items.Add(new ListItem(s, ds.Tables[0].Rows[i]["GroupID"].ToString()));

            }
        }

        /// <summary>
        /// 加载分类
        /// </summary>
        /// <param name="MtID">分类上级ID</param>
        /// <param name="Depth">分类级别深度</param>
        /// <param name="flag">指定分类组件</param>
        protected void BindModuleType(string MtID, int Depth) {
            SmartPoms.BLL.BASE_MODULE MTbll = new BLL.BASE_MODULE();
            DataView dvList = new DataView(MTbll.GetModuleTypeList("").Tables[0]);
            dvList.RowFilter = "ModuleTypeSuperiorID=" + MtID;  //过滤父节点 
            foreach (DataRowView dv in dvList) {
                string depth = string.Empty;
                for (int i = 0; i < Depth; i++) {
                    depth = depth + "-";
                }

                ModuleTypeList.Items.Add(new ListItem(depth + dv["ModuleTypeName"].ToString(), dv["ModuleTypeID"].ToString()));
                BindModuleType(dv["ModuleTypeID"].ToString(), int.Parse(dv["ModuleTypeDepth"].ToString()) + 1);  //递归 
            }
        }

        /// <summary>
        /// 查看角权限
        /// </summary>
        protected void RoleView_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName.ToString() == "EditView") {
                Rid.Text = e.CommandArgument.ToString();
                if (!ModuleTypeList.Enabled)
                    ModuleTypeList.Enabled = true;
                //int.Parse(e.CommandArgument.ToString());

                BindModules();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            }
        }

        /// <summary>
        /// 根据分组排序角色
        /// </summary>
        protected void GroupList_SelectedIndexChanged(object sender, EventArgs e) {
            Rid.Text = "";
            ModuleTypeList.Enabled = false;
            BindRoles();
            BindModules();
        }

        /// <summary>
        /// 根据模块分类排序模块
        /// </summary>
        protected void ModuleTypeList_SelectedIndexChanged(object sender, EventArgs e) {
            BindModules();
        }

        /// <summary>
        /// 模块分类数据绑定
        /// </summary>
        protected void ModuleView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                BLL.BASE_AUTHORITYDIR AD = new BLL.BASE_AUTHORITYDIR();
                BLL.BASE_MODULE Modulebll = new BLL.BASE_MODULE();
                BLL.BASE_ROLE Rolebll = new BLL.BASE_ROLE();

                CheckBoxList AuthorityList = (CheckBoxList)e.Row.FindControl("AuthorityList");
                Label lab_ID = (Label)e.Row.FindControl("lab_ID");
                Label lab_Verify = (Label)e.Row.FindControl("lab_Verify");

                DataSet ds = AD.GetAuthorityList("", "order by AuthorityOrder asc");
                DataSet MALDS = Modulebll.GetAuthorityList(int.Parse(lab_ID.Text));
                DataSet RALDS = Rolebll.GetRoleAuthorityList(int.Parse(Rid.Text), int.Parse(lab_ID.Text));

                int n = ds.Tables[0].Rows.Count;//系统权限个数

                string[] vstate = new string[n];

                //获取系统配置的权限列表，如果模块没有该权限，则禁用该权限
                for (int i = 0; i < n; i++) {
                    AuthorityList.Items.Add(new ListItem(ds.Tables[0].Rows[i]["AuthorityName"].ToString(), ds.Tables[0].Rows[i]["AuthorityTag"].ToString()));
                    AuthorityList.Items[i].Enabled = false;
                    for (int k = 0; k < MALDS.Tables[0].Rows.Count; k++) {
                        if (ds.Tables[0].Rows[i]["AuthorityTag"].ToString() == MALDS.Tables[0].Rows[k]["AuthorityTag"].ToString()) {
                            AuthorityList.Items[i].Enabled = true;
                            break;
                        }
                    }
                    vstate[i] = "0";//初始状态数组;
                }
                AuthorityList.DataBind();

                //将模块权限付值
                for (int j = 0; j < RALDS.Tables[0].Rows.Count; j++) {
                    for (int l = 0; l < AuthorityList.Items.Count; l++) {
                        if (RALDS.Tables[0].Rows[j]["AuthorityTag"].ToString() == AuthorityList.Items[l].Value && RALDS.Tables[0].Rows[j]["Flag"].ToString().ToLower() == "true") {
                            if (AuthorityList.Items[l].Enabled)
                                vstate[l] = "1";//权限存在
                            AuthorityList.Items[l].Selected = true;
                            break;
                        }
                    }
                }

                lab_Verify.Text = Smart.Utility.TypeParse.StringArrayToString(vstate, ',');
                if (!Code.UserHandle.ValidationHandle(Code.Tag.Grant))//是否有编辑权限
                {
                    ModuleView.Columns[2].Visible = false;
                }
            }
        }

        /// <summary>
        /// 保存所有修改的权限
        /// </summary>
        protected void btn_AllSave_Click(object sender, EventArgs e) {
            BLL.BASE_ROLE Rolebll = new BLL.BASE_ROLE();

            ArrayList list = new ArrayList();//建立事务列表
            for (int i = 0; i <= ModuleView.Rows.Count - 1; i++) {
                CheckBoxList cal = (CheckBoxList)this.ModuleView.Rows[i].Cells[1].FindControl("AuthorityList");
                Label lab_Verify = (Label)this.ModuleView.Rows[i].Cells[0].FindControl("lab_Verify");
                string[] vstate = lab_Verify.Text.Split(',');//获取原始状态

                for (int j = 0; j < cal.Items.Count; j++) {
                    if (cal.Items[j].Enabled) {
                        if (cal.Items[j].Selected) {
                            if (vstate[j] != "1")//检查数据有没有变化
                            {
                                string item = string.Empty;
                                item = item + Rid.Text + "|"
                                    + this.ModuleView.DataKeys[i].Values[0].ToString() + "|"
                                    + cal.Items[j].Value + "|1";//设置为1，加入权限
                                list.Add(item);
                            }
                        } else {
                            if (vstate[j] != "0")//检查数据有没有变化
                            {
                                string item = string.Empty;
                                item = item + Rid.Text + "|"
                                    + this.ModuleView.DataKeys[i].Values[0].ToString() + "|"
                                    + cal.Items[j].Value + "|0";//设置为0，删除删除
                                list.Add(item);
                            }
                        }
                    }
                }
            }

            if (Rolebll.UpdateRoleAuthority(list)) {
                BindModules();
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("设置成功！");
                strinfo.Visible = true;
            } else {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("设置操作失败！");
                strinfo.Visible = true;
            }
        }

        /// <summary>
        /// 更新设置
        /// </summary>
        protected void ModuleView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
            ArrayList list = new ArrayList();//建立事务列表
            BLL.BASE_ROLE Rolebll = new BLL.BASE_ROLE();
            CheckBoxList cal = (CheckBoxList)this.ModuleView.Rows[e.NewSelectedIndex].Cells[1].FindControl("AuthorityList");
            Label lab_Verify = (Label)this.ModuleView.Rows[e.NewSelectedIndex].Cells[0].FindControl("lab_Verify");
            string[] vstate = lab_Verify.Text.Split(',');//获取原始状态

            for (int i = 0; i < cal.Items.Count; i++) {
                if (cal.Items[i].Enabled) {
                    if (cal.Items[i].Selected) {
                        if (vstate[i] != "1")//检查数据有没有变化
                        {
                            string item = string.Empty;
                            item = item + Rid.Text + "|"
                                + this.ModuleView.DataKeys[e.NewSelectedIndex].Values[0].ToString() + "|"
                                + cal.Items[i].Value + "|1";//设置为1，加入权限
                            list.Add(item);
                        }
                    } else {
                        if (vstate[i] != "0")//检查数据有没有变化
                        {
                            string item = string.Empty;
                            item = item + Rid.Text + "|"
                                + this.ModuleView.DataKeys[e.NewSelectedIndex].Values[0].ToString() + "|"
                                + cal.Items[i].Value + "|0";//设置为0，删除删除
                            list.Add(item);
                        }
                    }
                }
            }

            if (Rolebll.UpdateRoleAuthority(list)) {
                BindModules();
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("更新成功！");
                strinfo.Visible = true;
            } else {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("更新失败！");
                strinfo.Visible = true;
            }
        }
    }
}