// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_ARTICLE_TYPE.cs
// 功能描述:公文类别表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-18
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 公文类别表 -- 实体定义
    /// </summary>
    public class BASE_ARTICLE_TYPE {
        /// <summary>
        /// 主键，自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 分类名称
        /// </summary>		
        private string _TYPENAME;
        /// <summary>
        /// 分类描述
        /// </summary>		
        private string _SUMMARY;
        /// <summary>
        /// 状态：0正常，1删除
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 父分类编号：0根节点
        /// </summary>		
        private decimal _PARENT;
        /// <summary>
        /// 排序
        /// </summary>		
        private decimal _SORT;
        /// <summary>
        /// 所属部门
        /// </summary>		
        private decimal _DEPTID;

        /// <summary>
        /// 主键，自增
        /// </summary>
        public decimal ID {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string TYPENAME {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }
        /// <summary>
        /// 分类描述
        /// </summary>
        public string SUMMARY {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
        /// <summary>
        /// 状态：0正常，1删除
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 父分类编号：0根节点
        /// </summary>
        public decimal PARENT {
            get { return _PARENT; }
            set { _PARENT = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public decimal SORT {
            get { return _SORT; }
            set { _SORT = value; }
        }
        /// <summary>
        /// 所属部门
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
    }
}