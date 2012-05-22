using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ARTICLE_TYPE {
        private OracleDAL.BASE_ARTICLE_TYPE dal = new OracleDAL.BASE_ARTICLE_TYPE();

        public DataTable GetList(string where) {
            return dal.GetList(where).Tables[0];
        }

        public void Add(Entity.BASE_ARTICLE_TYPE model) {
            dal.Add(model);
        }

        /// <summary>
        /// 根据部门ID不去部门下档案分类数据
        /// </summary>
        /// <param name="deptCode">部门编号</param>
        /// <returns></returns>
        public DataTable GetDeptNodeData(int deptCode) {
            return dal.GetList(string.Format("DEPTID={0}", deptCode.ToString())).Tables[0];
        }
    }
}
