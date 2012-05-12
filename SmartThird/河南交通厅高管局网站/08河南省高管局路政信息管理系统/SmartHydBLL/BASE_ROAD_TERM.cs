using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.BLL {
    public class BASE_ROAD_TERM {
        private OracleDAL.BASE_ROAD_TERM dal = new OracleDAL.BASE_ROAD_TERM();
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">路产路产设备</param>
        public void Add(Entity.BASE_ROAD_TERM model) {
            dal.Add(model);
        }
    }
}
