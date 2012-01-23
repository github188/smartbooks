using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //证书信息表
    public class BASE_CRET
    {
        /// <summary>
        /// CRETID
        /// </summary>		
        private int _cretid;
        public int CRETID
        {
            get { return _cretid; }
            set { _cretid = value; }
        }
        /// <summary>
        /// CRETNO
        /// </summary>		
        private string _cretno;
        public string CRETNO
        {
            get { return _cretno; }
            set { _cretno = value; }
        }
        /// <summary>
        /// CRETNAME
        /// </summary>		
        private string _cretname;
        public string CRETNAME
        {
            get { return _cretname; }
            set { _cretname = value; }
        }
        /// <summary>
        /// CRETGROUPID
        /// </summary>		
        private int _cretgroupid;
        public int CRETGROUPID
        {
            get { return _cretgroupid; }
            set { _cretgroupid = value; }
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

    }
}
