// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROAD_TERM_TYPE.cs
// 功能描述:路产设备类型表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 路产设备类型表 -- 实体定义
    /// </summary>
    public class BASE_ROAD_TERM_TYPE {
        /// <summary>
        /// 路产设备类型编号
        /// </summary>		
        private decimal _TYPEID;
        /// <summary>
        /// 路产设备类型名称
        /// </summary>		
        private string _TYPENAME;

        /// <summary>
        /// 路产设备类型编号
        /// </summary>
        public decimal TYPEID {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        /// <summary>
        /// 路产设备类型名称
        /// </summary>
        public string TYPENAME {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }
    }
}