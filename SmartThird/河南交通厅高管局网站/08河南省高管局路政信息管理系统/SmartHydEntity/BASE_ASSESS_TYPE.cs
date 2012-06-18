// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ASSESS_TYPE.cs
// 功能描述:考评项目表 -- 实体定义
//
// 创建标识： 王 亚 2012-06-18
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 考评项目表 -- 实体定义
    /// </summary>
    public class BASE_ASSESS_TYPE {
        /// <summary>
        /// 主键，自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTCODE;
        /// <summary>
        /// 考评项目名称
        /// </summary>		
        private string _NAME;
        /// <summary>
        /// 考评项目描述
        /// </summary>		
        private string _SUMMARY;
        /// <summary>
        /// 父级考评分类
        /// </summary>		
        private decimal _PARENTID;
        /// <summary>
        /// 排序
        /// </summary>		
        private decimal _SORT;
        /// <summary>
        /// 状态:0正常,1删除
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 初始分值，默认100
        /// </summary>		
        private decimal _SCORE;

        /// <summary>
        /// 主键，自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DEPTCODE {
            get { return _DEPTCODE; }
            set { _DEPTCODE = value; }
        }
        /// <summary>
        /// 考评项目名称
        /// </summary>
        public string NAME {
            get { return _NAME; }
            set { _NAME = value; }
        }
        /// <summary>
        /// 考评项目描述
        /// </summary>
        public string SUMMARY {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
        /// <summary>
        /// 父级考评分类
        /// </summary>
        public decimal PARENTID {
            get { return _PARENTID; }
            set { _PARENTID = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public decimal SORT {
            get { return _SORT; }
            set { _SORT = value; }
        }
        /// <summary>
        /// 状态:0正常,1删除
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 初始分值，默认100
        /// </summary>
        public decimal SCORE {
            get { return _SCORE; }
            set { _SCORE = value; }
        }
    }
}