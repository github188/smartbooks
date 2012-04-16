using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// 下载文件类型实体类
    /// </summary>
  public class FileType
    {
      /// <summary>
      /// 类型编号
      /// </summary>
        private int fT_ID;

        public int FT_ID
        {
            get { return fT_ID; }
            set { fT_ID = value; }
        }
      /// <summary>
      /// 类型名称
      /// </summary>
        private string fT_Name;

        public string FT_Name
        {
            get { return fT_Name; }
            set { fT_Name = value; }
        }
    }
}
