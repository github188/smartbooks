﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCampus.Entity
{
    //照片信息表
    public class BASE_PHOTO
    {

        /// <summary>
        /// PHOTOID
        /// </summary>		
        private int _photoid;
        public int PHOTOID
        {
            get { return _photoid; }
            set { _photoid = value; }
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
        /// <summary>
        /// GROUPID
        /// </summary>		
        private string _groupid;
        public string GROUPID
        {
            get { return _groupid; }
            set { _groupid = value; }
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
