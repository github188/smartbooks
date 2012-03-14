// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CONFIGURATION.cs
// 功能描述:Base_Configuration -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_Configuration -- 实体定义
    /// </summary>
    public class BASE_CONFIGURATION {
        /// <summary>
        /// 配置项ID
        /// </summary>		
        private int _ItemID;
        /// <summary>
        /// 配置名
        /// </summary>		
        private string _ItemName;
        /// <summary>
        /// 配置值
        /// </summary>		
        private string _ItemValue;
        /// <summary>
        /// 说明
        /// </summary>		
        private string _ItemDescription;

        /// <summary>
        /// 配置项ID
        /// </summary>
        public int ItemID {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        /// <summary>
        /// 配置名
        /// </summary>
        public string ItemName {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        /// <summary>
        /// 配置值
        /// </summary>
        public string ItemValue {
            get { return _ItemValue; }
            set { _ItemValue = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string ItemDescription {
            get { return _ItemDescription; }
            set { _ItemDescription = value; }
        }
    }
}