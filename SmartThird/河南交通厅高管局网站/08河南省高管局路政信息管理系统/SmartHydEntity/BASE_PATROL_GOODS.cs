// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PATROL_GOODS.cs
// 功能描述:移交器材表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 移交器材表 -- 实体定义
    /// </summary>
    public class BASE_PATROL_GOODS {
        /// <summary>
        /// 编号
        /// </summary>		
        private decimal _PATROLGOODSID;
        /// <summary>
        /// 巡逻日志编号
        /// </summary>		
        private decimal _PATROLID;
        /// <summary>
        /// 器材数量
        /// </summary>		
        private decimal _AMOUNT;
        /// <summary>
        /// 器材名称
        /// </summary>		
        private string _TOOLNAME;

        /// <summary>
        /// 编号
        /// </summary>
        public decimal PATROLGOODSID {
            get { return _PATROLGOODSID; }
            set { _PATROLGOODSID = value; }
        }
        /// <summary>
        /// 巡逻日志编号
        /// </summary>
        public decimal PATROLID {
            get { return _PATROLID; }
            set { _PATROLID = value; }
        }
        /// <summary>
        /// 器材数量
        /// </summary>
        public decimal AMOUNT {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }
        /// <summary>
        /// 器材名称
        /// </summary>
        public string TOOLNAME {
            get { return _TOOLNAME; }
            set { _TOOLNAME = value; }
        }
    }
}