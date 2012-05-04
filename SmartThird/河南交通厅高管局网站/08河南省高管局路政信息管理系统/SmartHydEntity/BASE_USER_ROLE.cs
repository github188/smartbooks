// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER_ROLE.cs
// 功能描述:用户角色信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 用户角色信息表 -- 实体定义
    /// </summary>
    public class BASE_USER_ROLE {
        /// <summary>
        /// 用户角色编号
        /// </summary>		
        private decimal _USERROLEID;
        /// <summary>
        /// 用户编号
        /// </summary>		
        private decimal _USERID;
        /// <summary>
        /// 角色编号
        /// </summary>		
        private decimal _ROLEID;
        /// <summary>
        /// 菜单编号
        /// </summary>		
        private decimal _MENUID;
        /// <summary>
        /// 用户模块操作权限
        /// </summary>		
        private decimal _ACTIONID;

        /// <summary>
        /// 用户角色编号
        /// </summary>
        public decimal USERROLEID {
            get { return _USERROLEID; }
            set { _USERROLEID = value; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public decimal USERID {
            get { return _USERID; }
            set { _USERID = value; }
        }
        /// <summary>
        /// 角色编号
        /// </summary>
        public decimal ROLEID {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public decimal MENUID {
            get { return _MENUID; }
            set { _MENUID = value; }
        }
        /// <summary>
        /// 用户模块操作权限
        /// </summary>
        public decimal ACTIONID {
            get { return _ACTIONID; }
            set { _ACTIONID = value; }
        }
    }
}