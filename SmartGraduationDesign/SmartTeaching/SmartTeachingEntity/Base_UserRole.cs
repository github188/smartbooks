namespace SmartTeaching.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_UserRole
    /// </summary>
    public class Base_UserRole
    {
        /// <summary>
        /// UserRoleId
        /// </summary>		
        private int _UserRoleId;
        /// <summary>
        /// UserId
        /// </summary>		
        private int _UserId;
        /// <summary>
        /// RoleId
        /// </summary>		
        private int _RoleId;
        /// <summary>
        /// NewsTypeId
        /// </summary>		
        private int _NewsTypeId;

        /// <summary>
        /// UserRoleId
        /// </summary>
        public int UserRoleId
        {
            get { return _UserRoleId; }
            set { _UserRoleId = value; }
        }
        /// <summary>
        /// UserId
        /// </summary>
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        /// <summary>
        /// RoleId
        /// </summary>
        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
        /// <summary>
        /// NewsTypeId
        /// </summary>
        public int NewsTypeId
        {
            get { return _NewsTypeId; }
            set { _NewsTypeId = value; }
        }
    }
}