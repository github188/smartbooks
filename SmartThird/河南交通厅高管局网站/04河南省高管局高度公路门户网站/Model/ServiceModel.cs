using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// ������ģ��ʵ����
    /// </summary>
  public  class ServiceModel
    {
      /// <summary>
      /// ģ����
      /// </summary>
        private int m_ID;

        public int M_ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
      /// <summary>
      /// ģ������
      /// </summary>
        private string m_Name;

        public string M_Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
      /// <summary>
      /// ��ģ����
      /// </summary>
        private int m_ParentID;

        public int M_ParentID
        {
            get { return m_ParentID; }
            set { m_ParentID = value; }
        }
    }
}
