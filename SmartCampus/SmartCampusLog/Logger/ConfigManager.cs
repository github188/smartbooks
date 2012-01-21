
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 配置管理
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        public static string GetConnectionString()
        {
            return SmartCampus.Utility.ConnectionInfo.CONN_STRING;
        }
    }
}
