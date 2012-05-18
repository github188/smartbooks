using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ROLE {
        private OracleDAL.BASE_ROLE roleDal = new OracleDAL.BASE_ROLE();

        public Entity.BASE_ROLE GetEntity(int roleId) {
            return roleDal.GetEntity(roleId);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        public void Add(Entity.BASE_ROLE model)
        {
            roleDal.Add(model);
        }
        /// <summary>
        /// 根据条件获取角色列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            return roleDal.GetList(strWhere).Tables[0];
        }
    }
}
