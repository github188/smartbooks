using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //证书分类信息表
    public class BASE_CRET_CROUP
    {
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
        /// PARENTID
        /// </summary>		
        private int _parentid;
        public int PARENTID
        {
            get { return _parentid; }
            set { _parentid = value; }
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
    }
}
