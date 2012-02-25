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
        }

        private string _DisplayName;
        private string _Name;

        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        public string DisplayName {
            get {
                return _DisplayName;
            }
            set {
                _DisplayName = value;
            }
        }
    }
}
