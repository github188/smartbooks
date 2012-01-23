using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //菜单信息表
    public class BASE_MENU
    {

        /// <summary>
        /// MENUID
        /// </summary>		
        private int _menuid;
        public int MENUID
        {
            get { return _menuid; }
            set { _menuid = value; }
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
        /// PATH
        /// </summary>		
        private string _path;
        public string PATH
        {
            get { return _path; }
            set { _path = value; }
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
        /// <summary>
        /// SORT
        /// </summary>		
        private int _sort;
        public int SORT
        {
            get { return _sort; }
            set { _sort = value; }
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
        /// LICENSECODE
        /// </summary>		
        private string _licensecode;
        public string LICENSECODE
        {
            get { return _licensecode; }
            set { _licensecode = value; }
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
