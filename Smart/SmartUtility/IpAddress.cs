using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Smart.Utility
{
    /// <summary>
    /// 
    /// </summary>
   public class IpAddress
    {
       private static string strgetIP;

       //public static string netIP()
       //{
       //    Uri uri = new Uri("http://www.ikaka.com/ip/index.asp");//查本机网络IP的网页
       //    try
       //    {
       //        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
       //        req.Method = "POST";
       //        req.ContentType = "application/x-www-form-urlencoded";
       //        req.ContentLength = 0;
       //        req.CookieContainer = new CookieContainer();
       //        req.GetRequestStream().Write(new byte[0], 0, 0);
       //        HttpWebResponse res = (HttpWebResponse)(req.GetResponse());
       //        StreamReader rs = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("GB18030"));
       //        string s = rs.ReadToEnd();
       //        rs.Close();
       //        req.Abort();
       //        res.Close();
       //        Match m = Regex.Match(s, @"IP：/[(?<IP>[0-9/.]*)/]");
       //        if (m.Success) return m.Groups["IP"].Value;
       //        string strnetIP = string.Empty;
       //        return strnetIP;
              
       //    }
       //    catch (Exception ex)
       //    {
               
       //        throw ex;
       //    }
          
       //}

        public static string getIP()//注意与static 的区别
        {
            System.Net.IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;//获取本机内网IP


            strgetIP = addressList[0].ToString();
            return strgetIP;

        }



    }
}
