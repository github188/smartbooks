// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_OBSERVED.cs
// 功能描述:电子巡逻日志表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-10
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 电子巡逻日志表 -- 实体定义
    /// </summary>
    public class BASE_OBSERVED {
        /// <summary>
        /// 电子巡逻日志编号
        /// </summary>		
        private decimal _OBSERVEDID;
        /// <summary>
        /// 巡查人员
        /// </summary>		
        private string _PATROLUSER;
        /// <summary>
        /// 天气
        /// </summary>		
        private string _WEATHER;
        /// <summary>
        /// 巡查开始时间
        /// </summary>		
        private DateTime _BEGINTIME = DateTime.Now;
        /// <summary>
        /// 巡查结束时间
        /// </summary>		
        private DateTime _ENDDATE = DateTime.Now;
        /// <summary>
        /// 巡查处理情况
        /// </summary>		
        private string _LOG;
        /// <summary>
        /// 部门
        /// </summary>		
        private decimal _DEPTID;
        /// <summary>
        /// 状态
        /// </summary>
        private decimal _STATE;

        /// <summary>
        /// 电子巡逻日志编号
        /// </summary>
        public decimal OBSERVEDID {
            get { return _OBSERVEDID; }
            set { _OBSERVEDID = value; }
        }
        /// <summary>
        /// 巡查人员
        /// </summary>
        public string PATROLUSER {
            get { return _PATROLUSER; }
            set { _PATROLUSER = value; }
        }
        /// <summary>
        /// 天气
        /// </summary>
        public string WEATHER {
            get { return _WEATHER; }
            set { _WEATHER = value; }
        }
        /// <summary>
        /// 巡查开始时间
        /// </summary>
        public DateTime BEGINTIME {
            get { return _BEGINTIME; }
            set { _BEGINTIME = value; }
        }
        /// <summary>
        /// 巡查结束时间
        /// </summary>
        public DateTime ENDDATE {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        /// <summary>
        /// 巡查处理情况
        /// </summary>
        public string LOG {
            get { return _LOG; }
            set { _LOG = value; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public decimal STATE {
            get { return _STATE; }
            set { _STATE = value; }
        }
    }
}