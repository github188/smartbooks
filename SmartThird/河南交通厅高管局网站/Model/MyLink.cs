using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// ��������ʵ����
    /// </summary>
   public class MyLink
    {
       /// <summary>
       /// ���
       /// </summary>
        private int l_ID;

        public int L_ID
        {
            get { return l_ID; }
            set { l_ID = value; }
        }
       /// <summary>
       /// ����
       /// </summary>
        private string l_Title;

        public string L_Title
        {
            get { return l_Title; }
            set { l_Title = value; }
        }
       /// <summary>
       /// ���ӵ�ַ
       /// </summary>
        private string l_URL;

        public string L_URL
        {
            get { return l_URL; }
            set { l_URL = value; }
        }
       /// <summary>
       /// ���������
       /// </summary>
        private int l_SID;

        public int L_SID
        {
            get { return l_SID; }
            set { l_SID = value; }
        }
    }
}
