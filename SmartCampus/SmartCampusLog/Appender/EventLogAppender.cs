
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using System.Collections;

    /// <summary>
    /// 写入系统日志Appender
    /// </summary>
    public class EventLogAppender : IAppender
    {
        private const string logName = "SmartCampus Log";
        /// <summary>
        /// 写日志到Windows系统日志
        /// </summary>
        /// <param name="logSource"> 应用程序在本地计算机上注册时所采用的源名称。</param>
        /// <param name="msg"></param>
        public void WriteLog(string logSource,string msg)
        {    
            if (!EventLog.SourceExists(logSource))
            {
                EventLog.CreateEventSource(logSource, logName);
            }
             
            EventLog log = new EventLog(logName,".",logSource);
            log.Source = logSource;
            
            log.WriteEntry(msg);
        }
        /// <summary>
        /// 获取系统日志
        /// </summary>
        /// <param name="logSource"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public ArrayList ReadLog(string logSource, int size)
        {
            if (!EventLog.SourceExists(logSource) || size <= 0)
            {
                return null; 
            }   

            EventLog log = new EventLog();
            log.Source = logSource;   

            size = size > log.Entries.Count ? log.Entries.Count : size;
            size = size > 10000 ? 10000 : size;    

            ArrayList al = new ArrayList(size);

            for (int i = 0; i < size ; i++)
            {
                al.Add(log.Entries[i]);
            }
            return al;
        }
    }
}
