using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //证书考试成绩等级表
    public class BASE_CRET_LEVAL
    {
        /// <summary>
        /// CRETLEVALID
        /// </summary>		
        private int _cretlevalid;
        public int CRETLEVALID
        {
            get { return _cretlevalid; }
            set { _cretlevalid = value; }
        }
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
        /// SCORE
        /// </summary>		
        private decimal _score;
        public decimal SCORE
        {
            get { return _score; }
            set { _score = value; }
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
