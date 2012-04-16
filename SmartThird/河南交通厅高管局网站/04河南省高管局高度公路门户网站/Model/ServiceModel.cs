using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 服务区模块实体类
    /// </summary>
  public  class ServiceModel
    {
      /// <summary>
      /// 模块编号
      /// </summary>
        private int m_ID;

        public int M_ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
      /// <summary>
      /// 模块名称
      /// </summary>
        private string m_Name;

        public string M_Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
      /// <summary>
      /// 父模块编号
      /// </summary>
        private int m_ParentID;

        public int M_ParentID
        {
            get { return m_ParentID; }
            set { m_ParentID = value; }
        }
    }
}
