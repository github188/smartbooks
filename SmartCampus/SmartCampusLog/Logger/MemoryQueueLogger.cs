
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// 日志内存队列Logger
    /// </summary>
    public class MemoryQueueLogger : ILogger
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="size">内存队列容量</param>
        /// <param name="logLevel">日志级别</param>
        public MemoryQueueLogger(int size, int logLevel)
            : base(logLevel)
        {
            operateLog = new MemoryQueueAppender(size);
            runningLog = new MemoryQueueAppender(size);
            applicationLog = new MemoryQueueAppender(size);
            exceptionLog = new MemoryQueueAppender(size);
            loginLog = new MemoryQueueAppender(size);
            feedbackLog = new MemoryQueueAppender(size);
            commonLog = new MemoryQueueAppender(size);
        }

        #region private static field
        /// <summary>
        /// 日志Appender对象
        /// </summary>
        private static MemoryQueueAppender operateLog;
        private static MemoryQueueAppender runningLog;
        private static MemoryQueueAppender applicationLog;
        private static MemoryQueueAppender exceptionLog;
        private static MemoryQueueAppender loginLog;
        private static MemoryQueueAppender feedbackLog;
        private static MemoryQueueAppender commonLog;
        /// <summary>
        /// 日志最大最小数
        /// </summary>
        private static long operateLogMaxSN = 0;
        private static long runningLogMaxSN = 0;
        private static long applicationLogMaxSN = 0;
        private static long exceptionLogMaxSN = 0;
        private static long loginLogMaxSN = 0;
        private static long feedbackLogMaxSN = 0;
        private static long commonLogMaxSN = 0;
        #endregion
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="level">日志级别</param>
        /// <param name="fileName">文件名</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteLog(string message, int level, string fileName)
        {
            if (level < this.logLevel)
                return true;

            LogEventData data = new LogEventData();
            data.CreateDate = System.DateTime.Now;
            data.Level = logLevel;
            data.Message = message;
            data.SN = ++commonLogMaxSN;
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            commonLog.AddTail<LogEventData>(data);
            return true;
        }

        #region override ILogger abstract method
        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="data">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteOperateLog(OperateLogEventData data, int level)
        {
            if (level < this.logLevel)
                return true;

            data.SN = ++operateLogMaxSN;

            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            operateLog.AddTail<OperateLogEventData>(data);
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

            data.SN = ++runningLogMaxSN;

            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            runningLog.AddTail<RunningLogEventData>(data);
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

            data.SN = ++applicationLogMaxSN;
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            applicationLog.AddTail<ApplicationEventData>(data);
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

            data.SN = ++exceptionLogMaxSN;
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            exceptionLog.AddTail<ExceptionLogEventData>(data);
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

            data.SN = ++loginLogMaxSN;
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            loginLog.AddTail<LoginLogEventData>(data);
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

            data.SN = ++feedbackLogMaxSN;
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            feedbackLog.AddTail<FeedbackEventData>(data);
            return true;
        }
        #endregion

        /// <summary>
        /// 获取日志：比指定日期大的记录
        /// </summary>
        /// <param name="minDate">最小日期</param>
        /// <param name="logCategory">日志种类</param>
        /// <returns>日志记录集合</returns>
        public override ArrayList GetLog(DateTime minDate, string logCategory)
        {
            switch (logCategory)
            {
                case LogCategory.Common:
                    return commonLog.GetList<LogEventData>(minDate);

                case LogCategory.Running:
                    return runningLog.GetList<RunningLogEventData>(minDate);

                case LogCategory.Operate:
                    return operateLog.GetList<OperateLogEventData>(minDate);

                case LogCategory.Exception:
                    return exceptionLog.GetList<ExceptionLogEventData>(minDate);

                case LogCategory.Application:
                    return applicationLog.GetList<ApplicationEventData>(minDate);

                case LogCategory.Login:
                    return loginLog.GetList<LoginLogEventData>(minDate);

                case LogCategory.Feedback:
                    return feedbackLog.GetList<FeedbackEventData>(minDate);
                    ;
                default:
                    return null;

            }
        }
        /// <summary>
        /// 获取日志：比指定sn大的记录
        /// </summary>
        /// <param name="sn">最小序号</param>
        /// <param name="logCategory">日志种类</param>
        /// <returns>日志集合</returns>
        public override ArrayList GetLog(long sn, string logCategory)
        {
            switch (logCategory)
            {
                case LogCategory.Common:
                    return commonLog.GetList<LogEventData>(sn);

                case LogCategory.Running:
                    return runningLog.GetList<RunningLogEventData>(sn);

                case LogCategory.Operate:
                    return operateLog.GetList<OperateLogEventData>(sn);

                case LogCategory.Exception:
                    return exceptionLog.GetList<ExceptionLogEventData>(sn);

                case LogCategory.Application:
                    return applicationLog.GetList<ApplicationEventData>(sn);

                case LogCategory.Login:
                    return loginLog.GetList<LoginLogEventData>(sn);

                case LogCategory.Feedback:
                    return feedbackLog.GetList<FeedbackEventData>(sn);
                    ;
                default:
                    return null;

            }
        }
    }
}
