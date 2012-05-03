using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class UserManage : UI.BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.DeletePanel.Controls.Add(this.Button1);

            Label1.Text = Roles + "|";  //roles all
            Label1.Text += Request.Url.AbsolutePath + "|";  // /ManageCenter/UserManage.aspx
            Label1.Text += Request.Url.AbsoluteUri + "|";   // http://localhost:3710/ManageCenter/UserManage.aspx
            Label1.Text += Request.Url.Authority;   // localhost:3710
        }
    }
}