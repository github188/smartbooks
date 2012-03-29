using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// 后台管理用户信息实体类
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
        /// 用户名
        /// </summary>
        private string u_Name;

        public string U_Name
        {
            get { return u_Name; }
            set { u_Name = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        private string u_Pwd;
        public string U_Pwd
        {
            get { return u_Pwd; }
            set { u_Pwd = value; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        private string u_CreateDate;
        public string U_CreateDate
        {
            set { u_CreateDate = value; }
            get { return u_CreateDate; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        private int u_DepartId;
        public int U_DepartId
        {
            get { return u_DepartId; }
            set { u_DepartId = value; }
        }
    }
}
