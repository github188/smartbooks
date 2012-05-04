// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE.cs
// 功能描述:路产案件表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 路产案件表 -- 实体定义
    /// </summary>
    public class BASE_CASE {
        /// <summary>
        /// 编号
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 案件编号
        /// </summary>		
        private string _CASECODE;
        /// <summary>
        /// 案件登记人
        /// </summary>		
        private decimal _USERID;
        /// <summary>
        /// 发生时间
        /// </summary>		
        private DateTime _TICKTIME;
        /// <summary>
        /// 天气情况
        /// </summary>		
        private string _WEATHER;
        /// <summary>
        /// 线路名称
        /// </summary>		
        private string _LINENAME;
        /// <summary>
        /// 桩号（K）
        /// </summary>		
        private decimal _STAKEK;
        /// <summary>
        /// 桩号（M）
        /// </summary>		
        private decimal _STAKEM;
        /// <summary>
        /// 路段类型
        /// </summary>		
        private string _LINETYPE;
        /// <summary>
        /// 事故类型
        /// </summary>		
        private string _ACCIDENTTYPE;
        /// <summary>
        /// 事故发生原因
        /// </summary>		
        private string _ACCIDENTCAUSE;
        /// <summary>
        /// 案由
        /// </summary>		
        private string _ACTION;
        /// <summary>
        /// 立案人
        /// </summary>		
        private string _LAUNCH;
        /// <summary>
        /// 办案主持人
        /// </summary>		
        private string _PRESENTERS;
        /// <summary>
        /// 办案主持人执法证编号
        /// </summary>		
        private string _PRESENTERSID;
        /// <summary>
        /// 办案主持人职务
        /// </summary>		
        private string _PRESENTERSDUTY;
        /// <summary>
        /// 勘验检查人
        /// </summary>		
        private string _INQUEST;
        /// <summary>
        /// 勘验检查人执法证编号
        /// </summary>		
        private string _INQUESTID;
        /// <summary>
        /// 勘验检查人职务
        /// </summary>		
        private string _INQUESTDUTY;
        /// <summary>
        /// 勘验检查时间起
        /// </summary>		
        private DateTime _INQUESTBEGINTIME;
        /// <summary>
        /// 勘验检查时间止
        /// </summary>		
        private DateTime _INQUESTENDTIME;
        /// <summary>
        /// 被邀请人
        /// </summary>		
        private string _INVITE;
        /// <summary>
        /// 被邀请人电话
        /// </summary>		
        private string _INVITETEL;
        /// <summary>
        /// 被邀请人职务
        /// </summary>		
        private string _INVITEDUTY;
        /// <summary>
        /// 车货损失
        /// </summary>		
        private decimal _BUSLOSS;
        /// <summary>
        /// 死亡人数
        /// </summary>		
        private decimal _DEATH;
        /// <summary>
        /// 重伤人数
        /// </summary>		
        private decimal _WEIGHT;
        /// <summary>
        /// 轻伤人数
        /// </summary>		
        private decimal _LIGHT;
        /// <summary>
        /// 案情摘要
        /// </summary>		
        private string _SUMMARY;
        /// <summary>
        /// 立案日期
        /// </summary>		
        private DateTime _CREATETIME;

        /// <summary>
        /// 编号
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 案件编号
        /// </summary>
        public string CASECODE {
            get { return _CASECODE; }
            set { _CASECODE = value; }
        }
        /// <summary>
        /// 案件登记人
        /// </summary>
        public decimal USERID {
            get { return _USERID; }
            set { _USERID = value; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime TICKTIME {
            get { return _TICKTIME; }
            set { _TICKTIME = value; }
        }
        /// <summary>
        /// 天气情况
        /// </summary>
        public string WEATHER {
            get { return _WEATHER; }
            set { _WEATHER = value; }
        }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string LINENAME {
            get { return _LINENAME; }
            set { _LINENAME = value; }
        }
        /// <summary>
        /// 桩号（K）
        /// </summary>
        public decimal STAKEK {
            get { return _STAKEK; }
            set { _STAKEK = value; }
        }
        /// <summary>
        /// 桩号（M）
        /// </summary>
        public decimal STAKEM {
            get { return _STAKEM; }
            set { _STAKEM = value; }
        }
        /// <summary>
        /// 路段类型
        /// </summary>
        public string LINETYPE {
            get { return _LINETYPE; }
            set { _LINETYPE = value; }
        }
        /// <summary>
        /// 事故类型
        /// </summary>
        public string ACCIDENTTYPE {
            get { return _ACCIDENTTYPE; }
            set { _ACCIDENTTYPE = value; }
        }
        /// <summary>
        /// 事故发生原因
        /// </summary>
        public string ACCIDENTCAUSE {
            get { return _ACCIDENTCAUSE; }
            set { _ACCIDENTCAUSE = value; }
        }
        /// <summary>
        /// 案由
        /// </summary>
        public string ACTION {
            get { return _ACTION; }
            set { _ACTION = value; }
        }
        /// <summary>
        /// 立案人
        /// </summary>
        public string LAUNCH {
            get { return _LAUNCH; }
            set { _LAUNCH = value; }
        }
        /// <summary>
        /// 办案主持人
        /// </summary>
        public string PRESENTERS {
            get { return _PRESENTERS; }
            set { _PRESENTERS = value; }
        }
        /// <summary>
        /// 办案主持人执法证编号
        /// </summary>
        public string PRESENTERSID {
            get { return _PRESENTERSID; }
            set { _PRESENTERSID = value; }
        }
        /// <summary>
        /// 办案主持人职务
        /// </summary>
        public string PRESENTERSDUTY {
            get { return _PRESENTERSDUTY; }
            set { _PRESENTERSDUTY = value; }
        }
        /// <summary>
        /// 勘验检查人
        /// </summary>
        public string INQUEST {
            get { return _INQUEST; }
            set { _INQUEST = value; }
        }
        /// <summary>
        /// 勘验检查人执法证编号
        /// </summary>
        public string INQUESTID {
            get { return _INQUESTID; }
            set { _INQUESTID = value; }
        }
        /// <summary>
        /// 勘验检查人职务
        /// </summary>
        public string INQUESTDUTY {
            get { return _INQUESTDUTY; }
            set { _INQUESTDUTY = value; }
        }
        /// <summary>
        /// 勘验检查时间起
        /// </summary>
        public DateTime INQUESTBEGINTIME {
            get { return _INQUESTBEGINTIME; }
            set { _INQUESTBEGINTIME = value; }
        }
        /// <summary>
        /// 勘验检查时间止
        /// </summary>
        public DateTime INQUESTENDTIME {
            get { return _INQUESTENDTIME; }
            set { _INQUESTENDTIME = value; }
        }
        /// <summary>
        /// 被邀请人
        /// </summary>
        public string INVITE {
            get { return _INVITE; }
            set { _INVITE = value; }
        }
        /// <summary>
        /// 被邀请人电话
        /// </summary>
        public string INVITETEL {
            get { return _INVITETEL; }
            set { _INVITETEL = value; }
        }
        /// <summary>
        /// 被邀请人职务
        /// </summary>
        public string INVITEDUTY {
            get { return _INVITEDUTY; }
            set { _INVITEDUTY = value; }
        }
        /// <summary>
        /// 车货损失
        /// </summary>
        public decimal BUSLOSS {
            get { return _BUSLOSS; }
            set { _BUSLOSS = value; }
        }
        /// <summary>
        /// 死亡人数
        /// </summary>
        public decimal DEATH {
            get { return _DEATH; }
            set { _DEATH = value; }
        }
        /// <summary>
        /// 重伤人数
        /// </summary>
        public decimal WEIGHT {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        /// <summary>
        /// 轻伤人数
        /// </summary>
        public decimal LIGHT {
            get { return _LIGHT; }
            set { _LIGHT = value; }
        }
        /// <summary>
        /// 案情摘要
        /// </summary>
        public string SUMMARY {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
        /// <summary>
        /// 立案日期
        /// </summary>
        public DateTime CREATETIME {
            get { return _CREATETIME; }
            set { _CREATETIME = value; }
        }
    }
}