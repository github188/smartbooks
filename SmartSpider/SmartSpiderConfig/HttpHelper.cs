namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;

    public class HttpHelper {
        #region 私有变量定义
        private HttpWebRequest _WebRequest;
        private HttpWebResponse _WebResponse;
        #endregion

        #region 公共方法定义

        /// <param name="handers">Hander集合</param>
        /// <param name="method">Http请求方式</param>
        /// <param name="encoding">网页数据编码</param>
        /// <param name="timeOut">请求超时单位/秒</param>
        public HttpHelper(WebHeaderCollection handers, HttpMethod method, string encoding, int timeOut) {
            throw new System.NotImplementedException();
        }

        public HttpHelper() { }
        #endregion

        #region 公共属性定义
        /// <summary>
        /// HttpWebRequest对象
        /// </summary>
        public HttpWebRequest WebRequest {
            get {
                return _WebRequest;
            }
            set {
                _WebRequest = value;
            }
        }

        /// <summary>
        /// HttpWebResponse对象
        /// </summary>
        public HttpWebResponse WebResponse {
            get {
                return _WebResponse;
            }
            set {
                _WebResponse = value;
            }
        }
        #endregion
    }
}
