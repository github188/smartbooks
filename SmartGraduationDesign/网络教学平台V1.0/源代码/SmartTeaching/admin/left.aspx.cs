using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindRoleFun();
            }
        }
        private void BindRoleFun() {
            try {
                string userName = Session["username"].ToString();
                HtmlGenericControl addnews = (HtmlGenericControl)this.FindControl("addnews");
                HtmlGenericControl newsmgr = (HtmlGenericControl)this.FindControl("newsmgr");
                HtmlGenericControl newstype = (HtmlGenericControl)this.FindControl("newstype");
                HtmlGenericControl rolemgr = (HtmlGenericControl)this.FindControl("rolemgr");
                HtmlGenericControl addrole = (HtmlGenericControl)this.FindControl("addrole");
                HtmlGenericControl adduser = (HtmlGenericControl)this.FindControl("adduser");
                HtmlGenericControl usermgr = (HtmlGenericControl)this.FindControl("usermgr");
                HtmlGenericControl msg = (HtmlGenericControl)this.FindControl("msg");

                if (userName.Equals("admin")) {
                    addnews.Visible = true;
                    newsmgr.Visible = true;
                    newstype.Visible = true;
                    rolemgr.Visible = true;
                    addrole.Visible = true;
                    adduser.Visible = true;
                    usermgr.Visible = true;
                    msg.Visible = true;
                    return;
                } else if (userName.Equals("teching")) {
                    addnews.Visible = true;
                    newsmgr.Visible = true;
                    newstype.Visible = false;
                    rolemgr.Visible = false;
                    addrole.Visible = false;
                    adduser.Visible = true;
                    usermgr.Visible = true;
                    msg.Visible = true;
                    return;
                } else if (userName.Equals("student")) {
                    addnews.Visible = false;
                    newsmgr.Visible = true;
                    newstype.Visible = false;
                    rolemgr.Visible = false;
                    addrole.Visible = false;
                    adduser.Visible = false;
                    usermgr.Visible = false;
                    msg.Visible = true;
                } else if (userName.Equals("guest")) {
                    addnews.Visible = false;
                    newsmgr.Visible = false;
                    newstype.Visible = false;
                    rolemgr.Visible = false;
                    addrole.Visible = false;
                    adduser.Visible = false;
                    usermgr.Visible = false;
                    msg.Visible = true;
                }
            } catch {
            }
        }
    }
}