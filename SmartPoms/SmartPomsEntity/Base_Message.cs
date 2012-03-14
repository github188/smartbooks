// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_MESSAGE.cs
// 功能描述:预警信息表 -- 实体定义
//
// 创建标识： 王 亚 2012-03-14
namespace SmartPoms.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 预警信息表 -- 实体定义
    /// </summary>
    public class BASE_MESSAGE {
        /// <summary>
        /// MessageID
        /// </summary>		
        private int _MessageID;
        /// <summary>
        /// Title
        /// </summary>		
        private string _Title;
        /// <summary>
        /// Detail
        /// </summary>		
        private string _Detail;
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _CreateTime;
        /// <summary>
        /// Status
        /// </summary>		
        private int _Status;
        /// <summary>
        /// Snapshop
        /// </summary>		
        private string _Snapshop;
        /// <summary>
        /// UserID
        /// </summary>		
        private int _UserID;

        /// <summary>
        /// MessageID
        /// </summary>
        public int MessageID {
            get { return _MessageID; }
            set { _MessageID = value; }
        }
        /// <summary>
        /// Title
        /// </summary>
        public string Title {
            get { return _Title; }
            set { _Title = value; }
        }
        /// <summary>
        /// Detail
        /// </summary>
        public string Detail {
            get { return _Detail; }
            set { _Detail = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime CreateTime {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        /// <summary>
        /// Status
        /// </summary>
        public int Status {
            get { return _Status; }
            set { _Status = value; }
        }
        /// <summary>
        /// Snapshop
        /// </summary>
        public string Snapshop {
            get { return _Snapshop; }
            set { _Snapshop = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>
        public int UserID {
            get { return _UserID; }
            set { _UserID = value; }
        }
    }
}