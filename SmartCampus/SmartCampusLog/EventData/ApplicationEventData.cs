namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 应用日志事件数据
    /// 
    /// 主要记录应用系统设计缺陷、功能缺陷，非致命异常。
    /// </summary>
    [Serializable]
    public class ApplicationEventData : LogEventData
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="appID">应用编号</param>
        /// <param name="componentName">组件名称</param>
        /// <param name="errType">错误类型</param>
        /// <param name="message">日志消息</param>
        /// <param name="messagePosition">产生日志位置</param>
        public ApplicationEventData(int logLevel, string appID, string componentName, string errType,
                                    string message, string messagePosition)
        {
            this.Level = logLevel;
            this.AppID = appID;
            this.ComponentName = componentName;
            this.ErrType = errType;
            this.Message = message;
            this.MessagePosition = messagePosition;   
        }
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID = "未知";
        /// <summary>
        /// 组件名
        /// </summary>
        public string ComponentName = "未知";
        /// <summary>
        /// 错误类型
        /// </summary>
        public string ErrType = "未知";   
        /// <summary>
        /// 错误报告位置
        /// </summary>
        public string MessagePosition = "未知";
        /// <summary>
        /// 重载方法，获得格式化后的日志数据
        /// </summary>
        /// <returns>格式化后的日志数据</returns>
        public override string ToString()
        {
            string msg = String.Format("记录时间:{0},工作站:{1},子系统:{2},应用ID:{3} ,组件名称:{4}, 错误类型:{5},错误报告:{6}, 错误报告位置:{7}",
                                     CreateDate, StationID,SystemID,AppID, ComponentName, ErrType, Message,MessagePosition);
            return msg;
        }   
    }
}
