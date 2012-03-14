// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USERGROUP.cs
// 功能描述:Base_UserGroup -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_UserGroup -- 实体定义
    /// </summary>
    public class BASE_USERGROUP {
        /// <summary>
        /// 用户组ID
        /// </summary>		
        private int _UG_ID;
        /// <summary>
        /// 用户分组名称
        /// </summary>		
        private string _UG_Name;
        /// <summary>
        /// 用户分组排序
        /// </summary>		
        private int _UG_Order;
        /// <summary>
        /// 用户分组描述
        /// </summary>		
        private string _UG_Description;
        /// <summary>
        /// 用户分组深度
        /// </summary>		
        private int _UG_Depth;
        /// <summary>
        /// 用户分组上级
        /// </summary>		
        private int _UG_SuperiorID;
        /// <summary>
        /// 用户分组下级数
        /// </summary>		
        private int _UG_Count;

        /// <summary>
        /// 用户组ID
        /// </summary>
        public int UG_ID {
            get { return _UG_ID; }
            set { _UG_ID = value; }
        }
        /// <summary>
        /// 用户分组名称
        /// </summary>
        public string UG_Name {
            get { return _UG_Name; }
            set { _UG_Name = value; }
        }
        /// <summary>
        /// 用户分组排序
        /// </summary>
        public int UG_Order {
            get { return _UG_Order; }
            set { _UG_Order = value; }
        }
        /// <summary>
        /// 用户分组描述
        /// </summary>
        public string UG_Description {
            get { return _UG_Description; }
            set { _UG_Description = value; }
        }
        /// <summary>
        /// 用户分组深度
        /// </summary>
        public int UG_Depth {
            get { return _UG_Depth; }
            set { _UG_Depth = value; }
        }
        /// <summary>
        /// 用户分组上级
        /// </summary>
        public int UG_SuperiorID {
            get { return _UG_SuperiorID; }
            set { _UG_SuperiorID = value; }
        }
        /// <summary>
        /// 用户分组下级数
        /// </summary>
        public int UG_Count {
            get { return _UG_Count; }
            set { _UG_Count = value; }
        }
    }
}