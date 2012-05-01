namespace SmartTeaching.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_Role
    /// </summary>
    public class Base_Role
    {
        /// <summary>
        /// RoleId
        /// </summary>		
        private int _RoleId;
        /// <summary>
        /// RoleName
        /// </summary>		
        private string _RoleName;
        /// <summary>
        /// Description
        /// </summary>		
        private string _Description;

        /// <summary>
        /// RoleId
        /// </summary>
        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
        /// <summary>
        /// RoleName
        /// </summary>
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }
}