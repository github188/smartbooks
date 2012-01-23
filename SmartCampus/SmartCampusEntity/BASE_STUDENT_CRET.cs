using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //学员证书信息表
    public class BASE_STUDENT_CRET
    {

        /// <summary>
        /// STUDENTCRETID
        /// </summary>		
        private int _studentcretid;
        public int STUDENTCRETID
        {
            get { return _studentcretid; }
            set { _studentcretid = value; }
        }
        /// <summary>
        /// STUDENTID
        /// </summary>		
        private int _studentid;
        public int STUDENTID
        {
            get { return _studentid; }
            set { _studentid = value; }
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
        /// BISHI
        /// </summary>		
        private decimal _bishi;
        public decimal BISHI
        {
            get { return _bishi; }
            set { _bishi = value; }
        }
        /// <summary>
        /// JISHI
        /// </summary>		
        private decimal _jishi;
        public decimal JISHI
        {
            get { return _jishi; }
            set { _jishi = value; }
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
        /// CRETLEVALID
        /// </summary>		
        private int _cretlevalid;
        public int CRETLEVALID
        {
            get { return _cretlevalid; }
            set { _cretlevalid = value; }
        }

    }
}
