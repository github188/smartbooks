// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_BUS_OVERRUN.cs
// 功能描述:高速公路超限车辆数据表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-15
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 高速公路超限车辆数据表 -- 实体定义
    /// </summary>
    public class BASE_BUS_OVERRUN {
        /// <summary>
        /// id,主键,自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 车牌号码
        /// </summary>		
        private string _VEHICLELICENSE;
        /// <summary>
        /// 入口车站
        /// </summary>		
        private decimal _ENTRYSTATION;
        /// <summary>
        /// 入口站名
        /// </summary>		
        private string _ENTRYSTATIONNAME;
        /// <summary>
        /// 入口时间
        /// </summary>		
        private DateTime _ENTRYTIME;
        /// <summary>
        /// 出口车站
        /// </summary>		
        private decimal _EXITSTATION;
        /// <summary>
        /// 出口站名
        /// </summary>		
        private string _EXITSTATIONNAME;
        /// <summary>
        /// 出口时间
        /// </summary>		
        private DateTime _EXITTIME;
        /// <summary>
        /// 支付方式
        /// </summary>		
        private string _PAYTYPE;
        /// <summary>
        /// 轴数
        /// </summary>		
        private decimal _AXISNUM;
        /// <summary>
        /// 实际超载率
        /// </summary>		
        private decimal _OVERLOADRATE;
        /// <summary>
        /// 总重量
        /// </summary>		
        private decimal _TOTALWEIGHT;
        /// <summary>
        /// 总计隧道费
        /// </summary>		
        private decimal _TOTALTOLL;
        /// <summary>
        /// 距离
        /// </summary>		
        private decimal _DISTANCE;
        /// <summary>
        /// 数据导入时间
        /// </summary>		
        private DateTime _IMPORTDATE;

        /// <summary>
        /// id,主键,自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string VEHICLELICENSE {
            get { return _VEHICLELICENSE; }
            set { _VEHICLELICENSE = value; }
        }
        /// <summary>
        /// 入口车站
        /// </summary>
        public decimal ENTRYSTATION {
            get { return _ENTRYSTATION; }
            set { _ENTRYSTATION = value; }
        }
        /// <summary>
        /// 入口站名
        /// </summary>
        public string ENTRYSTATIONNAME {
            get { return _ENTRYSTATIONNAME; }
            set { _ENTRYSTATIONNAME = value; }
        }
        /// <summary>
        /// 入口时间
        /// </summary>
        public DateTime ENTRYTIME {
            get { return _ENTRYTIME; }
            set { _ENTRYTIME = value; }
        }
        /// <summary>
        /// 出口车站
        /// </summary>
        public decimal EXITSTATION {
            get { return _EXITSTATION; }
            set { _EXITSTATION = value; }
        }
        /// <summary>
        /// 出口站名
        /// </summary>
        public string EXITSTATIONNAME {
            get { return _EXITSTATIONNAME; }
            set { _EXITSTATIONNAME = value; }
        }
        /// <summary>
        /// 出口时间
        /// </summary>
        public DateTime EXITTIME {
            get { return _EXITTIME; }
            set { _EXITTIME = value; }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PAYTYPE {
            get { return _PAYTYPE; }
            set { _PAYTYPE = value; }
        }
        /// <summary>
        /// 轴数
        /// </summary>
        public decimal AXISNUM {
            get { return _AXISNUM; }
            set { _AXISNUM = value; }
        }
        /// <summary>
        /// 实际超载率
        /// </summary>
        public decimal OVERLOADRATE {
            get { return _OVERLOADRATE; }
            set { _OVERLOADRATE = value; }
        }
        /// <summary>
        /// 总重量
        /// </summary>
        public decimal TOTALWEIGHT {
            get { return _TOTALWEIGHT; }
            set { _TOTALWEIGHT = value; }
        }
        /// <summary>
        /// 总计隧道费
        /// </summary>
        public decimal TOTALTOLL {
            get { return _TOTALTOLL; }
            set { _TOTALTOLL = value; }
        }
        /// <summary>
        /// 距离
        /// </summary>
        public decimal DISTANCE {
            get { return _DISTANCE; }
            set { _DISTANCE = value; }
        }
        /// <summary>
        /// 数据导入时间
        /// </summary>
        public DateTime IMPORTDATE {
            get { return _IMPORTDATE; }
            set { _IMPORTDATE = value; }
        }
    }
}