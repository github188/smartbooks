using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //用户信息表
    public class BASE_USER
    {

        /// <summary>
        /// USERID
        /// </summary>		
        private int _userid;
        public int USERID
        {
            get { return _userid; }
            set { _userid = value; }
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
        /// EMAIL
        /// </summary>		
        private string _email;
        public string EMAIL
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// TEL
        /// </summary>		
        private string _tel;
        public string TEL
        {
            get { return _tel; }
            set { _tel = value; }
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
        /// <summary>
        /// ROLEID
        /// </summary>		
        private string _roleid;
        public string ROLEID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

    }
}
