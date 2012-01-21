
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Diagnostics;

    /// <summary>
    /// 写入滚动文件Appender
    /// 
    /// 每天一个日志
    /// </summary>
    public class RollingFileAppender : IAppender
    {
        /// <summary>
        /// 默认的文件容量
        /// </summary>
        public const int DefaultFileSize = 800 * 1024;//800K  
        private static int  rollingFileSize = DefaultFileSize;

		/// <summary>
		/// 固定文件大小
		/// </summary>
        public static int  RollingFileSize
        {
            set
            {
                rollingFileSize = value >= 1024 ? value : DefaultFileSize; 
            }
            get
            {
                return rollingFileSize;
            }
        }

        #region 获取系统路径和Windows路径

        [DllImport("kernel32")]
        private static extern void GetWindowsDirectory(StringBuilder WinDir, int count);
        [DllImport("kernel32")]
        private static extern void GetSystemDirectory(StringBuilder SysDir, int count);

        /// <summary>
        /// 得到windows路径
        /// </summary>
        /// <returns></returns>
        public static string GetWindowsDir()
        {
            StringBuilder sb = new StringBuilder(255, 256);
            GetWindowsDirectory(sb, 255);
            return sb.ToString();
        }
        /// <summary>
        /// 得到系统路径
        /// </summary>
        /// <returns></returns>
        public static string GetSysDir()
        {
            StringBuilder sb = new StringBuilder(255, 256);
            GetSystemDirectory(sb, 255);
            return sb.ToString();
        }
        #endregion


        /// <summary>
        /// 检查目录
        /// 
        /// 不存在就创建
        /// </summary>
        /// <param name="path"></param>
        public static void CheckDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            try
            {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path); 
            }
            catch (Exception)
            {
            }
        }  
     
        /// <summary>
        /// 转移文件到compact目录
        /// </summary>
        /// <param name="filePath">当前文件路径</param>
        /// <param name="orgFile">当前文件名</param>
        /// <param name="newFile">新文件名</param>
        public static void CompactFile(string filePath, string orgFile, string newFile)
        {
            try
            {  
                DirectoryInfo dirInfo = new DirectoryInfo(filePath + "\\CompactFile");
                if (!dirInfo.Exists)
                {
                    Directory.CreateDirectory(filePath + "\\CompactFile");
                }

                File.Move(orgFile, filePath + "\\CompactFile\\" + newFile);
            }
            catch (Exception)
            {
            }

        }
        /// <summary>
        /// 删除Compact文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="holdDays">日志保留天数</param>
        public static void DeleteCompactFile(string filePath, int holdDays)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(filePath + "\\CompactFile");

                foreach (FileInfo fInfo in dirInfo.GetFiles("*.*"))
                {
                    TimeSpan timeEscape = DateTime.Now - fInfo.CreationTime;
                    if (timeEscape.Days > holdDays)
                    {
                        File.Delete(fInfo.FullName);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 检查日志文件是否存在
        /// 
        /// 返回全路径的文件名，找不到，返回0
        /// </summary>
		/// <param name="filePath">文件路径</param>
		/// <param name="logCategory"></param>
		/// <param name="fileName">文件名称</param>
		/// <returns>返回全路径的文件名</returns>
        public static string CheckFileRecord(string filePath,string logCategory, ref string fileName)
        {
            try
            {  
                DirectoryInfo dirInfo = new DirectoryInfo(filePath);

                foreach (FileInfo fInfo in dirInfo.GetFiles(logCategory + "*.*"))
                {
                    fileName = fInfo.Name;
                    return fInfo.FullName;
                }
            }
            catch (Exception)
            {
                return "";
            }
            return "";
        }

          /// <summary>
        /// 删除Compact文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="holdDays">日志保留天数</param>
        /// <param name="logCategory">文件类型：填LogCategory对象</param>
        public static void DeleteOldFile(string filePath, int holdDays, string logCategory)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(filePath);

                foreach (FileInfo fInfo in dirInfo.GetFiles(logCategory + "*.*"))
                {
                    TimeSpan timeEscape = DateTime.Now - fInfo.CreationTime;
                    if (timeEscape.Days > holdDays)
                    {
                        File.Delete(fInfo.FullName);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 删除Compact文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="holdDays">日志保留天数</param>
        public static void DeleteOldFile(string filePath, int holdDays)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(filePath);

                foreach (FileInfo fInfo in dirInfo.GetFiles("*.*"))
                {
                    TimeSpan timeEscape = DateTime.Now - fInfo.CreationTime;
                    if (timeEscape.Days > holdDays)
                    {
                        File.Delete(fInfo.FullName);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
      
       
        /// <summary>                                 
        /// 日志的简单实现
        /// 
        /// 
        /// </summary>
		/// <param name="fullFileName">当fullFileName ＝“”时候,按默认当天日期作为文件名</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SimpleFileLog(string fullFileName, string message)
        {  
            bool bReturn = false;  
            try
            {
                //如果文件不存在，建立文件
                if (!File.Exists(fullFileName))
                {
                    FileStream fs = new FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fullFileName, true);

                sw.BaseStream.Seek(0, SeekOrigin.End);
                //sw.Write("{0}\t{1}\r\n", DateTime.Now.ToString(), message);
                sw.Write("{0}\r\n", message);
                sw.WriteLine();
                sw.Flush();
                sw.Close();

                FileInfo fi = new FileInfo(fullFileName);

                if (fi.Length > RollingFileAppender.rollingFileSize)// DefaultFileSize
                {
                    string newFileName = fi.Name.ToUpper();
                    int length = newFileName.Length > fi.Extension.Length ?   newFileName.Length -(fi.Extension.Length +1) : newFileName.Length ;
                    newFileName = newFileName.Substring(0, length) + "-" + GetFileNameFromTime(fi.Extension);
                    
                    File.Move(fullFileName, fi.DirectoryName +"\\"+ newFileName);
                }

                bReturn = true;
            }
            catch (Exception)
            {
                bReturn = false;
            }
            return bReturn;
        } 
        /// <summary>
        /// 从当前的系统时间，生成文件名：年月日时分秒
        /// </summary>
        /// <returns></returns>
        private static string GetFileNameFromDateTime()
        {
            string newFileName = string.Format("{0}{1}{2}{3}{4}{5}.txt",
                       DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            return newFileName;

        }
        /// <summary>
        /// 从当前的系统时间，生成文件名：时分秒
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        private static string GetFileNameFromTime(string extension)
        {
            string newFileName = string.Format("{0}{1}{2}.{3}",
                     DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, extension);
            return newFileName;

        }
        /// <summary>
        /// 从当前的系统时间，生成文件名：年月日
        /// </summary>
        /// <returns></returns>
        public static string GetFileNameFromDate()
        {
            string newFileName = string.Format("{0}{1}{2}.txt",
                       DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return newFileName;

        }
    }
}
                                         