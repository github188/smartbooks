using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// �����ļ�����ʵ����
    /// </summary>
  public class FileType
    {
      /// <summary>
      /// ���ͱ��
      /// </summary>
        private int fT_ID;

        public int FT_ID
        {
            get { return fT_ID; }
            set { fT_ID = value; }
        }
      /// <summary>
      /// ��������
      /// </summary>
        private string fT_Name;

        public string FT_Name
        {
            get { return fT_Name; }
            set { fT_Name = value; }
        }
    }
}
