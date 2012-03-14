// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AUTHORITYDIR.cs
// 功能描述:Base_AuthorityDir -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_AuthorityDir -- 实体定义
    /// </summary>
    public class BASE_AUTHORITYDIR {
        /// <summary>
        /// 权限ID
        /// </summary>		
        private int _AuthorityID;
        /// <summary>
        /// 权限名称
        /// </summary>		
        private string _AuthorityName;
        /// <summary>
        /// 权限标识
        /// </summary>		
        private string _AuthorityTag;
        /// <summary>
        /// 说明
        /// </summary>		
        private string _AuthorityDescription;
        /// <summary>
        /// 排序
        /// </summary>		
        private int _AuthorityOrder;

        /// <summary>
        /// 权限ID
        /// </summary>
        public int AuthorityID {
            get { return _AuthorityID; }
            set { _AuthorityID = value; }
        }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string AuthorityName {
            get { return _AuthorityName; }
            set { _AuthorityName = value; }
        }
        /// <summary>
        /// 权限标识
        /// </summary>
        public string AuthorityTag {
            get { return _AuthorityTag; }
            set { _AuthorityTag = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string AuthorityDescription {
            get { return _AuthorityDescription; }
            set { _AuthorityDescription = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int AuthorityOrder {
            get { return _AuthorityOrder; }
            set { _AuthorityOrder = value; }
        }
    }
}