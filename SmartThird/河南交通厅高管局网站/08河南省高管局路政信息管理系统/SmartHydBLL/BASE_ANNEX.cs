using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ANNEX {
        private OracleDAL.BASE_ANNEX dal = new OracleDAL.BASE_ANNEX();

        public decimal Add(Entity.BASE_ANNEX model) {
            dal.Add(model);

            decimal id;
            string sqlString = string.Format("SERVERNAME='{0}'", model.SERVERNAME);
            string serverName = dal.GetList(sqlString).Tables[0].Rows[0]["ID"].ToString();
            id = Convert.ToDecimal(serverName);

            return id;
        }

        public void Update(Entity.BASE_ANNEX model) {
        }

        public void Del(decimal id) {
        }

        public DataTable GetList(string sqlString) {
            return dal.GetList(sqlString).Tables[0];
        }
    }
}
