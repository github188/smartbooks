using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_TERM {
        private OracleDAL.BASE_TERM termDal = new OracleDAL.BASE_TERM();

        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="model"></param>
        public void Add(Entity.BASE_TERM model) {
            termDal.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_TERM model)
        {
            return termDal.Update(model);
        }
        /// <summary>
        /// 获取部门下装备数据
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public DataTable GetTermList(int deptId) {
            return termDal.GetTermList(deptId);
        }
        /// <summary>
        /// 获取装备实体数据
        /// </summary>
        /// <param name="termid"></param>
        /// <returns></returns>
        public Entity.BASE_TERM getModel( decimal termid)
        {
            return termDal.GetEntity(termid);
        }
        /// <summary>
        /// 根据条件获取装备信息
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable getTermList(string strwhere)
        {
            return termDal.GetList(strwhere).Tables[0];
        }
    }
}
