using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.IO;
using System.Text;

/// <summary>
/// WriteFile 的摘要说明
/// </summary>
public class WriteFile
{
    public WriteFile()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 生成静态页面
    /// </summary>
    /// <param name="strnewsHtml">参数对应的值</param>
    /// <param name="stroldHtml">参数</param>
    /// <param name="strModeFilePath">使用的模板</param>
    /// <param name="strPath">生成的静态页面地址</param>
    /// <returns></returns>
    public static bool createHtml(string[] strnewsHtml, string[] stroldHtml, string strModeFilePath, string strPath)
    {
        bool flag = false;
        StreamReader sr = null;
        StreamWriter sw = null;
        string filepath = HttpContext.Current.Server.MapPath(strModeFilePath);
        Encoding code = Encoding.GetEncoding("gb2312");
        string s = string.Empty;
        try
        {
            sr = new StreamReader(filepath, code); 
            s = sr.ReadToEnd();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sr.Close();
        }
        try
        {
            for (int i = 0; i < strnewsHtml.Length; i++)
            {
                s = s.Replace(stroldHtml[i], strnewsHtml[i]);
            }
            sw = new StreamWriter(HttpContext.Current.Server.MapPath(strPath), false, code);
            sw.Write(s);
            flag = true;
        }
        catch (Exception ex)
        {
            flag = false;
            throw ex;
        }
        finally
        {
            sw.Flush();
            sw.Close();
        }
        return flag;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="strNewsHtml">参数对应的值</param>
    /// <param name="strStartHtml"></param>
    /// <param name="strEndHtml"></param>
    /// <param name="strHtml">使用的模板</param>
    /// <returns></returns>
    public static bool UpdateHtmlPage(string[] strNewsHtml, string[] strStartHtml, string[] strEndHtml, string strHtml)
    {
        bool Flage = false;
        StreamReader ReaderFile = null;
        StreamWriter WrirteFile = null;
        string FilePath = HttpContext.Current.Server.MapPath(strHtml);
        Encoding Code = Encoding.GetEncoding("gb2312");
        string strFile = string.Empty;
        try
        {
            ReaderFile = new StreamReader(FilePath,Code);
            strFile = ReaderFile.ReadToEnd();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ReaderFile.Close();
        }
        try
        {
            int intLengTh = strNewsHtml.Length;
            for (int i = 0; i < intLengTh; i++)
            {
                int intStart = strFile.IndexOf(strStartHtml[i]) + strStartHtml[i].Length;
                int intEnd = strFile.IndexOf(strEndHtml[i]);
                string strOldHtml = strFile.Substring(intStart, intEnd - intStart);
                strFile = strFile.Replace(strOldHtml, strNewsHtml[i]);
            }
            WrirteFile = new StreamWriter(FilePath, false, Code);
            WrirteFile.Write(strFile);
            Flage = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            WrirteFile.Flush();
            WrirteFile.Close();
        }
        return Flage;
    }


}
