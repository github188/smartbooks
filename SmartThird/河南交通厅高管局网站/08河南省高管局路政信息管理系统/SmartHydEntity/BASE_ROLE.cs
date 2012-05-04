// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLE.cs
// 功能描述:角色信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 角色信息表 -- 实体定义
    /// </summary>
    public class BASE_ROLE {
        /// <summary>
        /// 角色编号
        /// </summary>		
        private decimal _ROLEID;
        /// <summary>
        /// 角色名称
        /// </summary>		
        private string _ROLENAME;
        /// <summary>
        /// 角色描述
        /// </summary>		
        private string _ROLEINFO;

        /// <summary>
        /// 角色编号
        /// </summary>
        public decimal ROLEID {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string ROLENAME {
            get { return _ROLENAME; }
            set { _ROLENAME = value; }
        }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string ROLEINFO {
            get { return _ROLEINFO; }
            set { _ROLEINFO = value; }
        }
    }
}