using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 服务区新闻动态
    /// </summary>
  public  class ServiceNews
    {
     /// <summary>
     /// 编号
     /// </summary>
        private int n_ID;

        public int N_ID
        {
            get { return n_ID; }
            set { n_ID = value; }
        }
      /// <summary>
      /// 标题
      /// </summary>
        private string n_Title;

        public string N_Title
        {
            get { return n_Title; }
            set { n_Title = value; }
        }
      /// <summary>
      /// 内容
      /// </summary>
        private string n_Content;

        public string N_Content
        {
            get { return n_Content; }
            set { n_Content = value; }
        }
      /// <summary>
      /// 发布时间
      /// </summary>
        private DateTime n_Time;

        public DateTime N_Time
        {
            get { return n_Time; }
            set { n_Time = value; }
        }
      /// <summary>
      /// 新闻来源
      /// </summary>
        private string n_From;

        public string N_From
        {
            get { return n_From; }
            set { n_From = value; }
        }
      /// <summary>
      /// 隶属服务区编号
      /// </summary>
        private int n_SID;

        public int N_SID
        {
            get { return n_SID; }
            set { n_SID = value; }
        }

      /// <summary>
      /// 消息类型
      /// </summary>
      private string n_newsType;
      public string N_NewsType
      {
          get { return n_newsType; }
          set { this.n_newsType = value; }
      }

      /// <summary>
      /// 被浏览次数
      /// </summary>
      private int n_ViewedCount;
      public int N_ViewedCount {
          get { return n_ViewedCount; }
          set { this.n_ViewedCount = value; }
      }
    }
}
