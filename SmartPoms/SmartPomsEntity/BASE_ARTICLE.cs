// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE.cs
// 功能描述:文章信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 文章信息表 -- 实体定义
    /// </summary>
    public class BASE_ARTICLE {
        /// <summary>
        /// ArticleID
        /// </summary>		
        private int _ArticleID;
        /// <summary>
        /// Title
        /// </summary>		
        private string _Title;
        /// <summary>
        /// Detail
        /// </summary>		
        private string _Detail;
        /// <summary>
        /// SendTime
        /// </summary>		
        private DateTime _SendTime;
        /// <summary>
        /// Media
        /// </summary>		
        private string _Media;
        /// <summary>
        /// Author
        /// </summary>		
        private string _Author;
        /// <summary>
        /// ClickNum
        /// </summary>		
        private int _ClickNum;
        /// <summary>
        /// CommentNum
        /// </summary>		
        private int _CommentNum;
        /// <summary>
        /// Url
        /// </summary>		
        private string _Url;
        /// <summary>
        /// ExtractionTime
        /// </summary>		
        private DateTime _ExtractionTime;
        /// <summary>
        /// Score
        /// </summary>		
        private decimal _Score;

        /// <summary>
        /// ArticleID
        /// </summary>
        public int ArticleID {
            get { return _ArticleID; }
            set { _ArticleID = value; }
        }
        /// <summary>
        /// Title
        /// </summary>
        public string Title {
            get { return _Title; }
            set { _Title = value; }
        }
        /// <summary>
        /// Detail
        /// </summary>
        public string Detail {
            get { return _Detail; }
            set { _Detail = value; }
        }
        /// <summary>
        /// SendTime
        /// </summary>
        public DateTime SendTime {
            get { return _SendTime; }
            set { _SendTime = value; }
        }
        /// <summary>
        /// Media
        /// </summary>
        public string Media {
            get { return _Media; }
            set { _Media = value; }
        }
        /// <summary>
        /// Author
        /// </summary>
        public string Author {
            get { return _Author; }
            set { _Author = value; }
        }
        /// <summary>
        /// ClickNum
        /// </summary>
        public int ClickNum {
            get { return _ClickNum; }
            set { _ClickNum = value; }
        }
        /// <summary>
        /// CommentNum
        /// </summary>
        public int CommentNum {
            get { return _CommentNum; }
            set { _CommentNum = value; }
        }
        /// <summary>
        /// Url
        /// </summary>
        public string Url {
            get { return _Url; }
            set { _Url = value; }
        }
        /// <summary>
        /// ExtractionTime
        /// </summary>
        public DateTime ExtractionTime {
            get { return _ExtractionTime; }
            set { _ExtractionTime = value; }
        }
        /// <summary>
        /// Score
        /// </summary>
        public decimal Score {
            get { return _Score; }
            set { _Score = value; }
        }
    }
}