// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_TERM.cs
// 功能描述:装备信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 装备信息表 -- 实体定义
    /// </summary>
    public class BASE_TERM {
        /// <summary>
        /// 编号
        /// </summary>		
        private decimal _TERMID;
        /// <summary>
        /// 所属部门
        /// </summary>		
        private decimal _DEPTID;
        /// <summary>
        /// 设备编号
        /// </summary>		
        private string _TERMCODE;
        /// <summary>
        /// 设备名称
        /// </summary>		
        private string _TERMNAME;
        /// <summary>
        /// 出厂编号
        /// </summary>		
        private string _SERIALCODE;
        /// <summary>
        /// 规格型号
        /// </summary>		
        private string _FORMAT;
        /// <summary>
        /// 制造厂商
        /// </summary>		
        private string _BRAND;
        /// <summary>
        /// 装备用途
        /// </summary>		
        private string _USE;
        /// <summary>
        /// 投入使用时间
        /// </summary>		
        private DateTime _USETIME;
        /// <summary>
        /// 存放地点
        /// </summary>		
        private string _SAVEPOINT;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _REMARK;
        /// <summary>
        /// 状态（0：正常，1：删除）
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 装备类型
        /// </summary>		
        private decimal _TYPEID;

        /// <summary>
        /// 编号
        /// </summary>
        public decimal TERMID {
            get { return _TERMID; }
            set { _TERMID = value; }
        }
        /// <summary>
        /// 所属部门
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string TERMCODE {
            get { return _TERMCODE; }
            set { _TERMCODE = value; }
        }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string TERMNAME {
            get { return _TERMNAME; }
            set { _TERMNAME = value; }
        }
        /// <summary>
        /// 出厂编号
        /// </summary>
        public string SERIALCODE {
            get { return _SERIALCODE; }
            set { _SERIALCODE = value; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string FORMAT {
            get { return _FORMAT; }
            set { _FORMAT = value; }
        }
        /// <summary>
        /// 制造厂商
        /// </summary>
        public string BRAND {
            get { return _BRAND; }
            set { _BRAND = value; }
        }
        /// <summary>
        /// 装备用途
        /// </summary>
        public string USE {
            get { return _USE; }
            set { _USE = value; }
        }
        /// <summary>
        /// 投入使用时间
        /// </summary>
        public DateTime USETIME {
            get { return _USETIME; }
            set { _USETIME = value; }
        }
        /// <summary>
        /// 存放地点
        /// </summary>
        public string SAVEPOINT {
            get { return _SAVEPOINT; }
            set { _SAVEPOINT = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        /// <summary>
        /// 状态（0：正常，1：删除）
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 装备类型
        /// </summary>
        public decimal TYPEID {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
    }
}