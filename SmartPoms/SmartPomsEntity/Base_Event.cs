// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_EVENT.cs
// 功能描述:专题信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 专题信息表 -- 实体定义
    /// </summary>
    public class BASE_EVENT {
        /// <summary>
        /// EventID
        /// </summary>		
        private int _EventID;
        /// <summary>
        /// EventName
        /// </summary>		
        private string _EventName;
        /// <summary>
        /// Summary
        /// </summary>		
        private string _Summary;
        /// <summary>
        /// Score
        /// </summary>		
        private int _Score;
        /// <summary>
        /// EventIDParent
        /// </summary>		
        private int _EventIDParent;
        /// <summary>
        /// Enable
        /// </summary>		
        private int _Enable;
        /// <summary>
        /// Sort
        /// </summary>		
        private int _Sort;

        /// <summary>
        /// EventID
        /// </summary>
        public int EventID {
            get { return _EventID; }
            set { _EventID = value; }
        }
        /// <summary>
        /// EventName
        /// </summary>
        public string EventName {
            get { return _EventName; }
            set { _EventName = value; }
        }
        /// <summary>
        /// Summary
        /// </summary>
        public string Summary {
            get { return _Summary; }
            set { _Summary = value; }
        }
        /// <summary>
        /// Score
        /// </summary>
        public int Score {
            get { return _Score; }
            set { _Score = value; }
        }
        /// <summary>
        /// EventIDParent
        /// </summary>
        public int EventIDParent {
            get { return _EventIDParent; }
            set { _EventIDParent = value; }
        }
        /// <summary>
        /// Enable
        /// </summary>
        public int Enable {
            get { return _Enable; }
            set { _Enable = value; }
        }
        /// <summary>
        /// Sort
        /// </summary>
        public int Sort {
            get { return _Sort; }
            set { _Sort = value; }
        }
    }
}