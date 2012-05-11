using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_TERM {
        private OracleDAL.BASE_TERM termDal = new OracleDAL.BASE_TERM();

        public void Add(Entity.BASE_TERM model) {
            termDal.Add(model);
        }

        /// <summary>
        /// 获取部门下装备数据
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public DataTable GetTermList(int deptId) {
            return termDal.GetTermList(deptId);
        }
    }
}
