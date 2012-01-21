
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;

    /// <summary>
    /// 写到系统日志
    /// </summary>
    public class EventLogLogger : ILogger
    {  
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        public EventLogLogger(int logLevel):base(logLevel)
        {                                                                            
        }
        /// <summary>
        /// appender对象
        /// </summary>
        private static EventLogAppender appender = new EventLogAppender();
        /// <summary>
        /// 写通用日志
        /// 
        /// 为了解决对单个操作日志分不同文件保存的需求，增加该方法
        /// 当filename ="" 时，按原来的默认处理，否则文件写入fileName
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="level">日志级别</param>
        /// <param name="fileName">日志文件名</param>
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteLog( string message,int level,string fileName) 
        {
            if (level < this.logLevel)
                return true;

            string msg = String.Format("日志级别:{0},日志时间:{1},日志内容:{3}",
                            logLevel.ToString(), System.DateTime.Now, message);
            
            appender.WriteLog("Common", message);
            return true;
        }

        #region override ILogger abstract method
        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="data">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteOperateLog(OperateLogEventData data,int level)  
        {
            if (level < this.logLevel)
                return true;  
       
            appender.WriteLog("Operate", data.ToString());
            return true;
        }
        /// <summary>
        /// 写运行日志
        /// </summary>
        /// <param name="data">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteRunningLog(RunningLogEventData data, int level)  
        {
            if (level < this.logLevel)
                return true;

            appender.WriteLog("Running", data.ToString());
            return true;
        }
        /// <summary>
        /// 写应用日志
        /// </summary>
        /// <param name="data">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteApplicationLog(ApplicationEventData data, int level)  
        {
            if (level < this.logLevel)
                return true;

            appender.WriteLog("Application", data.ToString());
            return true;
        }
        /// <summary>
        /// 写异常日志
        /// </summary>
        /// <param name="data">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteExceptionLog(ExceptionLogEventData data, int level)  
        {
            if (level < this.logLevel)
                return true;

            appender.WriteLog("Exception", data.ToString());
            return true;
        }
        /// <summary>
        /// 写登陆日志
        /// </summary>
        /// <param name="data">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteLoginLog(LoginLogEventData data, int level)  
        {
            if (level < this.logLevel)
                return true;

            appender.WriteLog("Login", data.ToString());
            return true;
        }
        /// <summary>
        /// 写客户反馈
        /// </summary>
        /// <param name="data">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteFeedbackLog(FeedbackEventData data, int level)  
        {
            if (level < this.logLevel)
                return true;

            appender.WriteLog("Feedback", data.ToString());
            return true;
        }
        #endregion
    }
}
