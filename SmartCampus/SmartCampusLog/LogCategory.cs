
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 日志种类
    /// </summary>
    public class LogCategory
    {
        /// <summary>
        /// 操作日志 
        /// </summary>
        public const string Operate = "Operate";       
        /// <summary>
        /// 运行日志 
        /// </summary>
        public const string Running = "Running";        
        /// <summary>
        /// 登陆日志 
        /// </summary>
        public const string Login = "Login";   
        /// <summary>
        /// 异常日志 
        /// </summary>
        public const string Exception = "Exception";    
        /// <summary>
        /// 应用日志:主要记录应用程序错误
        /// </summary>
        public const string Application = "Application";     
        /// <summary>
        /// 收集客户反馈日志 
        /// </summary>
        public const string Feedback = "Feedback";               
        /// <summary>
        /// 通用日志 
        /// </summary>
        public const string Common = "Common";
        /// <summary>
        /// 业务日志
        /// </summary>
        public const string Operation = "Operation";
    }
}
