﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter
{
    public partial class DeptManage : UI.BaseUserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // AjaxPro.Utility.RegisterTypeForAjax(typeof(DeptManage));//对AjaxPro在页Page_Load事件中进行运行时注册;
            if (!IsPostBack)
            {
                
            }
        }
    }
}