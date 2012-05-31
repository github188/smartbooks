using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Text;

namespace SmartHyd {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

        }

        protected void Session_Start(object sender, EventArgs e) {
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {
            /*
             * 开发模式下请注释掉该段代码，上线运行期间请去掉注释。
             */
            //SaveError();
        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }

        /// <summary>
        /// 保存异常信息到日志文件
        /// </summary>
        private void SaveError() {
            Exception ex = Server.GetLastError();
            string path = string.Format("{0}\\{1}.txt", Server.MapPath("~/Log"), DateTime.Now.ToString("yyyyMMdd"));
            string message = string.Empty;

            if (ex.InnerException != null) {
                message = ex.InnerException.Message;
                message += "\t异常对象:" + ex.InnerException.StackTrace;
            } else {
                message = ex.Message;
                message += "\t异常对象:" + ex.StackTrace;
            }
            string errorMsg = string.Format("{0}\t{1}\n\n", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), message);

            //保存错误日志
            File.AppendAllText(path, errorMsg, Encoding.UTF8);

            //页面跳转
            Server.ClearError();
            if (Request.UrlReferrer != null) {
                Session["referer"] = Request.UrlReferrer.AbsoluteUri;
            } else {
                Session["referer"] = "";
            }

            /*出错跳转页面*/
            string errorPath = "~/Error.aspx";
            if (ex.InnerException != null) {
                Session["error"] = ex.InnerException;
            } else {
                Session["error"] = ex;
            }
            Response.Redirect(errorPath, true);
        }
    }
}