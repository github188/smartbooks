namespace SmartTeaching.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_News
    /// </summary>
    public class Base_News
    {
        /// <summary>
        /// NewsId
        /// </summary>		
        private int _NewsId;
        /// <summary>
        /// NewsTypeId
        /// </summary>		
        private int _NewsTypeId;
        /// <summary>
        /// UserId
        /// </summary>		
        private int _UserId;
        /// <summary>
        /// NewsTitle
        /// </summary>		
        private string _NewsTitle;
        /// <summary>
        /// NewsContent
        /// </summary>		
        private string _NewsContent;
        /// <summary>
        /// CreateDate
        /// </summary>		
        private DateTime _CreateDate;
        /// <summary>
        /// Summary
        /// </summary>		
        private string _Summary;
        /// <summary>
        /// FileName
        /// </summary>		
        private string _FileName;
        /// <summary>
        /// FilePath
        /// </summary>		
        private string _FilePath;
        /// <summary>
        /// FileSize
        /// </summary>		
        private int _FileSize;

        /// <summary>
        /// NewsId
        /// </summary>
        public int NewsId
        {
            get { return _NewsId; }
            set { _NewsId = value; }
        }
        /// <summary>
        /// NewsTypeId
        /// </summary>
        public int NewsTypeId
        {
            get { return _NewsTypeId; }
            set { _NewsTypeId = value; }
        }
        /// <summary>
        /// UserId
        /// </summary>
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        /// <summary>
        /// NewsTitle
        /// </summary>
        public string NewsTitle
        {
            get { return _NewsTitle; }
            set { _NewsTitle = value; }
        }
        /// <summary>
        /// NewsContent
        /// </summary>
        public string NewsContent
        {
            get { return _NewsContent; }
            set { _NewsContent = value; }
        }
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        /// <summary>
        /// Summary
        /// </summary>
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }
        /// <summary>
        /// FileSize
        /// </summary>
        public int FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
    }
}