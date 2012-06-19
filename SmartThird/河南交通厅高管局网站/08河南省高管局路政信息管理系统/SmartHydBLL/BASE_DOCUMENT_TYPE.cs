using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_DOCUMENT_TYPE {
        private OracleDAL.BASE_DOCUMENT_TYPE dal = new OracleDAL.BASE_DOCUMENT_TYPE();

        public Entity.BASE_DOCUMENT_TYPE GetEntity(decimal id) {
            return dal.GetEntity(id);
        }

        public void Add(SmartHyd.Entity.BASE_DOCUMENT_TYPE model) {
            dal.Add(model);
        }

        public void Update(SmartHyd.Entity.BASE_DOCUMENT_TYPE model) {
            dal.Update(model);
        }

        public DataTable GetList(decimal deptCode) {
            string sqlString = string.Format("DEPTCODE={0} AND STATUS=0", deptCode.ToString());
            return dal.GetList(sqlString).Tables[0];
        }

        public void UpdateStatusAsDelete(decimal id) {
            string sqlString = string.Format("update BASE_DOCUMENT_TYPE set STATUS=1 where ID={0}", id.ToString());
            dal.Query(sqlString);
        }
    }
}
