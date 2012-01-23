using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //友情链接信息表
    public class BASE_LINK
    {

        /// <summary>
        /// LINKID
        /// </summary>		
        private int _linkid;
        public int LINKID
        {
            get { return _linkid; }
            set { _linkid = value; }
        }
        /// <summary>
        /// TITLE
        /// </summary>		
        private string _title;
        public string TITLE
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// SUMMARY
        /// </summary>		
        private string _summary;
        public string SUMMARY
        {
            get { return _summary; }
            set { _summary = value; }
        }
        /// <summary>
        /// HOME
        /// </summary>		
        private string _home;
        public string HOME
        {
            get { return _home; }
            set { _home = value; }
        }
        /// <summary>
        /// PR
        /// </summary>		
        private int _pr;
        public int PR
        {
            get { return _pr; }
            set { _pr = value; }
        }
        /// <summary>
        /// IMAGE
        /// </summary>		
        private string _image;
        public string IMAGE
        {
            get { return _image; }
            set { _image = value; }
        }
        /// <summary>
        /// SDATE
        /// </summary>		
        private DateTime _sdate;
        public DateTime SDATE
        {
            get { return _sdate; }
            set { _sdate = value; }
        }
        /// <summary>
        /// EDATE
        /// </summary>		
        private DateTime _edate;
        public DateTime EDATE
        {
            get { return _edate; }
            set { _edate = value; }
        }
        /// <summary>
        /// STATUS
        /// </summary>		
        private int _status;
        public int STATUS
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// VERSION
        /// </summary>		
        private string _version;
        public string VERSION
        {
            get { return _version; }
            set { _version = value; }
        }
        /// <summary>
        /// ICON
        /// </summary>		
        private string _icon;
        public string ICON
        {
            get { return _icon; }
            set { _icon = value; }
        }

    }
}
