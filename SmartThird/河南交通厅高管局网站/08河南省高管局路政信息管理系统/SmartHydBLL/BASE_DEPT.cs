using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace SmartHyd.BLL {
    public class BASE_DEPT {
        private OracleDAL.BASE_DEPT dal = new OracleDAL.BASE_DEPT();

        /// <summary>
        /// 获取用户所属的部门和子部门
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="issubdept">0:包含子部门,其他:用户所属部门</param>
        /// <returns>部门信息</returns>
        public DataTable GetUserWhereDepartment(string userName, int issubdept) {
            //校验用户名合法性

            return dal.GetUserWhereDepartment(userName, issubdept);
        }
    }
}
