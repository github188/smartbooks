using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.Utility {
    /// <summary>
    /// 当前登录用户Session信息
    /// 包含用户：权限、角色、功能、部门、基本信息、动作
    /// </summary>
    public class UserSession : Entity.BASE_USER {
        private List<UserRole> _UserRole = new List<UserRole>();
        private Entity.BASE_DEPT _Department = new Entity.BASE_DEPT();
        private BLL.BASE_USER_ROLE _bll = new BLL.BASE_USER_ROLE();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="username">用户名称</param>
        public UserSession(int userId) {
            BindingUserInfo(userId);
        }

        /// <summary>
        /// 绑定用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        private void BindingUserInfo(int userId) {
            BLL.BASE_USER_ROLE userRoleBLL = new BLL.BASE_USER_ROLE();
            var dt = userRoleBLL.GetList(userId);    //获取用户权限集合

            #region 绑定用户基本信息
            BLL.BASE_USER userBLL = new BLL.BASE_USER();
            Entity.BASE_USER userModel = new Entity.BASE_USER();
            userModel = userBLL.GetUser(userId);
            this.BIRTHDAY = userModel.BIRTHDAY;
            this.DEGREE = userModel.DEGREE;
            this.DEPTID = userModel.DEPTID;
            this.FACE = userModel.FACE;
            this.IDNUMBER = userModel.IDNUMBER;
            this.JOBNUMBER = userModel.JOBNUMBER;
            this.PARENTID = userModel.PARENTID;
            this.PHONE = userModel.PHONE;
            this.PHOTO = userModel.PHONE;
            this.PROF = userModel.PROF;
            this.REMARK = userModel.REMARK;
            this.SEX = userModel.SEX;
            this.STSTUS = userModel.STSTUS;
            this.USERID = userModel.USERID;
            this.USERNAME = userModel.USERNAME;
            this.USERPWD = userModel.USERPWD;
            #endregion

            //绑定部门
            BLL.BASE_DEPT deptBLL = new BLL.BASE_DEPT();
            _Department = deptBLL.GetEntity(userModel.DEPTID);

            /*
            #region 绑定角色信息
            var roles = userRoleBLL.Query(
                string.Format("SELECT distinct ROLEID FROM base_user_role WHERE userid = {0}",
                userId.ToString()));
            BLL.BASE_ROLE roleBll = new BLL.BASE_ROLE();
            foreach (DataRow dr in roles.Rows) {
                Entity.BASE_ROLE roleModel = new Entity.BASE_ROLE();                
                roleModel = roleBll.GetEntity(Convert.ToInt32(dr["ROLEID"]));
                
                Utility.UserRole role = new UserRole();
                role.ROLEID = roleModel.ROLEID;
                role.ROLEINFO = roleModel.ROLEINFO;
                role.ROLENAME = roleModel.ROLENAME;

                #region 绑定菜单
                var menus = userRoleBLL.GetList(string.Format("USERID={0} AND ROLEID={1}", 
                    userId.ToString(), 
                    roleModel.ROLEID.ToString()));
                BLL.BASE_MENU bllMenu = new BLL.BASE_MENU();
                foreach (DataRow menuDr in menus.Rows) {
                    Entity.BASE_MENU menuModel = new Entity.BASE_MENU();
                    menuModel = bllMenu.GetEntity(Convert.ToInt32(menuDr["MENUID"]));
                    
                    Utility.UserMenu menu = new UserMenu();
                    menu.ICON = menuModel.ICON;
                    menu.MENUID = menuModel.MENUID;
                    menu.MENUINFO = menuModel.MENUINFO;
                    menu.MENUNAME = menuModel.MENUNAME;
                    menu.MENUURL = menuModel.MENUURL;
                    menu.PARENTID = menuModel.PARENTID;
                    menu.STATUS = menuModel.STATUS;

                    #region 绑定菜单的Action
                    var actions = userRoleBLL.GetList(string.Format("USERID={0} AND ROLEID={1} AND MENUID={2}",
                        userId.ToString(),
                        roleModel.ROLEID.ToString(),
                        menu.MENUID.ToString()));
                    BLL.BASE_ACTION actionBLL = new BLL.BASE_ACTION();
                    foreach (DataRow actionDr in actions.Rows) {
                        Entity.BASE_ACTION actionModel = new Entity.BASE_ACTION();
                        actionModel = actionBLL.GetEntity(Convert.ToInt32(actionDr["ACTIONID"].ToString()));

                        menu.UserAction.Add(actionModel);   //动作信息加载菜单中
                    }
                    #endregion

                    role.UserMenu.Add(menu);    //菜单加入角色组中
                }
                #endregion

                UserRole.Add(role); //角色组加入集合中
            }
            #endregion
            */
        }

        /// <summary>
        /// 用户所属部门
        /// </summary>
        public Entity.BASE_DEPT Department {
            get {
                return _Department;
            }
            set {
                _Department = value;
            }
        }

        /// <summary>
        /// 用户角色集合
        /// </summary>
        public List<UserRole> UserRole {
            get {
                return _UserRole;
            }
            set {
                _UserRole = value;
            }
        }
    }
}