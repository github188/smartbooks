// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MODULETYPE.cs
// 功能描述:Base_ModuleType -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_ModuleType -- 实体定义
    /// </summary>
    public class BASE_MODULETYPE {
        /// <summary>
        /// 模块分类ID
        /// </summary>		
        private int _ModuleTypeID;
        /// <summary>
        /// 模块类型名称
        /// </summary>		
        private string _ModuleTypeName;
        /// <summary>
        /// 排序
        /// </summary>		
        private int _ModuleTypeOrder;
        /// <summary>
        /// 说明
        /// </summary>		
        private string _ModuleTypeDescription;
        /// <summary>
        /// 深度
        /// </summary>		
        private int _ModuleTypeDepth;
        /// <summary>
        /// 上级ID
        /// </summary>		
        private int _ModuleTypeSuperiorID;
        /// <summary>
        /// 下级个数
        /// </summary>		
        private int _ModuleTypeCount;

        /// <summary>
        /// 模块分类ID
        /// </summary>
        public int ModuleTypeID {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        /// <summary>
        /// 模块类型名称
        /// </summary>
        public string ModuleTypeName {
            get { return _ModuleTypeName; }
            set { _ModuleTypeName = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int ModuleTypeOrder {
            get { return _ModuleTypeOrder; }
            set { _ModuleTypeOrder = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string ModuleTypeDescription {
            get { return _ModuleTypeDescription; }
            set { _ModuleTypeDescription = value; }
        }
        /// <summary>
        /// 深度
        /// </summary>
        public int ModuleTypeDepth {
            get { return _ModuleTypeDepth; }
            set { _ModuleTypeDepth = value; }
        }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int ModuleTypeSuperiorID {
            get { return _ModuleTypeSuperiorID; }
            set { _ModuleTypeSuperiorID = value; }
        }
        /// <summary>
        /// 下级个数
        /// </summary>
        public int ModuleTypeCount {
            get { return _ModuleTypeCount; }
            set { _ModuleTypeCount = value; }
        }
    }
}