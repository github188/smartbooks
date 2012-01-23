using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //学员信息表
    public class BASE_STUDENT
    {

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
        /// USERNAME
        /// </summary>		
        private string _username;
        public string USERNAME
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// PWD
        /// </summary>		
        private string _pwd;
        public string PWD
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        /// <summary>
        /// SEX
        /// </summary>		
        private string _sex;
        public string SEX
        {
            get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// CARDNUMBER
        /// </summary>		
        private string _cardnumber;
        public string CARDNUMBER
        {
            get { return _cardnumber; }
            set { _cardnumber = value; }
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
        /// PHOTO
        /// </summary>		
        private string _photo;
        public string PHOTO
        {
            get { return _photo; }
            set { _photo = value; }
        }
        /// <summary>
        /// ADDRESS
        /// </summary>		
        private string _address;
        public string ADDRESS
        {
            get { return _address; }
            set { _address = value; }
        }

    }
}
