using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// ���������Ŷ�̬
    /// </summary>
  public  class ServiceNews
    {
     /// <summary>
     /// ���
     /// </summary>
        private int n_ID;

        public int N_ID
        {
            get { return n_ID; }
            set { n_ID = value; }
        }
      /// <summary>
      /// ����
      /// </summary>
        private string n_Title;

        public string N_Title
        {
            get { return n_Title; }
            set { n_Title = value; }
        }
      /// <summary>
      /// ����
      /// </summary>
        private string n_Content;

        public string N_Content
        {
            get { return n_Content; }
            set { n_Content = value; }
        }
      /// <summary>
      /// ����ʱ��
      /// </summary>
        private DateTime n_Time;

        public DateTime N_Time
        {
            get { return n_Time; }
            set { n_Time = value; }
        }
      /// <summary>
      /// ������Դ
      /// </summary>
        private string n_From;

        public string N_From
        {
            get { return n_From; }
            set { n_From = value; }
        }
      /// <summary>
      /// �������������
      /// </summary>
        private int n_SID;

        public int N_SID
        {
            get { return n_SID; }
            set { n_SID = value; }
        }

      /// <summary>
      /// ��Ϣ����
      /// </summary>
      private string n_newsType;
      public string N_NewsType
      {
          get { return n_newsType; }
          set { this.n_newsType = value; }
      }

      /// <summary>
      /// ���������
      /// </summary>
      private int n_ViewedCount;
      public int N_ViewedCount {
          get { return n_ViewedCount; }
          set { this.n_ViewedCount = value; }
      }
    }
}
