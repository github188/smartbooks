// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:BASE_PROCEDURE.cs
// 功能描述:路政许可流程表 -- 实体定义
//
// 创建标识： 付晓 2012-05-15
namespace SmartHyd.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
	
    /// <summary>
    /// 路政许可流程表 -- 实体定义
    /// </summary>
    public class BASE_PROCEDURE
    {
		/// <summary>
        /// 编号
        /// </summary>		
        private decimal _PID;
		/// <summary>
        /// 路政许可申请单编号
        /// </summary>		
        private decimal _REQUISITIONID;
		/// <summary>
        /// 审理单位(部门)
        /// </summary>		
        private string _DEPARTMENT;
		/// <summary>
        /// 审理人
        /// </summary>		
        private string _TRANSACTOR;
		/// <summary>
        /// 审理意见
        /// </summary>		
        private string _CONTENTS;
		/// <summary>
        /// 审理结果
        /// </summary>		
        private string _RESULT;
		/// <summary>
        /// 审理时间
        /// </summary>		
        private DateTime _P_DATE;
		/// <summary>
        /// 状态(0:正常；)
        /// </summary>		
        private decimal _P_STATUS;
	
	        /// <summary>
        /// 编号
        /// </summary>
        public decimal PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
	        /// <summary>
        /// 路政许可申请单编号
        /// </summary>
        public decimal REQUISITIONID
        {
            get { return _REQUISITIONID; }
            set { _REQUISITIONID = value; }
        }
	        /// <summary>
        /// 审理单位(部门)
        /// </summary>
        public string DEPARTMENT
        {
            get { return _DEPARTMENT; }
            set { _DEPARTMENT = value; }
        }
	        /// <summary>
        /// 审理人
        /// </summary>
        public string TRANSACTOR
        {
            get { return _TRANSACTOR; }
            set { _TRANSACTOR = value; }
        }
	        /// <summary>
        /// 审理意见
        /// </summary>
        public string CONTENTS
        {
            get { return _CONTENTS; }
            set { _CONTENTS = value; }
        }
	        /// <summary>
        /// 审理结果
        /// </summary>
        public string RESULT
        {
            get { return _RESULT; }
            set { _RESULT = value; }
        }
	        /// <summary>
        /// 审理时间
        /// </summary>
        public DateTime P_DATE
        {
            get { return _P_DATE; }
            set { _P_DATE = value; }
        }
	        /// <summary>
        /// 状态(0:正常；)
        /// </summary>
        public decimal P_STATUS
        {
            get { return _P_STATUS; }
            set { _P_STATUS = value; }
        }
	}
}