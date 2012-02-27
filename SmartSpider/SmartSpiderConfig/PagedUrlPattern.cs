namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("PagedUrlPattern")]
    public class PagedUrlPatterns {
        public PagedUrlPatterns() {
            this._StartPage = 1;
            this._EndPage = 0;
            this._Step = 1;
            this._Format = "";
            this._PagedUrlPattern = "";
        }

        #region 私有变量定义
        private int _EndPage;
        private string _Format;
        private string _PagedUrlPattern;
        private int _StartPage;
        private int _Step;
        #endregion

        #region 公共属性定义

        public int StartPage {
            get {
                return _StartPage;
            }
            set {
                _StartPage = value;
            }
        }

        public int EndPage {
            get {
                return _EndPage;
            }
            set {
                _EndPage = value;
            }
        }

        public int Step {
            get {
                return _Step;
            }
            set {
                _Step = value;
            }
        }

        public string Format {
            get {
                return _Format;
            }
            set {
                _Format = value;
            }
        }

        public string PagedUrlPattern {
            get {
                return _PagedUrlPattern;
            }
            set {
                _PagedUrlPattern = value;
            }
        }
        #endregion
    }
}