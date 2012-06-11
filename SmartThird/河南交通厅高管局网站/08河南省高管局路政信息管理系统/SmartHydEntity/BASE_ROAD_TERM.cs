// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ROAD_TERM.cs
// 功能描述:路产设备信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 路产设备信息表 -- 实体定义
    /// </summary>
    public class BASE_ROAD_TERM {
        /// <summary>
        /// 路产设别编号
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 路产设备名称
        /// </summary>		
        private string _ROADNAME;
        /// <summary>
        /// 高速公路名称
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
        /// 位置描述
        /// </summary>		
        private string _SUMMARY;
        /// <summary>
        /// 竣工时间
        /// </summary>		
        private DateTime _COMPTIME = DateTime.Now;
        /// <summary>
        /// 登记时间
        /// </summary>		
        private DateTime _REGTIME = DateTime.Now;
        /// <summary>
        /// 设备照片
        /// </summary>		
        private string _PHOTO;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _REMARK;
        /// <summary>
        /// 状态（0：正常，1删除）
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 路产设备类型编号
        /// </summary>		
        private decimal _TYPEID;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTID;

        /// <summary>
        /// 路产设备编号
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 路产设备名称
        /// </summary>
        public string ROADNAME {
            get { return _ROADNAME; }
            set { _ROADNAME = value; }
        }
        /// <summary>
        /// 高速公路名称
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
        /// 位置描述
        /// </summary>
        public string SUMMARY {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
        /// <summary>
        /// 竣工时间
        /// </summary>
        public DateTime COMPTIME {
            get { return _COMPTIME; }
            set { _COMPTIME = value; }
        }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime REGTIME {
            get { return _REGTIME; }
            set { _REGTIME = value; }
        }
        /// <summary>
        /// 设备照片
        /// </summary>
        public string PHOTO {
            get { return _PHOTO; }
            set { _PHOTO = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        /// <summary>
        /// 状态（0：正常，1删除）
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 路产设备类型编号
        /// </summary>
        public decimal TYPEID {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
    }
}