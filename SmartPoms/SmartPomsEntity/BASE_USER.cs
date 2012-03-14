// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER.cs
// 功能描述:用户帐户信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 用户帐户信息表 -- 实体定义
    /// </summary>
    public class BASE_USER {
        /// <summary>
        /// 用户ID
        /// </summary>		
        private int _UserID;
        /// <summary>
        /// 登录名，用户Email
        /// </summary>		
        private string _UserName;
        /// <summary>
        /// 密码
        /// </summary>		
        private string _Password;
        /// <summary>
        /// Email
        /// </summary>		
        private string _Email;
        /// <summary>
        /// 重置密码的问题
        /// </summary>		
        private string _Question;
        /// <summary>
        /// 重置密码的答案
        /// </summary>		
        private string _Answer;
        /// <summary>
        /// 角色
        /// </summary>		
        private int _RoleID;
        /// <summary>
        /// 用户组
        /// </summary>		
        private int _UserGroup;
        /// <summary>
        /// 帐户创建时间
        /// </summary>		
        private DateTime _CreateTime;
        /// <summary>
        /// 上一次登录的时间
        /// </summary>		
        private DateTime _LastLoginTime;
        /// <summary>
        /// 用户状态
        /// </summary>		
        private int _Status;
        /// <summary>
        /// 是否在线
        /// </summary>		
        private bool _IsOnline;
        /// <summary>
        /// 是否受权限限制，0为受限制
        /// </summary>		
        private bool _IsLimit;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID {
            get { return _UserID; }
            set { _UserID = value; }
        }
        /// <summary>
        /// 登录名，用户Email
        /// </summary>
        public string UserName {
            get { return _UserName; }
            set { _UserName = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password {
            get { return _Password; }
            set { _Password = value; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email {
            get { return _Email; }
            set { _Email = value; }
        }
        /// <summary>
        /// 重置密码的问题
        /// </summary>
        public string Question {
            get { return _Question; }
            set { _Question = value; }
        }
        /// <summary>
        /// 重置密码的答案
        /// </summary>
        public string Answer {
            get { return _Answer; }
            set { _Answer = value; }
        }
        /// <summary>
        /// 角色
        /// </summary>
        public int RoleID {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        /// <summary>
        /// 用户组
        /// </summary>
        public int UserGroup {
            get { return _UserGroup; }
            set { _UserGroup = value; }
        }
        /// <summary>
        /// 帐户创建时间
        /// </summary>
        public DateTime CreateTime {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        /// <summary>
        /// 上一次登录的时间
        /// </summary>
        public DateTime LastLoginTime {
            get { return _LastLoginTime; }
            set { _LastLoginTime = value; }
        }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status {
            get { return _Status; }
            set { _Status = value; }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline {
            get { return _IsOnline; }
            set { _IsOnline = value; }
        }
        /// <summary>
        /// 是否受权限限制，0为受限制
        /// </summary>
        public bool IsLimit {
            get { return _IsLimit; }
            set { _IsLimit = value; }
        }
    }
}