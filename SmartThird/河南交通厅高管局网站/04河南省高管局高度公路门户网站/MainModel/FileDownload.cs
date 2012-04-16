using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// 下载文件信息实体类
    /// </summary>
  public  class FileDownload
    {
      /// <summary>
      /// 文件编号
      /// </summary>
        private int fD_ID;

        public int FD_ID
        {
            get { return fD_ID; }
            set { fD_ID = value; }
        }
      /// <summary>
      /// 文件标题
      /// </summary>
        private string fD_Title;

        public string FD_Title
        {
            get { return fD_Title; }
            set { fD_Title = value; }
        }
      /// <summary>
      /// 文件路径
      /// </summary>
        private string fD_Path;

        public string FD_Path
        {
            get { return fD_Path; }
            set { fD_Path = value; }
        }
      /// <summary>
      /// 文件大小
      /// </summary>
        private string fD_Size;

        public string FD_Size
        {
            get { return fD_Size; }
            set { fD_Size = value; }
        }
      /// <summary>
      /// 创建日期
      /// </summary>
        private string fD_CreateDate;

        public string FD_CreateDate
        {
            get { return fD_CreateDate; }
            set { fD_CreateDate = value; }
        }
      /// <summary>
      /// 文件类型编号
      /// </summary>
        private int fD_FTID;

        public int FD_FTID
        {
            get { return fD_FTID; }
            set { fD_FTID = value; }
        }
    }
}
