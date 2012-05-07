// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MESSAGE.cs
// 功能描述:消息记录信息表 -- 实体定义
//
// 创建标识： 付晓 2012-05-04
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 消息记录信息表 -- 实体定义
    /// </summary>
    public class BASE_MESSAGE
    {
		/// <summary>
        /// 消息编号
        /// </summary>		
        private decimal _MESSAGEID;
		/// <summary>
        /// 发送者编号
        /// </summary>		
        private decimal _SENDER;
		/// <summary>
        /// 接收者编号
        /// </summary>		
        private decimal _TOUSER;
		/// <summary>
        /// 消息内容
        /// </summary>		
        private string _MESSAGEBODY;
		/// <summary>
        /// 发送时间
        /// </summary>		
        private DateTime _SENDDATE;
		/// <summary>
        /// 消息状态（0未读，1已读）
        /// </summary>		
        private decimal _STATE;
	
	        /// <summary>
        /// 消息编号
        /// </summary>
        public decimal MESSAGEID
        {
            get { return _MESSAGEID; }
            set { _MESSAGEID = value; }
        }
	        /// <summary>
        /// 发送者编号
        /// </summary>
        public decimal SENDER
        {
            get { return _SENDER; }
            set { _SENDER = value; }
        }
	        /// <summary>
        /// 接收者编号
        /// </summary>
        public decimal TOUSER
        {
            get { return _TOUSER; }
            set { _TOUSER = value; }
        }
	        /// <summary>
        /// 消息内容
        /// </summary>
        public string MESSAGEBODY
        {
            get { return _MESSAGEBODY; }
            set { _MESSAGEBODY = value; }
        }
	        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SENDDATE
        {
            get { return _SENDDATE; }
            set { _SENDDATE = value; }
        }
	        /// <summary>
        /// 消息状态（0未读，1已读）
        /// </summary>
        public decimal STATE
        {
            get { return _STATE; }
            set { _STATE = value; }
        }
	}
}