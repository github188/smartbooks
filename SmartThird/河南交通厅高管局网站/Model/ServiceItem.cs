using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// ������ģ����Ϣʵ����
    /// </summary>
  public  class ServiceItem
    {
      /// <summary>
      /// ���
      /// </summary>
        private int i_ID;

        public int I_ID
        {
            get { return i_ID; }
            set { i_ID = value; }
        }
      /// <summary>
      /// ����
      /// </summary>
        private string i_Title;

        public string I_Title
        {
            get { return i_Title; }
            set { i_Title = value; }
        }
      /// <summary>
      /// ����
      /// </summary>
        private string i_Content;

        public string I_Content
        {
            get { return i_Content; }
            set { i_Content = value; }
        }
      /// <summary>
      /// ����ʱ��
      /// </summary>
        private string i_Time;

        public string I_Time
        {
            get { return i_Time; }
            set { i_Time = value; }
        }
      /// <summary>
      /// ���������
      /// </summary>
      private int i_SID;

      public int I_SID
      {
          get { return i_SID; }
          set { i_SID = value; }
      }
      /// <summary>
      /// ��ģ����
      /// </summary>
      private string i_MID;

      public string I_MID
      {
          get { return i_MID; }
          set { i_MID = value; }
      }
    }
}
