// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_DEPT.cs
// 功能描述:部门信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 部门信息表 -- 实体定义
    /// </summary>
    public class BASE_DEPT {
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTID;
        /// <summary>
        /// 部门名称
        /// </summary>		
        private string _DPTNAME;
        /// <summary>
        /// 部门描述
        /// </summary>		
        private string _DPTINFO;
        /// <summary>
        /// 上级部门编号（根节点0）
        /// </summary>		
        private decimal _PARENTID;
        /// <summary>
        /// 状态（0：正常 1：关闭）
        /// </summary>		
        private decimal _STATUS;

        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DPTNAME {
            get { return _DPTNAME; }
            set { _DPTNAME = value; }
        }
        /// <summary>
        /// 部门描述
        /// </summary>
        public string DPTINFO {
            get { return _DPTINFO; }
            set { _DPTINFO = value; }
        }
        /// <summary>
        /// 上级部门编号（根节点0）
        /// </summary>
        public decimal PARENTID {
            get { return _PARENTID; }
            set { _PARENTID = value; }
        }
        /// <summary>
        /// 状态（0：正常 1：关闭）
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
    }
}