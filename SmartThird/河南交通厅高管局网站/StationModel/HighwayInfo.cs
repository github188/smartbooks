using System;
using System.Collections.Generic;
using System.Text;

namespace StationModel
{
    /// <summary>
    /// 高速公路信息实体类
    /// </summary>
   [Serializable]
   public class HighwayInfo
    {
        /// <summary>
        /// 高速公路编号
        /// </summary>
        private int h_ID;

        public int H_ID
        {
            get { return h_ID; }
            set { h_ID = value; }
        }
        /// <summary>
        /// 高速公路名称
        /// </summary>
        private string h_Name;

        public string H_Name
        {
            get { return h_Name; }
            set { h_Name = value; }
        }
    }
}
