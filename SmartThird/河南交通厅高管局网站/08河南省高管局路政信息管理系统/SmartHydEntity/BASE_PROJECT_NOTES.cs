// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PROJECT_NOTES.cs
// 功能描述:考核项目记录表 -- 实体定义
//
// 创建标识： 付晓 2012-05-04
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 考核项目记录表 -- 实体定义
    /// </summary>
    public class BASE_PROJECT_NOTES
    {
		/// <summary>
        /// 编号
        /// </summary>		
        private decimal _PID;
		/// <summary>
        /// 考核信息编号
        /// </summary>		
        private decimal _ASSESSID;
		/// <summary>
        /// 考核批复内容
        /// </summary>		
        private string _REPLY_CONTENT;
		/// <summary>
        /// 批复人
        /// </summary>		
        private string _REPLY_PRESON;
		/// <summary>
        /// 批复时间
        /// </summary>		
        private DateTime _REPLY_DATE;
		/// <summary>
        /// 分值
        /// </summary>		
        private decimal _SCORE;
	
	        /// <summary>
        /// 编号
        /// </summary>
        public decimal PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
	        /// <summary>
        /// 考核信息编号
        /// </summary>
        public decimal ASSESSID
        {
            get { return _ASSESSID; }
            set { _ASSESSID = value; }
        }
	        /// <summary>
        /// 考核批复内容
        /// </summary>
        public string REPLY_CONTENT
        {
            get { return _REPLY_CONTENT; }
            set { _REPLY_CONTENT = value; }
        }
	        /// <summary>
        /// 批复人
        /// </summary>
        public string REPLY_PRESON
        {
            get { return _REPLY_PRESON; }
            set { _REPLY_PRESON = value; }
        }
	        /// <summary>
        /// 批复时间
        /// </summary>
        public DateTime REPLY_DATE
        {
            get { return _REPLY_DATE; }
            set { _REPLY_DATE = value; }
        }
	        /// <summary>
        /// 分值
        /// </summary>
        public decimal SCORE
        {
            get { return _SCORE; }
            set { _SCORE = value; }
        }
	}
}