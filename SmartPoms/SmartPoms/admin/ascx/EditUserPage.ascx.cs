using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;

namespace SmartPoms.admin.ascx {
    public partial class EditUserPage : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Msg", "window.parent.changewin();", true);
            strinfo.InnerHtml = "";
            strinfo.Visible = false;
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/login.aspx");
                } else {
                    if (Code.UserHandle.ValidationHandle(Code.Tag.View)) {
                        if (!Code.UserHandle.ValidationHandle(Code.Tag.Edit)) {
                            Btn_ok.Visible = false;
                        }
                        if (Request.QueryString["uid"] != null) {
                            GetUser(int.Parse(Request.QueryString["uid"].ToString()));
                        }
                    }
                }
            }
        }

        protected void GetUser(int id) {
            BLL.BASE_USERGROUP ugbll = new BLL.BASE_USERGROUP();
            DataView dvList = new DataView(ugbll.GetUserGroupList("").Tables[0]);
            LoadGroupList("0", 0, dvList);

            BLL.BASE_USER bll = new BLL.BASE_USER();
            Entity.BASE_USER model = new Entity.BASE_USER();
            model = bll.GetUserModel(id);
            uid.Text = id.ToString();
            txt_name.Text = model.UserName;
            GroupList.SelectedValue = model.UserGroup.ToString();

            txt_email.Text = model.Email;
            StateList.SelectedValue = model.Status.ToString();
            Lab_time1.Text = model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            ArrayList rid = model.RoleID;
            for (int i = 0; i < rid.Count; i++) {
                string[] r = rid[i].ToString().Split(',');
                RoleList.Items.Add(new ListItem(r[1], r[0]));
            }

            //string stime = model.LastLoginTime.ToString("yyyy-MM-dd HH:mm:ss");

            //if (stime != "0001-01-01 00:00:00")
            //{
            //    Lab_time2.Text = stime;
            //}
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

        protected void Btn_ok_Click(object sender, EventArgs e) {
            BLL.BASE_USER bll = new BLL.BASE_USER();
            Entity.BASE_USER model = new Entity.BASE_USER();
            model.UserID = int.Parse(uid.Text);
            model.UserName = txt_name.Text;
            model.UserGroup = int.Parse(GroupList.SelectedItem.Value);
            model.Email = txt_email.Text;
            model.Status = int.Parse(StateList.SelectedItem.Value);

            if (bll.UpdateUser(model) >= 1) {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("用户信息更新成功!");
                strinfo.Visible = true;
            } else {
                strinfo.InnerHtml = Smart.Utility.JScript.errinfo("用户信息更新失败!");
                strinfo.Visible = true;
            }
        }
    }
}