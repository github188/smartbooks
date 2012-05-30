using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHyd.Ashx {
    /// <summary>
    /// 验证码
    /// </summary>
    public class VerificationCode : IHttpHandler {

        public void ProcessRequest(HttpContext context) {

            Random rd = new Random();
            string code = string.Empty;
            Smart.Utility.ValidateCode verificationCode = new Smart.Utility.ValidateCode();
            verificationCode.Border = true;
            verificationCode.BorderWidth = 1;
            verificationCode.Chaos = true;
            verificationCode.Length = 4;            

            //生成随机数字
            code = string.Format("{0}{1}{2}{3}",
                rd.Next(0, 9).ToString(),
                rd.Next(0, 9).ToString(),
                rd.Next(0, 9).ToString(),
                rd.Next(0, 9).ToString());

            //加入cookie
            context.Response.Cookies.Add(new HttpCookie("code", code));

            verificationCode.CreateImageOnPage(code, context);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}