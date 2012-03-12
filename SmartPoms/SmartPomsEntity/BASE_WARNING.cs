// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_WARNING.cs
// 功能描述:预警信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-12
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 预警信息表 -- 实体定义
    /// </summary>
    public class BASE_WARNING {
        /// <summary>
        /// WARNINGID
        /// </summary>		
        private int _WARNINGID;
        /// <summary>
        /// TITLE
        /// </summary>		
        private string _TITLE;
        /// <summary>
        /// DETAIL
        /// </summary>		
        private string _DETAIL;
        /// <summary>
        /// GENERATEDATE
        /// </summary>		
        private DateTime _GENERATEDATE;
        /// <summary>
        /// ARTICLE
        /// </summary>		
        private int _ARTICLE;
        /// <summary>
        /// ENABLE
        /// </summary>		
        private int _ENABLE;
        /// <summary>
        /// SNAPSHOT
        /// </summary>		
        private string _SNAPSHOT;
        /// <summary>
        /// ISREAD
        /// </summary>		
        private int _ISREAD;
        /// <summary>
        /// SORT
        /// </summary>		
        private int _SORT;

        /// <summary>
        /// WARNINGID
        /// </summary>
        public int WARNINGID {
            get { return _WARNINGID; }
            set { _WARNINGID = value; }
        }
        /// <summary>
        /// TITLE
        /// </summary>
        public string TITLE {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        /// <summary>
        /// DETAIL
        /// </summary>
        public string DETAIL {
            get { return _DETAIL; }
            set { _DETAIL = value; }
        }
        /// <summary>
        /// GENERATEDATE
        /// </summary>
        public DateTime GENERATEDATE {
            get { return _GENERATEDATE; }
            set { _GENERATEDATE = value; }
        }
        /// <summary>
        /// ARTICLE
        /// </summary>
        public int ARTICLE {
            get { return _ARTICLE; }
            set { _ARTICLE = value; }
        }
        /// <summary>
        /// ENABLE
        /// </summary>
        public int ENABLE {
            get { return _ENABLE; }
            set { _ENABLE = value; }
        }
        /// <summary>
        /// SNAPSHOT
        /// </summary>
        public string SNAPSHOT {
            get { return _SNAPSHOT; }
            set { _SNAPSHOT = value; }
        }
        /// <summary>
        /// ISREAD
        /// </summary>
        public int ISREAD {
            get { return _ISREAD; }
            set { _ISREAD = value; }
        }
        /// <summary>
        /// SORT
        /// </summary>
        public int SORT {
            get { return _SORT; }
            set { _SORT = value; }
        }
    }
}