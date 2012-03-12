﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_TOPIC.cs
// 功能描述:专题信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-12
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 专题信息表 -- 实体定义
    /// </summary>
    public class BASE_TOPIC {
        /// <summary>
        /// TOPICID
        /// </summary>		
        private int _TOPICID;
        /// <summary>
        /// TOPICNAME
        /// </summary>		
        private string _TOPICNAME;
        /// <summary>
        /// SUMMARY
        /// </summary>		
        private string _SUMMARY;
        /// <summary>
        /// SCORE
        /// </summary>		
        private int _SCORE;
        /// <summary>
        /// TOPICIDPARENT
        /// </summary>		
        private int _TOPICIDPARENT;
        /// <summary>
        /// ENABLE
        /// </summary>		
        private int _ENABLE;
        /// <summary>
        /// SORT
        /// </summary>		
        private int _SORT;

        /// <summary>
        /// TOPICID
        /// </summary>
        public int TOPICID {
            get { return _TOPICID; }
            set { _TOPICID = value; }
        }
        /// <summary>
        /// TOPICNAME
        /// </summary>
        public string TOPICNAME {
            get { return _TOPICNAME; }
            set { _TOPICNAME = value; }
        }
        /// <summary>
        /// SUMMARY
        /// </summary>
        public string SUMMARY {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
        /// <summary>
        /// SCORE
        /// </summary>
        public int SCORE {
            get { return _SCORE; }
            set { _SCORE = value; }
        }
        /// <summary>
        /// TOPICIDPARENT
        /// </summary>
        public int TOPICIDPARENT {
            get { return _TOPICIDPARENT; }
            set { _TOPICIDPARENT = value; }
        }
        /// <summary>
        /// ENABLE
        /// </summary>
        public int ENABLE {
            get { return _ENABLE; }
            set { _ENABLE = value; }
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