using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// ���԰�ʵ����
    /// </summary>
  public  class MessageBoard
    {
      /// <summary>
      /// ���Ա��
      /// </summary>
        private int m_ID;

        public int M_ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
      /// <summary>
      /// ����
      /// </summary>
        private string m_UName;

        public string M_UName
        {
            get { return m_UName; }
            set { m_UName = value; }
        }
      /// <summary>
      /// Email
      /// </summary>
        private string m_Email;

        public string M_Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

      /// <summary>
      /// ��ϵ�绰
      /// </summary>
        private string m_Phone;

        public string M_Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }
      /// <summary>
      /// ����
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
      /// �ظ�
      /// </summary>
        private string m_Reply;

        public string M_Reply
        {
            get { return m_Reply; }
            set { m_Reply = value; }
        }
      /// <summary>
      /// �ظ�ʱ��
      /// </summary>
        private string m_RTime;

        public string M_RTime
        {
            get { return m_RTime; }
            set { m_RTime = value; }
        }
      /// <summary>
      /// �Ƿ񷢲�
      /// </summary>
        private string m_Open;

        public string M_Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }
    }
}
