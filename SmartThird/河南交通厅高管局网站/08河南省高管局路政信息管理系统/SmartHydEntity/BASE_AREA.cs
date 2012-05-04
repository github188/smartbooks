// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_AREA.cs
// 功能描述:控制区违章信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 控制区违章信息表 -- 实体定义
    /// </summary>
    public class BASE_AREA {
        /// <summary>
        /// 编号
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 违章名称
        /// </summary>		
        private string _AREANAME;
        /// <summary>
        /// 分类编号
        /// </summary>		
        private decimal _TYPEID;
        /// <summary>
        /// 公路名称
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
        private DateTime _COMPTIME;
        /// <summary>
        /// 登记时间
        /// </summary>		
        private DateTime _REGTIME;
        /// <summary>
        /// 物主名称
        /// </summary>		
        private string _OWNER;
        /// <summary>
        /// 详细描述
        /// </summary>		
        private string _DETAILED;
        /// <summary>
        /// 现状描述
        /// </summary>		
        private string _STATUS;
        /// <summary>
        /// 详细备注
        /// </summary>		
        private string _REMARK;
        /// <summary>
        /// 现场照片
        /// </summary>		
        private string _PHOTO;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTID;

        /// <summary>
        /// 编号
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 违章名称
        /// </summary>
        public string AREANAME {
            get { return _AREANAME; }
            set { _AREANAME = value; }
        }
        /// <summary>
        /// 分类编号
        /// </summary>
        public decimal TYPEID {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        /// <summary>
        /// 公路名称
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
        /// 物主名称
        /// </summary>
        public string OWNER {
            get { return _OWNER; }
            set { _OWNER = value; }
        }
        /// <summary>
        /// 详细描述
        /// </summary>
        public string DETAILED {
            get { return _DETAILED; }
            set { _DETAILED = value; }
        }
        /// <summary>
        /// 现状描述
        /// </summary>
        public string STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 详细备注
        /// </summary>
        public string REMARK {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        /// <summary>
        /// 现场照片
        /// </summary>
        public string PHOTO {
            get { return _PHOTO; }
            set { _PHOTO = value; }
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