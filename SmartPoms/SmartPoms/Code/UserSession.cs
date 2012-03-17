
namespace SmartPoms.Code {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    [Serializable]
    public class UserSession {
        /// <summary>
        /// 初始化用户登录Session
        /// </summary>
        /// <param name="_loginId">用户ID</param>
        /// <param name="_loginname">用户名</param>
        /// <param name="_roleid">角色ID</param>
        /// <param name="_groupid">分组ID</param>
        /// <param name="_islimit">是否授权限限制</param>
        /// <param name="_status">用户状态</param>
        public UserSession(int _loginId, string _loginname, ArrayList _roleid, int _groupid, bool _islimit, int _status) {
            this.LoginId = _loginId;
            this.LoginName = _loginname;
            this.RoleID = _roleid;
            this.GroupID = _groupid;
            this.IsLimit = _islimit;
            this.Status = _status;
        }

        public int LoginId;
        public string LoginName;
        public ArrayList RoleID;
        public int GroupID;
        public bool IsLimit;
        public int Status;
    }
}