using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace SmartHyd.UI {
    public class BaseUserPage : System.Web.UI.Page, Smart.Utility.ISessionBox {
        #region 私有变量
        private Utility.UserSession _UserSession = null;
        private BLL.BASE_USER bll = new BLL.BASE_USER();
        #endregion
        
        #region 公共方法

        /// <summary>
        /// 检查Session是否有效
        /// </summary>
        /// <param name="name">Session名称</param>
        /// <param name="value">Session值</param>
        /// <returns>结果：true有效，false无效</returns>
        public bool Checked(string name, object value) {
            try {
                object old = Session[name];
                if (old.Equals(value)) {
                    return true;
                } else {
                    return false;                    
                }
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 增加一个Session
        /// </summary>
        /// <param name="name">Session名称</param>
        /// <param name="value">Session值</param>
        /// <returns>结果：true成功，false失败</returns>
        public bool Add(string name, object value) {
            if (!Checked(name, value)) {
                Session[name] = value;
                return true;
            } else {
                throw new Exception(string.Format("Session {0} 已存在。", name));
            }
        }

        /// <summary>
        /// 移除一个Session
        /// </summary>
        /// <param name="name">Session名称</param>
        /// <returns>结果：true成功，false失败</returns>
        public bool Remove(string name) {
            try {
                Session.Remove(name);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 更新一个Session
        /// </summary>
        /// <param name="name">Session名称</param>
        /// <param name="value">Session值</param>
        /// <returns>结果：true成功，false失败</returns>
        public bool Update(string name, object value) {
            if (Checked(name, value)) {
                Session[name] = value;
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 获取一个Session
        /// </summary>
        /// <param name="name">Session名称</param>
        /// <returns>Session Object值对象</returns>
        public object Get(string name) {
            try {
                return Session[name];
            } catch {
                return null;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>true登录成功,false失败</returns>
        public bool Login(string userName, string pwd) {
            //判断用户是否存在
            Entity.BASE_USER model;
            model = bll.GetUser(userName, pwd);
            if (model != null) {
                //初始化用户Session类
                Utility.UserSession userSession = new Utility.UserSession(Convert.ToInt32(model.USERID));
                
                //用户Session加入Session
                if (this.Add("user", userSession)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns>true退出成功,false退出失败</returns>
        public bool LoginOut() {
            //移除用户Session
            if (this.Remove("user")) {
                return true;
            } else {
                return false;
            }
        }
        #endregion

        #region 公共属性

        /// <summary>
        /// 获取当前已登录用户的Session，默认Null值
        /// </summary>
        public Utility.UserSession UserSession {
            get { return _UserSession; }
        }

        #endregion
        
        /*
        void Page_Init(Object source, EventArgs e) {
            object userSession = this.Get("user");
            if (userSession == null) {
                throw new Exception("用户尚未登录系统,无法授权使用该页面。");
            } else {
                _UserSession = (Utility.UserSession)userSession;
            }
        }
        */
    }
}
