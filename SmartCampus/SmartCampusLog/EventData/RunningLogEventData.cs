
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 运行日志数据
    /// 一般运行日志记载的是能够从日志还原程序运行轨迹的东西。主要给采集使用
    /// 
    /// 例如:
    /// 系统启动
    /// 读取配置文件成功，通信方式：RS232
    /// 数据库连接成功
    /// 通信线程启动成功
    /// 系统退出、
    /// </summary>
    [Serializable]
    public class RunningLogEventData : LogEventData
    {
        /// <summary>
        /// 构造
        /// </summary>
        public RunningLogEventData()
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="appID">应用ID</param>
        /// <param name="message">日志内容</param>
        public RunningLogEventData(int logLevel,string appID,string message)
        {
            this.AppID = appID; 
            // 数据，可自定义格式，以便于解析
            this.Message = message;
            this.Level = logLevel;
        }
        /// <summary>
        /// 应用编号
        /// </summary>
        public string AppID = "";
        /// <summary>
        /// 重载方法，获得格式化后的日志数据
        /// </summary>
        /// <returns>格式化后的日志数据</returns>
        public override string ToString()
        {
            string msg = String.Format("记录时间:{0},工作站:{1},子系统:{2},应用ID:{3},详细描述:{4}",
                                      CreateDate,StationID, SystemID, AppID, Message);
            return msg;
        }
    }
}
