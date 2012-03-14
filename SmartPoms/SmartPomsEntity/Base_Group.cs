// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_GROUP.cs
// 功能描述:Base_Group -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_Group -- 实体定义
    /// </summary>
    public class BASE_GROUP {
        /// <summary>
        /// 分组ID
        /// </summary>		
        private int _GroupID;
        /// <summary>
        /// 组名称
        /// </summary>		
        private string _GroupName;
        /// <summary>
        /// 排序
        /// </summary>		
        private int _GroupOrder;
        /// <summary>
        /// 说明
        /// </summary>		
        private string _GroupDescription;
        /// <summary>
        /// 分组类型 用户组0,角色组1
        /// </summary>		
        private int _GroupType;

        /// <summary>
        /// 分组ID
        /// </summary>
        public int GroupID {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int GroupOrder {
            get { return _GroupOrder; }
            set { _GroupOrder = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string GroupDescription {
            get { return _GroupDescription; }
            set { _GroupDescription = value; }
        }
        /// <summary>
        /// 分组类型 用户组0,角色组1
        /// </summary>
        public int GroupType {
            get { return _GroupType; }
            set { _GroupType = value; }
        }
    }
}