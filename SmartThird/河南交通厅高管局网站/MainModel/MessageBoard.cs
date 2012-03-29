using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// 留言板实体类
    /// </summary>
  public  class MessageBoard
    {
      /// <summary>
      /// 留言编号
      /// </summary>
        private int m_ID;

        public int M_ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
      /// <summary>
      /// 姓名
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
      /// 联系电话
      /// </summary>
        private string m_Phone;

        public string M_Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }
      /// <summary>
      /// 内容
      /// </summary>
        private string m_Content;

        public string M_Content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }
      /// <summary>
      /// 留言时间
      /// </summary>
        private string m_Time;

        public string M_Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }
      /// <summary>
      /// 回复
      /// </summary>
        private string m_Reply;

        public string M_Reply
        {
            get { return m_Reply; }
            set { m_Reply = value; }
        }
      /// <summary>
      /// 回复时间
      /// </summary>
        private string m_RTime;

        public string M_RTime
        {
            get { return m_RTime; }
            set { m_RTime = value; }
        }
      /// <summary>
      /// 是否发布
      /// </summary>
        private string m_Open;

        public string M_Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }
    }
}
