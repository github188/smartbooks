using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace SmartPoms.Api {
    /// <summary>
    /// SinaWB 的摘要说明
    /// </summary>
    public class HttpUtility : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            /*获取Url地址，并发送get请求返回json数据*/            
            string url = context.Request.QueryString["u"];  /*url地址*/
            string c = context.Request.QueryString["c"];    /*结果编码*/
            string result = string.Empty;
            url = context.Server.UrlDecode(url);
            c = string.IsNullOrEmpty(c) ? "utf-8" : c;
            if (!string.IsNullOrEmpty(url)) {
                result = Code.HttpHelper.RequestResult(url, "", Code.HttpMethod.GET, "",Encoding.GetEncoding(c));
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}