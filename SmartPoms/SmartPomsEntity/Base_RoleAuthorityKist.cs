// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLEAUTHORITYKIST.cs
// 功能描述:Base_RoleAuthorityKist -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_RoleAuthorityKist -- 实体定义
    /// </summary>
    public class BASE_ROLEAUTHORITYKIST {
        /// <summary>
        /// 编号
        /// </summary>		
        private int _ID;
        /// <summary>
        /// 用户ID
        /// </summary>		
        private int _UserID;
        /// <summary>
        /// 角色ID
        /// </summary>		
        private int _RoleID;
        /// <summary>
        /// 分组ID
        /// </summary>		
        private int _GroupID;
        /// <summary>
        /// 模块ID
        /// </summary>		
        private int _ModuleID;
        /// <summary>
        /// 权限标识
        /// </summary>		
        private string _AuthorityTag;
        /// <summary>
        /// 1为允许，0为不禁止
        /// </summary>		
        private bool _Flag;

        /// <summary>
        /// 编号
        /// </summary>
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID {
            get { return _UserID; }
            set { _UserID = value; }
        }
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
        public int GroupID {
            get { return _GroupID; }
            set { _GroupID = value; }
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
        /// <summary>
        /// 1为允许，0为不禁止
        /// </summary>
        public bool Flag {
            get { return _Flag; }
            set { _Flag = value; }
        }
    }
}