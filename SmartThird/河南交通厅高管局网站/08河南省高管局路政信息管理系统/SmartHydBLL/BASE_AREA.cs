using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.BLL {
    public class BASE_AREA {
        private OracleDAL.BASE_AREA dal = new OracleDAL.BASE_AREA();

        public void Add(Entity.BASE_AREA model) {
            dal.Add(model);
        }
    }
}
