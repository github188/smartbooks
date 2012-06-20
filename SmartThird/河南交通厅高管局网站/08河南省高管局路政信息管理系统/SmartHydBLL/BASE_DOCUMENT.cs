using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_DOCUMENT {
        private OracleDAL.BASE_DOCUMENT dal = new OracleDAL.BASE_DOCUMENT();

        public void Add(Entity.BASE_DOCUMENT model) {
            dal.Add(model);
        }

        public void Update(Entity.BASE_DOCUMENT model) {
            dal.Update(model);
        }

        public Entity.BASE_DOCUMENT GetEntity(decimal id) {
            return dal.GetEntity(id);
        }

        public DataTable GetList(decimal deptCode) {
            return dal.GetList(string.Format("DEPTCODE={0} order by ID", deptCode.ToString())).Tables[0];
        }

        public void Del(decimal id) {
            dal.Delete(id);
        }
    }
}
