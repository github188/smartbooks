using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSpide.Config {
    public enum DatabaseType {
        /// <summary>
        /// Access数据库
        /// </summary>
        Access = 0,
        /// <summary>
        /// SqlServer数据库
        /// </summary>
        SqlServer = 1,
        /// <summary>
        /// MySql数据库
        /// </summary>
        MySql = 2,
        /// <summary>
        /// Oracle数据库
        /// </summary>
        Oracle = 3,
        /// <summary>
        /// SqlLite数据库
        /// </summary>
        SqlLite = 4,
    }
}
