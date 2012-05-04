// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_BUS_OVERRUN_SUBMIT.cs
// 功能描述:查处非法超限车辆数据 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 查处非法超限车辆数据 -- 实体定义
    /// </summary>
    public class BASE_BUS_OVERRUN_SUBMIT {
        /// <summary>
        /// id，主键，自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 车牌号码
        /// </summary>		
        private string _BUSCODE;
        /// <summary>
        /// 车货总长
        /// </summary>		
        private decimal _BUSLONG;
        /// <summary>
        /// 宽度
        /// </summary>		
        private decimal _BUSWIDTH;
        /// <summary>
        /// 高度
        /// </summary>		
        private decimal _BUSHEIGHT;
        /// <summary>
        /// 总重量
        /// </summary>		
        private decimal _WEIGHT;
        /// <summary>
        /// 车货照片
        /// </summary>		
        private string _PHOTO;
        /// <summary>
        /// 入口站名称
        /// </summary>		
        private string _INNAME;
        /// <summary>
        /// 出口站名称
        /// </summary>		
        private string _OUTNAME;
        /// <summary>
        /// 查处时间
        /// </summary>		
        private DateTime _TICKTIME;
        /// <summary>
        /// 查处人
        /// </summary>		
        private decimal _USERID;
        /// <summary>
        /// 查处单位
        /// </summary>		
        private decimal _DEPTID;
        /// <summary>
        /// 查处地点
        /// </summary>		
        private string _LOCATION;
        /// <summary>
        /// 车辆所属单位
        /// </summary>		
        private string _BUSUNIT;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _REMARKS;

        /// <summary>
        /// id，主键，自增
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
        /// 车货总长
        /// </summary>
        public decimal BUSLONG {
            get { return _BUSLONG; }
            set { _BUSLONG = value; }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public decimal BUSWIDTH {
            get { return _BUSWIDTH; }
            set { _BUSWIDTH = value; }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public decimal BUSHEIGHT {
            get { return _BUSHEIGHT; }
            set { _BUSHEIGHT = value; }
        }
        /// <summary>
        /// 总重量
        /// </summary>
        public decimal WEIGHT {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        /// <summary>
        /// 车货照片
        /// </summary>
        public string PHOTO {
            get { return _PHOTO; }
            set { _PHOTO = value; }
        }
        /// <summary>
        /// 入口站名称
        /// </summary>
        public string INNAME {
            get { return _INNAME; }
            set { _INNAME = value; }
        }
        /// <summary>
        /// 出口站名称
        /// </summary>
        public string OUTNAME {
            get { return _OUTNAME; }
            set { _OUTNAME = value; }
        }
        /// <summary>
        /// 查处时间
        /// </summary>
        public DateTime TICKTIME {
            get { return _TICKTIME; }
            set { _TICKTIME = value; }
        }
        /// <summary>
        /// 查处人
        /// </summary>
        public decimal USERID {
            get { return _USERID; }
            set { _USERID = value; }
        }
        /// <summary>
        /// 查处单位
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        /// <summary>
        /// 查处地点
        /// </summary>
        public string LOCATION {
            get { return _LOCATION; }
            set { _LOCATION = value; }
        }
        /// <summary>
        /// 车辆所属单位
        /// </summary>
        public string BUSUNIT {
            get { return _BUSUNIT; }
            set { _BUSUNIT = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARKS {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
    }
}