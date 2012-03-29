using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 服务区留言板实体信息类
    /// </summary>
  public  class MessageBoard
    {
      /// <summary>
      /// 编号
      /// </summary>
        private int m_ID;

        public int M_ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
      /// <summary>
      /// 昵称
      /// </summary>
        private string m_UName;

        public string M_UName
        {
            get { return m_UName; }
            set { m_UName = value; }
        }
      /// <summary>
      /// 留言内容
      /// </summary>
        private string m_Content;

        public string M_Content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }
      /// <summary>
      /// 发布时间
      /// </summary>
        private string m_Time;

        public string M_Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }
      /// <summary>
      /// 表情
      /// </summary>
        private string m_Emotion;

        public string M_Emotion
        {
            get { return m_Emotion; }
            set { m_Emotion = value; }
        }
      /// <summary>
      /// 管理员回复
      /// </summary>
        private string m_Reply;

        public string M_Reply
        {
            get { return m_Reply; }
            set { m_Reply = value; }
        }
      /// <summary>
      /// 是否发布状态
      /// </summary>
        private string m_Status;

        public string M_Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
      /// <summary>
      /// 服务区编号
      /// </summary>
        private int m_SID;

        public int M_SID
        {
            get { return m_SID; }
            set { m_SID = value; }
        }
    }
}
