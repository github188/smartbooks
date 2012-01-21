
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 日志事件数据基类
    /// </summary>
    public class LogEventData
    {
        /// <summary>
        /// 日志时间
        /// </summary>
        public DateTime CreateDate = System.DateTime.Now;
        /// <summary>
        /// 日志级别
        /// </summary>
        public int  Level;
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Message;

        /// <summary>
        /// 日志序号，为内存数据建立的版本
        /// </summary>
        public long SN = 0;
        /// <summary>
        /// 工作站ID
        /// </summary>
        public string StationID = "未定义";
        /// <summary>
        /// 子系统ID
        /// </summary>
        public string SystemID = "未定义";    
    }
}
