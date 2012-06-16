using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_AREA_TYPE {
        private OracleDAL.BASE_AREA_TYPE dal = new OracleDAL.BASE_AREA_TYPE();

        public DataTable GetAllList() {
            return dal.GetList("1=1").Tables[0];            
        }
    }
}
