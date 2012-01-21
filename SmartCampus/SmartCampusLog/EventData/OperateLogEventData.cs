
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 操作日志事件数据
    /// 
    /// 记录系统操作日志，需要缓存到内存，按时间取数据，内存缓存数据定长
    /// </summary>
    [Serializable]
    public class OperateLogEventData : LogEventData  
    {
        /// <summary>
        /// 构造
        /// </summary>
        public OperateLogEventData()
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="loglevel">日志类型</param>
        /// <param name="operateLevel">操作级别</param>
        /// <param name="appID">应用ID</param>
        /// <param name="operatorUser">操作者</param>
        /// <param name="operateDT">操作时间</param>
        /// <param name="operateResult">操作结果</param>
        /// <param name="message">日志消息</param>
        /// <param name="operateCategory">操作种类</param>
        public OperateLogEventData(int loglevel,int operateLevel,string appID,string operatorUser,DateTime operateDT,
                                   string operateResult,string message,string operateCategory)
        {
            this.Level = loglevel;
            this.AppID = appID;
            this.Operator = operatorUser;
            this.RecordDate = operateDT;
 
            this.OperateLevel = operateLevel;
            this.OperateResult =operateResult;
            this.Message = message;
            this.OperateCategory = operateCategory; 

        }
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID = "未知";
        /// <summary>
        /// 操作者
        /// </summary>  
        public string Operator = "未知";
        /// <summary>
        /// 操作时间
        /// </summary>               
        public DateTime RecordDate = System.DateTime.Now;
        /// <summary>
        /// 操作级别
        /// </summary>
        public int OperateLevel = LogLevel.Info;
        /// <summary>
        /// 操作结果
        /// </summary>
        public string OperateResult = "未知";   
        /// <summary>
        /// 操作归类
        /// </summary>
        public string OperateCategory = "未知";
        /// <summary>
        /// 重载方法，获得格式化后的日志数据
        /// </summary>
        /// <returns>格式化后的日志数据</returns>
        public override string ToString()
        {
            string msg = String.Format("记录时间:{0} ,工作站:{1},子系统:{2},应用ID:{3},操作归类:{4},操作描述:{5},操作结果:{6},操作者:{7} , 操作时间:{8}",
                                      CreateDate,StationID, SystemID, AppID, OperateCategory, Message, OperateResult, Operator, RecordDate); 
            return msg;
        }   
    }
}
