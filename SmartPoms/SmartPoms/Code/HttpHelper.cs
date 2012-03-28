using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace SmartPoms.Code {
    public class HttpHelper {

        /// <summary>
        /// 发送一次HTTP请求
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="referer">referer地址</param>
        /// <param name="method">请求模式</param>
        /// <param name="data">post数据(仅用于POST模式)</param>
        public static string RequestResult(string url, string referer, HttpMethod method, string data, Encoding enc) {
            HttpWebRequest _WebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            _WebRequest.CookieContainer = new CookieContainer();
            _WebRequest.Method = method.ToString();
            _WebRequest.Accept = "*/*";
            _WebRequest.ContentType = "application/x-www-form-urlencoded";
            if (method == HttpMethod.POST) {
                byte[] buffer = enc.GetBytes(data);
                _WebRequest.ContentLength = buffer.Length;
                _WebRequest.GetRequestStream().Write(buffer, 0, buffer.Length);
            }
            HttpWebResponse _WebResponse = (HttpWebResponse)_WebRequest.GetResponse();
            StreamReader read = new StreamReader(_WebResponse.GetResponseStream(), enc);
            string htmlText = read.ReadToEnd();
            read.Close();
            read.Dispose();
            return htmlText;
        }
    }
}