
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 不支持的Appender异常
    /// </summary>
    public class NonsupportAppenderException : ApplicationException 
    {
         /// <summary>
         /// 构造
         /// </summary>
         /// <param name="message">异常消息</param>
         public NonsupportAppenderException(string message)
             : base(message)
         {
         }
    }
}
