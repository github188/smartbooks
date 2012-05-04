// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AREA_TYPE.cs
// 功能描述:控制区违章类型表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 控制区违章类型表 -- 实体定义
    /// </summary>
    public class BASE_AREA_TYPE {
        /// <summary>
        /// 分类名称
        /// </summary>		
        private string _TYPENAME;
        /// <summary>
        /// id,主键，自增
        /// </summary>		
        private decimal _TYPEID;

        /// <summary>
        /// 分类名称
        /// </summary>
        public string TYPENAME {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }
        /// <summary>
        /// id,主键，自增
        /// </summary>
        public decimal TYPEID {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
    }
}