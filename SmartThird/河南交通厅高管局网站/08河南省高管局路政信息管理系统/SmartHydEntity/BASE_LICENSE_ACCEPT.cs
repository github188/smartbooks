// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_LICENSE_ACCEPT.cs
// 功能描述:路政许可申请表 -- 实体定义
//
// 创建标识： 付晓 2012-05-04
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 路政许可申请表 -- 实体定义
    /// </summary>
    public class BASE_LICENSE_ACCEPT
    {
		/// <summary>
        /// 申请书编号
        /// </summary>		
        private decimal _REQUISITIONID;
		/// <summary>
        /// 申请人及法定代表人名称
        /// </summary>		
        private string _REQUISITIONNAME;
		/// <summary>
        /// 申请人住址
        /// </summary>		
        private string _ADDRESS;
		/// <summary>
        /// 电话
        /// </summary>		
        private string _TEL;
		/// <summary>
        /// 手机
        /// </summary>		
        private string _PHONE;
		/// <summary>
        /// 邮箱
        /// </summary>		
        private string _EMAIL;
		/// <summary>
        /// 邮编
        /// </summary>		
        private string _POST;
		/// <summary>
        /// 申请许可事项及内容
        /// </summary>		
        private string _REQUISITIONCONTENT;
		/// <summary>
        /// 委托代理人
        /// </summary>		
        private string _DEPUTY;
		/// <summary>
        /// 申请材料目录
        /// </summary>		
        private string _MATERIALS;
		/// <summary>
        /// 备注
        /// </summary>		
        private string _MARK;
		/// <summary>
        /// 申请日期
        /// </summary>		
        private DateTime _CREATDATE;
		/// <summary>
        /// 审核人
        /// </summary>		
        private string _AUDITOR;
		/// <summary>
        /// 审核状态
        /// </summary>		
        private decimal _AUDIT_STATE;
		/// <summary>
        /// 附件路径
        /// </summary>		
        private string _FILE_PATH;
		/// <summary>
        /// 审核意见
        /// </summary>		
        private string _AUDIT_DESC;
		/// <summary>
        /// 意见回复
        /// </summary>		
        private string _AUDIT_REPLY;
	
	        /// <summary>
        /// 申请书编号
        /// </summary>
        public decimal REQUISITIONID
        {
            get { return _REQUISITIONID; }
            set { _REQUISITIONID = value; }
        }
	        /// <summary>
        /// 申请人及法定代表人名称
        /// </summary>
        public string REQUISITIONNAME
        {
            get { return _REQUISITIONNAME; }
            set { _REQUISITIONNAME = value; }
        }
	        /// <summary>
        /// 申请人住址
        /// </summary>
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
	        /// <summary>
        /// 电话
        /// </summary>
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
	        /// <summary>
        /// 手机
        /// </summary>
        public string PHONE
        {
            get { return _PHONE; }
            set { _PHONE = value; }
        }
	        /// <summary>
        /// 邮箱
        /// </summary>
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
	        /// <summary>
        /// 邮编
        /// </summary>
        public string POST
        {
            get { return _POST; }
            set { _POST = value; }
        }
	        /// <summary>
        /// 申请许可事项及内容
        /// </summary>
        public string REQUISITIONCONTENT
        {
            get { return _REQUISITIONCONTENT; }
            set { _REQUISITIONCONTENT = value; }
        }
	        /// <summary>
        /// 委托代理人
        /// </summary>
        public string DEPUTY
        {
            get { return _DEPUTY; }
            set { _DEPUTY = value; }
        }
	        /// <summary>
        /// 申请材料目录
        /// </summary>
        public string MATERIALS
        {
            get { return _MATERIALS; }
            set { _MATERIALS = value; }
        }
	        /// <summary>
        /// 备注
        /// </summary>
        public string MARK
        {
            get { return _MARK; }
            set { _MARK = value; }
        }
	        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime CREATDATE
        {
            get { return _CREATDATE; }
            set { _CREATDATE = value; }
        }
	        /// <summary>
        /// 审核人
        /// </summary>
        public string AUDITOR
        {
            get { return _AUDITOR; }
            set { _AUDITOR = value; }
        }
	        /// <summary>
        /// 审核状态
        /// </summary>
        public decimal AUDIT_STATE
        {
            get { return _AUDIT_STATE; }
            set { _AUDIT_STATE = value; }
        }
	        /// <summary>
        /// 附件路径
        /// </summary>
        public string FILE_PATH
        {
            get { return _FILE_PATH; }
            set { _FILE_PATH = value; }
        }
	        /// <summary>
        /// 审核意见
        /// </summary>
        public string AUDIT_DESC
        {
            get { return _AUDIT_DESC; }
            set { _AUDIT_DESC = value; }
        }
	        /// <summary>
        /// 意见回复
        /// </summary>
        public string AUDIT_REPLY
        {
            get { return _AUDIT_REPLY; }
            set { _AUDIT_REPLY = value; }
        }
	}
}