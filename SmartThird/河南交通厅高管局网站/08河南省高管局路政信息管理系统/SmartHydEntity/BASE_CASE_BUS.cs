// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_CASE_BUS.cs
// 功能描述:路产案件（车辆人员信息） -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 路产案件（车辆人员信息） -- 实体定义
    /// </summary>
    public class BASE_CASE_BUS {
        /// <summary>
        /// ID编号
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 当事人
        /// </summary>		
        private string _PARTY;
        /// <summary>
        /// 性别（0：男 1：女）
        /// </summary>		
        private decimal _SEX;
        /// <summary>
        /// 年龄
        /// </summary>		
        private decimal _AGE;
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _PHONE;
        /// <summary>
        /// 驾龄
        /// </summary>		
        private decimal _DRIVING;
        /// <summary>
        /// 证件号码
        /// </summary>		
        private string _CARDID;
        /// <summary>
        /// 车辆类型
        /// </summary>		
        private string _BUSTYPE;
        /// <summary>
        /// 车牌号码
        /// </summary>		
        private string _BUSNUMBER;
        /// <summary>
        /// 厂牌
        /// </summary>		
        private string _LABEL;
        /// <summary>
        /// 型号
        /// </summary>		
        private string _PATTERN;
        /// <summary>
        /// 工作单位或地址
        /// </summary>		
        private string _ADDRESS;
        /// <summary>
        /// 邮编
        /// </summary>		
        private string _ZIPCODE;
        /// <summary>
        /// 车籍地
        /// </summary>		
        private string _ATTRIB;
        /// <summary>
        /// 案件编号
        /// </summary>		
        private decimal _CASEID;

        /// <summary>
        /// ID编号
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 当事人
        /// </summary>
        public string PARTY {
            get { return _PARTY; }
            set { _PARTY = value; }
        }
        /// <summary>
        /// 性别（0：男 1：女）
        /// </summary>
        public decimal SEX {
            get { return _SEX; }
            set { _SEX = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public decimal AGE {
            get { return _AGE; }
            set { _AGE = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PHONE {
            get { return _PHONE; }
            set { _PHONE = value; }
        }
        /// <summary>
        /// 驾龄
        /// </summary>
        public decimal DRIVING {
            get { return _DRIVING; }
            set { _DRIVING = value; }
        }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CARDID {
            get { return _CARDID; }
            set { _CARDID = value; }
        }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string BUSTYPE {
            get { return _BUSTYPE; }
            set { _BUSTYPE = value; }
        }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string BUSNUMBER {
            get { return _BUSNUMBER; }
            set { _BUSNUMBER = value; }
        }
        /// <summary>
        /// 厂牌
        /// </summary>
        public string LABEL {
            get { return _LABEL; }
            set { _LABEL = value; }
        }
        /// <summary>
        /// 型号
        /// </summary>
        public string PATTERN {
            get { return _PATTERN; }
            set { _PATTERN = value; }
        }
        /// <summary>
        /// 工作单位或地址
        /// </summary>
        public string ADDRESS {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZIPCODE {
            get { return _ZIPCODE; }
            set { _ZIPCODE = value; }
        }
        /// <summary>
        /// 车籍地
        /// </summary>
        public string ATTRIB {
            get { return _ATTRIB; }
            set { _ATTRIB = value; }
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