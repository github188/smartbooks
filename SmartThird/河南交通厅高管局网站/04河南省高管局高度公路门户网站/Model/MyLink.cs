using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 友情链接实体类
    /// </summary>
   public class MyLink
    {
       /// <summary>
       /// 编号
       /// </summary>
        private int l_ID;

        public int L_ID
        {
            get { return l_ID; }
            set { l_ID = value; }
        }
       /// <summary>
       /// 标题
       /// </summary>
        private string l_Title;

        public string L_Title
        {
            get { return l_Title; }
            set { l_Title = value; }
        }
       /// <summary>
       /// 链接地址
       /// </summary>
        private string l_URL;

        public string L_URL
        {
            get { return l_URL; }
            set { l_URL = value; }
        }
       /// <summary>
       /// 服务区编号
       /// </summary>
        private int l_SID;

        public int L_SID
        {
            get { return l_SID; }
            set { l_SID = value; }
        }
    }
}
