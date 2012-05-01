namespace SmartTeaching.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_BBS
    /// </summary>
    public class Base_BBS
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _ID;
        /// <summary>
        /// UserId
        /// </summary>		
        private int _UserId;
        /// <summary>
        /// ToUserId
        /// </summary>		
        private int _ToUserId;
        /// <summary>
        /// NewsId
        /// </summary>		
        private int _NewsId;
        /// <summary>
        /// CreateDate
        /// </summary>		
        private DateTime _CreateDate;
        /// <summary>
        /// NewsContent
        /// </summary>		
        private string _NewsContent;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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
        /// ToUserId
        /// </summary>
        public int ToUserId
        {
            get { return _ToUserId; }
            set { _ToUserId = value; }
        }
        /// <summary>
        /// NewsId
        /// </summary>
        public int NewsId
        {
            get { return _NewsId; }
            set { _NewsId = value; }
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
        /// NewsContent
        /// </summary>
        public string NewsContent
        {
            get { return _NewsContent; }
            set { _NewsContent = value; }
        }
    }
}