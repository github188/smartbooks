// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_WORD.cs
// 功能描述:关键字信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-12
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 关键字信息表 -- 实体定义
    /// </summary>
    public class BASE_WORD {
        /// <summary>
        /// WORDID
        /// </summary>		
        private int _WORDID;
        /// <summary>
        /// WORDNAME
        /// </summary>		
        private string _WORDNAME;
        /// <summary>
        /// SCORE
        /// </summary>		
        private decimal _SCORE;
        /// <summary>
        /// WORDIDPARENT
        /// </summary>		
        private int _WORDIDPARENT;
        /// <summary>
        /// ENABLE
        /// </summary>		
        private int _ENABLE;
        /// <summary>
        /// TOPICID
        /// </summary>		
        private string _TOPICID;

        /// <summary>
        /// WORDID
        /// </summary>
        public int WORDID {
            get { return _WORDID; }
            set { _WORDID = value; }
        }
        /// <summary>
        /// WORDNAME
        /// </summary>
        public string WORDNAME {
            get { return _WORDNAME; }
            set { _WORDNAME = value; }
        }
        /// <summary>
        /// SCORE
        /// </summary>
        public decimal SCORE {
            get { return _SCORE; }
            set { _SCORE = value; }
        }
        /// <summary>
        /// WORDIDPARENT
        /// </summary>
        public int WORDIDPARENT {
            get { return _WORDIDPARENT; }
            set { _WORDIDPARENT = value; }
        }
        /// <summary>
        /// ENABLE
        /// </summary>
        public int ENABLE {
            get { return _ENABLE; }
            set { _ENABLE = value; }
        }
        /// <summary>
        /// TOPICID
        /// </summary>
        public string TOPICID {
            get { return _TOPICID; }
            set { _TOPICID = value; }
        }
    }
}