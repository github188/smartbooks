// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROLE.cs
// 功能描述:角色信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-12
namespace SmartPoms.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 角色信息表 -- 实体定义
    /// </summary>
    public class BASE_ROLE
    {
		/// <summary>
        /// ROLEID
        /// </summary>		
        private int _ROLEID;
		/// <summary>
        /// ROLENAME
        /// </summary>		
        private string _ROLENAME;
		/// <summary>
        /// ROLEIDPARENT
        /// </summary>		
        private int _ROLEIDPARENT;
		/// <summary>
        /// SORT
        /// </summary>		
        private int _SORT;
		/// <summary>
        /// SUMMARY
        /// </summary>		
        private string _SUMMARY;
		/// <summary>
        /// ENABLE
        /// </summary>		
        private int _ENABLE;
	
	        /// <summary>
        /// ROLEID
        /// </summary>
        public int ROLEID
        {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }
	        /// <summary>
        /// ROLENAME
        /// </summary>
        public string ROLENAME
        {
            get { return _ROLENAME; }
            set { _ROLENAME = value; }
        }
	        /// <summary>
        /// ROLEIDPARENT
        /// </summary>
        public int ROLEIDPARENT
        {
            get { return _ROLEIDPARENT; }
            set { _ROLEIDPARENT = value; }
        }
	        /// <summary>
        /// SORT
        /// </summary>
        public int SORT
        {
            get { return _SORT; }
            set { _SORT = value; }
        }
	        /// <summary>
        /// SUMMARY
        /// </summary>
        public string SUMMARY
        {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
	        /// <summary>
        /// ENABLE
        /// </summary>
        public int ENABLE
        {
            get { return _ENABLE; }
            set { _ENABLE = value; }
        }
	}
}