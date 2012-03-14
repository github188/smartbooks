// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MODULE.cs
// 功能描述:Base_Module -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_Module -- 实体定义
    /// </summary>
    public class BASE_MODULE {
        /// <summary>
        /// 模块ID
        /// </summary>		
        private int _ModuleID;
        /// <summary>
        /// 模块类型
        /// </summary>		
        private int _ModuleTypeID;
        /// <summary>
        /// 模块名称
        /// </summary>		
        private string _ModuleName;
        /// <summary>
        /// 模块标识
        /// </summary>		
        private string _ModuleTag;
        /// <summary>
        /// 模块地址
        /// </summary>		
        private string _ModuleURL;
        /// <summary>
        /// 是否禁用
        /// </summary>		
        private bool _ModuleDisabled;
        /// <summary>
        /// 排序
        /// </summary>		
        private int _ModuleOrder;
        /// <summary>
        /// 说明
        /// </summary>		
        private string _ModuleDescription;
        /// <summary>
        /// 是否显示在导航菜单中
        /// </summary>		
        private bool _IsMenu;

        /// <summary>
        /// 模块ID
        /// </summary>
        public int ModuleID {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }
        /// <summary>
        /// 模块类型
        /// </summary>
        public int ModuleTypeID {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }
        /// <summary>
        /// 模块标识
        /// </summary>
        public string ModuleTag {
            get { return _ModuleTag; }
            set { _ModuleTag = value; }
        }
        /// <summary>
        /// 模块地址
        /// </summary>
        public string ModuleURL {
            get { return _ModuleURL; }
            set { _ModuleURL = value; }
        }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool ModuleDisabled {
            get { return _ModuleDisabled; }
            set { _ModuleDisabled = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int ModuleOrder {
            get { return _ModuleOrder; }
            set { _ModuleOrder = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string ModuleDescription {
            get { return _ModuleDescription; }
            set { _ModuleDescription = value; }
        }
        /// <summary>
        /// 是否显示在导航菜单中
        /// </summary>
        public bool IsMenu {
            get { return _IsMenu; }
            set { _IsMenu = value; }
        }
    }
}