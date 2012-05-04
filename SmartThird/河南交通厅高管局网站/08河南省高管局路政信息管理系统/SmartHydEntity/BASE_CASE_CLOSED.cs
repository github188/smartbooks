// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE_CLOSED.cs
// 功能描述:路产案件（议案结案表） -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 路产案件（议案结案表） -- 实体定义
    /// </summary>
    public class BASE_CASE_CLOSED {
        /// <summary>
        /// ID
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 议案时间
        /// </summary>		
        private DateTime _MOTIONTIME;
        /// <summary>
        /// 议案地点
        /// </summary>		
        private DateTime _MOTIONLOCATION;
        /// <summary>
        /// 主持人
        /// </summary>		
        private string _MOTIONPRO;
        /// <summary>
        /// 议案记录人
        /// </summary>		
        private string _RECORD;
        /// <summary>
        /// 讨论意见
        /// </summary>		
        private string _DISCUSS;
        /// <summary>
        /// 主管领导意见
        /// </summary>		
        private string _LEAD;
        /// <summary>
        /// 结案日期
        /// </summary>		
        private DateTime _CLOSEDTIME;
        /// <summary>
        /// 追回损失
        /// </summary>		
        private decimal _RECOVERLOSS;
        /// <summary>
        /// 结案方式
        /// </summary>		
        private string _CLOSEDEAY;
        /// <summary>
        /// 处理结果
        /// </summary>		
        private string _RESULT;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _REMARK;
        /// <summary>
        /// 案件编号
        /// </summary>		
        private decimal _CASEID;

        /// <summary>
        /// ID
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 议案时间
        /// </summary>
        public DateTime MOTIONTIME {
            get { return _MOTIONTIME; }
            set { _MOTIONTIME = value; }
        }
        /// <summary>
        /// 议案地点
        /// </summary>
        public DateTime MOTIONLOCATION {
            get { return _MOTIONLOCATION; }
            set { _MOTIONLOCATION = value; }
        }
        /// <summary>
        /// 主持人
        /// </summary>
        public string MOTIONPRO {
            get { return _MOTIONPRO; }
            set { _MOTIONPRO = value; }
        }
        /// <summary>
        /// 议案记录人
        /// </summary>
        public string RECORD {
            get { return _RECORD; }
            set { _RECORD = value; }
        }
        /// <summary>
        /// 讨论意见
        /// </summary>
        public string DISCUSS {
            get { return _DISCUSS; }
            set { _DISCUSS = value; }
        }
        /// <summary>
        /// 主管领导意见
        /// </summary>
        public string LEAD {
            get { return _LEAD; }
            set { _LEAD = value; }
        }
        /// <summary>
        /// 结案日期
        /// </summary>
        public DateTime CLOSEDTIME {
            get { return _CLOSEDTIME; }
            set { _CLOSEDTIME = value; }
        }
        /// <summary>
        /// 追回损失
        /// </summary>
        public decimal RECOVERLOSS {
            get { return _RECOVERLOSS; }
            set { _RECOVERLOSS = value; }
        }
        /// <summary>
        /// 结案方式
        /// </summary>
        public string CLOSEDEAY {
            get { return _CLOSEDEAY; }
            set { _CLOSEDEAY = value; }
        }
        /// <summary>
        /// 处理结果
        /// </summary>
        public string RESULT {
            get { return _RESULT; }
            set { _RESULT = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        /// <summary>
        /// 案件编号
        /// </summary>
        public decimal CASEID {
            get { return _CASEID; }
            set { _CASEID = value; }
        }
    }
}