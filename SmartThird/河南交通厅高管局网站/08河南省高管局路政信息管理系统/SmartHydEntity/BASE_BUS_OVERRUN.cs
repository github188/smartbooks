// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_BUS_OVERRUN.cs
// 功能描述:高速公路超限车辆数据表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 高速公路超限车辆数据表 -- 实体定义
    /// </summary>
    public class BASE_BUS_OVERRUN {
        /// <summary>
        /// ID编号
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 车牌号码
        /// </summary>		
        private string _BUSCODE;
        /// <summary>
        /// 入口站名
        /// </summary>		
        private string _INNAME;
        /// <summary>
        /// 入口时间
        /// </summary>		
        private DateTime _INTIME;
        /// <summary>
        /// 出口站名
        /// </summary>		
        private string _OUTNAME;
        /// <summary>
        /// 出口时间
        /// </summary>		
        private DateTime _OUTTIME;
        /// <summary>
        /// 支付形式
        /// </summary>		
        private string _PAY;
        /// <summary>
        /// 轴数
        /// </summary>		
        private decimal _AXIS;
        /// <summary>
        /// 超载率
        /// </summary>		
        private decimal _OVERLOADRATE;
        /// <summary>
        /// 总重
        /// </summary>		
        private decimal _TOTALWEIGHT;
        /// <summary>
        /// 金额
        /// </summary>		
        private decimal _MONEY;
        /// <summary>
        /// 里程
        /// </summary>		
        private decimal _MILEAGE;

        /// <summary>
        /// ID编号
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string BUSCODE {
            get { return _BUSCODE; }
            set { _BUSCODE = value; }
        }
        /// <summary>
        /// 入口站名
        /// </summary>
        public string INNAME {
            get { return _INNAME; }
            set { _INNAME = value; }
        }
        /// <summary>
        /// 入口时间
        /// </summary>
        public DateTime INTIME {
            get { return _INTIME; }
            set { _INTIME = value; }
        }
        /// <summary>
        /// 出口站名
        /// </summary>
        public string OUTNAME {
            get { return _OUTNAME; }
            set { _OUTNAME = value; }
        }
        /// <summary>
        /// 出口时间
        /// </summary>
        public DateTime OUTTIME {
            get { return _OUTTIME; }
            set { _OUTTIME = value; }
        }
        /// <summary>
        /// 支付形式
        /// </summary>
        public string PAY {
            get { return _PAY; }
            set { _PAY = value; }
        }
        /// <summary>
        /// 轴数
        /// </summary>
        public decimal AXIS {
            get { return _AXIS; }
            set { _AXIS = value; }
        }
        /// <summary>
        /// 超载率
        /// </summary>
        public decimal OVERLOADRATE {
            get { return _OVERLOADRATE; }
            set { _OVERLOADRATE = value; }
        }
        /// <summary>
        /// 总重
        /// </summary>
        public decimal TOTALWEIGHT {
            get { return _TOTALWEIGHT; }
            set { _TOTALWEIGHT = value; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal MONEY {
            get { return _MONEY; }
            set { _MONEY = value; }
        }
        /// <summary>
        /// 里程
        /// </summary>
        public decimal MILEAGE {
            get { return _MILEAGE; }
            set { _MILEAGE = value; }
        }
    }
}