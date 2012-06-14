using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ARTICLE_ANNEX {
        private OracleDAL.BASE_ARTICLE_ANNEX dal = new OracleDAL.BASE_ARTICLE_ANNEX();

        public void Add(Entity.BASE_ARTICLE_ANNEX model) {
            dal.Add(model);
        }

        public int GetMaxId() {
            string sql = "select max(id) from base_article_annex";
            DataTable dt = new DataTable();
            dt = dal.Query(sql);

            if (dt != null && dt.Rows.Count != 0) {
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            else {
                return -1;
            }
        }
    }
}
