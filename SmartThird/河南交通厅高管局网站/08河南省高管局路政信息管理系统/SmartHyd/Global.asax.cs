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

            //保存路径
            string path = string.Format("{0}\\{1}.txt", Server.MapPath("~/Log"), DateTime.Now.ToString("yyyyMMdd"));
            string query = string.Empty;
            string form = string.Empty;
            string cookie = string.Empty;
            for (int i = 0; i < Request.QueryString.Count; i++) {
                query += Request.QueryString.GetKey(i) + "=";
                query += Request.QueryString.GetValues(i) + ";";
            }
            for (int i = 0; i < Request.Form.Count; i++) {
                form += Request.Form.GetKey(i) + "=";
                form += Request.Form.GetValues(i) + ";";
            }
            for (int i = 0; i < Request.Cookies.Count; i++) {
                cookie += Request.Cookies[i].Name + "=";
                cookie += Request.Cookies[i].Value + ";";
            }
            //错误详细信息
            //string errorMsg = string.Format("异常时间:{0}\n客户端IP:{1}\n页面地址:{2}\n浏览器:{3}\n代理信息:{4}\nQueryString:{5}\nForm:{6}\nCookie:{7}\nErrorTitle:{8}\nErrorContent:{9}\n\n",
            //    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
            //    Request.UserHostAddress,
            //    Request.Url.AbsoluteUri,
            //    Request.Browser.Version,
            //    Request.UserAgent,
            //    query, form, cookie,
            //    ex.Source,
            //    ex.Message);
            string errorMsg = string.Format("{0}\t{1}\n\n", 
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                ex.InnerException.Message
                );;

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