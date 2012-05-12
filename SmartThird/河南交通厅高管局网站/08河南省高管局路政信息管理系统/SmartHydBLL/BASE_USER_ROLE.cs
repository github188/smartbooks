using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_USER_ROLE {
        private OracleDAL.BASE_USER_ROLE dal = new OracleDAL.BASE_USER_ROLE();

        /// <summary>
        /// 获取用户功能模块
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public DataTable GetList(int userId) {
            return dal.GetList(string.Format("USERID={0}", userId.ToString())).Tables[0];
        }

        public DataTable GetList(string where) {
            return dal.GetList(where).Tables[0];
        }
    }
}
