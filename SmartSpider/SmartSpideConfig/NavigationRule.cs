namespace SmartSpide.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("NavigationRule")]
    public class NavigationRule {

        #region 私有变量定义
        private string _ContentEncoding;
        private string _ExtractionEndFlag;
        private string _ExtractionStartFlag;
        private bool _HistoryUrlEnabled;
        private bool _HistoryUrlOptimization;
        private string _IterationFlag;
        private bool _JsDecoding;
        private int _Name;
        private bool _NextLayerUrlEncoded;
        private string _NextLayerUrlPattern;
        private string _NextLayerUrlReferer;
        private int _NextPageLargest;
        private string _NextPageUrlPattern;
        private string _PickingEndFlag;
        private string _PickingStartFlag;
        private bool _PickNextLayerUrls;
        private bool _PickNextPageUrl;
        private bool _ProccessScripts;
        private string _Replacements;
        private int _RestInterval;
        private string _SkipToIfPickingFailed;
        private bool _Terminal;
        private bool _UsePluginOfPickNextLayerUrls;
        private bool _UsePluginOfPickNextPageUrl;
        private bool _UsePluginOfVisit;
        private bool _UseRegularExpression;
        #endregion

        #region 公共属性定义
        public int Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        public bool Terminal {
            get {
                return _Terminal;
            }
            set {
                _Terminal = value;
            }
        }

        public bool PickNextLayerUrls {
            get {
                return _PickNextLayerUrls;
            }
            set {
                _PickNextLayerUrls = value;
            }
        }

        public string NextLayerUrlPattern {
            get {
                return _NextLayerUrlPattern;
            }
            set {
                _NextLayerUrlPattern = value;
            }
        }

        public bool UseRegularExpression {
            get {
                return _UseRegularExpression;
            }
            set {
                _UseRegularExpression = value;
            }
        }

        public bool HistoryUrlEnabled {
            get {
                return _HistoryUrlEnabled;
            }
            set {
                _HistoryUrlEnabled = value;
            }
        }

        public bool HistoryUrlOptimization {
            get {
                return _HistoryUrlOptimization;
            }
            set {
                _HistoryUrlOptimization = value;
            }
        }

        public bool PickNextPageUrl {
            get {
                return _PickNextPageUrl;
            }
            set {
                _PickNextPageUrl = value;
            }
        }

        public string NextPageUrlPattern {
            get {
                return _NextPageUrlPattern;
            }
            set {
                _NextPageUrlPattern = value;
            }
        }

        public int NextPageLargest {
            get {
                return _NextPageLargest;
            }
            set {
                _NextPageLargest = value;
            }
        }

        public string PickingStartFlag {
            get {
                return _PickingStartFlag;
            }
            set {
                _PickingStartFlag = value;
            }
        }

        public string PickingEndFlag {
            get {
                return _PickingEndFlag;
            }
            set {
                _PickingEndFlag = value;
            }
        }

        public string ExtractionStartFlag {
            get {
                return _ExtractionStartFlag;
            }
            set {
                _ExtractionStartFlag = value;
            }
        }

        public string ExtractionEndFlag {
            get {
                return _ExtractionEndFlag;
            }
            set {
                _ExtractionEndFlag = value;
            }
        }

        public string IterationFlag {
            get {
                return _IterationFlag;
            }
            set {
                _IterationFlag = value;
            }
        }

        public int RestInterval {
            get {
                return _RestInterval;
            }
            set {
                _RestInterval = value;
            }
        }

        public string ContentEncoding {
            get {
                return _ContentEncoding;
            }
            set {
                _ContentEncoding = value;
            }
        }

        public bool ProccessScripts {
            get {
                return _ProccessScripts;
            }
            set {
                _ProccessScripts = value;
            }
        }

        public string NextLayerUrlReferer {
            get {
                return _NextLayerUrlReferer;
            }
            set {
                _NextLayerUrlReferer = value;
            }
        }

        public bool NextLayerUrlEncoded {
            get {
                return _NextLayerUrlEncoded;
            }
            set {
                _NextLayerUrlEncoded = value;
            }
        }

        public bool JsDecoding {
            get {
                return _JsDecoding;
            }
            set {
                _JsDecoding = value;
            }
        }

        public string SkipToIfPickingFailed {
            get {
                return _SkipToIfPickingFailed;
            }
            set {
                _SkipToIfPickingFailed = value;
            }
        }

        public bool UsePluginOfVisit {
            get {
                return _UsePluginOfVisit;
            }
            set {
                _UsePluginOfVisit = value;
            }
        }

        public bool UsePluginOfPickNextLayerUrls {
            get {
                return _UsePluginOfPickNextLayerUrls;
            }
            set {
                _UsePluginOfPickNextLayerUrls = value;
            }
        }

        public bool UsePluginOfPickNextPageUrl {
            get {
                return _UsePluginOfPickNextPageUrl;
            }
            set {
                _UsePluginOfPickNextPageUrl = value;
            }
        }

        public string Replacements {
            get {
                return _Replacements;
            }
            set {
                _Replacements = value;
            }
        }
        #endregion
    }
}
