
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 日志级别
    /// </summary>
    public sealed class LogLevel
    {
        /// <summary>
        /// 记录所有级别日志: Trace
        /// </summary>
        public const int All = 0;
        /// <summary>
        /// 调试信息
        /// </summary>
        public const int Debug = 1;
        /// <summary>
        /// 正常信息
        /// </summary>
        public const int Info = 2;
        /// <summary>
        /// 报警信息
        /// </summary>
        public const int Warn = 3;
        /// <summary>
        /// 错误信息
        /// </summary>
        public const int Error = 4;
        /// <summary>
        /// 严重错误
        /// </summary>
        public const int Fatal = 5;
        /// <summary>
        /// 不记录日志
        /// </summary>
        public const int Off = 1000;  
    }
}
