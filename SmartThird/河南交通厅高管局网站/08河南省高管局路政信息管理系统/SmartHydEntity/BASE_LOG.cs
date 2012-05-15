// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_LOG.cs
// 功能描述:系统日志表 -- 实体定义
//
// 创建标识： 付晓 2012-05-15
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 系统日志表 -- 实体定义
    /// </summary>
    public class BASE_LOG
    {
		/// <summary>
        /// 日志编号
        /// </summary>		
        private decimal _LOGID;
		/// <summary>
        /// 日志类型
        /// </summary>		
        private string _LOGTYPE;
		/// <summary>
        /// 日志创建时间
        /// </summary>		
        private DateTime _CREATEDATE;
		/// <summary>
        /// 操作人
        /// </summary>		
        private decimal _OPERATORID;
		/// <summary>
        /// 日志信息描述
        /// </summary>		
        private string _DESCRIPTION;
		/// <summary>
        /// Ip地址
        /// </summary>		
        private string _IPADDRESS;
	
	        /// <summary>
        /// 日志编号
        /// </summary>
        public decimal LOGID
        {
            get { return _LOGID; }
            set { _LOGID = value; }
        }
	        /// <summary>
        /// 日志类型
        /// </summary>
        public string LOGTYPE
        {
            get { return _LOGTYPE; }
            set { _LOGTYPE = value; }
        }
	        /// <summary>
        /// 日志创建时间
        /// </summary>
        public DateTime CREATEDATE
        {
            get { return _CREATEDATE; }
            set { _CREATEDATE = value; }
        }
	        /// <summary>
        /// 操作人
        /// </summary>
        public decimal OPERATORID
        {
            get { return _OPERATORID; }
            set { _OPERATORID = value; }
        }
	        /// <summary>
        /// 日志信息描述
        /// </summary>
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
	        /// <summary>
        /// Ip地址
        /// </summary>
        public string IPADDRESS
        {
            get { return _IPADDRESS; }
            set { _IPADDRESS = value; }
        }
	}
}