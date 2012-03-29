using System;
using System.Collections.Generic;
using System.Text;

namespace StationModel
{
    /// <summary>
    /// 河南18地市信息实体类
    /// </summary>
   [Serializable]
   public class CityInfo
    {
        /// <summary>
        /// 地市编号
        /// </summary>
        private int cI_ID;

        public int CI_ID
        {
            get { return cI_ID; }
            set { cI_ID = value; }
        }
        /// <summary>
        /// 地市名称
        /// </summary>
        private string cI_Name;

        public string CI_Name
        {
            get { return cI_Name; }
            set { cI_Name = value; }
        }
    }
}
