using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPoms.UI {
    public class BaseException {
        private string _ErrorTitle = "";
        private string _ErrorContent = "";

        public string ErrorTitle {
            get {
                return _ErrorTitle;
            }
            set {
                _ErrorTitle = value;
            }
        }
        public string ErrorContent {
            get {
                return _ErrorContent;
            }
            set {
                _ErrorContent = value;
            }
        }
    }
}
