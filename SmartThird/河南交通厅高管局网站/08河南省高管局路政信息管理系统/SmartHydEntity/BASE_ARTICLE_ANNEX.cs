// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE_ANNEX.cs
// 功能描述:公文附件表 -- 实体定义
//
// 创建标识： 王 亚 2012-06-14
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 公文附件表 -- 实体定义
    /// </summary>
    public class BASE_ARTICLE_ANNEX {
        /// <summary>
        /// 主键,自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 源文件名称
        /// </summary>		
        private string _SOURCENAME;
        /// <summary>
        /// 文件扩展名
        /// </summary>		
        private string _EXTENSION;
        /// <summary>
        /// 服务器存储文件名
        /// </summary>		
        private string _SERVERNAME;
        /// <summary>
        /// 服务器存储路径
        /// </summary>		
        private string _SERVERPATH;
        /// <summary>
        /// 文件上传日期
        /// </summary>		
        private DateTime _UPTIME;
        /// <summary>
        /// 状态:0正常，1删除
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 上传者用户ID
        /// </summary>		
        private decimal _UPAUTHOR;

        /// <summary>
        /// 主键,自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 源文件名称
        /// </summary>
        public string SOURCENAME {
            get { return _SOURCENAME; }
            set { _SOURCENAME = value; }
        }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string EXTENSION {
            get { return _EXTENSION; }
            set { _EXTENSION = value; }
        }
        /// <summary>
        /// 服务器存储文件名
        /// </summary>
        public string SERVERNAME {
            get { return _SERVERNAME; }
            set { _SERVERNAME = value; }
        }
        /// <summary>
        /// 服务器存储路径
        /// </summary>
        public string SERVERPATH {
            get { return _SERVERPATH; }
            set { _SERVERPATH = value; }
        }
        /// <summary>
        /// 文件上传日期
        /// </summary>
        public DateTime UPTIME {
            get { return _UPTIME; }
            set { _UPTIME = value; }
        }
        /// <summary>
        /// 状态:0正常，1删除
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 上传者用户ID
        /// </summary>
        public decimal UPAUTHOR {
            get { return _UPAUTHOR; }
            set { _UPAUTHOR = value; }
        }
    }
}