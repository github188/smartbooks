
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 写到文件
    /// </summary>
    public class RollingFileLogger : ILogger
    {
        #region
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel"></param>
        public RollingFileLogger(int logLevel)
            : base(logLevel)
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="filePath"></param>
        public RollingFileLogger(int logLevel,string filePath) :base(logLevel)
        {
            while (filePath.EndsWith("\\"))
                filePath = filePath.Substring(0,filePath.Length -1);

            this.filePath = filePath;

            RollingFileAppender.CheckDirectory(FilePath);
        }
        #endregion
        /// <summary>
        /// 文件路径
        /// </summary>
        private string  filePath = "\\";
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            set
            {
                this.filePath = value;
                {
                    while (filePath.EndsWith("\\"))
                        filePath = filePath.Substring(0, filePath.Length - 1);
                }
            }
            get
            {
                return this.filePath;
            }
        }
        /// <summary>
        /// 日志保留天数
        /// </summary>
        private int holdDays = 60;
        /// <summary>
        /// 日志保留天数
        /// </summary>
        public int HoldDays
        {
            get
            {
                return holdDays;
            }
            set
            {
                holdDays = value >0 ? value : 60;
            }
        }
        /// <summary>
        /// 设置单个文件最大容量
        /// </summary>
        /// <param name="maxRollingSize">单个日志文件最大容量</param>
        public void SetRollingFileSize(int maxRollingSize)
        {
            RollingFileAppender.RollingFileSize = maxRollingSize;
        }
        /// <summary>
        /// 处理当用户不输入文件名时
        /// 按默认的文件名处理
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        private string PrepareFileName(string fileName,string fileType)
        {
            try{

            if (fileName.Trim() == "")
                fileName = filePath + @"\\"+fileType + RollingFileAppender.GetFileNameFromDate();
            else
                fileName = filePath + "\\" + fileName;

            RollingFileAppender.CheckDirectory(filePath);
            return fileName;
            }
            catch(Exception)
            {
                return "";
            }
        }                        
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="level">日志级别</param> 
        /// <param name="fileName">日志文件名</param>    
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteLog(string message, int level,string fileName) 
        {
            if (level < this.logLevel)
                return true;

            try
            {
                string dt = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string msg = String.Format("日志时间:{0},工作站:{1},子系统:{2},日志级别:{3},日志内容:{4}",
                                dt, StationID, SystemID, logLevel.ToString(), message);

                return RollingFileAppender.SimpleFileLog(PrepareFileName(fileName, LogCategory.Common), msg);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="level">日志级别</param>
        /// <param name="category">日志种类</param>
        /// <returns></returns>
        public bool WriteLogWithCatetory(string message, int level,string category)
        {
            if (level < this.logLevel)
                return true;

            try
            {
                string dt = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string msg = String.Format("日志时间:{0},工作站:{1},子系统:{2},日志级别:{3},日志内容:{4}",
                               dt,StationID, SystemID, logLevel.ToString(),  message);

                return RollingFileAppender.SimpleFileLog(PrepareFileName("",category), msg);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 删除所有的旧日志
        /// 
        /// 默认删除60天之前的日志
        /// </summary>
        public void DeleteOldLog()
        {
            RollingFileAppender.DeleteOldFile(this.filePath, this.holdDays);
        }
        /// <summary>
        /// 删除指定类型旧日志 
        /// 
        /// 默认删除60天之前的日志
        /// </summary>
        /// <param name="logCategory">LogCategory对象</param>
        public void DeleteOldLog(string logCategory)
        {
            RollingFileAppender.DeleteOldFile(this.filePath, this.holdDays,logCategory);
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
           
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            return RollingFileAppender.SimpleFileLog(PrepareFileName("", LogCategory.Operate), data.ToString());
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
           
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            return RollingFileAppender.SimpleFileLog(PrepareFileName("", LogCategory.Running), data.ToString()); 
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

            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            return RollingFileAppender.SimpleFileLog(PrepareFileName("", LogCategory.Application), data.ToString()); 
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
             data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            return RollingFileAppender.SimpleFileLog(PrepareFileName("", LogCategory.Exception), data.ToString());
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
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            return RollingFileAppender.SimpleFileLog(PrepareFileName("", LogCategory.Login), data.ToString());
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
            
            data.StationID = this.StationID;
            data.SystemID = this.SystemID;

            return RollingFileAppender.SimpleFileLog(PrepareFileName("", LogCategory.Feedback), data.ToString());
        }
        #endregion

    }
}
