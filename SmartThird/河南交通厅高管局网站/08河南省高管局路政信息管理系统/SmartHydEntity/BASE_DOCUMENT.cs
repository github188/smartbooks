// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_DOCUMENT.cs
// 功能描述:档案信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-06-18
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 档案信息表 -- 实体定义
    /// </summary>
    public class BASE_DOCUMENT {
        /// <summary>
        /// 主键，自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 年度
        /// </summary>		
        private decimal _YEAR;
        /// <summary>
        /// 全宗号
        /// </summary>		
        private string _FONDSNO;
        /// <summary>
        /// 目录号
        /// </summary>		
        private string _CATALOGNUMBER;
        /// <summary>
        /// 案卷号
        /// </summary>		
        private string _CASEFILENUMBER;
        /// <summary>
        /// 保管期限(单位/年)
        /// </summary>		
        private decimal _RETENTION;
        /// <summary>
        /// 卷内标题
        /// </summary>		
        private string _TIELE;
        /// <summary>
        /// 起始时间
        /// </summary>		
        private DateTime _BEGINTIME;
        /// <summary>
        /// 截止时间
        /// </summary>		
        private DateTime _ENDTIME;
        /// <summary>
        /// 卷内册数
        /// </summary>		
        private decimal _NUMBEROFCOPIES;
        /// <summary>
        /// 单位
        /// </summary>		
        private string _UNIT;
        /// <summary>
        /// 附件(BASE_ANNEX表)编号多个附件之间用英文逗号隔开。如(52,45,65,78)
        /// </summary>		
        private string _ANNEX;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTCODE;
        /// <summary>
        /// 所属分类
        /// </summary>		
        private decimal _TYPECODE;

        /// <summary>
        /// 主键，自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 年度
        /// </summary>
        public decimal YEAR {
            get { return _YEAR; }
            set { _YEAR = value; }
        }
        /// <summary>
        /// 全宗号
        /// </summary>
        public string FONDSNO {
            get { return _FONDSNO; }
            set { _FONDSNO = value; }
        }
        /// <summary>
        /// 目录号
        /// </summary>
        public string CATALOGNUMBER {
            get { return _CATALOGNUMBER; }
            set { _CATALOGNUMBER = value; }
        }
        /// <summary>
        /// 案卷号
        /// </summary>
        public string CASEFILENUMBER {
            get { return _CASEFILENUMBER; }
            set { _CASEFILENUMBER = value; }
        }
        /// <summary>
        /// 保管期限(单位/年)
        /// </summary>
        public decimal RETENTION {
            get { return _RETENTION; }
            set { _RETENTION = value; }
        }
        /// <summary>
        /// 卷内标题
        /// </summary>
        public string TIELE {
            get { return _TIELE; }
            set { _TIELE = value; }
        }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime BEGINTIME {
            get { return _BEGINTIME; }
            set { _BEGINTIME = value; }
        }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime ENDTIME {
            get { return _ENDTIME; }
            set { _ENDTIME = value; }
        }
        /// <summary>
        /// 卷内册数
        /// </summary>
        public decimal NUMBEROFCOPIES {
            get { return _NUMBEROFCOPIES; }
            set { _NUMBEROFCOPIES = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        /// <summary>
        /// 附件(BASE_ANNEX表)编号多个附件之间用英文逗号隔开。如(52,45,65,78)
        /// </summary>
        public string ANNEX {
            get { return _ANNEX; }
            set { _ANNEX = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DEPTCODE {
            get { return _DEPTCODE; }
            set { _DEPTCODE = value; }
        }
        /// <summary>
        /// 所属分类
        /// </summary>
        public decimal TYPECODE {
            get { return _TYPECODE; }
            set { _TYPECODE = value; }
        }
    }
}