using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Office : UI.BaseUserControl
    {
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_PLAN planbll = new BLL.BASE_PLAN();
        private BLL.BASE_AFFICHE affichebll = new BLL.BASE_AFFICHE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }





    }
}