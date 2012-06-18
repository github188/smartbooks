// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ASSESS.cs
// 功能描述:考评项目记录表 -- 实体定义
//
// 创建标识： 王 亚 2012-06-18
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 考评项目记录表 -- 实体定义
    /// </summary>
    public class BASE_ASSESS {
        /// <summary>
        /// 主键，自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTCODE;
        /// <summary>
        /// 分值：正数或负数
        /// </summary>		
        private decimal _SCORE;
        /// <summary>
        /// 加减分原因
        /// </summary>		
        private string _REASON;
        /// <summary>
        /// 考评项目
        /// </summary>		
        private decimal _TYPEID;
        /// <summary>
        /// 时间戳
        /// </summary>		
        private DateTime _TICKTIME;
        /// <summary>
        /// 状态:0正常，1删除
        /// </summary>		
        private decimal _STATUS;

        /// <summary>
        /// 主键，自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DEPTCODE {
            get { return _DEPTCODE; }
            set { _DEPTCODE = value; }
        }
        /// <summary>
        /// 分值：正数或负数
        /// </summary>
        public decimal SCORE {
            get { return _SCORE; }
            set { _SCORE = value; }
        }
        /// <summary>
        /// 加减分原因
        /// </summary>
        public string REASON {
            get { return _REASON; }
            set { _REASON = value; }
        }
        /// <summary>
        /// 考评项目
        /// </summary>
        public decimal TYPEID {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime TICKTIME {
            get { return _TICKTIME; }
            set { _TICKTIME = value; }
        }
        /// <summary>
        /// 状态:0正常，1删除
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
    }
}