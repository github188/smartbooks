using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_MENU {
        private OracleDAL.BASE_MENU dal = new OracleDAL.BASE_MENU();

        public void Add(Entity.BASE_MENU model) {
            dal.Add(model);
        }

        public Entity.BASE_MENU GetEntity(int menuId) {
            return dal.GetEntity(menuId);
        }
        public DataTable GetList(string strwhere)
        {
            return dal.GetList(strwhere).Tables[0];
        }
    }
}
