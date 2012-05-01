namespace SmartTeaching.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_User
    /// </summary>
    public class Base_User
    {
        /// <summary>
        /// UserId
        /// </summary>		
        private int _UserId;
        /// <summary>
        /// UserName
        /// </summary>		
        private string _UserName;
        /// <summary>
        /// Userpwd
        /// </summary>		
        private string _Userpwd;

        private int _RoleId;

        /// <summary>
        /// UserId
        /// </summary>
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        /// <summary>
        /// Userpwd
        /// </summary>
        public string Userpwd
        {
            get { return _Userpwd; }
            set { _Userpwd = value; }
        }

        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
    }
}