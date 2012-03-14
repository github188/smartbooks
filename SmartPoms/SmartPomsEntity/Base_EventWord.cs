// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_EVENTWORD.cs
// 功能描述:Base_EventWord -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_EventWord -- 实体定义
    /// </summary>
    public class BASE_EVENTWORD {
        /// <summary>
        /// EventWordID
        /// </summary>		
        private int _EventWordID;
        /// <summary>
        /// EventID
        /// </summary>		
        private int _EventID;
        /// <summary>
        /// WordID
        /// </summary>		
        private int _WordID;

        /// <summary>
        /// EventWordID
        /// </summary>
        public int EventWordID {
            get { return _EventWordID; }
            set { _EventWordID = value; }
        }
        /// <summary>
        /// EventID
        /// </summary>
        public int EventID {
            get { return _EventID; }
            set { _EventID = value; }
        }
        /// <summary>
        /// WordID
        /// </summary>
        public int WordID {
            get { return _WordID; }
            set { _WordID = value; }
        }
    }
}