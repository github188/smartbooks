// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE_LOSS.cs
// 功能描述:路产案件损失表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 路产案件损失表 -- 实体定义
    /// </summary>
    public class BASE_CASE_LOSS {
        /// <summary>
        /// id,primary
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 赔偿项目标准
        /// </summary>		
        private decimal _COMPSID;
        /// <summary>
        /// 路产案件编号
        /// </summary>		
        private decimal _CASEID;
        /// <summary>
        /// 损失单位量
        /// </summary>		
        private decimal _AMOUNT;

        /// <summary>
        /// id,primary
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 赔偿项目标准
        /// </summary>
        public decimal COMPSID {
            get { return _COMPSID; }
            set { _COMPSID = value; }
        }
        /// <summary>
        /// 路产案件编号
        /// </summary>
        public decimal CASEID {
            get { return _CASEID; }
            set { _CASEID = value; }
        }
        /// <summary>
        /// 损失单位量
        /// </summary>
        public decimal AMOUNT {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }
    }
}