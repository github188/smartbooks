// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_FILETYPE.cs
// 功能描述:公文类型表 -- 实体定义
//
// 创建标识： 付晓 2012-05-08
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 公文类型表 -- 实体定义
    /// </summary>
    public class BASE_FILETYPE
    {
		/// <summary>
        /// 编号
        /// </summary>		
        private decimal _FTID;
		/// <summary>
        /// 公文类型名称
        /// </summary>		
        private string _FT_NAME;
		/// <summary>
        /// 公文类型说明
        /// </summary>		
        private string _FT_DESCRIBE;
		/// <summary>
        /// 所属分类
        /// </summary>		
        private string _FT_DEPT;
		/// <summary>
        /// 默认文号前缀
        /// </summary>		
        private string _FT_PREFIX;
		/// <summary>
        /// 默认文号后缀
        /// </summary>		
        private string _FT_SUFFIX;
		/// <summary>
        /// 状态(0正常；1已删除)
        /// </summary>		
        private decimal _FT_STATE;
	
	        /// <summary>
        /// 编号
        /// </summary>
        public decimal FTID
        {
            get { return _FTID; }
            set { _FTID = value; }
        }
	        /// <summary>
        /// 公文类型名称
        /// </summary>
        public string FT_NAME
        {
            get { return _FT_NAME; }
            set { _FT_NAME = value; }
        }
	        /// <summary>
        /// 公文类型说明
        /// </summary>
        public string FT_DESCRIBE
        {
            get { return _FT_DESCRIBE; }
            set { _FT_DESCRIBE = value; }
        }
	        /// <summary>
        /// 所属分类
        /// </summary>
        public string FT_DEPT
        {
            get { return _FT_DEPT; }
            set { _FT_DEPT = value; }
        }
	        /// <summary>
        /// 默认文号前缀
        /// </summary>
        public string FT_PREFIX
        {
            get { return _FT_PREFIX; }
            set { _FT_PREFIX = value; }
        }
	        /// <summary>
        /// 默认文号后缀
        /// </summary>
        public string FT_SUFFIX
        {
            get { return _FT_SUFFIX; }
            set { _FT_SUFFIX = value; }
        }
	        /// <summary>
        /// 状态(0正常；1已删除)
        /// </summary>
        public decimal FT_STATE
        {
            get { return _FT_STATE; }
            set { _FT_STATE = value; }
        }
	}
}