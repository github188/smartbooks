using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.BLL {
    public class BASE_ARTICLE_UNIT {
        private OracleDAL.BASE_ARTICLE_UNIT dal = new OracleDAL.BASE_ARTICLE_UNIT();
        
        public void Add(Entity.BASE_ARTICLE_UNIT model) {
            dal.Add(model);
        }
    }
}
