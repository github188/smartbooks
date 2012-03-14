// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_WORD.cs
// 功能描述:关键字信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 关键字信息表 -- 实体定义
    /// </summary>
    public class BASE_WORD {
        /// <summary>
        /// WordID
        /// </summary>		
        private int _WordID;
        /// <summary>
        /// WordName
        /// </summary>		
        private string _WordName;
        /// <summary>
        /// Score
        /// </summary>		
        private decimal _Score;
        /// <summary>
        /// WordIDParent
        /// </summary>		
        private int _WordIDParent;
        /// <summary>
        /// Enable
        /// </summary>		
        private int _Enable;

        /// <summary>
        /// WordID
        /// </summary>
        public int WordID {
            get { return _WordID; }
            set { _WordID = value; }
        }
        /// <summary>
        /// WordName
        /// </summary>
        public string WordName {
            get { return _WordName; }
            set { _WordName = value; }
        }
        /// <summary>
        /// Score
        /// </summary>
        public decimal Score {
            get { return _Score; }
            set { _Score = value; }
        }
        /// <summary>
        /// WordIDParent
        /// </summary>
        public int WordIDParent {
            get { return _WordIDParent; }
            set { _WordIDParent = value; }
        }
        /// <summary>
        /// Enable
        /// </summary>
        public int Enable {
            get { return _Enable; }
            set { _Enable = value; }
        }
    }
}