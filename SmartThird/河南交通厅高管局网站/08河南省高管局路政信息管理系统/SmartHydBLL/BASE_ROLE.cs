using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.BLL {
    public class BASE_ROLE {
        private OracleDAL.BASE_ROLE roleDal = new OracleDAL.BASE_ROLE();

        public Entity.BASE_ROLE GetEntity(int roleId) {
            return roleDal.GetEntity(roleId);
        }
    }
}
