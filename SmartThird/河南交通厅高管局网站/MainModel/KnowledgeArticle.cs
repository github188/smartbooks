using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// 高速知识文章实体类
    /// </summary>
  [Serializable]
  public  class KnowledgeArticle
    {
      /// <summary>
      /// 文章编号
      /// </summary>
        private int kA_ID;

        public int KA_ID
        {
            get { return kA_ID; }
            set { kA_ID = value; }
        }
     /// <summary>
     /// 文章标题
     /// </summary>
        private string kA_Title;

        public string KA_Title
        {
            get { return kA_Title; }
            set { kA_Title = value; }
        }
      /// <summary>
      /// 文章内容
      /// </summary>
        private string kA_Content;

        public string KA_Content
        {
            get { return kA_Content; }
            set { kA_Content = value; }
        }
      /// <summary>
      /// 创建日期
      /// </summary>
        private string kA_CreateDate;

        public string KA_CreateDate
        {
            get { return kA_CreateDate; }
            set { kA_CreateDate = value; }
        }
      /// <summary>
      /// 高速知识模块编号
      /// </summary>
        private int kA_KMID;

        public int KA_KMID
        {
            get { return kA_KMID; }
            set { kA_KMID = value; }
        }
    }
    /// <summary>
   /// 高速知识模块信息实体类
    /// </summary>
    public class KnowledgeModule {
        /// <summary>
        /// 模块编号
        /// </summary>
        private int kM_ID;

        public int KM_ID
        {
            get { return kM_ID; }
            set { kM_ID = value; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        private string kM_Name;

        public string KM_Name
        {
            get { return kM_Name; }
            set { kM_Name = value; }
        }
    }
}
