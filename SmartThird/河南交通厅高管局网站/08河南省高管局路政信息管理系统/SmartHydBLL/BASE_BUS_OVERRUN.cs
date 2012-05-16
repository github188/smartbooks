using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public delegate void OnCompleteSingle(int size, int count);

    public class BASE_BUS_OVERRUN {
        public event OnCompleteSingle On_CompleteSingle;

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
        /// 执行导入数据到Oracle
        /// </summary>
        /// <param name="tabname">表名</param>
        /// <param name="connectionAccess">Access连接字符串</param>
        /// <param name="resNum">返回结果数</param>
        public void ExecImportDataToOracle(string tabname, string connectionAccess) {
            dal.On_CompleteSingle +=new OracleDAL.OnCompleteSingle(dal_On_CompleteSingle);
            dal.ExecImportDataToOracle(tabname, connectionAccess);            
        }
        private void dal_On_CompleteSingle(int size, int count) {
            if (On_CompleteSingle != null) {
                On_CompleteSingle(size, count);
            }
        }        
    }
}
