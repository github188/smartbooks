// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE_UNIT.cs
// 功能描述:公文发送单位表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-22
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 公文发送单位表 -- 实体定义
    /// </summary>
    public class BASE_ARTICLE_UNIT {
        /// <summary>
        /// 主键,自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 公文编号
        /// </summary>		
        private decimal _ARTICLEID;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DPTCODE;
        /// <summary>
        /// 查阅状态：0未查阅，1已查阅
        /// </summary>		
        private decimal _ISREAD;
        /// <summary>
        /// 查阅时间
        /// </summary>		
        private DateTime _READTIME;

        /// <summary>
        /// 主键,自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 公文编号
        /// </summary>
        public decimal ARTICLEID {
            get { return _ARTICLEID; }
            set { _ARTICLEID = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DPTCODE {
            get { return _DPTCODE; }
            set { _DPTCODE = value; }
        }
        /// <summary>
        /// 查阅状态：0未查阅，1已查阅
        /// </summary>
        public decimal ISREAD {
            get { return _ISREAD; }
            set { _ISREAD = value; }
        }
        /// <summary>
        /// 查阅时间
        /// </summary>
        public DateTime READTIME {
            get { return _READTIME; }
            set { _READTIME = value; }
        }
    }
}