namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;

    public class HttpHelper {
        /// <param name="handers">Hander集合</param>
        /// <param name="method">Http请求方式</param>
        /// <param name="encoding">网页数据编码</param>
        /// <param name="timeOut">请求超时单位/秒</param>
        public HttpHelper(WebHeaderCollection handers, HttpMethod method, string encoding, int timeOut) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// HttpWebRequest对象
        /// </summary>
        public HttpWebRequest WebRequest {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// HttpWebResponse对象
        /// </summary>
        public HttpWebResponse WebResponse {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
    }
}
