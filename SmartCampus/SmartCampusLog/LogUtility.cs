
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Web;
    using System.Configuration;
    using System.Collections;

    /// <summary>
    /// 日志处理   
    /// </summary>
    public class LogUtility
    {
        public LogUtility()
        {
       
        }

        #region old
        /// <summary>
        /// 写应用日志：
        /// 
        /// 不提供多种查询，只能按先后顺序和时间来查询
        /// 查询结果是message
        /// </summary>
        /// <param name="strMessage">记录的消息</param>
        /// <returns></returns>
        public static bool WriteApplicationLog(string message)
        {
#if LOG4NET
            return true;
#else
            return SimpleFileLog(message);
#endif
        }


        /// <summary>
        /// 写操作日志
        /// 
        /// 对一些非系统问题而引起的操作失败操作提供给操作员日志，使他们能够自己解决问题
        /// 只要有分系统，分类型查询就行
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool WriteOperateLog(string message)
        {
#if LOG4NET
            return true;
#else
            return SimpleFileLog(message);
#endif
        }

        /// <summary>
        /// 登陆日志
        /// </summary>
        /// <param name="message">登陆信息</param>
        /// <param name="userCode">用户编码</param>
        /// <param name="date">登陆/退出时间</param>
        /// <param name="systemName">登陆/退出系统名称</param>
        /// <param name="ip">登陆/退出IP</param>
        /// <param name="isWarn">是否报警</param>
        /// <param name="type">1 登陆成功，0 退出登陆，－1 登陆失败</param>
        /// <returns></returns>
        public static bool WriteLoginLog(string message, string userCode, DateTime date, string systemName,
                                          string ip, bool isWarn, int type)
        {
#if LOG4NET
            return true;
#else
            message = (isWarn == true ? "" : "报警信息") + " 登陆用户编码：" + userCode.ToString()
                       + " 登陆时间：" + date.ToString() + " 登陆系统：" + systemName.ToString()
                       + " 登陆IP：" + ip.ToString() + " 登陆信息：" + message.ToString();
            return SimpleFileLog(message);
#endif
        }

        /// <summary>
        /// 写异常日志  
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool WriteExceptionLog(string message)
        {
#if LOG4NET
            return true;
#else
            return SimpleFileLog(message);
#endif
        }

        public static bool SaveGatherError(string errMessage)
        {
            return true;
        }
        #region private method   日志的简单实现
        private static System.IO.StreamWriter sw = null;

        /// <summary>
        /// 日志的简单实现
        /// 
        /// 每天一个日志文件
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static bool SimpleFileLog(string message)
        {
            bool bReturn = false;
            string strApplicationLogFile = "\\" + DateTime.Now.Date.ToShortDateString().Replace(':', '-') + ".txt";

            try
            {
                //如果文件不存在，建立文件
                if (!File.Exists(strApplicationLogFile))
                {
                    FileStream fs = new FileStream(strApplicationLogFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }

                sw = new System.IO.StreamWriter(strApplicationLogFile, true);
                sw.WriteLine(DateTime.Now.ToString());

                sw.WriteLine(message);
                sw.WriteLine();
                sw.Flush();
                sw.Close();
                bReturn = true;
            }
            catch (Exception err)
            {
                err.ToString();
                err = null;
                bReturn = false;
            }
            return bReturn;
        }
        #endregion
        #endregion

        protected int _level = LogLevel.Info;
        public const int DefaultMemoryQueueSize = 500;
        protected int memoryQueueSize = DefaultMemoryQueueSize;

        protected  EventLogLogger eventlogger = new EventLogLogger(LoggerFactory.GetLogLevel());
        protected OracleLogger oracleLogger = new OracleLogger(LoggerFactory.GetLogLevel());
        protected MemoryQueueLogger memoryQueueLogger = new MemoryQueueLogger(LoggerFactory.GetMemoryQueueSize(),LoggerFactory.GetLogLevel());
        protected RollingFileLogger rollingFileLogger = new RollingFileLogger(LoggerFactory.GetLogLevel());

        protected static Hashtable cacheLogger = Hashtable.Synchronized(new Hashtable());    
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }  
        /// <summary>
        /// 写操作日志
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool WriteOperateLog(OperateLogEventData data,int level)
        {
            //根据日志级别，过滤日志： 从配置中获取或者从logger获取
            if (level < this.Level)
                return true;

            //从日志工厂获取日志logger： 共有四个日志logger，分别是内存、oracle、文件、系统日志   
            LoggerCollectionEnumerator enumerator =  (LoggerCollectionEnumerator)cacheLogger["OperateLog"];
            if (enumerator == null)
                throw new ApplicationException("操作日志Logger为空，请检查系统配置文件");

            //调用logger写操作日志接口：分别写入内存或者oracle、或者文件、或者系统日志
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                //写日志
                ILogger logger = enumerator.Current;
                logger.WriteOperateLog(data, level);
            } 
            return true;
        }
        /// <summary>
        /// 写运行日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool WriteRunningLog(RunningLogEventData data, int level)
        {
            //根据日志级别，过滤日志： 从配置中获取或者从logger获取
            if (level < this.Level)
                return true;

            //从日志工厂获取日志logger： 共有四个日志logger，分别是内存、oracle、文件、系统日志   
            LoggerCollectionEnumerator enumerator = (LoggerCollectionEnumerator)cacheLogger["RunningLog"];
            if (enumerator == null)
                throw new ApplicationException("运行日志Logger为空，请检查系统配置文件");

            //调用logger写操作日志接口：分别写入内存或者oracle、或者文件、或者系统日志
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                //写日志
                ILogger logger = enumerator.Current;
                logger.WriteRunningLog(data, level);
            }
            return true;
        }
        /// <summary>
        /// 写应用日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool WriteApplicationLog(ApplicationEventData data, int level)
        {
            //根据日志级别，过滤日志： 从配置中获取或者从logger获取
            if (level < this.Level)
                return true;

            //从日志工厂获取日志logger： 共有四个日志logger，分别是内存、oracle、文件、系统日志   
            LoggerCollectionEnumerator enumerator = (LoggerCollectionEnumerator)cacheLogger["ApplicationLog"];
            if (enumerator == null)
                throw new ApplicationException("应用日志Logger为空，请检查系统配置文件");

            //调用logger写操作日志接口：分别写入内存或者oracle、或者文件、或者系统日志
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                //写日志
                ILogger logger = enumerator.Current;
                logger.WriteApplicationLog(data, level);
            }
            return true;
        }
        /// <summary>
        /// 写异常日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool WriteExceptionLog(ExceptionLogEventData data, int level)
        {
            //根据日志级别，过滤日志： 从配置中获取或者从logger获取
            if (level < this.Level)
                return true;

            //从日志工厂获取日志logger： 共有四个日志logger，分别是内存、oracle、文件、系统日志   
            LoggerCollectionEnumerator enumerator = (LoggerCollectionEnumerator)cacheLogger["ExceptionLog"];
            if (enumerator == null)
                throw new ApplicationException("异常日志Logger为空，请检查系统配置文件");

            //调用logger写操作日志接口：分别写入内存或者oracle、或者文件、或者系统日志
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                //写日志
                ILogger logger = enumerator.Current;
                logger.WriteExceptionLog(data, level);
            }
            return true;   
        }
        /// <summary>
        /// 写登陆日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool WriteLoginLog(LoginLogEventData data, int level)
        {
            //根据日志级别，过滤日志： 从配置中获取或者从logger获取
            if (level < this.Level)
                return true;

            //从日志工厂获取日志logger： 共有四个日志logger，分别是内存、oracle、文件、系统日志   
            LoggerCollectionEnumerator enumerator = (LoggerCollectionEnumerator)cacheLogger["LoginLog"];
            if (enumerator == null)
                throw new ApplicationException("登陆日志Logger为空，请检查系统配置文件");

            //调用logger写操作日志接口：分别写入内存或者oracle、或者文件、或者系统日志
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                //写日志
                ILogger logger = enumerator.Current;
                logger.WriteLoginLog(data, level);
            }
            return true;
        }
        /// <summary>
        /// 写客户反馈
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool WriteFeedbackLog(FeedbackEventData data, int level)
        {
            //根据日志级别，过滤日志： 从配置中获取或者从logger获取
            if (level < this.Level)
                return true;

            //从日志工厂获取日志logger： 共有四个日志logger，分别是内存、oracle、文件、系统日志   
            LoggerCollectionEnumerator enumerator = (LoggerCollectionEnumerator)cacheLogger["FeedbackLog"];
            if (enumerator == null)
                throw new ApplicationException("客户反馈日志Logger为空，请检查系统配置文件");

            //调用logger写操作日志接口：分别写入内存或者oracle、或者文件、或者系统日志
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                //写日志
                ILogger logger = enumerator.Current;
                logger.WriteFeedbackLog(data, level);
            }
            return true;
        }
        
    }
}
