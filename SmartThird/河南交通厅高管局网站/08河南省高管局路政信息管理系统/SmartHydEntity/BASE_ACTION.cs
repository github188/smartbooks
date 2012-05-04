// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ACTION.cs
// 功能描述:动作信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 动作信息表 -- 实体定义
    /// </summary>
    public class BASE_ACTION {
        /// <summary>
        /// 动作编号
        /// </summary>		
        private decimal _ACTIONID;
        /// <summary>
        /// 动作名称
        /// </summary>		
        private string _ACTIONNAME;
        /// <summary>
        /// 状态（0：正常 1关闭）
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 动作描述
        /// </summary>		
        private string _ACTIONINFO;

        /// <summary>
        /// 动作编号
        /// </summary>
        public decimal ACTIONID {
            get { return _ACTIONID; }
            set { _ACTIONID = value; }
        }
        /// <summary>
        /// 动作名称
        /// </summary>
        public string ACTIONNAME {
            get { return _ACTIONNAME; }
            set { _ACTIONNAME = value; }
        }
        /// <summary>
        /// 状态（0：正常 1关闭）
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 动作描述
        /// </summary>
        public string ACTIONINFO {
            get { return _ACTIONINFO; }
            set { _ACTIONINFO = value; }
        }
    }
}