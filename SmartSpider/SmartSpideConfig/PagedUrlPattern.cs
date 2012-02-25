namespace SmartSpide.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("PagedUrlPattern")]
    public class PagedUrlPatterns {

        #region 私有变量定义
        private int _EndPage;
        private int _Format;
        private int _PagedUrlPattern;
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

        public int Format {
            get {
                return _Format;
            }
            set {
                _Format = value;
            }
        }

        public int PagedUrlPattern {
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