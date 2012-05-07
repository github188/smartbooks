// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_FAWEN.cs
// 功能描述:发文信息表 -- 实体定义
//
// 创建标识： 付晓 2012-05-07
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 发文信息表 -- 实体定义
    /// </summary>
    public class BASE_FAWEN
    {
		/// <summary>
        /// 编号
        /// </summary>		
        private decimal _FID;
		/// <summary>
        /// 公文号
        /// </summary>		
        private string _F_NUMBER;
		/// <summary>
        /// 公文标题
        /// </summary>		
        private string _F_TITLE;
		/// <summary>
        /// 公文类型
        /// </summary>		
        private string _F_TYPE;
		/// <summary>
        /// 公文内容
        /// </summary>		
        private string _F_CONTENT;
		/// <summary>
        /// 公文附件路径
        /// </summary>		
        private string _F_ANNEX;
		/// <summary>
        /// 发文日期
        /// </summary>		
        private DateTime _F_DATE;
		/// <summary>
        /// 备注
        /// </summary>		
        private string _REMARK;
		/// <summary>
        /// 发文单位
        /// </summary>		
        private string _F_ORGAN;
		/// <summary>
        /// 密级
        /// </summary>		
        private string _F_LEVEL;
		/// <summary>
        /// 缓急程度
        /// </summary>		
        private string _F_DEGREE;
		/// <summary>
        /// 删除状态
        /// </summary>		
        private decimal _F_DELSTATE;
	
	        /// <summary>
        /// 编号
        /// </summary>
        public decimal FID
        {
            get { return _FID; }
            set { _FID = value; }
        }
	        /// <summary>
        /// 公文号
        /// </summary>
        public string F_NUMBER
        {
            get { return _F_NUMBER; }
            set { _F_NUMBER = value; }
        }
	        /// <summary>
        /// 公文标题
        /// </summary>
        public string F_TITLE
        {
            get { return _F_TITLE; }
            set { _F_TITLE = value; }
        }
	        /// <summary>
        /// 公文类型
        /// </summary>
        public string F_TYPE
        {
            get { return _F_TYPE; }
            set { _F_TYPE = value; }
        }
	        /// <summary>
        /// 公文内容
        /// </summary>
        public string F_CONTENT
        {
            get { return _F_CONTENT; }
            set { _F_CONTENT = value; }
        }
	        /// <summary>
        /// 公文附件路径
        /// </summary>
        public string F_ANNEX
        {
            get { return _F_ANNEX; }
            set { _F_ANNEX = value; }
        }
	        /// <summary>
        /// 发文日期
        /// </summary>
        public DateTime F_DATE
        {
            get { return _F_DATE; }
            set { _F_DATE = value; }
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
        /// 发文单位
        /// </summary>
        public string F_ORGAN
        {
            get { return _F_ORGAN; }
            set { _F_ORGAN = value; }
        }
	        /// <summary>
        /// 密级
        /// </summary>
        public string F_LEVEL
        {
            get { return _F_LEVEL; }
            set { _F_LEVEL = value; }
        }
	        /// <summary>
        /// 缓急程度
        /// </summary>
        public string F_DEGREE
        {
            get { return _F_DEGREE; }
            set { _F_DEGREE = value; }
        }
	        /// <summary>
        /// 删除状态
        /// </summary>
        public decimal F_DELSTATE
        {
            get { return _F_DELSTATE; }
            set { _F_DELSTATE = value; }
        }
	}
}