
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 异常日志事件数据
    /// </summary>
    [Serializable]
    public class ExceptionLogEventData : LogEventData
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="ex">异常对象</param>
        public ExceptionLogEventData(System.Exception ex)
        {
            CreateDate = System.DateTime.Now;
            Source = ex.Source;
            Type = ex.GetType().ToString();
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }
        /// <summary>
        /// 应用 
        /// </summary>
        public string AppID = "未知";
        /// <summary>
        /// 异常来源
        /// </summary>
        public string Source = "未知";
        /// <summary>
        /// 异常类型
        /// </summary>
        public string Type = "未知";
        /// <summary>
        /// 异常堆栈
        /// </summary>
        public string StackTrace = "未知";
        /// <summary>
        /// 重载方法，获得格式化后的日志数据
        /// </summary>
        /// <returns>格式化后的日志数据</returns>
        public override string ToString()
        {
            string msg = String.Format("记录时间:{0},工作站:{1},子系统:{2},应用名称:{3}, 异常来源:{4} , 异常类型:{5}, 异常消息:{6},异常堆栈:{7} ",
                                       CreateDate,StationID, SystemID, AppID, Source, Type, Message, StackTrace);
            return msg;
        }
    } 
}
