// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AFFICHE.cs
// 功能描述:公告信息表 -- 实体定义
//
// 创建标识： 付晓 2012-05-10
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 公告信息表 -- 实体定义
    /// </summary>
    public class BASE_AFFICHE
    {
		/// <summary>
        /// 公告编号
        /// </summary>		
        private decimal _AFFICHEID;
		/// <summary>
        /// 公告标题
        /// </summary>		
        private string _AFFICHETITLE;
		/// <summary>
        /// 公告内容
        /// </summary>		
        private string _AFFICHECONTENTS;
		/// <summary>
        /// 公告发布人
        /// </summary>		
        private string _AFFICHER;
		/// <summary>
        /// 公告发布时间
        /// </summary>		
        private DateTime _AFFICHEDATE;
		/// <summary>
        /// 公告状态
        /// </summary>		
        private decimal _STATES;
	
	        /// <summary>
        /// 公告编号
        /// </summary>
        public decimal AFFICHEID
        {
            get { return _AFFICHEID; }
            set { _AFFICHEID = value; }
        }
	        /// <summary>
        /// 公告标题
        /// </summary>
        public string AFFICHETITLE
        {
            get { return _AFFICHETITLE; }
            set { _AFFICHETITLE = value; }
        }
	        /// <summary>
        /// 公告内容
        /// </summary>
        public string AFFICHECONTENTS
        {
            get { return _AFFICHECONTENTS; }
            set { _AFFICHECONTENTS = value; }
        }
	        /// <summary>
        /// 公告发布人
        /// </summary>
        public string AFFICHER
        {
            get { return _AFFICHER; }
            set { _AFFICHER = value; }
        }
	        /// <summary>
        /// 公告发布时间
        /// </summary>
        public DateTime AFFICHEDATE
        {
            get { return _AFFICHEDATE; }
            set { _AFFICHEDATE = value; }
        }
	        /// <summary>
        /// 公告状态
        /// </summary>
        public decimal STATES
        {
            get { return _STATES; }
            set { _STATES = value; }
        }
	}
}