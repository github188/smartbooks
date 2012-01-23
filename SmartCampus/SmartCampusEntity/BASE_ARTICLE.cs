using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    /// <summary>
    /// 文章信息表
    /// </summary>
    public class BASE_ARTICLE
    {
        /// <summary>
        /// ARTICLEID
        /// </summary>		
        private int _articleid;
        public int ARTICLEID
        {
            get { return _articleid; }
            set { _articleid = value; }
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
        /// CONTENT
        /// </summary>		
        private string _content;
        public string CONTENT
        {
            get { return _content; }
            set { _content = value; }
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
        /// READ
        /// </summary>		
        private int _read;
        public int READ
        {
            get { return _read; }
            set { _read = value; }
        }
        /// <summary>
        /// COMMENT
        /// </summary>		
        private int _comment;
        public int COMMENT
        {
            get { return _comment; }
            set { _comment = value; }
        }
        /// <summary>
        /// COPYRIGHT
        /// </summary>		
        private string _copyright;
        public string COPYRIGHT
        {
            get { return _copyright; }
            set { _copyright = value; }
        }
        /// <summary>
        /// AUTHOR
        /// </summary>		
        private string _author;
        public string AUTHOR
        {
            get { return _author; }
            set { _author = value; }
        }
        /// <summary>
        /// QUOTE
        /// </summary>		
        private string _quote;
        public string QUOTE
        {
            get { return _quote; }
            set { _quote = value; }
        }
        /// <summary>
        /// MENUID
        /// </summary>		
        private string _menuid;
        public string MENUID
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        /// <summary>
        /// PHOTOID
        /// </summary>		
        private string _photoid;
        public string PHOTOID
        {
            get { return _photoid; }
            set { _photoid = value; }
        }
        /// <summary>
        /// FILEID
        /// </summary>		
        private string _fileid;
        public string FILEID
        {
            get { return _fileid; }
            set { _fileid = value; }
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
        /// STATUS
        /// </summary>		
        private int _status;
        public int STATUS
        {
            get { return _status; }
            set { _status = value; }
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
