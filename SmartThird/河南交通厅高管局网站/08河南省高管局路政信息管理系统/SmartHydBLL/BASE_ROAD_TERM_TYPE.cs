using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ROAD_TERM_TYPE {
        private OracleDAL.BASE_ROAD_TERM_TYPE dal = new OracleDAL.BASE_ROAD_TERM_TYPE();

        /// <summary>
        /// 获取全部路产设备类型数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList() {
            return dal.GetAllList();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">实体</param>
        public void Add(Entity.BASE_ROAD_TERM_TYPE model) {
            dal.Add(model);
        }
    }
}
