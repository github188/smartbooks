using System;
using System.Collections.Generic;
using System.Text;

namespace PubClass
{
    /// <summary>
    /// 常用公共方法类
    /// </summary>
  public static  class Tool
    {
      /// <summary>
      /// 获得短日期  格式为：2010-12-21
      /// </summary>
      /// <param name="strDate"></param>
      /// <returns></returns>
      public static string Get_ShortDate(string strDate) {
          DateTime dtTime = Convert.ToDateTime(strDate);
          string strMonth = dtTime.Month<10?"0"+dtTime.Month : dtTime.Month.ToString();
          string strDay = dtTime.Day<10?"0" + dtTime.Day : dtTime.Day.ToString();
          return dtTime.Year + "-" + strMonth + "-" + strDay;
      }
      /// <summary>
      /// 获得日期中的月份和天数 格式为：12-21
      /// </summary>
      /// <param name="strDate"></param>
      /// <returns></returns>
      public static string Get_MonthAndDay(string strDate) {
          DateTime dtTime = Convert.ToDateTime(strDate);
          string strMonth = dtTime.Month < 10 ? "0" + dtTime.Month : dtTime.Month.ToString();
          string strDay = dtTime.Day < 10 ? "0" + dtTime.Day : dtTime.Day.ToString();
          return strMonth + "-" + strDay;
      }
      /// <summary>
      /// 截取指定长度的字符串
      /// </summary>
      /// <param name="str">被截取的字符串</param>
      /// <param name="length">截取的长度</param>
      /// <returns></returns>
      public static string SubString(string str, int length)
      {
          if (str.Length <= length)
              return str;
          else
              return str.Substring(0, length - 1) + "...";
      }
      /// <summary>
      /// 根据指定的日期获得该日期所在的季度的开始日期和结束日期的下一天
      /// </summary>
      /// <param name="strDate"></param>
      /// <returns></returns>
      public static string[] Get_DateInQuarterByDate(string strDate) {
          DateTime dTime = Convert.ToDateTime(strDate);
          int year = dTime.Year;
          int month = dTime.Month;
          string[] QuarterArr = new string[2];
          if (month == 1 || month == 2 || month == 3) {
              QuarterArr[0] = year + "-1-1";
              QuarterArr[1] = year + "-4-1";
          }
          else if (month == 4 || month == 5 || month == 6)
          {
              QuarterArr[0] = year + "-4-1";
              QuarterArr[1] = year + "-7-1";
          }else if(month==7||month==8||month==9)
          {
              QuarterArr[0] = year + "-7-1";
              QuarterArr[1] = year + "-10-1";
          }
          else if (month == 10 || month == 11 || month == 12)
          {
              QuarterArr[0] = year + "-10-1";
              QuarterArr[1] = (year+1) + "-1-1";
          }
          return QuarterArr;
      }
      //根据指定的月份获得所在季度序号
      public static int Get_QuarterByMonth(int month) {
          int quarter = 0;
          if (month == 1 || month == 2 || month == 3) {
              quarter = 1;
          }else if(month == 4 || month == 5 || month == 6){
              quarter = 2;
          }
          else if (month == 7 || month == 8 || month == 9)
          {
              quarter = 3;
          }
          else if (month == 10 || month == 11 || month == 12)
          {
              quarter = 4;
          }
          return quarter;
      }
      /// <summary>
      /// 为SQL字符串补引号
      /// </summary>
      /// <param name="str_check"></param>
      /// <returns></returns>
      public static string CheckStr(string str_check)
      {
          string str = str_check;
          int pos = str.IndexOf("'");
          while (pos >= 0)
          {
              str = str.Insert(pos, "'");
              pos = str.IndexOf("'", pos + 2);
          }
          return str;
      }
    }
}
