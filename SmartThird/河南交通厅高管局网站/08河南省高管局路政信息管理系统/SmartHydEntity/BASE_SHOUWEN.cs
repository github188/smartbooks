// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_SHOUWEN.cs
// 功能描述:收文信息表 -- 实体定义
//
// 创建标识： 付晓 2012-05-04
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 收文信息表 -- 实体定义
    /// </summary>
    public class BASE_SHOUWEN
    {
		/// <summary>
        /// 收文信息 编号
        /// </summary>		
        private decimal _SID;
		/// <summary>
        /// 原号
        /// </summary>		
        private string _S_NUMBERS;
		/// <summary>
        /// 来文机关
        /// </summary>		
        private string _S_ORGAN;
		/// <summary>
        /// 来文时间
        /// </summary>		
        private DateTime _S_FROMDATE;
		/// <summary>
        /// 标题
        /// </summary>		
        private string _S_TITLE;
		/// <summary>
        /// 承办时间
        /// </summary>		
        private DateTime _S_HANDLINGTIME;
		/// <summary>
        /// 涉及相关运营管理单位
        /// </summary>		
        private string _S_DEP_ORGAN;
		/// <summary>
        /// 办理进度
        /// </summary>		
        private string _S_HANDLEPROGRESS;
		/// <summary>
        /// 办理结果
        /// </summary>		
        private string _S_RESULT;
		/// <summary>
        /// 申请人
        /// </summary>		
        private string _S_APPLICANT;
		/// <summary>
        /// 相关单位承办人
        /// </summary>		
        private string _S_HANDLER;
		/// <summary>
        /// 备注
        /// </summary>		
        private string _REMARKS;
		/// <summary>
        /// 来文内容
        /// </summary>		
        private string _S_CONTENT;
	
	        /// <summary>
        /// 收文信息 编号
        /// </summary>
        public decimal SID
        {
            get { return _SID; }
            set { _SID = value; }
        }
	        /// <summary>
        /// 原号
        /// </summary>
        public string S_NUMBERS
        {
            get { return _S_NUMBERS; }
            set { _S_NUMBERS = value; }
        }
	        /// <summary>
        /// 来文机关
        /// </summary>
        public string S_ORGAN
        {
            get { return _S_ORGAN; }
            set { _S_ORGAN = value; }
        }
	        /// <summary>
        /// 来文时间
        /// </summary>
        public DateTime S_FROMDATE
        {
            get { return _S_FROMDATE; }
            set { _S_FROMDATE = value; }
        }
	        /// <summary>
        /// 标题
        /// </summary>
        public string S_TITLE
        {
            get { return _S_TITLE; }
            set { _S_TITLE = value; }
        }
	        /// <summary>
        /// 承办时间
        /// </summary>
        public DateTime S_HANDLINGTIME
        {
            get { return _S_HANDLINGTIME; }
            set { _S_HANDLINGTIME = value; }
        }
	        /// <summary>
        /// 涉及相关运营管理单位
        /// </summary>
        public string S_DEP_ORGAN
        {
            get { return _S_DEP_ORGAN; }
            set { _S_DEP_ORGAN = value; }
        }
	        /// <summary>
        /// 办理进度
        /// </summary>
        public string S_HANDLEPROGRESS
        {
            get { return _S_HANDLEPROGRESS; }
            set { _S_HANDLEPROGRESS = value; }
        }
	        /// <summary>
        /// 办理结果
        /// </summary>
        public string S_RESULT
        {
            get { return _S_RESULT; }
            set { _S_RESULT = value; }
        }
	        /// <summary>
        /// 申请人
        /// </summary>
        public string S_APPLICANT
        {
            get { return _S_APPLICANT; }
            set { _S_APPLICANT = value; }
        }
	        /// <summary>
        /// 相关单位承办人
        /// </summary>
        public string S_HANDLER
        {
            get { return _S_HANDLER; }
            set { _S_HANDLER = value; }
        }
	        /// <summary>
        /// 备注
        /// </summary>
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
	        /// <summary>
        /// 来文内容
        /// </summary>
        public string S_CONTENT
        {
            get { return _S_CONTENT; }
            set { _S_CONTENT = value; }
        }
	}
}