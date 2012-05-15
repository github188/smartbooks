using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_BUS_OVERRUN {
        private OracleDAL.BASE_BUS_OVERRUN dal = new OracleDAL.BASE_BUS_OVERRUN();

        /// <summary>
        /// 获取预览数据
        /// </summary>
        /// <param name="beginTime">导入数据开始时间</param>
        /// <param name="endTime">导入数据结束时间</param>
        /// <returns></returns>
        public DataTable GetPreviewData(DateTime beginTime, DateTime endTime) {
            string where = string.Format("IMPORTDATE >= TO_DATE('{0}','yyyy-mm-dd hh24:mi:ss') AND IMPORTDATE <= TO_DATE('{1}','yyyy-mm-dd hh24:mi:ss')",
                beginTime.ToString("yyyy-MM-dd HH:mm:ss"),
                endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return dal.GetList(where).Tables[0];
        }

        /// <summary>
        /// 导入数据到表中
        /// </summary>
        /// <param name="source">数据源</param>
        public void ImportData(DataTable source) {
            dal.ImportData(source);
        }

        public DataTable GetImportData(string tabname, string connectionAccess) {
            return dal.GetImportData(tabname, connectionAccess);
        }
    }
}
