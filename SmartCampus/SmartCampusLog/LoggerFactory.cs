
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using System.Configuration;

    /// <summary>
    /// 日志Logger工厂
    /// </summary>
    public sealed class LoggerFactory
    {
        #region LoggerName class
        /// <summary>
        /// 日志Logger名称
        /// </summary>
        public sealed class LoggerName
        {
			/// <summary>
			/// ORACLE数据库
			/// </summary>
            public const string Oracle = "Oracle";
			/// <summary>
			/// 固定大小的文件
			/// </summary>
            public const string FileRolling = "FileRolling";
			/// <summary>
			/// 事件日志
			/// </summary>
            public const string EventLog = "EventLog";
			/// <summary>
			/// 内存队列
			/// </summary>
            public const string MemoryQueue = "MemoryQueue";
            /// <summary>
            /// sql数据库
            /// </summary>
            public const string Sql = "Sql";
        }
        #endregion

        #region field
        /// <summary>
        /// 默认的内存队列缓存容量
        /// </summary>
        public const int DefaultMemoryQueueSize = 50;
        /// <summary>
        /// 默认的日志级别
        /// </summary>
        public const int DefaultLogLevel = LogLevel.Info;
        #region private fields
        /// <summary>
        /// 内存队列容量
        /// </summary>
        private static int memoryQueueSize = -1;  
        /// <summary>
        /// 日志级别
        /// </summary>
        private static int logLevel = -1;
        /// <summary>
        /// 缓存容器
        /// </summary>
        private static Hashtable cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 写入系统事件日志的Logger
        /// </summary>
        private static EventLogLogger eventlogger = new EventLogLogger(GetLogLevel());
        /// <summary>
        /// 写入Oracle的日志Logger
        /// </summary>
        private static OracleLogger oracleLogger = new OracleLogger(GetLogLevel());
        /// <summary>
        /// 写入sql的日志Logger
        /// </summary>
        private static SqlLogger sqlLogger = new SqlLogger(GetLogLevel());
        /// <summary>
        /// 写入内存队列的日志Logger
        /// </summary>
        private static MemoryQueueLogger memoryQueueLogger = new MemoryQueueLogger(GetMemoryQueueSize(), GetLogLevel());
        /// <summary>
        /// 写入固定大小文件的日志Logger
        /// </summary>
        private static RollingFileLogger rollingFileLogger = new RollingFileLogger(GetLogLevel(), GetFilePath());     
        #endregion
        #endregion
        /// <summary>
        /// 设置公共变量
        /// 
        /// 主要设定工作站编号、子系统编号
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="obj">泛型类型参数对象</param>
        private static void SetPubicValue<T>(T obj ) where T:ILogger
        {
            obj.StationID = GetStationID();
            obj.SystemID = GetSystemID();
        }

        #region construct
        /// <summary>
        /// 构造
        /// </summary>
        static LoggerFactory()
        {
            //合并sql版
            cache[LoggerName.EventLog] = eventlogger;
           cache[LoggerName.Oracle] = oracleLogger;
            cache[LoggerName.FileRolling] = rollingFileLogger;
            cache[LoggerName.MemoryQueue] = memoryQueueLogger;
            cache[LoggerName.Sql] = sqlLogger;
            SetPubicValue<EventLogLogger>(eventlogger);
            SetPubicValue<OracleLogger>(oracleLogger);
            SetPubicValue<SqlLogger>(sqlLogger);
            SetPubicValue<RollingFileLogger>(rollingFileLogger);
            SetPubicValue<MemoryQueueLogger>(memoryQueueLogger);
        }
        #endregion


        #region public method
        /// <summary>
        /// 获得日志Logger
        /// </summary>
        /// <param name="loggerName">日志名：LoggerName枚举值，在此之外，返回null</param>
        /// <returns>失败返回null</returns>
        public static ILogger GetLogger(string loggerName)
        {
            ILogger logger = (ILogger)cache[loggerName];
            if (logger == null)
            {
                throw new ApplicationException("从日志工厂获取Logger时，使用了不支持的LoggerName:" + loggerName);
            }
            return logger;
        }
        /// <summary>
        /// 获得业务日志的Logger
        /// </summary>
        /// <returns></returns>
        public static OperationLogger GetOperationLogger()
        {
            OperationLogger logger = (OperationLogger)cache["Operation"];
            if (logger == null)
            {
                logger = new OperationLogger();
                cache["Operation"] = logger;
            }
            return logger;
        }

        /// <summary>
        /// 获得业务日志的Logger
        /// </summary>
        /// <returns></returns>
        public static OperationLoggerSql GetOperationLoggerSql()
        {
            OperationLoggerSql logger = (OperationLoggerSql)cache["Operation"];
            if (logger == null)
            {
                logger = new OperationLoggerSql();
                cache["Operation"] = logger;
            }
            return logger;
        }

        /// <summary>
        /// 获得固定大小文件日志的Logger
        /// </summary>
        /// <returns></returns>
        public static RollingFileLogger GetLogger()
        {  
            if (rollingFileLogger == null)
            {
                rollingFileLogger = new RollingFileLogger(GetLogLevel(), GetFilePath());
            }
            return rollingFileLogger;
        }
        /// <summary>
        /// 获得内存队列缓存容量
        /// </summary>
        /// <returns></returns>
        public static int GetMemoryQueueSize()
        {
            try
            {
                if (memoryQueueSize != -1)
                    return memoryQueueSize;

                if (ConfigurationManager.AppSettings["MemoryQueueSize"] != null)
                {
                    memoryQueueSize = Int32.Parse(ConfigurationManager.AppSettings["MemoryQueueSize"].ToString());
                    memoryQueueSize = memoryQueueSize > 0 ? memoryQueueSize : DefaultMemoryQueueSize;
                }
            }
            catch (Exception)
            {
                memoryQueueSize = DefaultMemoryQueueSize;
            }
            return memoryQueueSize;
        }
        /// <summary>
        /// 获得工作站编号
        /// </summary>
        /// <returns></returns>
        public static string GetStationID()
        {
            try
            {
                if (ConfigurationManager.AppSettings["StationID"] != null)
                {
                    return ConfigurationManager.AppSettings["StationID"].ToString();  
                }
            }
            catch (Exception)
            {
            }
            return @"未配置";
        }
        /// <summary>
        /// 获得子系统编号
        /// </summary>
        /// <returns></returns>
        public static string GetSystemID()
        {
            try
            {
                if (ConfigurationManager.AppSettings["SystemID"] != null)
                {
                    return ConfigurationManager.AppSettings["SystemID"].ToString();

                }
            }
            catch (Exception)
            {
            }
            return @"未配置";
        }
        /// <summary>
        /// 获得日志文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetFilePath()
        {
            try
            {   
                if (ConfigurationManager.AppSettings["FilePath"] != null)
                {
                    return ConfigurationManager.AppSettings["FilePath"].ToString();
                    
                }
            }
            catch (Exception)
            {     
            }
            return @"\";   
        }
        /// <summary>
        /// 获得设置的日志级别
        /// </summary>
        /// <returns></returns>
        public static int GetLogLevel()
        {
            try
            {
                if (logLevel != -1)
                    return logLevel;

                if (ConfigurationManager.AppSettings["LogLevel"] != null)
                {
                    string strLogLevel = ConfigurationManager.AppSettings["LogLevel"].ToString();
                    switch (strLogLevel.ToUpper())
                    {
                        case "ALL":
                            logLevel = 0;
                            break;
                        case "DEBUG":
                            logLevel = 1;
                            break;
                        case "INFO":
                            logLevel = 2;
                            break;
                        case "WARN":
                            logLevel = 3;
                            break;
                        case "ERROR":
                            logLevel = 4;
                            break;
                        case "FATAL":
                            logLevel = 5;
                            break;
                        case "OFF":
                            logLevel = 1000;
                            break;
                        default:
                            logLevel = DefaultLogLevel;
                            break;
                    }  
                }
            }
            catch (Exception)
            {
                logLevel = DefaultLogLevel;
            }
            return logLevel;
        }
        #endregion
    }
}
