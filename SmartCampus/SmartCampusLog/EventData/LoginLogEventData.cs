
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 登陆日志事件数据
    /// 
    /// 记录系统登陆、退出、登陆失败数据
    /// </summary>  
    [Serializable]
    public class LoginLogEventData : LogEventData
    {
        /// <summary>
        /// 构造
        /// </summary>
        public LoginLogEventData()
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="appID">应用ID</param>
        /// <param name="userCode">用户编码</param>
        /// <param name="message">日志内容</param>
        /// <param name="loginDate">登陆时间</param>
        /// <param name="logIP">登陆IP</param>
        /// <param name="loginType">日志类型</param>
        /// <param name="isWarn">是否报警</param>
        public LoginLogEventData(int logLevel,string appID,string userCode,string message,
                                 DateTime loginDate,string logIP,int loginType,bool isWarn)
        {
            this.Level = logLevel;
            this.AppID = appID;
            this.UserCode = userCode;
            this.Message = message;
            this.LoginDate = loginDate;
            this.IP = logIP;
            this.LoginType = loginType;
            this.IsWarn = isWarn; 
        }
        /// <summary>
        /// 登陆应用名称
        /// </summary>
        public string AppID = "未知";
        /// <summary>
        /// 登陆用户
        /// </summary>
        public string UserCode = "未知";
        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTime LoginDate = System.DateTime.Now;
       
        /// <summary>
        /// 登陆IP
        /// </summary>
        public string IP = "未知";
        /// <summary>
        /// 是否报警
        /// </summary>
        public bool IsWarn = false;
        /// <summary>
        /// 登陆记录类型
        /// </summary>
        public int LoginType = LoginTypeEnum.Successed;
        /// <summary>
        /// 重载方法，获得格式化后的日志数据
        /// </summary>
        /// <returns>格式化后的日志数据</returns>
        public override string ToString()
        {
            string msg = String.Format("记录时间:{0},工作站:{1},子系统:{2},登陆应用:{3},登陆用户:{4} , 登陆消息:{5}, 登陆IP:{6},登陆类型:{7},是否报警:{8},登陆时间:{9}",
                                    CreateDate,StationID, SystemID, AppID, UserCode, Message, IP, LoginType, IsWarn, LoginDate);
            return msg;
        }
    }
}
