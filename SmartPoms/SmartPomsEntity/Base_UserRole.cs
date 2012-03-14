// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USERROLE.cs
// 功能描述:Base_UserRole -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_UserRole -- 实体定义
    /// </summary>
    public class BASE_USERROLE {
        /// <summary>
        /// UR_ID
        /// </summary>		
        private int _UR_ID;
        /// <summary>
        /// UserID
        /// </summary>		
        private int _UserID;
        /// <summary>
        /// RoleID
        /// </summary>		
        private int _RoleID;

        /// <summary>
        /// UR_ID
        /// </summary>
        public int UR_ID {
            get { return _UR_ID; }
            set { _UR_ID = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>
        public int UserID {
            get { return _UserID; }
            set { _UserID = value; }
        }
        /// <summary>
        /// RoleID
        /// </summary>
        public int RoleID {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
    }
}