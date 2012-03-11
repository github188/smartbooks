
namespace Smart.ServiceFactory
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 配置未加载异常
    /// </summary>
    public class ConfigWithoutLoadException : ApplicationException
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message">异常消息</param>
        public ConfigWithoutLoadException(string message)
            : base(message)
        {
        }
    }

}
