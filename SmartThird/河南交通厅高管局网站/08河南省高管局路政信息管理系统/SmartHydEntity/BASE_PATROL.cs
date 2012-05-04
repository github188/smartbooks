// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PATROL.cs
// 功能描述:人工巡逻日志表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 人工巡逻日志表 -- 实体定义
    /// </summary>
    public class BASE_PATROL {
        /// <summary>
        /// 巡逻日志ID
        /// </summary>		
        private decimal _PATROLID;
        /// <summary>
        /// 巡查中队
        /// </summary>		
        private decimal _DEPTID;
        /// <summary>
        /// 巡查负责人
        /// </summary>		
        private decimal _RESPUSER;
        /// <summary>
        /// 巡查人员
        /// </summary>		
        private decimal _PATROLUSER;
        /// <summary>
        /// 巡查车牌号
        /// </summary>		
        private string _BUSNUMBER;
        /// <summary>
        /// 巡查里程
        /// </summary>		
        private decimal _MILEAGE;
        /// <summary>
        /// 天气
        /// </summary>		
        private string _WEATHER;
        /// <summary>
        /// 巡查处理情况
        /// </summary>		
        private string _LOG;
        /// <summary>
        /// 巡查开始时间
        /// </summary>		
        private DateTime _BEGINTIME;
        /// <summary>
        /// 巡查结束时间
        /// </summary>		
        private DateTime _ENDTIME;
        /// <summary>
        /// 移交人
        /// </summary>		
        private decimal _TRANSFER;
        /// <summary>
        /// 接收人
        /// </summary>		
        private decimal _ACCEPT;
        /// <summary>
        /// 移交内业处理事项
        /// </summary>		
        private string _WITHIN;
        /// <summary>
        /// 移交下班处理事项
        /// </summary>		
        private string _NEXTWITHIN;
        /// <summary>
        /// 接班中队长
        /// </summary>		
        private decimal _ACCEPTCAPTAIN;
        /// <summary>
        /// 交班中队长
        /// </summary>		
        private decimal _SHIFTCAPTAIN;
        /// <summary>
        /// 接班巡逻车牌号
        /// </summary>		
        private string _ACCEPTBUSNUMBER;
        /// <summary>
        /// 交接班时间
        /// </summary>		
        private DateTime _TICKTIME;
        /// <summary>
        /// 接班巡逻车里程表（KM）
        /// </summary>		
        private decimal _BUSKM;

        /// <summary>
        /// 巡逻日志ID
        /// </summary>
        public decimal PATROLID {
            get { return _PATROLID; }
            set { _PATROLID = value; }
        }
        /// <summary>
        /// 巡查中队
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        /// <summary>
        /// 巡查负责人
        /// </summary>
        public decimal RESPUSER {
            get { return _RESPUSER; }
            set { _RESPUSER = value; }
        }
        /// <summary>
        /// 巡查人员
        /// </summary>
        public decimal PATROLUSER {
            get { return _PATROLUSER; }
            set { _PATROLUSER = value; }
        }
        /// <summary>
        /// 巡查车牌号
        /// </summary>
        public string BUSNUMBER {
            get { return _BUSNUMBER; }
            set { _BUSNUMBER = value; }
        }
        /// <summary>
        /// 巡查里程
        /// </summary>
        public decimal MILEAGE {
            get { return _MILEAGE; }
            set { _MILEAGE = value; }
        }
        /// <summary>
        /// 天气
        /// </summary>
        public string WEATHER {
            get { return _WEATHER; }
            set { _WEATHER = value; }
        }
        /// <summary>
        /// 巡查处理情况
        /// </summary>
        public string LOG {
            get { return _LOG; }
            set { _LOG = value; }
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
        public DateTime ENDTIME {
            get { return _ENDTIME; }
            set { _ENDTIME = value; }
        }
        /// <summary>
        /// 移交人
        /// </summary>
        public decimal TRANSFER {
            get { return _TRANSFER; }
            set { _TRANSFER = value; }
        }
        /// <summary>
        /// 接收人
        /// </summary>
        public decimal ACCEPT {
            get { return _ACCEPT; }
            set { _ACCEPT = value; }
        }
        /// <summary>
        /// 移交内业处理事项
        /// </summary>
        public string WITHIN {
            get { return _WITHIN; }
            set { _WITHIN = value; }
        }
        /// <summary>
        /// 移交下班处理事项
        /// </summary>
        public string NEXTWITHIN {
            get { return _NEXTWITHIN; }
            set { _NEXTWITHIN = value; }
        }
        /// <summary>
        /// 接班中队长
        /// </summary>
        public decimal ACCEPTCAPTAIN {
            get { return _ACCEPTCAPTAIN; }
            set { _ACCEPTCAPTAIN = value; }
        }
        /// <summary>
        /// 交班中队长
        /// </summary>
        public decimal SHIFTCAPTAIN {
            get { return _SHIFTCAPTAIN; }
            set { _SHIFTCAPTAIN = value; }
        }
        /// <summary>
        /// 接班巡逻车牌号
        /// </summary>
        public string ACCEPTBUSNUMBER {
            get { return _ACCEPTBUSNUMBER; }
            set { _ACCEPTBUSNUMBER = value; }
        }
        /// <summary>
        /// 交接班时间
        /// </summary>
        public DateTime TICKTIME {
            get { return _TICKTIME; }
            set { _TICKTIME = value; }
        }
        /// <summary>
        /// 接班巡逻车里程表（KM）
        /// </summary>
        public decimal BUSKM {
            get { return _BUSKM; }
            set { _BUSKM = value; }
        }
    }
}