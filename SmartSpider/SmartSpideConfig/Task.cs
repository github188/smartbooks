using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSpide.Config {
    public class Task {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string Description {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 任务状态
        /// </summary>
        public State State {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 运行时间
        /// </summary>
        public DateTime ElapsedTime {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartingTime {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 线程数量
        /// </summary>
        public int ThreadNumber {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 输出详细日志
        /// </summary>
        public bool OutputDetailedLog {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 保存日志到文件
        /// </summary>
        public bool SaveLogToFile {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 最后一个日志文件名称
        /// </summary>
        public string lastLogFileName {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// Cookie
        /// </summary>
        public string Cookie {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 登录网址
        /// </summary>
        public string LoginUrl {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 自动登录
        /// </summary>
        public bool LoginAutomatically {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 登录目标URL
        /// </summary>
        public string LoginTargetUrl {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 登录成功标志
        /// </summary>
        public string LoginSuccessFlag {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 定期登录
        /// </summary>
        public bool LoginAtRegularIntervals {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 登录间隔时间
        /// </summary>
        public int LoginInterval {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 使用插件登录
        /// </summary>
        public bool UsePluginOfLogin {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 登录网址的Referer
        /// </summary>
        public string LoginUrlReferer {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool ScheduleEnabled {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleMode {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleDays {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleHours {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleMinutes {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool ScheduleLimitTimeRange {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleFromHour {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleToHour {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleFromDayOfWeek {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleToDayOfWeek {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleFromDay {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public int ScheduleToDay {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool DisableScheduleAfterFinish {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 最后停止时间
        /// </summary>
        public DateTime lastStoppingTime {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public string PublicationTarget {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UseProcedure {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool PublishResultDircetly {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool DeleteResultAfterPublication {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool IgnoreDataColumnNotFound {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool SaveRepeatedRows {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 保存错误行
        /// </summary>
        public bool SaveErrorRows {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UsePluginOfProcessResultRow {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 当前结果计数
        /// </summary>
        public int CurrentResultCount {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 结果总数
        /// </summary>
        public int ResultCount {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 重复的行数
        /// </summary>
        public int RepeatedRowsCount {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 错误的行数
        /// </summary>
        public int ErrorRowsCount {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 插件路径
        /// </summary>
        public string PluginPath {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UsePluginOfDownloadContentFile {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UsePluginOfDownloadSingleFile {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UsePluginOfProcessContentFile {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UsePluginOfProcessSingleFile {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UsePluginOfFilter {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public bool UsePluginOfGetWebProxy {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 提取规则
        /// </summary>
        public SmartSpide.Config.ExtractionRule[] ExtractionRules {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public UrlListManager UrlListManager {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        public string PluginData {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
    }
}
