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
    public partial class ModulesInfoPage : System.Web.UI.UserControl {
        SmartPoms.BLL.BASE_MODULE bll = new BLL.BASE_MODULE();

        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.change_child_win();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/Login.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_ModulesPage");

                    //是否有浏览权限
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse)) {
                        //是否有添加权限
                        if (!Code.UserHandle.ValidationHandle(Code.Tag.Add)) {
                            TitlePanel.Visible = false;
                            mt_btn_save.Visible = false;
                            mt_btn_update.Visible = false;
                            m_btn_save.Visible = false;
                            m_btn_update.Visible = false;
                        }

                        //是否有添加权限
                        if (!Code.UserHandle.ValidationHandle(Code.Tag.Edit)) {
                            mt_btn_delete.Visible = false;
                            m_btn_delete.Visible = false;
                        }

                        if (Request.QueryString["id"] != null && Request.QueryString["type"] != null) {
                            int id = int.Parse(Request.QueryString["id"].ToString());
                            int t = int.Parse(Request.QueryString["type"].ToString());
                            mt_btn_save.Attributes.Add("onclick", "return CheckAddType()");
                            m_btn_save.Attributes.Add("onclick", "return CheckAddmodule()");

                            MID.Text = id.ToString();
                            switch (t) {
                                case 0:
                                    TitlePanel.Visible = true;
                                    LoadType("0", 0, 0);
                                    txt_MTPID.Items.Insert(0, new ListItem("根节点", "0"));
                                    mt_btn_add.Visible = true;
                                    mt_btn_save.Visible = false;
                                    EditModuleTypePanel.Visible = true;
                                    GetModuleType(id);
                                    break;
                                case 1:
                                    TitlePanel.Visible = false;
                                    LoadType("0", 0, 1);
                                    m_btn_add.Visible = true;
                                    m_btn_save.Visible = false;
                                    m_btn_update.Visible = true;
                                    EditModulePanel.Visible = true;
                                    BindPermissionUpdate(id);
                                    mt_btn_add.Visible = false;
                                    break;
                                case 2:
                                    TitlePanel.Visible = true;
                                    m_btn_add.Visible = false;
                                    break;
                            }
                        }
                    } else {
                        Session["ErrorNum"] = "0";
                        Response.Redirect("~/Error.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// 加载分类
        /// </summary>
        /// <param name="MtID">分类上级ID</param>
        /// <param name="Depth">分类级别深度</param>
        /// <param name="flag">指定分类组件</param>
        protected void LoadType(string MtID, int Depth, int flag) {
            DataView dvList = new DataView(bll.GetModuleTypeList("").Tables[0]);
            dvList.RowFilter = "ModuleTypeSuperiorID=" + MtID;  //过滤父节点 
            foreach (DataRowView dv in dvList) {
                string depth = string.Empty;
                for (int i = 0; i < Depth; i++) {
                    depth = depth + "-";
                }
                switch (flag) {
                    case 0:
                        txt_MTPID.Items.Add(new ListItem(depth + dv["ModuleTypeName"].ToString(), dv["ModuleTypeID"].ToString()));
                        break;
                    case 1:
                        txt_MT.Items.Add(new ListItem(depth + dv["ModuleTypeName"].ToString(), dv["ModuleTypeID"].ToString()));
                        break;
                }

                LoadType(dv["ModuleTypeID"].ToString(), int.Parse(dv["ModuleTypeDepth"].ToString()) + 1, flag);  //递归 
            }
        }

        protected void GetModuleType(int id) {
            Entity.BASE_MODULETYPE model = new Entity.BASE_MODULETYPE();
            model = bll.GetModuleTypeModel(id);
            MT_ID.Text = model.ModuleTypeID.ToString();
            txt_MTName.Text = model.ModuleTypeName;
            txt_MTorder.Text = model.ModuleTypeOrder.ToString();
            txt_MTDescription.Text = model.ModuleTypeDescription;
            txt_MTPID.SelectedValue = model.ModuleTypeSuperiorID.ToString();
        }

        /// <summary>
        /// 添加时初始化权限
        /// </summary>
        public void BindPermission() {
            StringBuilder strState = new StringBuilder();
            StringBuilder strTag = new StringBuilder();
            SmartPoms.BLL.BASE_AUTHORITYDIR Abll = new BLL.BASE_AUTHORITYDIR();
            DataSet ds = Abll.GetAuthorityList("", "order by AuthorityOrder asc");

            int rcount = ds.Tables[0].Rows.Count;
            AuthorityNum.Text = rcount.ToString();
            if (rcount == 0) {
                divstate.InnerHtml = "暂无记录";
            } else {
                strState.Append("<table width=\"340\" border=\"0\" cellpadding=\"0\" cellspacing=\"2\">");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                    if ((i + 1) % 2 != 0) {
                        #region 左边
                        strState.Append("<tr><td width=\"50\"><span class=\"RoleTitle\">" + ds.Tables[0].Rows[i]["AuthorityName"].ToString()
                            + "</span></td><td width=\"100\"><table id=\"Alist" + i.ToString()
                            + "\" border=\"0\"><tr><td><input id=\"Alist" + i.ToString()
                            + "_0\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"1\" />"
                            + "<label for=\"Alist" + i.ToString() + "_0\">允许</label></td><td>"
                            + "<input id=\"Alist" + i.ToString() + "_1\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"0\" checked=\"checked\" />"
                            + "<label for=\"Alist" + i.ToString() + "_1\">拒绝</label></td></tr></table></td>");

                        #endregion
                    } else {
                        #region 左边
                        strState.Append("<td width=\"50\"><span class=\"RoleTitle\">" + ds.Tables[0].Rows[i]["AuthorityName"].ToString()
                            + "</span></td><td width=\"100\"><table id=\"Alist" + i.ToString()
                            + "\" border=\"0\"><tr><td><input id=\"Alist" + i.ToString()
                            + "_0\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"1\" />"
                            + "<label for=\"Alist" + i.ToString() + "_0\">允许</label></td><td>"
                            + "<input id=\"Alist" + i.ToString() + "_1\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"0\" checked=\"checked\" />"
                            + "<label for=\"Alist" + i.ToString() + "_1\">拒绝</label></td></tr></table></td></tr>");

                        #endregion
                    }

                    //写入标识
                    strTag.Append("<input type=\"hidden\" name=\"Atag" + i.ToString() + "\" id=\"Atag" + i.ToString() + "\" value=\"" + ds.Tables[0].Rows[i]["AuthorityTag"] + "\" />");
                }

                if ((rcount) % 2 == 0) {
                    strState.Append("</table>");
                } else {
                    strState.Append("<td width=\"50\">&nbsp;</td><td width=\"100\">&nbsp;</td></tr></table>");
                }

                divstate.InnerHtml = strState.ToString() + strTag.ToString();
            }
        }

        /// <summary>
        /// 更新时初始化权限
        /// </summary>
        /// <param name="ModuleID"></param>
        public void BindPermissionUpdate(int ModuleID) {
            #region 模块数据绑定
            
            Entity.BASE_MODULE model = new Entity.BASE_MODULE();
            model = bll.GetModuleModel(ModuleID);
            M_ID.Text = model.ModuleID.ToString();
            txt_MT.SelectedValue = model.ModuleTypeID.ToString();
            txt_name.Text = model.ModuleName;
            txt_tag.Text = model.ModuleTag;
            txt_url.Text = model.ModuleURL;
            if (model.ModuleDisabled) { txt_state.SelectedIndex = 0; } else { txt_state.SelectedIndex = 1; }

            txt_order.Text = model.ModuleOrder.ToString();
            txt_Description.Text = model.ModuleDescription;

            if (model.IsMenu) { IsMenu.SelectedIndex = 0; } else { IsMenu.SelectedIndex = 1; }

            #endregion

            #region 权限数据绑定

            StringBuilder strState = new StringBuilder();//状态
            StringBuilder strTag = new StringBuilder();//标识
            StringBuilder strVerify = new StringBuilder();//对比状态            

            BLL.BASE_AUTHORITYDIR Abll = new BLL.BASE_AUTHORITYDIR();
            DataSet MALDS = bll.GetAuthorityList(ModuleID);
            DataSet ds = Abll.GetAuthorityList("", "order by AuthorityOrder asc");

            int rcount = ds.Tables[0].Rows.Count;
            AuthorityNum.Text = rcount.ToString();
            if (rcount == 0) {
                divstate.InnerHtml = "暂无记录";
            } else {
                strVerify.Append("<input type=\"hidden\" name=\"verifystate\" id=\"verifystate\" value=\"");
                strState.Append("<table width=\"340\" border=\"0\" cellpadding=\"0\" cellspacing=\"2\">");
                for (int i = 0; i < rcount; i++) {
                    bool v = false;
                    for (int k = 0; k < MALDS.Tables[0].Rows.Count; k++) {
                        if (MALDS.Tables[0].Rows[k]["AuthorityTag"].ToString() == ds.Tables[0].Rows[i]["AuthorityTag"].ToString()) {
                            v = true;
                            break;
                        }
                    }
                    if ((i + 1) % 2 != 0) {
                        #region 左边
                        if (v)//是否为可以使用的权限
                        {
                            strState.Append("<tr><td width=\"50\"><span class=\"RoleTitle\">" + ds.Tables[0].Rows[i]["AuthorityName"].ToString()
                                + "</span></td><td width=\"100\"><table id=\"Alist" + i.ToString()
                                + "\" border=\"0\"><tr><td><input id=\"Alist" + i.ToString()
                                + "_0\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"1\" checked=\"checked\" />"
                                + "<label for=\"Alist" + i.ToString() + "_0\">允许</label></td><td>"
                                + "<input id=\"Alist" + i.ToString() + "_1\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"0\" />"
                                + "<label for=\"Alist" + i.ToString() + "_1\">拒绝</label></td></tr></table></td>");
                            strVerify.Append("1,");
                        } else {
                            strState.Append("<tr><td width=\"50\"><span class=\"RoleTitle\">" + ds.Tables[0].Rows[i]["AuthorityName"].ToString()
                                + "</span></td><td width=\"100\"><table id=\"Alist" + i.ToString()
                                + "\" border=\"0\"><tr><td><input id=\"Alist" + i.ToString()
                                + "_0\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"1\" />"
                                + "<label for=\"Alist" + i.ToString() + "_0\">允许</label></td><td>"
                                + "<input id=\"Alist" + i.ToString() + "_1\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"0\" checked=\"checked\" />"
                                + "<label for=\"Alist" + i.ToString() + "_1\">拒绝</label></td></tr></table></td>");
                            strVerify.Append("0,");
                        }
                        #endregion
                    } else {
                        #region 右边
                        if (v)//是否为可以使用的权限
                        {
                            strState.Append("<td width=\"50\"><span class=\"RoleTitle\">" + ds.Tables[0].Rows[i]["AuthorityName"].ToString()
                                + "</span></td><td width=\"100\"><table id=\"Alist" + i.ToString()
                                + "\" border=\"0\"><tr><td><input id=\"Alist" + i.ToString()
                                + "_0\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"1\" checked=\"checked\" />"
                                + "<label for=\"Alist" + i.ToString() + "_0\">允许</label></td><td>"
                                + "<input id=\"Alist" + i.ToString() + "_1\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"0\" />"
                                + "<label for=\"Alist" + i.ToString() + "_1\">拒绝</label></td></tr></table></td></tr>");
                            strVerify.Append("1,");
                        } else {
                            strState.Append("<td width=\"50\"><span class=\"RoleTitle\">" + ds.Tables[0].Rows[i]["AuthorityName"].ToString()
                                + "</span></td><td width=\"100\"><table id=\"Alist" + i.ToString()
                                + "\" border=\"0\"><tr><td><input id=\"Alist" + i.ToString()
                                + "_0\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"1\" />"
                                + "<label for=\"Alist" + i.ToString() + "_0\">允许</label></td><td>"
                                + "<input id=\"Alist" + i.ToString() + "_1\" type=\"radio\" name=\"Alist" + i.ToString() + "\" value=\"0\" checked=\"checked\" />"
                                + "<label for=\"Alist" + i.ToString() + "_1\">拒绝</label></td></tr></table></td></tr>");
                            strVerify.Append("0,");
                        }
                        #endregion
                    }
                    //写入标识
                    strTag.Append("<input type=\"hidden\" name=\"Atag" + i.ToString() + "\" id=\"Atag" + i.ToString() + "\" value=\"" + ds.Tables[0].Rows[i]["AuthorityTag"] + "\" />");
                }

                strVerify.Append("\" />");

                if ((rcount) % 2 == 0) {
                    strState.Append("</table>");
                } else {
                    strState.Append("<td width=\"50\">&nbsp;</td><td width=\"100\">&nbsp;</td></tr></table>");
                }

                divstate.InnerHtml = strState.ToString() + strTag.ToString() + strVerify.ToString();
            }
            #endregion
        }

        /// <summary>
        /// 清空输入框数据
        /// </summary>
        public void clearTxt() {
            txt_name.Text = "";
            txt_tag.Text = "";
            txt_url.Text = "";
            txt_state.SelectedIndex = 0;
            txt_order.Text = "";
            txt_Description.Text = "";
        }

        /// <summary>
        /// 清空输入框数据
        /// </summary>
        public void clearTxt2() {
            txt_MTName.Text = "";
            txt_MTDescription.Text = "";
            txt_MTorder.Text = "";
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        protected void m_btn_delete_Click(object sender, EventArgs e) {
            if (bll.DeleteModule(int.Parse(M_ID.Text))) {
                Smart.Utility.JScript.Extjs("alert('删除成功!');window.parent.location.href='ModulesPage.aspx';");
            } else {
                strinfo.InnerHtml =Smart.Utility.JScript.errinfo("删除操作失败!");
                strinfo.Visible = true;
            }
        }

        /// <summary>
        /// 删除模块分类
        /// </summary>
        protected void mt_btn_delete_Click(object sender, EventArgs e) {
            switch (bll.DeleteModuleType(int.Parse(MT_ID.Text))) {
                case 0:
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("删除操作失败!");
                    strinfo.Visible = true;
                    break;
                case 1:
                    Smart.Utility.JScript.Extjs("alert('删除成功!');window.parent.location.href='ModulesPage.aspx';");
                    break;
                case 2:
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("分类下还有子级,不能进行删除操作!");
                    strinfo.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 更新模块信息
        /// </summary>
        protected void btn_update_Click(object sender, EventArgs e) {
            Entity.BASE_MODULE model = new Entity.BASE_MODULE();
            model.ModuleID = int.Parse(M_ID.Text);
            model.ModuleTypeID = int.Parse(txt_MT.SelectedValue);
            model.ModuleName = txt_name.Text.Trim();
            model.ModuleTag = txt_tag.Text.Trim();
            model.ModuleURL = txt_url.Text.Trim();
            if (txt_state.SelectedValue == "0") { model.ModuleDisabled = false; } else { model.ModuleDisabled = true; }
            model.ModuleOrder = int.Parse(txt_order.Text.Trim());
            model.ModuleDescription = txt_Description.Text.Trim();
            if (IsMenu.SelectedValue == "0") { model.IsMenu = false; } else { model.IsMenu = true; }

            string[] vstr = Request.Form["verifystate"].Split(',');

            switch (bll.UpdateModule(model)) {
                case 1:
                    ArrayList list = new ArrayList();//建立事务列表
                    int n = int.Parse(AuthorityNum.Text);
                    for (int i = 0; i < n; i++) {
                        //判断权限是否有变化
                        if (vstr[i] != Request.Form["Alist" + i.ToString()].ToString()) {
                            string item = string.Empty;
                            item = item + model.ModuleID.ToString() + "|"
                                + Request.Form["Atag" + i.ToString()].ToString() + "|"
                                + Request.Form["Alist" + i.ToString()].ToString();//判断插入增加还是删除
                            list.Add(item);
                        }
                    }
                    //权限更新是否成功！
                    if (bll.UpdateAuthorityList(list)) {
                        //BindPermissionUpdate(model.ModuleID);
                        Smart.Utility.JScript.Extjs("alert('更新成功!');window.parent.location.href='ModulesPage.aspx';");
                    } else {
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("更新操作失败!");
                        strinfo.Visible = true;
                    }
                    break;
                case 2:
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("标识已经存在，请更换后重试!");
                    strinfo.Visible = true;
                    break;
                default:
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("更新操作失败!");
                    strinfo.Visible = true;
                    break;
            }

        }

        /// <summary>
        /// 更新模块分类信息
        /// </summary>
        protected void mt_btn_update_Click(object sender, EventArgs e) {
             
            Entity.BASE_MODULETYPE model = new Entity.BASE_MODULETYPE();
            model.ModuleTypeID = int.Parse(MT_ID.Text);
            model.ModuleTypeName = txt_MTName.Text.Trim();
            model.ModuleTypeSuperiorID = int.Parse(txt_MTPID.SelectedValue);
            model.ModuleTypeDescription = txt_MTDescription.Text.Trim();
            model.ModuleTypeOrder = int.Parse(txt_MTorder.Text.Trim());

            if (bll.UpdateModuleType(model)) {
                Smart.Utility.JScript.Extjs("alert('更新成功!');window.parent.location.href='ModulesPage.aspx';");
            } else {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("更新操作失败!");
                strinfo.Visible = true;
            }
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        protected void mt_btn_add_Click(object sender, EventArgs e) {
            txt_MTPID.Items.Clear();
            LoadType("0", 0, 0);
            txt_MTPID.Items.Insert(0, new ListItem("根节点", "0"));
            clearTxt2();
            EditModuleTypePanel.Visible = true;
            EditModulePanel.Visible = false;
            mt_btn_delete.Visible = false;
            mt_btn_update.Visible = false;
            mt_btn_save.Visible = true;
            txt_MTPID.SelectedValue = MID.Text;
        }

        /// <summary>
        /// 添加模块
        /// </summary>
        protected void m_btn_add_Click(object sender, EventArgs e) {
            txt_MT.Items.Clear();
            LoadType("0", 0, 1);
            clearTxt();
            BindPermission();
            m_btn_update.Visible = false;
            m_btn_save.Visible = true;
            m_btn_delete.Visible = false;
            EditModuleTypePanel.Visible = false;
            EditModulePanel.Visible = true;
            txt_MT.SelectedValue = MID.Text;
        }

        /// <summary>
        /// 保存模块信息
        /// </summary>
        protected void mt_btn_save_Click(object sender, EventArgs e) {
            if (txt_MTName.Text.Trim() != "" || txt_MTorder.Text.Trim() != "" || Smart.Utility.TypeParse.IsUnsign(txt_MTorder.Text.Trim())) {
                Entity.BASE_MODULETYPE model = new Entity.BASE_MODULETYPE();

                model.ModuleTypeName = txt_MTName.Text.Trim();
                model.ModuleTypeDescription = txt_MTDescription.Text.Trim();
                model.ModuleTypeOrder = int.Parse(txt_MTorder.Text.Trim());
                model.ModuleTypeSuperiorID = int.Parse(txt_MTPID.SelectedValue);

                switch (bll.CreateModuleType(model)) {
                    case 1:
                        txt_MTName.Text = "";
                        txt_MTDescription.Text = "";
                        txt_MTorder.Text = "";
                        Smart.Utility.JScript.Extjs("alert('添加成功!');window.parent.location.href='ModulesPage.aspx';");
                        break;
                    case 2:
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("标识已存在,请更换后重试!");
                        strinfo.Visible = true;
                        break;
                    default:
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("添加操作失败!");
                        strinfo.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// 保存模块信息
        /// </summary>
        protected void m_btn_save_Click(object sender, EventArgs e) {
            Entity.BASE_MODULE model = new Entity.BASE_MODULE();
            model.ModuleTypeID = int.Parse(txt_MT.SelectedValue);
            model.ModuleName = txt_name.Text.Trim();
            model.ModuleTag = txt_tag.Text.Trim();
            model.ModuleURL = txt_url.Text.Trim();
            if (txt_state.SelectedValue == "0") { model.ModuleDisabled = true; } else { model.ModuleDisabled = true; }
            model.ModuleOrder = int.Parse(txt_order.Text.Trim());
            model.ModuleDescription = txt_Description.Text.Trim();

            if (IsMenu.SelectedValue == "0") { model.IsMenu = false; } else { model.IsMenu = true; }

            if (!bll.ModuleExists(txt_tag.Text.Trim())) {
                int RowID = bll.CreateModule(model);//返回模块ID;
                if (RowID != 0)//添加OK
                {
                    ArrayList list = new ArrayList();//建立事务列表
                    int n = int.Parse(AuthorityNum.Text);
                    for (int i = 0; i < n; i++) {
                        if (Request.Form["Alist" + i.ToString()].ToString() == "1")//如果允许则插入记录
                        {
                            string item = string.Empty;
                            item = item + RowID.ToString() + "|" + Request.Form["Atag" + i.ToString()].ToString();
                            list.Add(item);
                        }
                    }
                    //权限加入是否成功！
                    if (bll.CreateAuthorityList(list)) {
                        clearTxt();
                        EditModulePanel.Visible = true;
                        Smart.Utility.JScript.Extjs("alert('添加成功!');window.parent.location.href='ModulesPage.aspx';");
                    } else {
                        strinfo.InnerHtml = Smart.Utility.JScript.errinfo("添加操作失败!");
                        strinfo.Visible = true;
                    }
                } else {
                    strinfo.InnerHtml = Smart.Utility.JScript.errinfo("标识已存在,请更换后重试!");
                    strinfo.Visible = true;
                }
            } else {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("添加操作失败!");
                strinfo.Visible = true;
            }

        }
    }
}