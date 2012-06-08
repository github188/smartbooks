using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class SysManager :UI.BaseUserControl
    {
        private BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_MENU menubll = new BLL.BASE_MENU();
        private BLL.BASE_ROLE rolebll = new BLL.BASE_ROLE();
        private BLL.BASE_ACTION actionbll = new BLL.BASE_ACTION();
        private BLL.BASE_USER_ROLE userRolebll = new BLL.BASE_USER_ROLE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
       
     
       

       
    }
}