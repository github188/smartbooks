// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLE.cs
// 功能描述:Base_Role -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_Role -- 实体定义
    /// </summary>
    public class BASE_ROLE {
        /// <summary>
        /// 角色ID
        /// </summary>		
        private int _RoleID;
        /// <summary>
        /// 分组ID
        /// </summary>		
        private int _RoleGroupID;
        /// <summary>
        /// 角色名称
        /// </summary>		
        private string _RoleName;
        /// <summary>
        /// 说明
        /// </summary>		
        private string _RoleDescription;
        /// <summary>
        /// RoleOrder
        /// </summary>		
        private int _RoleOrder;

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        /// <summary>
        /// 分组ID
        /// </summary>
        public int RoleGroupID {
            get { return _RoleGroupID; }
            set { _RoleGroupID = value; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string RoleDescription {
            get { return _RoleDescription; }
            set { _RoleDescription = value; }
        }
        /// <summary>
        /// RoleOrder
        /// </summary>
        public int RoleOrder {
            get { return _RoleOrder; }
            set { _RoleOrder = value; }
        }
    }
}