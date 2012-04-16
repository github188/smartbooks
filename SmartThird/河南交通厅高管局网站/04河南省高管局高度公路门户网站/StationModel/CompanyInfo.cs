using System;
using System.Collections.Generic;
using System.Text;

namespace StationModel
{
    /// <summary>
    /// 运营管理单位信息实体类
    /// </summary>
    [Serializable]
   public class CompanyInfo
    {
        /// <summary>
        /// 运营管理单位编号
        /// </summary>
        private int c_ID;

        public int C_ID
        {
            get { return c_ID; }
            set { c_ID = value; }
        }
        /// <summary>
        /// 运营管理单位名称
        /// </summary>
        private string c_Name;

        public string C_Name
        {
            get { return c_Name; }
            set { c_Name = value; }
        }
    }
}
