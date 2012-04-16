using System;
using System.Collections.Generic;
using System.Text;

namespace StationModel
{
    /// <summary>
    /// 用户信息实体类
    /// </summary>
    [Serializable]
   public class UserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        private int u_ID;

        public int U_ID
        {
            get { return u_ID; }
            set { u_ID = value; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        private string u_LoginName;

        public string U_LoginName
        {
            get { return u_LoginName; }
            set { u_LoginName = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        private string u_LoginPwd;

        public string U_LoginPwd
        {
            get { return u_LoginPwd; }
            set { u_LoginPwd = value; }
        }
        /// <summary>
        /// 收费站信息对象
        /// </summary>
        private TollStation u_TollStation;

        public TollStation U_TollStation
        {
            get { return u_TollStation; }
            set { u_TollStation = value; }
        }
        /// <summary>
        /// 是否为系统管理员(1:是，0:否)
        /// </summary>
        private int u_IsSuper;

        public int U_IsSuper
        {
            get { return u_IsSuper; }
            set { u_IsSuper = value; }
        }
    }
}
