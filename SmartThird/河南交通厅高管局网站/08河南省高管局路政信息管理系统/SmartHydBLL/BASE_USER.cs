using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_USER {
        private OracleDAL.BASE_USER dal = new OracleDAL.BASE_USER();

        public DataTable GetAllUser() {
            return dal.GetAllList();
        }

        public void Add(Entity.BASE_USER model) {
            dal.Add(model);
        }
    }
}
