// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_DOCUMENT_TYPE.cs
// 功能描述:档案类别表 -- 实体定义
//
// 创建标识： 王 亚 2012-06-18
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 档案类别表 -- 实体定义
    /// </summary>
    public class BASE_DOCUMENT_TYPE {
        /// <summary>
        /// 主键，自增
        /// </summary>		
        private decimal _ID;
        /// <summary>
        /// 分类名称
        /// </summary>		
        private string _NAME;
        /// <summary>
        /// 分类描述
        /// </summary>		
        private string _SUMMARY;
        /// <summary>
        /// 状态:0正常，1删除
        /// </summary>		
        private decimal _STATUS;
        /// <summary>
        /// 排序
        /// </summary>		
        private decimal _SORT;
        /// <summary>
        /// 部门编号
        /// </summary>		
        private decimal _DEPTCODE;
        /// <summary>
        /// 共享:0不共享,1共享给上级单位,2共享给下级单位,3共享给上级和下级单位
        /// </summary>		
        private decimal _ISSHARE;

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
        public string NAME {
            get { return _NAME; }
            set { _NAME = value; }
        }
        /// <summary>
        /// 分类描述
        /// </summary>
        public string SUMMARY {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
        /// <summary>
        /// 状态:0正常，1删除
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public decimal SORT {
            get { return _SORT; }
            set { _SORT = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        public decimal DEPTCODE {
            get { return _DEPTCODE; }
            set { _DEPTCODE = value; }
        }
        /// <summary>
        /// 共享:0不共享,1共享给上级单位,2共享给下级单位,3共享给上级和下级单位
        /// </summary>
        public decimal ISSHARE {
            get { return _ISSHARE; }
            set { _ISSHARE = value; }
        }
    }
}