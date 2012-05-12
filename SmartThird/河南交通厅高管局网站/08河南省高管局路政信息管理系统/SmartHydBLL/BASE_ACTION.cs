using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.BLL {
    public class BASE_ACTION {
        private OracleDAL.BASE_ACTION dal = new OracleDAL.BASE_ACTION();

        public Entity.BASE_ACTION GetEntity(int ActionId) {
            return dal.GetEntity(ActionId);
        }
    }
}
