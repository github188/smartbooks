using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ASSESS_TYPE {
        OracleDAL.BASE_ASSESS_TYPE dal = new OracleDAL.BASE_ASSESS_TYPE();


        public DataTable GetBelongDepartmentData(int deptCode) {
            string sqlString = string.Format("DEPTCODE={0} and STATUS=0 order by id DESC", deptCode.ToString());
            return dal.GetList(sqlString).Tables[0];
        }

        public bool Del(decimal id) {
            return dal.Delete(id);
        }

        public void UpdateStatusAsDelete(decimal id) {
            string sqlString = string.Format("update BASE_ASSESS_TYPE set STATUS=1 where ID={0}", id.ToString());
            dal.Query(sqlString);
        }

        public void Add(Entity.BASE_ASSESS_TYPE model) {
            dal.Add(model);
        }

        public Entity.BASE_ASSESS_TYPE GetEntity(decimal id) {
            return dal.GetEntity(id);
        }

        public bool Update(Entity.BASE_ASSESS_TYPE model) {
            return dal.Update(model);
        }
    }
}
