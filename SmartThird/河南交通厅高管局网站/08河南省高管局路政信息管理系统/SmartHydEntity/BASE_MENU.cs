// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MENU.cs
// 功能描述:菜单信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-04
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 菜单信息表 -- 实体定义
    /// </summary>
    public class BASE_MENU {
        /// <summary>
        /// 菜单编号
        /// </summary>		
        private decimal _MENUID;
        /// <summary>
        /// 菜单名称
        /// </summary>		
        private string _MENUNAME;
        /// <summary>
        /// 菜单说明
        /// </summary>		
        private string _MENUINFO;
        /// <summary>
        /// 菜单URL地址
        /// </summary>		
        private string _MENUURL;
        /// <summary>
        /// 菜单图标
        /// </summary>		
        private string _ICON;
        /// <summary>
        /// 父菜单编号（根节点0）
        /// </summary>		
        private decimal _PARENTID;
        /// <summary>
        /// 状态（0：正常 1：关闭）
        /// </summary>		
        private decimal _STATUS;

        /// <summary>
        /// 菜单编号
        /// </summary>
        public decimal MENUID {
            get { return _MENUID; }
            set { _MENUID = value; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MENUNAME {
            get { return _MENUNAME; }
            set { _MENUNAME = value; }
        }
        /// <summary>
        /// 菜单说明
        /// </summary>
        public string MENUINFO {
            get { return _MENUINFO; }
            set { _MENUINFO = value; }
        }
        /// <summary>
        /// 菜单URL地址
        /// </summary>
        public string MENUURL {
            get { return _MENUURL; }
            set { _MENUURL = value; }
        }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string ICON {
            get { return _ICON; }
            set { _ICON = value; }
        }
        /// <summary>
        /// 父菜单编号（根节点0）
        /// </summary>
        public decimal PARENTID {
            get { return _PARENTID; }
            set { _PARENTID = value; }
        }
        /// <summary>
        /// 状态（0：正常 1：关闭）
        /// </summary>
        public decimal STATUS {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
    }
}