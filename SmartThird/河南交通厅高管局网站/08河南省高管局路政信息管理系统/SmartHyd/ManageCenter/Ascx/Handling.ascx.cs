using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Handling : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtBEGINDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtENDDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
    }
}