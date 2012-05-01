namespace SmartTeaching.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base_NewsType
    /// </summary>
    public class Base_NewsType
    {
        /// <summary>
        /// NewsTypeId
        /// </summary>		
        private int _NewsTypeId;
        /// <summary>
        /// NewsTypeName
        /// </summary>		
        private string _NewsTypeName;
        /// <summary>
        /// Remarks
        /// </summary>		
        private string _Remarks;
        /// <summary>
        /// ParentId
        /// </summary>		
        private int _ParentId;

        /// <summary>
        /// NewsTypeId
        /// </summary>
        public int NewsTypeId
        {
            get { return _NewsTypeId; }
            set { _NewsTypeId = value; }
        }
        /// <summary>
        /// NewsTypeName
        /// </summary>
        public string NewsTypeName
        {
            get { return _NewsTypeName; }
            set { _NewsTypeName = value; }
        }
        /// <summary>
        /// Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        /// <summary>
        /// ParentId
        /// </summary>
        public int ParentId
        {
            get { return _ParentId; }
            set { _ParentId = value; }
        }
    }
}