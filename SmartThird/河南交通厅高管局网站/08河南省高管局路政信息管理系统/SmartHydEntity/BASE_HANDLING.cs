// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_HANDLING.cs
// 功能描述:巡查处理情况表 -- 实体定义
//
// 创建标识： 付晓 2012-06-14
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 巡查处理情况表 -- 实体定义
    /// </summary>
    public class BASE_HANDLING
    {
		/// <summary>
        /// 巡逻处理情况编号
        /// </summary>		
        private decimal _HID;
		/// <summary>
        /// 巡逻类型
        /// </summary>		
        private string _PATROLTYPE;
		/// <summary>
        /// 巡逻开始时间
        /// </summary>		
        private DateTime _BEGINTIME;
		/// <summary>
        /// 巡逻结束时间
        /// </summary>		
        private DateTime _ENDTIME;
		/// <summary>
        /// 巡逻次数
        /// </summary>		
        private decimal _TIMES;
		/// <summary>
        /// 处理情况内容
        /// </summary>		
        private string _CONTENT;
		/// <summary>
        /// 备注
        /// </summary>		
        private string _REMARK;
		/// <summary>
        /// 巡逻日志编号
        /// </summary>		
        private decimal _PID;
	
	        /// <summary>
        /// 巡逻处理情况编号
        /// </summary>
        public decimal HID
        {
            get { return _HID; }
            set { _HID = value; }
        }
	        /// <summary>
        /// 巡逻类型
        /// </summary>
        public string PATROLTYPE
        {
            get { return _PATROLTYPE; }
            set { _PATROLTYPE = value; }
        }
	        /// <summary>
        /// 巡逻开始时间
        /// </summary>
        public DateTime BEGINTIME
        {
            get { return _BEGINTIME; }
            set { _BEGINTIME = value; }
        }
	        /// <summary>
        /// 巡逻结束时间
        /// </summary>
        public DateTime ENDTIME
        {
            get { return _ENDTIME; }
            set { _ENDTIME = value; }
        }
	        /// <summary>
        /// 巡逻次数
        /// </summary>
        public decimal TIMES
        {
            get { return _TIMES; }
            set { _TIMES = value; }
        }
	        /// <summary>
        /// 处理情况内容
        /// </summary>
        public string CONTENT
        {
            get { return _CONTENT; }
            set { _CONTENT = value; }
        }
	        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
	        /// <summary>
        /// 巡逻日志编号
        /// </summary>
        public decimal PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
	}
}