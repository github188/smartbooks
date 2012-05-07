﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PLAN.cs
// 功能描述:日程信息表 -- 实体定义
//
// 创建标识： 付晓 2012-05-04
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 日程信息表 -- 实体定义
    /// </summary>
    public class BASE_PLAN
    {
		/// <summary>
        /// 日程信息编号
        /// </summary>		
        private decimal _CALENDARID;
		/// <summary>
        /// 用户编号
        /// </summary>		
        private decimal _USERID;
		/// <summary>
        /// 日程内容
        /// </summary>		
        private string _CALENDARCONTENT;
		/// <summary>
        /// 开始时间
        /// </summary>		
        private DateTime _START_DATE;
		/// <summary>
        /// 结束时间
        /// </summary>		
        private DateTime _END_DATE;
		/// <summary>
        /// 提醒时间
        /// </summary>		
        private DateTime _CALENDARREMIND;
	
	        /// <summary>
        /// 日程信息编号
        /// </summary>
        public decimal CALENDARID
        {
            get { return _CALENDARID; }
            set { _CALENDARID = value; }
        }
	        /// <summary>
        /// 用户编号
        /// </summary>
        public decimal USERID
        {
            get { return _USERID; }
            set { _USERID = value; }
        }
	        /// <summary>
        /// 日程内容
        /// </summary>
        public string CALENDARCONTENT
        {
            get { return _CALENDARCONTENT; }
            set { _CALENDARCONTENT = value; }
        }
	        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime START_DATE
        {
            get { return _START_DATE; }
            set { _START_DATE = value; }
        }
	        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime END_DATE
        {
            get { return _END_DATE; }
            set { _END_DATE = value; }
        }
	        /// <summary>
        /// 提醒时间
        /// </summary>
        public DateTime CALENDARREMIND
        {
            get { return _CALENDARREMIND; }
            set { _CALENDARREMIND = value; }
        }
	}
}