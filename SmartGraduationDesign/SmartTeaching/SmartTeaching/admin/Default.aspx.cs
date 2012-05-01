using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckLogin();
            }
        }

        public void CheckLogin()
        {
            try
            {
                //CheckSession
                string u = Session["username"].ToString();
                string p = Session["pwd"].ToString();
                string ssid = Session["ssid"].ToString();

                if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p) || string.IsNullOrEmpty(ssid))
                {
                    Response.Redirect("Login.aspx", true);
                }
            }
            catch
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }
}