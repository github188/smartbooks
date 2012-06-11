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
        /// <summary>
        /// 获取装备类型实体数据
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public Entity.BASE_TERM_TYPE getModel(decimal typeid)
        {
            return dal.GetEntity(typeid);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        public void Add(Entity.BASE_TERM_TYPE model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_TERM_TYPE model)
        {
            return dal.Update(model);
        }
    }
}
