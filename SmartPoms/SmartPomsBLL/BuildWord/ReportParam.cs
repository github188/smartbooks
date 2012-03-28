using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPoms.BLL.BuildWord {
    public class ReportParam {
        public ReportParam() {
            _FileName = "";
            _Tile = "河南省高速公路管理局舆情简报";
            _PublishWord = "高管局发";
            _Year = DateTime.Now.Year.ToString();
            _Number = "01";
            _SubTitle = string.Format("{0}年{1}周网络舆情简报", DateTime.Now.Year, (DateTime.Now.DayOfYear / 7).ToString());
            _BodyContent = "";
            _AnnexContent = "";
            _CreateDate = DateTime.Now.ToLongDateString();
            _KeyWord = new List<string>();
            _UnitName = "河南省高速公路管理局";
            _PublishDate = DateTime.Now.ToLongDateString();
            _Author = "";
            _Tel = "";
        }

        private string _FileName;
        private string _Tile;
        private string _PublishWord;
        private string _Year;
        private string _Number;
        private string _SubTitle;
        private string _BodyContent;
        private string _AnnexContent;
        private string _CreateDate;
        private List<string> _KeyWord;
        private string _UnitName;
        private string _PublishDate;
        private string _Author;
        private string _Tel;

        public string FileName {
            get { return _FileName; }
            set { _FileName = value; }
        }
        public string Tile {
            get {
                return _Tile;
            }
            set {
                _Tile = value;
            }
        }
        public string PublishWord {
            get {
                return _PublishWord;
            }
            set {
                _PublishWord = value;
            }
        }
        public string Year {
            get {
                return _Year;
            }
            set {
                _Year = value;
            }
        }
        public string Number {
            get {
                return _Number;
            }
            set {
                _Number = value;
            }
        }
        public string SubTitle {
            get {
                return _SubTitle;
            }
            set {
                _SubTitle = value;
            }
        }
        public string BodyContent {
            get {
                return _BodyContent;
            }
            set {
                _BodyContent = value;
            }
        }
        public string AnnexContent {
            get {
                return _AnnexContent;
            }
            set {
                _AnnexContent = value;
            }
        }
        public string CreateDate {
            get {
                return _CreateDate;
            }
            set {
                _CreateDate = value;
            }
        }
        public List<string> KeyWord {
            get {
                return _KeyWord;
            }
            set {
                _KeyWord = value;
            }
        }
        public string UnitName {
            get {
                return _UnitName;
            }
            set {
                _UnitName = value;
            }
        }
        public string PublishDate {
            get {
                return _PublishDate;
            }
            set {
                _PublishDate = value;
            }
        }
        public string Author {
            get {
                return _Author;
            }
            set {
                _Author = value;
            }
        }
        public string Tel {
            get {
                return _Tel;
            }
            set {
                _Tel = value;
            }
        }
    }
}
