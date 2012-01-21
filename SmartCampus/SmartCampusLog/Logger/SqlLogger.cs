
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Configuration;
    using System.Data.SqlClient;
    using SmartCampus.Utility;

    /// <summary>
    /// 记录到Sql数据库
    /// </summary>
    public class SqlLogger : ILogger
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private readonly string connectionString = ConfigManager.GetConnectionString();
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="logLevel">日志级别</param>   
        public SqlLogger(int logLevel)
            : base(logLevel)
        {

        }

        /// <summary>
        /// 写通用日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="level">日志级别</param>
        /// <param name="fileName">日志文件名</param>    
        /// <returns>true：成功；false：失败</returns>
        public override bool WriteLog(string message, int level, string fileName)
        {
            if (level < this.logLevel)
                return true;

            string commandText = string.Format("INSERT INTO LOG_COMMON(MESSAGE,RECORDLEVEL,CREATEDATE,STATIONID,SYSTEMID) VALUES({0},'{1}','{2}',{3},{4}) ",
                                            "@prmMessage", level, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "@prmStationID", "@prmSystemID");

            #region 定义参数
            SqlParameter[] para = new SqlParameter[3];

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(SystemID, 30);

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(StationID, 30);

            para[2] = new SqlParameter();
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(message, 2000);
            #endregion

            return SqlAppender.ExecuteNonQuery(connectionString, commandText, para) > 0;
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
            string commandText = string.Format("INSERT INTO LOG_OPERATE(APPID,OPERATEUSER,OPERATEDATE,MESSAGE,OPERATELEVEL,OPERATERESULT,OPERATECATEGORY,RECORDLEVEL,CREATEDATE,STATIONID,SYSTEMID)" +
                                            "VALUES('{0}','{1}','{2}',{3},'{4}',{5},'{6}',{7},'{8}',{9},{10}) ",
                                            StringHelper.GetSubStr(data.AppID, 30),
                                            StringHelper.GetSubStr(data.Operator, 50),
                                            data.RecordDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "@prmMessage",
                                            StringHelper.GetSubStr(data.OperateLevel.ToString(), 30),
                                            "@prmOperateResult",
                                            StringHelper.GetSubStr(data.OperateCategory, 30),
                                            data.Level,
                                            System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                           "@prmStationID",
                                           "@prmSystemID");

            #region 定义参数
            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(data.SystemID, 30);

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(data.StationID, 30);

            para[2] = new SqlParameter();
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(data.Message, 2000);

            para[3] = new SqlParameter();
            para[3].Direction = ParameterDirection.Input;
            para[3].SqlDbType = SqlDbType.VarChar;
            para[3].ParameterName = "@prmOperateResult";
            para[3].Value = StringHelper.GetSubStr(data.OperateResult, 30);
            #endregion

            return SqlAppender.ExecuteNonQuery(connectionString, commandText, para) > 0;

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

            string commandText = string.Format("INSERT INTO LOG_RUNNING(APPID,MESSAGE,RECORDLEVEL,CREATEDATE,STATIONID,SYSTEMID)" +
                                            "VALUES('{0}',{1},{2},'{3}',{4},{5}) ",
                                            StringHelper.GetSubStr(data.AppID, 30),
                                             "@prmMessage",
                                            data.Level,
                                            System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "@prmStationID",
                                           "@prmSystemID");

            #region 定义参数
            SqlParameter[] para = new SqlParameter[3];

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(data.SystemID, 30);

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(data.StationID, 30);

            para[2] = new SqlParameter();
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(data.Message, 2000);

            #endregion
            return SqlAppender.ExecuteNonQuery(connectionString, commandText, para) > 0;
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

            string commandText = string.Format("INSERT INTO LOG_APPLICATION(APPID,COMPONENTNAME,ERRTYPE,Message,MessagePOSITION,RECORDLEVEL,CREATEDATE,STATIONID,SYSTEMID)" +
                                                "VALUES( '{0}','{1}','{2}',{3}, {4},{5},'{6}',{7},{8}) ",
                                                StringHelper.GetSubStr(data.AppID, 30),
                                                StringHelper.GetSubStr(data.ComponentName, 30),
                                                StringHelper.GetSubStr(data.ErrType, 30),
                                                "@prmMessage",
                                                "@prmMessagePosition",

                                                data.Level,
                                                System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                 "@prmStationID",
                                                 "@prmSystemID");

            #region 定义参数
            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(data.SystemID, 30);

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(data.StationID, 30);

            para[2] = new SqlParameter();
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(data.Message, 2000);

            para[3] = new SqlParameter();
            para[3].Direction = ParameterDirection.Input;
            para[3].SqlDbType = SqlDbType.VarChar;
            para[3].ParameterName = "@prmMessagePosition";
            para[3].Value = StringHelper.GetSubStr(data.MessagePosition, 50);
            #endregion

            return SqlAppender.ExecuteNonQuery(connectionString, commandText, para) > 0;
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

            string commandText = string.Format("INSERT INTO LOG_EXCEPTION(APPID,EXCEPTIONSOURCE,EXCEPTIONTYPE,MESSAGE,EXCEPTIONSTACKTRACE,RECORDLEVEL,CREATEDATE,STATIONID,SYSTEMID)" +
                                               "VALUES('{0}',{1},'{2}',{3},{4},{5},'{6}',{7},{8}) ",
                                                StringHelper.GetSubStr(data.AppID, 30),
                                               "@prmSource",
                                                StringHelper.GetSubStr(data.Type, 30),
                                                "@prmMessage",
                                                "@prmStackTrace",
                                                data.Level,
                                                System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                 "@prmStationID",
                                                 "@prmSystemID");

            #region 定义参数
            SqlParameter[] para = new SqlParameter[5];

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(data.SystemID, 30);

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(data.StationID, 30);

            para[2] = new SqlParameter();
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(data.Message, 2000);

            para[3] = new SqlParameter();
            para[3].Direction = ParameterDirection.Input;
            para[3].SqlDbType = SqlDbType.VarChar;
            para[3].ParameterName = "@prmStackTrace";
            para[3].Value = StringHelper.GetSubStr(data.StackTrace, 1000);

            para[4] = new SqlParameter();
            para[4].Direction = ParameterDirection.Input;
            para[4].SqlDbType = SqlDbType.VarChar;
            para[4].ParameterName = "@prmSource";
            para[4].Value = StringHelper.GetSubStr(data.Source, 30);
            #endregion
            return SqlAppender.ExecuteNonQuery(connectionString, commandText, para) > 0;
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

            string commandText = string.Format("INSERT INTO LOG_LOGIN(APPID,USERCODE,MESSAGE,LOGINDATE,IP,ISWARN,LOGINTYPE,RECORDLEVEL,CREATEDATE,STATIONID,SYSTEMID)" +
                                                "VALUES('{0}','{1}',{2},'{3}','{4}',{5},{6},{7},'{8}',{9},{10}) ",
                                                StringHelper.GetSubStr(data.AppID, 30),
                                                StringHelper.GetSubStr(data.UserCode, 30),
                                                "@prmMessage",
                                                data.LoginDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                                StringHelper.GetSubStr(data.IP, 32),
                                                data.IsWarn == true ? 1 : 0,
                                                data.LoginType,
                                                data.Level,
                                                System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                 "@prmStationID",
                                                 "@prmSystemID");

            #region 定义参数
            SqlParameter[] para = new SqlParameter[3];

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(data.SystemID, 30);

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(data.StationID, 30);

            para[2] = new SqlParameter();
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(data.Message, 2000);    
           
            #endregion

            return SqlAppender.ExecuteNonQuery(connectionString, commandText, para) > 0;
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

            string commandText = string.Format("INSERT INTO LOG_FEEDBACK(APPID,FEEDTYPE,Message,FEEDBACKDESC,FEEDBACKUSER,RECORDLEVEL,CREATEDATE,STATIONID,SYSTEMID)" +
                                         "VALUES('{0}','{1}',{2},{3},'{4}',{5},'{6}',{7},{8}) ",
                                                StringHelper.GetSubStr(data.AppID, 30),
                                                StringHelper.GetSubStr(data.FeedbackType, 30),
                                                "@prmMessage",
                                                "@prmFeedbackDesc",
                                                StringHelper.GetSubStr(data.FeedbackUser, 32),
                                                data.Level,
                                                System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                "@prmStationID",
                                                 "@prmSystemID");

            #region 定义参数
            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter();
            para[0].Direction = ParameterDirection.Input;
            para[0].SqlDbType = SqlDbType.VarChar;
            para[0].ParameterName = "@prmSystemID";
            para[0].Value = StringHelper.GetSubStr(data.SystemID, 30);

            para[1] = new SqlParameter();
            para[1].Direction = ParameterDirection.Input;
            para[1].SqlDbType = SqlDbType.VarChar;
            para[1].ParameterName = "@prmStationID";
            para[1].Value = StringHelper.GetSubStr(data.StationID, 30);

            para[2] = new SqlParameter();
            para[2].Direction = ParameterDirection.Input;
            para[2].SqlDbType = SqlDbType.VarChar;
            para[2].ParameterName = "@prmMessage";
            para[2].Value = StringHelper.GetSubStr(data.Message, 2000);

            para[3] = new SqlParameter();
            para[3].Direction = ParameterDirection.Input;
            para[3].SqlDbType = SqlDbType.VarChar;
            para[3].ParameterName = "@prmFeedbackDesc";
            para[3].Value = StringHelper.GetSubStr(data.FeedbackDesc, 32);
            #endregion

            return SqlAppender.ExecuteNonQuery(connectionString, commandText, para) > 0;
        }
        #endregion
    }
}
