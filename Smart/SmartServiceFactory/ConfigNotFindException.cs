
namespace Smart.ServiceFactory
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 配置未发现异常
    /// </summary>
    public class ConfigNotFindException : ApplicationException
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message">异常消息</param>
        public ConfigNotFindException(string message)
            : base(message)
        {
        }
    }
}
