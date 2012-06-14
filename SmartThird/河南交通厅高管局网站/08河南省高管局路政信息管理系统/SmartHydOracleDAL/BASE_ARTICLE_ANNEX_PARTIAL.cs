

namespace SmartHyd.OracleDAL {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data;
    using Smart.DBUtility;
    using System.Data.OracleClient;
    using IDAL;

    /// <summary>
    /// 为不影响代码生成的文件类(代码生成的类单独存放一个文件)，用分部类实现类隔离。
    /// </summary>
    public partial class BASE_ARTICLE_ANNEX {

        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Query(string sql) {
            return OracleHelper.Query(sql).Tables[0];
        }
    }
}
