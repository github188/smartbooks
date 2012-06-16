using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_AREA {
        private OracleDAL.BASE_AREA dal = new OracleDAL.BASE_AREA();

        public void Add(Entity.BASE_AREA model) {
            dal.Add(model);
        }

        public DataTable GetDept(int detCode) {
            string sqlString = string.Format("select * from base_area where DEPTID={0}", detCode.ToString());
            return dal.Query(sqlString);
        }

        public bool Delete(int id) {
            return dal.Delete(id);
        }

        public Entity.BASE_AREA GetModel(int id) {
            return dal.GetEntity(id);
        }
    }
}
