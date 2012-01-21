
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 反馈信息事件数据
    /// 
    /// 记录用户反馈的系统使用中问题
    /// </summary>
    [Serializable]
    public class FeedbackEventData : LogEventData
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel">日志类型</param>
        /// <param name="appID">应用ID</param>
        /// <param name="feedbackType">客户反馈类型</param>
        /// <param name="message">消息</param>
        /// <param name="feedbackDesc">反馈描述</param>
        /// <param name="feedbackUser">反馈用户</param>
        public FeedbackEventData(int logLevel, string appID, string feedbackType,
                                    string message, string feedbackDesc, string feedbackUser)
        {
            this.Level = logLevel;
            this.AppID = appID;
            this.FeedbackType = feedbackType;
            this.FeedbackDesc = feedbackDesc;
            this.Message = message;
            this.FeedbackUser = feedbackUser;
        }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppID = "未知";
        /// <summary>
        /// 功能名称
        /// </summary>
        public string FeedbackType = "未知";   
        /// <summary>
        /// 反馈意见
        /// </summary>
        public string FeedbackDesc = "未知";
        /// <summary>
        /// 反馈者
        /// </summary>
        public string FeedbackUser = "未知";
        /// <summary>
        /// 重载方法，获得格式化后的日志数据
        /// </summary>
        /// <returns>格式化后的日志数据</returns>
        public override string ToString()
        {
            string msg = String.Format("记录时间:{0},工作站:{1},子系统:{2},应用名称:{3} ,反馈类型:{4}, 反馈消息:{5}, 反馈意见:{6}, 反馈者:{7}",
                                     CreateDate,StationID, SystemID, AppID, FeedbackType, Message, FeedbackDesc, FeedbackUser);
            return msg;
        }
    }
}
