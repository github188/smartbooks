using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smart.Utility;

namespace SmartPoms.Api {
    /// <summary>
    /// VerificationCode 的摘要说明
    /// </summary>
    public class VerificationCode : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            Random r = new Random();
            string c = string.Format("{0}{1}{2}{3}",
                r.Next(0, 9).ToString(),
                r.Next(0, 9).ToString(),
                r.Next(0, 9).ToString(),
                r.Next(0, 9).ToString());
            context.Response.Cookies.Add(new HttpCookie("captche", c));
            ValidateCode code = new ValidateCode();
            code.Chaos = true;
            code.CreateImageOnPage(c, context);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}