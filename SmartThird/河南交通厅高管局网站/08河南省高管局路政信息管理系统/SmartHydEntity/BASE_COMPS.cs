// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_COMPS.cs
// 功能描述:赔偿标准信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 赔偿标准信息表 -- 实体定义
    /// </summary>
    public class BASE_COMPS {
        /// <summary>
        /// ID
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 项目名称
        /// </summary>		
        private string _COMPSNAME;
        /// <summary>
        /// 单位
        /// </summary>		
        private string _UNIT;
        /// <summary>
        /// 金额（人民币）
        /// </summary>		
        private decimal _MONEY;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _REMARK;

        /// <summary>
        /// ID
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string COMPSNAME {
            get { return _COMPSNAME; }
            set { _COMPSNAME = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        /// <summary>
        /// 金额（人民币）
        /// </summary>
        public decimal MONEY {
            get { return _MONEY; }
            set { _MONEY = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
    }
}