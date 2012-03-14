// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USEREVENT.cs
// 功能描述:Base_UserEvent -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_UserEvent -- 实体定义
    /// </summary>
    public class BASE_USEREVENT {
        /// <summary>
        /// ID
        /// </summary>		
        private int _ID;
        /// <summary>
        /// UserID
        /// </summary>		
        private int _UserID;
        /// <summary>
        /// EventID
        /// </summary>		
        private int _EventID;

        /// <summary>
        /// ID
        /// </summary>
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>
        public int UserID {
            get { return _UserID; }
            set { _UserID = value; }
        }
        /// <summary>
        /// EventID
        /// </summary>
        public int EventID {
            get { return _EventID; }
            set { _EventID = value; }
        }
    }
}