using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_TERM_TYPE {
        private OracleDAL.BASE_TERM_TYPE dal = new OracleDAL.BASE_TERM_TYPE();

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList() {
            return dal.GetAllList();
        }
    }
}
