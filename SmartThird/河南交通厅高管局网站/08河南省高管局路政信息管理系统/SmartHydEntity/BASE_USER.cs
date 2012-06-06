// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_USER.cs
// 功能描述:用户信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-05-10
namespace SmartHyd.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 用户信息表 -- 实体定义
    /// </summary>
    public class BASE_USER {
        /// <summary>
        /// 用户ID编号
        /// </summary>		
        private decimal _USERID;
        /// <summary>
        /// 用户账号（登录使用）
        /// </summary>		
        private string _USERNAME;
        /// <summary>
        /// 用户密码（登录使用）
        /// </summary>		
        private string _USERPWD;
        /// <summary>
        /// 用户父ID编号（用于多个子账户）
        /// </summary>		
        private decimal _PARENTID;
        /// <summary>
        /// 性别（0：男 1：女）
        /// </summary>		
        private decimal _SEX;
        /// <summary>
        /// 用户所属部门
        /// </summary>		
        private decimal _DEPTID;
        /// <summary>
        /// 出生年月
        /// </summary>		
        private DateTime _BIRTHDAY = DateTime.Now;
        /// <summary>
        /// 学历
        /// </summary>		
        private string _DEGREE;
        /// <summary>
        /// 政治面貌
        /// </summary>		
        private string _FACE;
        /// <summary>
        /// 身份证号码
        /// </summary>		
        private string _IDNUMBER;
        /// <summary>
        /// 工作证号
        /// </summary>		
        private string _JOBNUMBER;
        /// <summary>
        /// 人员照片
        /// </summary>		
        private string _PHOTO;
        /// <summary>
        /// 专业
        /// </summary>		
        private string _PROF;
        /// <summary>
        /// 备注
        /// </summary>		
        private string _REMARK;
        /// <summary>
        /// 状态（0：正常，1：删除）
        /// </summary>		
        private decimal _STSTUS;
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _PHONE;

        /// <summary>
        /// 真实姓名
        /// </summary>
        private string _REALNAME;
        /// <summary>
        /// 用户ID编号
        /// </summary>
        public decimal USERID {
            get { return _USERID; }
            set { _USERID = value; }
        }
        /// <summary>
        /// 用户账号（登录使用）
        /// </summary>
        public string USERNAME {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        /// <summary>
        /// 用户密码（登录使用）
        /// </summary>
        public string USERPWD {
            get { return _USERPWD; }
            set { _USERPWD = value; }
        }
        /// <summary>
        /// 用户父ID编号（用于多个子账户）
        /// </summary>
        public decimal PARENTID {
            get { return _PARENTID; }
            set { _PARENTID = value; }
        }
        /// <summary>
        /// 性别（0：男 1：女）
        /// </summary>
        public decimal SEX {
            get { return _SEX; }
            set { _SEX = value; }
        }
        /// <summary>
        /// 用户所属部门
        /// </summary>
        public decimal DEPTID {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime BIRTHDAY {
            get { return _BIRTHDAY; }
            set { _BIRTHDAY = value; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string DEGREE {
            get { return _DEGREE; }
            set { _DEGREE = value; }
        }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string FACE {
            get { return _FACE; }
            set { _FACE = value; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDNUMBER {
            get { return _IDNUMBER; }
            set { _IDNUMBER = value; }
        }
        /// <summary>
        /// 工作证号
        /// </summary>
        public string JOBNUMBER {
            get { return _JOBNUMBER; }
            set { _JOBNUMBER = value; }
        }
        /// <summary>
        /// 人员照片
        /// </summary>
        public string PHOTO {
            get { return _PHOTO; }
            set { _PHOTO = value; }
        }
        /// <summary>
        /// 专业
        /// </summary>
        public string PROF {
            get { return _PROF; }
            set { _PROF = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        /// <summary>
        /// 状态（0：正常，1：删除）
        /// </summary>
        public decimal STSTUS {
            get { return _STSTUS; }
            set { _STSTUS = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PHONE {
            get { return _PHONE; }
            set { _PHONE = value; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string REALNAME
        {
            get { return _REALNAME; }
            set { _REALNAME = value; }
        }
    }
}