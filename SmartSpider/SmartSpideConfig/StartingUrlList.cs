namespace SmartSpide.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("StartingUrlList")]
    public class StartingUrlList {
        private string _String;
    
        public string String {
            get {
                return _String;
            }
            set {
                _String = value;
            }
        }
    }
}
