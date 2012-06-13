﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.Ascx {
    public partial class SystemModuleJSON : System.Web.UI.UserControl {

        public string JSON_SYSTEM_MODULE = "";
        BLL.BASE_MENU menu = new BLL.BASE_MENU();
        protected void Page_Load(object sender, EventArgs e) {
            ReturnMenuJSON();
        }

        public void ReturnMenuJSON() {
            string parentId = Request.Form["id"];
            if (parentId == "" || parentId == null) {
                JSON_SYSTEM_MODULE = menu.GetMenuJSON(0);
            } else {
                JSON_SYSTEM_MODULE = menu.GetMenuJSON(int.Parse(parentId));
            }
        }

        
    }
}