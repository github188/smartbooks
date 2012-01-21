
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// 日志logger
    /// 
    /// 原则：日志写入失败，不抛异常，只返回false
    /// </summary>
    public abstract class ILogger
    {
        /// <summary>
        /// 工作站编号
        /// </summary>
        public string StationID = "";
        /// <summary>
        /// 子系统编号
        /// </summary>
        public string SystemID = "";
        /// <summary>
        /// 日志级别
        /// </summary>
        protected int logLevel = LogLevel.Info;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="level"></param>
        public ILogger(int level)
        {
            logLevel = level;
        }

        #region 通用的日志
        /// <summary>
        /// 写日志
        /// 按默认的级别写日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteLog(string message)
        {
            return WriteLog(message, LogLevel.Info);
        }
        /// <summary>
        /// 写日志
        /// </summary>                     
        /// <param name="message">日志内容</param>
        /// <param name="logLevel">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteLog(string message, int logLevel)
        {
           return WriteLog(message,logLevel, "");
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="logLevel">日志级别</param>
        /// <param name="fileName">此参数只对写入文件有效。当fileName ＝“” 时，按默认文件名处理</param>
        /// <returns>true：成功；false：失败</returns>
        public abstract bool WriteLog(string message, int logLevel,string fileName);
         
        #endregion

        #region 日志结构传入
        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="data">操作日志数据</param>
        /// <param name="level">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public abstract bool WriteOperateLog(OperateLogEventData data,int level) ;
        /// <summary>
        /// 写运行日志
        /// </summary>
        /// <param name="data">运行日志数据</param>
        /// <param name="level">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public abstract bool WriteRunningLog(RunningLogEventData data, int level);
        /// <summary>
        /// 写应用日志
        /// </summary>
        /// <param name="data">应用日志数据</param>
        /// <param name="level">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public abstract bool WriteApplicationLog(ApplicationEventData data, int level);
        /// <summary>
        /// 写异常日志
        /// </summary>
        /// <param name="data">异常日志数据</param>
        /// <param name="level">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public abstract bool WriteExceptionLog(ExceptionLogEventData data, int level);
        /// <summary>
        /// 写登陆日志
        /// </summary>
        /// <param name="data">登陆日志数据</param>
        /// <param name="level">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public abstract bool WriteLoginLog(LoginLogEventData data, int level);
        /// <summary>
        /// 写客户反馈
        /// </summary>
        /// <param name="data">客户反馈日志数据</param>
        /// <param name="level">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public abstract bool WriteFeedbackLog(FeedbackEventData data, int level);
        #endregion 

        #region 原始数据传入  
        /// <summary>
        /// 写操作日志
        /// </summary>
		/// <param name="logLevel">日志级别</param>
		/// <param name="operateLevel">操作级别</param>
        /// <param name="appID">应用ID</param>
        /// <param name="operatorUser">操作员</param>
        /// <param name="operateDT">操作时间</param>
        /// <param name="operateDesc">操作描述</param>
        /// <param name="operateResult">操作结果</param>
        /// <param name="message">备注</param>
		/// <param name="operateCategory">操作归类</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteOperateLog(int logLevel, int operateLevel, string appID, string operatorUser,
                             DateTime operateDT, string operateDesc, string operateResult,
                             string message, string operateCategory)
        {
            OperateLogEventData data = new OperateLogEventData(logLevel, operateLevel, appID, operatorUser,
                             operateDT, operateResult,message, operateCategory);

            data.StationID = StationID;
            data.SystemID = SystemID;

            return WriteOperateLog(data, logLevel);
        }
        /// <summary>
        /// 写运行日志
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="appID">应用ID</param>
        /// <param name="data">运行日志消息</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteRunningLog(int logLevel, string appID, string data)
        {
            RunningLogEventData eventData = new RunningLogEventData(logLevel, appID,data);

            eventData.StationID = StationID;
            eventData.SystemID = SystemID;

            return WriteRunningLog(eventData, logLevel);
        }
        /// <summary>
        /// 写应用日志
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="appID">应用名称</param>
        /// <param name="componentName">组件名称</param>
        /// <param name="errType">错误类型</param>
        /// <param name="message">错误报告</param>
        /// <param name="messagePosition">错误报告位置</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteApplicationLog(int logLevel, string appID, string componentName, string errType,
                                    string message, string messagePosition)
        {
            ApplicationEventData eventData = new ApplicationEventData(logLevel, appID, componentName, errType,
                                    message, messagePosition);

            eventData.StationID = StationID;
            eventData.SystemID = SystemID;

            return WriteApplicationLog(eventData, logLevel);
        }
        /// <summary>
        /// 写异常日志
        /// </summary>
        /// <param name="ex">异常信息</param>
        /// <param name="level">日志级别</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteExceptionLog(Exception ex, int level)
        {
            ExceptionLogEventData eventData = new ExceptionLogEventData(ex);

            eventData.StationID = StationID;
            eventData.SystemID = SystemID;

            return WriteExceptionLog(eventData, level);
        }
        /// <summary>
        /// 写登陆日志
        /// </summary>
        /// <param name="logLevel">日志级别</param>
		/// <param name="appID">应用名称</param>
        /// <param name="userCode">登陆用户</param>
        /// <param name="message">登陆信息</param>
        /// <param name="loginDate">登陆时间</param>
        /// <param name="logIP">登陆IP</param>
        /// <param name="loginType">登陆类型</param>
        /// <param name="isWarn">是否报警</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteLoginLog(int logLevel, string appID, string userCode, string message,
                                 DateTime loginDate, string logIP, int loginType, bool isWarn)
        {
            LoginLogEventData eventData = new LoginLogEventData(logLevel, appID, userCode, message,
                                                            loginDate, logIP, loginType, isWarn);
            eventData.StationID = StationID;
            eventData.SystemID = SystemID;

            return WriteLoginLog(eventData, logLevel);
        }
        /// <summary>
        /// 写客户反馈
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="appID">应用名称</param>
        /// <param name="function">功能</param>
        /// <param name="message">错误报告</param>
        /// <param name="feedbackDesc">反馈意见</param>
        /// <param name="feedbackUser">反馈用户</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual bool WriteFeedbackLog(int logLevel, string appID, string function,
                                    string message, string feedbackDesc, string feedbackUser)
        {
            FeedbackEventData eventData = new FeedbackEventData(logLevel, appID, function, message, feedbackDesc,feedbackUser);
            eventData.StationID = StationID;
            eventData.SystemID = SystemID; 
            return WriteFeedbackLog(eventData, logLevel);
        }
        #endregion                                        
        /// <summary>
        /// 基类没有实现的方法 ，仅供内存队列Logger使用
        /// 
        /// 获得日志数据
        /// </summary>
        /// <param name="minDate">最小时间</param>
        /// <param name="logCategory">日志种类</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual ArrayList GetLog(DateTime minDate, string logCategory)
        {
            throw new NotImplementedException("没有实现的方法");
        } 
        /// <summary>
        /// 基类没有实现的方法，仅供内存队列Logger使用
        /// 
        /// 获得日志数据
        /// </summary>
        /// <param name="sn">日志记录序号</param>
        /// <param name="logCategory">日志种类</param>
        /// <returns>true：成功；false：失败</returns>
        public virtual ArrayList GetLog(long sn, string logCategory) 
        {
            throw new NotImplementedException("没有实现的方法");
        } 
    }
}
                        