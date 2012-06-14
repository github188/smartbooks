using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Smart.DBUtility;

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

        public string GetMenuJSON(int parentId) {
            string menuJSON = "";

            TreeJsonHelper treeJson = new TreeJsonHelper();
            treeJson.success = true;
            DataTable dtMenu = dal.GetMenuList(parentId);
            try {
                foreach (DataRow dr in dtMenu.Rows) {
                    treeJson.AddItem("id", dr["MENUID"].ToString());
                    treeJson.AddItem("text", dr["MENUNAME"].ToString());
                    treeJson.AddItem("parentid", dr["PARENTID"].ToString());
                    treeJson.AddItem("iconCls", dr["ICONCLS"].ToString());
                    treeJson.AddItem("leaf", dr["ISLEAF"].ToString());
                    treeJson.AddItem("href",dr["MENUURL"].ToString());
                    treeJson.ItemOk();
                }
                menuJSON = treeJson.ToString();
            } catch (Exception EX) {
                throw EX;
            }

            return menuJSON;
        }

        
    }
}
