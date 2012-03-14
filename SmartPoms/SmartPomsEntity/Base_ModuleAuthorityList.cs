// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MODULEAUTHORITYLIST.cs
// 功能描述:Base_ModuleAuthorityList -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_ModuleAuthorityList -- 实体定义
    /// </summary>
    public class BASE_MODULEAUTHORITYLIST {
        /// <summary>
        /// 模块权限ID
        /// </summary>		
        private int _ID;
        /// <summary>
        /// 模块ID
        /// </summary>		
        private int _ModuleID;
        /// <summary>
        /// 权限标识
        /// </summary>		
        private string _AuthorityTag;

        /// <summary>
        /// 模块权限ID
        /// </summary>
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 模块ID
        /// </summary>
        public int ModuleID {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }
        /// <summary>
        /// 权限标识
        /// </summary>
        public string AuthorityTag {
            get { return _AuthorityTag; }
            set { _AuthorityTag = value; }
        }
    }
}