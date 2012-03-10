namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 用户信息表
    /// </summary>
    public class BASE_USER {
        /// <summary>
        /// USERID
        /// </summary>		
        private int _USERID;
        /// <summary>
        /// USERNAME
        /// </summary>		
        private string _USERNAME;
        /// <summary>
        /// USERPWD
        /// </summary>		
        private string _USERPWD;
        /// <summary>
        /// ROLEID
        /// </summary>		
        private string _ROLEID;

        /// <summary>
        /// USERID
        /// </summary>
        public int USERID {
            get { return _USERID; }
            set { _USERID = value; }
        }
        /// <summary>
        /// USERNAME
        /// </summary>
        public string USERNAME {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        /// <summary>
        /// USERPWD
        /// </summary>
        public string USERPWD {
            get { return _USERPWD; }
            set { _USERPWD = value; }
        }
        /// <summary>
        /// ROLEID
        /// </summary>
        public string ROLEID {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }
    }
}