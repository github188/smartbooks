namespace SmartSpide.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("RegularExpression")]
    public class RegularExpression {
        private string _Expression;
        private string _Name;
    
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        public string Expression {
            get {
                return _Expression;
            }
            set {
                _Expression = value;
            }
        }
    }
}
