// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE.cs
// 功能描述:公文信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-18
namespace Maticsoft.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 公文信息表 -- 实体定义
    /// </summary>
    public class BASE_ARTICLE {
        /// <summary>
        /// 主键,自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 用户编号
        /// </summary>		
        private decimal _USERID;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTID;
        /// <summary>
        /// 0父发文编号，1回复发文编号
        /// </summary>		
        private decimal _PARENTID;
        /// <summary>
        /// 公文标题
        /// </summary>		
        private string _TITLE;
        /// <summary>
        /// 公文内容
        /// </summary>		
        private string _CONTENT;
        /// <summary>
        /// 时间戳
        /// </summary>		
        private DateTime _TIMESTAMP;
        /// <summary>
        /// 分值
        /// </summary>		
        private decimal _SCORE;
        /// <summary>
        /// 附件(服务器相对路径)
        /// </summary>		
        private string _ANNEX;
        /// <summary>
        /// 状态：0已审核，1未审核，2草稿，3已删除，4隐藏，5结贴
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 允许回复：0允许回复,1不允许回复
        /// </summary>		
        private decimal _ISREPLY;
        /// <summary>
        /// 公文所属分类编号
        /// </summary>		
        private decimal _TYPEID;
        /// <summary>
        /// 发文字号,回文指发文字号
        /// </summary>		
        private string _SENDCODE;

        /// <summary>
        /// 主键,自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public decimal USERID {
            get { return _USERID; }
            set { _USERID = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        /// <summary>
        /// 0父发文编号，1回复发文编号
        /// </summary>
        public decimal PARENTID {
            get { return _PARENTID; }
            set { _PARENTID = value; }
        }
        /// <summary>
        /// 公文标题
        /// </summary>
        public string TITLE {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        /// <summary>
        /// 公文内容
        /// </summary>
        public string CONTENT {
            get { return _CONTENT; }
            set { _CONTENT = value; }
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime TIMESTAMP {
            get { return _TIMESTAMP; }
            set { _TIMESTAMP = value; }
        }
        /// <summary>
        /// 分值
        /// </summary>
        public decimal SCORE {
            get { return _SCORE; }
            set { _SCORE = value; }
        }
        /// <summary>
        /// 附件(服务器相对路径)
        /// </summary>
        public string ANNEX {
            get { return _ANNEX; }
            set { _ANNEX = value; }
        }
        /// <summary>
        /// 状态：0已审核，1未审核，2草稿，3已删除，4隐藏，5结贴
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 允许回复：0允许回复,1不允许回复
        /// </summary>
        public decimal ISREPLY {
            get { return _ISREPLY; }
            set { _ISREPLY = value; }
        }
        /// <summary>
        /// 公文所属分类编号
        /// </summary>
        public decimal TYPEID {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        /// <summary>
        /// 发文字号,回文指发文字号
        /// </summary>
        public string SENDCODE {
            get { return _SENDCODE; }
            set { _SENDCODE = value; }
        }
    }
}