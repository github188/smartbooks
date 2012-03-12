// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE.cs
// 功能描述:文章信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-12
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 文章信息表 -- 实体定义
    /// </summary>
    public class BASE_ARTICLE {
        /// <summary>
        /// ARTICLEID
        /// </summary>		
        private int _ARTICLEID;
        /// <summary>
        /// TOPICID
        /// </summary>		
        private string _TOPICID;
        /// <summary>
        /// TITLE
        /// </summary>		
        private string _TITLE;
        /// <summary>
        /// PUBLISHDATE
        /// </summary>		
        private DateTime _PUBLISHDATE;
        /// <summary>
        /// SOURCE
        /// </summary>		
        private string _SOURCE;
        /// <summary>
        /// AUTHOR
        /// </summary>		
        private string _AUTHOR;
        /// <summary>
        /// CLICK
        /// </summary>		
        private int _CLICK;
        /// <summary>
        /// COMMENT
        /// </summary>		
        private int _COMMENT;
        /// <summary>
        /// DETAIL
        /// </summary>		
        private string _DETAIL;
        /// <summary>
        /// REFERER
        /// </summary>		
        private string _REFERER;
        /// <summary>
        /// EXTRACTIONDATE
        /// </summary>		
        private DateTime _EXTRACTIONDATE;
        /// <summary>
        /// SCORE
        /// </summary>		
        private decimal _SCORE;

        /// <summary>
        /// ARTICLEID
        /// </summary>
        public int ARTICLEID {
            get { return _ARTICLEID; }
            set { _ARTICLEID = value; }
        }
        /// <summary>
        /// TOPICID
        /// </summary>
        public string TOPICID {
            get { return _TOPICID; }
            set { _TOPICID = value; }
        }
        /// <summary>
        /// TITLE
        /// </summary>
        public string TITLE {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        /// <summary>
        /// PUBLISHDATE
        /// </summary>
        public DateTime PUBLISHDATE {
            get { return _PUBLISHDATE; }
            set { _PUBLISHDATE = value; }
        }
        /// <summary>
        /// SOURCE
        /// </summary>
        public string SOURCE {
            get { return _SOURCE; }
            set { _SOURCE = value; }
        }
        /// <summary>
        /// AUTHOR
        /// </summary>
        public string AUTHOR {
            get { return _AUTHOR; }
            set { _AUTHOR = value; }
        }
        /// <summary>
        /// CLICK
        /// </summary>
        public int CLICK {
            get { return _CLICK; }
            set { _CLICK = value; }
        }
        /// <summary>
        /// COMMENT
        /// </summary>
        public int COMMENT {
            get { return _COMMENT; }
            set { _COMMENT = value; }
        }
        /// <summary>
        /// DETAIL
        /// </summary>
        public string DETAIL {
            get { return _DETAIL; }
            set { _DETAIL = value; }
        }
        /// <summary>
        /// REFERER
        /// </summary>
        public string REFERER {
            get { return _REFERER; }
            set { _REFERER = value; }
        }
        /// <summary>
        /// EXTRACTIONDATE
        /// </summary>
        public DateTime EXTRACTIONDATE {
            get { return _EXTRACTIONDATE; }
            set { _EXTRACTIONDATE = value; }
        }
        /// <summary>
        /// SCORE
        /// </summary>
        public decimal SCORE {
            get { return _SCORE; }
            set { _SCORE = value; }
        }
    }
}