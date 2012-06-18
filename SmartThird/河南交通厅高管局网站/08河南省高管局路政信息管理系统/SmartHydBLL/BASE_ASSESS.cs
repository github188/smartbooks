using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ASSESS {
        private OracleDAL.BASE_ASSESS dal = new OracleDAL.BASE_ASSESS();
        
        public void Update(Entity.BASE_ASSESS model) {
            dal.Update(model);
        }

        public void Add(Entity.BASE_ASSESS model) {
            dal.Add(model);
        }

        public Entity.BASE_ASSESS GetEntity(decimal id) {
            return dal.GetEntity(id);
        }

        public void UpdateStatusAsDelete(decimal id) {
            string sqlString = string.Format("STATUS=1", id.ToString());
            dal.Query(sqlString);
        }

        public DataTable GetList(decimal deptCode, decimal typeCode, DateTime beginTime, DateTime endTime) {
            DataTable dt = new DataTable();
            string sqlString = string.Format("DEPTCODE={0} and TYPEID={1} and TICKTIME>=to_date('{2}','yyyy-mm-dd') and TICKTIME<=to_date('{3}','yyyy-mm-dd') order by TICKTIME desc", 
                deptCode.ToString(),
                typeCode.ToString(),
                beginTime.ToString("yyyy-MM-dd"),
                endTime.ToString("yyyy-MM-dd"));
            dt = dal.GetList(sqlString).Tables[0];
            return dt;
        }
    }
}
