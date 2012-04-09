using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

namespace SmartPoms.admin.ascx {
    public partial class UserGrant : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;

            if (!IsPostBack) {
                Code.UserHandle.InitModule("admin_ListUsers");
                if (!Code.UserHandle.ValidationHandle(Code.Tag.Grant)) {
                    Session["ErrorNum"] = "0";
                    Response.Redirect("~/Error.aspx");
                } else {
                    btn_saverole.Attributes.Add("OnClick", "getdata()");
                    if (Request.QueryString["uid"] != null && Request.QueryString["name"] != null) {
                        UNAME.Text = Request.QueryString["name"].ToString();
                        UID.Text = Request.QueryString["uid"].ToString();
                        BindModuleType();
                        RolePanel.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 绑定分组数据
        /// </summary>
        protected void BindModuleType() {
            BLL.BASE_MODULE MTbll = new BLL.BASE_MODULE();
            DataSet ds = MTbll.GetModuleTypeList("");
            ModuleTypeView.DataSource = ds;
            ModuleTypeView.DataBind();
        }

        /// <summary>
        /// 获取模块权限列表
        /// </summary>
        protected void BindModules() {
            if (TID.Text != "") {
                BLL.BASE_MODULE Mbll = new BLL.BASE_MODULE();
                DataSet ds = Mbll.GetModuleList2(TID.Text);
                ModuleView.DataSource = ds;
                ModuleView.DataBind();

                if (ds.Tables[0].Rows.Count == 0) {
                    btn_AllSave.Visible = false;
                } else {
                    btn_AllSave.Visible = true;
                }
            } else {
                btn_AllSave.Visible = false;
                ModuleView.DataSource = null;
                ModuleView.DataBind();
            }
        }

        protected void BindRole() {
            
            BLL.BASE_USER bll = new BLL.BASE_USER();
            RoleList.Items.Clear();
            ArrayList rid = bll.GetUserRoleArray(int.Parse(UID.Text));
            string strwhere = "";
            for (int i = 0; i < rid.Count; i++) {
                string[] r = rid[i].ToString().Split(',');
                RoleList.Items.Add(new ListItem(r[1], r[0]));
                strwhere += r[0] + ",";
            }
            if (strwhere != "") {
                OldRoleList.Text = strwhere.Substring(0, strwhere.Length - 1);
                strwhere = "not RoleID in(" + OldRoleList.Text + ")";
            }
            
            BLL.BASE_ROLE bll2 = new BLL.BASE_ROLE();
            FromRoleList.DataSource = bll2.GetRoleList(strwhere, "");
            FromRoleList.DataTextField = "RoleName";
            FromRoleList.DataValueField = "RoleID";
            FromRoleList.DataBind();
        }

        protected void ModuleType_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "EditView") {
                TID.Text = e.CommandArgument.ToString();
                BindModules();
            }
        }

        protected void ModuleView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                BLL.BASE_AUTHORITYDIR AD = new BLL.BASE_AUTHORITYDIR();
                BLL.BASE_MODULE Modulebll = new BLL.BASE_MODULE();
                BLL.BASE_ROLE Rolebll = new BLL.BASE_ROLE();

                CheckBoxList AuthorityList_Grant = (CheckBoxList)e.Row.FindControl("AuthorityList_Grant");
                CheckBoxList AuthorityList_Deny = (CheckBoxList)e.Row.FindControl("AuthorityList_Deny");
                Label lab_ID = (Label)e.Row.FindControl("lab_ID");
                Label lab_Verify = (Label)e.Row.FindControl("lab_Verify");

                DataSet ds = AD.GetAuthorityList("", "order by AuthorityOrder asc");
                DataSet MALDS = Modulebll.GetAuthorityList(int.Parse(lab_ID.Text));
                DataSet RALDS = Rolebll.GetUserAuthorityList(int.Parse(UID.Text), int.Parse(lab_ID.Text));

                int n = ds.Tables[0].Rows.Count;//系统权限个数

                string[] vstate = new string[n];

                //获取系统配置的权限列表，如果模块没有该权限，则禁用该权限
                for (int i = 0; i < n; i++) {
                    AuthorityList_Grant.Items.Add(new ListItem(ds.Tables[0].Rows[i]["AuthorityName"].ToString(), ds.Tables[0].Rows[i]["AuthorityTag"].ToString()));
                    AuthorityList_Deny.Items.Add(new ListItem(ds.Tables[0].Rows[i]["AuthorityName"].ToString(), ds.Tables[0].Rows[i]["AuthorityTag"].ToString()));
                    AuthorityList_Grant.Items[i].Enabled = false;
                    AuthorityList_Deny.Items[i].Enabled = false;
                    for (int k = 0; k < MALDS.Tables[0].Rows.Count; k++) {
                        if ((ds.Tables[0].Rows[i]["AuthorityTag"].ToString() == MALDS.Tables[0].Rows[k]["AuthorityTag"].ToString())) {
                            AuthorityList_Grant.Items[i].Enabled = true;
                            AuthorityList_Deny.Items[i].Enabled = true;
                            break;
                        }
                    }
                    vstate[i] = "0";//初始状态数组;
                }
                AuthorityList_Grant.DataBind();

                //将模块权限付值
                for (int j = 0; j < RALDS.Tables[0].Rows.Count; j++) {
                    for (int l = 0; l < AuthorityList_Grant.Items.Count; l++) {
                        if (RALDS.Tables[0].Rows[j]["AuthorityTag"].ToString() == AuthorityList_Grant.Items[l].Value) {
                            if (RALDS.Tables[0].Rows[j]["Flag"].ToString().ToLower() == "true") {
                                if (AuthorityList_Grant.Items[l].Enabled)
                                    vstate[l] = "1";
                                //权限允许
                                AuthorityList_Grant.Items[l].Selected = true;
                                break;
                            } else {
                                if (AuthorityList_Deny.Items[l].Enabled)
                                    vstate[l] = "1";
                                //权限禁止权限
                                AuthorityList_Deny.Items[l].Selected = true;
                                break;
                            }
                        }
                    }
                }

                lab_Verify.Text = Smart.Utility.TypeParse.StringArrayToString(vstate, ',');
            }
        }

        protected void ModuleView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
            ArrayList list = new ArrayList();//建立事务列表
            BLL.BASE_ROLE Rolebll = new BLL.BASE_ROLE();
            CheckBoxList calg = (CheckBoxList)this.ModuleView.Rows[e.NewSelectedIndex].Cells[1].FindControl("AuthorityList_Grant");
            CheckBoxList cald = (CheckBoxList)this.ModuleView.Rows[e.NewSelectedIndex].Cells[1].FindControl("AuthorityList_Deny");
            Label lab_Verify = (Label)this.ModuleView.Rows[e.NewSelectedIndex].Cells[0].FindControl("lab_Verify");
            string[] vstate = lab_Verify.Text.Split(',');//获取原始状态

            for (int i = 0; i < calg.Items.Count; i++) {
                if (calg.Items[i].Enabled) {
                    if (calg.Items[i].Selected) {
                        if (vstate[i] != "1")//检查数据有没有变化
                        {
                            string item = string.Empty;
                            item = item + UID.Text + "|"
                                + this.ModuleView.DataKeys[e.NewSelectedIndex].Values[0].ToString() + "|"
                                + calg.Items[i].Value + "|1";//设置为1，加入允许权限
                            list.Add(item);
                        }
                    } else if (cald.Items[i].Selected) {
                        string item = string.Empty;
                        item = item + UID.Text + "|"
                            + this.ModuleView.DataKeys[e.NewSelectedIndex].Values[0].ToString() + "|"
                            + cald.Items[i].Value + "|0";//设置为0，加入禁止权限
                        list.Add(item);
                    } else {
                        if (vstate[i] != "0")//检查数据有没有变化
                        {
                            string item = string.Empty;
                            item = item + UID.Text + "|"
                                + this.ModuleView.DataKeys[e.NewSelectedIndex].Values[0].ToString() + "|"
                                + cald.Items[i].Value + "|2";//设置为0，删除权限
                            list.Add(item);
                        }
                    }
                }
            }

            if (Rolebll.UpdateUserAuthority(list)) {
                BindModules();
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("更新成功！");
                strinfo.Visible = true;
            } else {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("更新失败！");
                strinfo.Visible = true;
            }
        }

        protected void btn_AllSave_Click(object sender, EventArgs e) {
            BLL.BASE_ROLE Rolebll = new BLL.BASE_ROLE();

            ArrayList list = new ArrayList();//建立事务列表
            for (int i = 0; i <= ModuleView.Rows.Count - 1; i++) {
                CheckBoxList calg = (CheckBoxList)this.ModuleView.Rows[i].Cells[1].FindControl("AuthorityList_Grant");
                CheckBoxList cald = (CheckBoxList)this.ModuleView.Rows[i].Cells[1].FindControl("AuthorityList_Deny");
                Label lab_Verify = (Label)this.ModuleView.Rows[i].Cells[0].FindControl("lab_Verify");
                string[] vstate = lab_Verify.Text.Split(',');//获取原始状态

                for (int j = 0; j < calg.Items.Count; j++) {
                    if (calg.Items[j].Selected) {
                        if (vstate[j] != "1")//检查数据有没有变化
                        {
                            string item = string.Empty;
                            item = item + UID.Text + "|"
                                + this.ModuleView.DataKeys[i].Values[0].ToString() + "|"
                                + calg.Items[j].Value + "|1";//设置为1，加入允许权限
                            list.Add(item);
                        }
                    } else if (cald.Items[j].Selected) {
                        string item = string.Empty;
                        item = item + UID.Text + "|"
                            + this.ModuleView.DataKeys[i].Values[0].ToString() + "|"
                            + cald.Items[j].Value + "|0";//设置为0，加入禁止权限
                        list.Add(item);
                    } else {
                        if (vstate[j] != "0")//检查数据有没有变化
                        {
                            string item = string.Empty;
                            item = item + UID.Text + "|"
                                + this.ModuleView.DataKeys[i].Values[0].ToString() + "|"
                                + cald.Items[j].Value + "|2";//设置为0，删除权限
                            list.Add(item);
                        }
                    }
                }
            }

            if (Rolebll.UpdateUserAuthority(list)) {
                BindModules();
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("设置成功！");
                strinfo.Visible = true;
            } else {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("设置操作失败！");
                strinfo.Visible = true;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
            if (DropDownList1.SelectedIndex == 0) {
                ModelPanel.Visible = true;
                RolePanel.Visible = false;
            } else {
                BindRole();
                ModelPanel.Visible = false;
                RolePanel.Visible = true;
            }
        }

        protected void btn_saverole_Click(object sender, EventArgs e) {
            string s = Request.Form["TRoleList"].ToString();

            BLL.BASE_USER bll = new BLL.BASE_USER();
            ArrayList ar = new ArrayList();//加加表
            ArrayList dr = new ArrayList();//删除表

            if (s != "") {
                string[] str = s.Substring(0, s.Length - 1).Split(',');
                string[] ostr = OldRoleList.Text.ToString().Split(',');
                for (int i = 0; i < str.Length; i++) {
                    if (!Smart.Utility.TypeParse.IsStringArray(str[i], ostr)) {
                        //不存在则添加到插入记录列表
                        ar.Add(UID.Text + "," + str[i]);
                    }
                }

                for (int i = 0; i < ostr.Length; i++) {
                    if (!Smart.Utility.TypeParse.IsStringArray(ostr[i], str)) {
                        //不存在则添加到删除记录列表
                        dr.Add(UID.Text + "," + ostr[i]);
                    }
                }
            } else {
                //如果提交角色为空则删除该用户的所有角色
                string[] ostr = OldRoleList.Text.ToString().Split(',');
                for (int i = 0; i < ostr.Length; i++) {
                    //不存在则添加到删除记录列表
                    dr.Add(UID.Text + "," + ostr[i]);
                }
            }

            try {
                if (ar.Count != 0) { bll.addUserRole(ar); }
                if (dr.Count != 0) { bll.DeleteUserRole(dr); }
                BindRole();
            } catch { }
        }
    }
}