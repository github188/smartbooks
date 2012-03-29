using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// ���������԰�ʵ����Ϣ��
    /// </summary>
  public  class MessageBoard
    {
      /// <summary>
      /// ���
      /// </summary>
        private int m_ID;

        public int M_ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
      /// <summary>
      /// �ǳ�
      /// </summary>
        private string m_UName;

        public string M_UName
        {
            get { return m_UName; }
            set { m_UName = value; }
        }
      /// <summary>
      /// ��������
      /// </summary>
        private string m_Content;

        public string M_Content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }
      /// <summary>
      /// ����ʱ��
      /// </summary>
        private string m_Time;

        public string M_Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }
      /// <summary>
      /// ����
      /// </summary>
        private string m_Emotion;

        public string M_Emotion
        {
            get { return m_Emotion; }
            set { m_Emotion = value; }
        }
      /// <summary>
      /// ����Ա�ظ�
      /// </summary>
        private string m_Reply;

        public string M_Reply
        {
            get { return m_Reply; }
            set { m_Reply = value; }
        }
      /// <summary>
      /// �Ƿ񷢲�״̬
      /// </summary>
        private string m_Status;

        public string M_Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
      /// <summary>
      /// ���������
      /// </summary>
        private int m_SID;

        public int M_SID
        {
            get { return m_SID; }
            set { m_SID = value; }
        }
    }
}
