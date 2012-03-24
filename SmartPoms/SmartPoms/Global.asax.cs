using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;

namespace SmartPoms {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {
            /*设置WebUrl、ConnectionStrings*/
            //ConfigurationManager.AppSettings["WebUrl"] = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //System.IO.File.AppendAllText(path + "log.txt",System.Web.HttpContext.Current.Request.Url.AbsolutePath + "\r\n" + System.Web.HttpContext.Current.Request.Url.AbsoluteUri+"\r\n"+ HttpContext.Current.Request.Url.Authority);
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}