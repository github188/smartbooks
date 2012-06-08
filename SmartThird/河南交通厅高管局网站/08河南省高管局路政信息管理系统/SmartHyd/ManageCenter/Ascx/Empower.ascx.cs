using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SmartHyd.Utility;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Empower : UI.BaseUserControl
    {

        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_DEPT deptbll = new BLL.BASE_DEPT();
        private BLL.BASE_ROLE rolebll = new BLL.BASE_ROLE();
        private BLL.BASE_ACTION actionbll = new BLL.BASE_ACTION();
        private BLL.BASE_MENU menubll = new BLL.BASE_MENU();
        private BLL.BASE_USER_ROLE userRolebll = new BLL.BASE_USER_ROLE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 6.6前
                //dataBindToRepeater();
                //GetTreeAction();//动作权限树绑定
                //GetTreeMenu();//菜单树绑定
                //GetTreeRole();//角色树绑定
                #endregion
                #region 6.6当天
                //UserBind();//授权用户绑定
                //RoleBind();//角色绑定
                //MenuBind();// 菜单绑定
                //ActionBind(); // 动作绑定
                #endregion
                #region 6.7
                if (null == Request.QueryString["userid"] || "" == Request.QueryString["userid"] && "" == Request.QueryString["name"])
                {
                    this.BtnEmp.Enabled = false;
                    this.LabUser.Text = "请选择授权用户";
                }
                else
                {
                    ViewState["userid"] = Request.QueryString["userid"];//视图状态：保存用户编号；
                    this.LabUser.Text = Request.QueryString["name"];
                }

                #endregion
            }
        }
        #region 6.7用户授权
       
        protected Entity.BASE_USER_ROLE GetModel(decimal userid, decimal ROLEID, decimal MENUID, decimal ACTIONID)
        {
            Entity.BASE_USER_ROLE Model = new Entity.BASE_USER_ROLE();
             Model.USERROLEID =-1;//主键，ID
            Model.USERID = userid;// 用户编号；
            Model.ROLEID = ROLEID;//角色编号；
            Model.MENUID = MENUID;//菜单编号；
            Model.ACTIONID = ACTIONID;//动作编号；
            return Model;
        }
        /// <summary>
        /// 授权
        /// </summary>
        private void EmpowerAdd(decimal userid, decimal ROLEID)
        {
            decimal MENUID = 0;//菜单编号默认为0
            decimal ACTIONID = 0;//动作编号默认为0
            //判断用户是否拥有权限;如果已有权限，删除已有权限
            if (userRolebll.ExistsUserid(userid))
            {
                string strwhere = "USERID=" + userid;
                userRolebll.deletelist(strwhere);//删除已有权限
                userRolebll.Add(GetModel(userid, ROLEID, MENUID, ACTIONID));//用户授权
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('授权成功！')", true);
            }
            else
            {
                userRolebll.Add(GetModel(userid, ROLEID, MENUID, ACTIONID));//用户授权
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('授权成功！')", true);
            }

        }
        /// <summary>
        /// 按钮事件：授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEmp_Click(object sender, EventArgs e)
        {
            decimal userid=Convert.ToDecimal(ViewState["userid"]);
            decimal roleid = 0;
            if (this.RadioButton1.Checked)
            {
                roleid = 1;
            }
            if (this.RadioButton2.Checked)
            {
                roleid = 2;
            }
            if (this.RadioButton3.Checked)
            {
                roleid = 3;
            }
            if (this.RadioButton4.Checked)
            {
                roleid = 4;
            }
            EmpowerAdd(userid, roleid);
        }
        #endregion
    }
}