namespace SmartSpide.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Html预定义标记
    /// </summary>
    [Serializable]
    [XmlRoot("HtmlMark")]
    public class HtmlMark {

        public HtmlMark() {
            this._Name = "";
            this._DisplayName = "";
        }

        #region 私有变量定义
        private string _DisplayName;
        private string _Name;
        #endregion

        #region 公共属性定义
        /// <summary>
        /// 标记名称
        /// </summary>
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName {
            get {
                return _DisplayName;
            }
            set {
                _DisplayName = value;
            }
        }
        #endregion
    }
}
