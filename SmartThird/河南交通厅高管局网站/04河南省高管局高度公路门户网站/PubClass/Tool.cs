using System;
using System.Collections.Generic;
using System.Text;

namespace PubClass
{
    /// <summary>
    /// ���ù���������
    /// </summary>
  public static  class Tool
    {
      /// <summary>
      /// ��ö�����  ��ʽΪ��2010-12-21
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
      /// ��������е��·ݺ����� ��ʽΪ��12-21
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
      /// ��ȡָ�����ȵ��ַ���
      /// </summary>
      /// <param name="str">����ȡ���ַ���</param>
      /// <param name="length">��ȡ�ĳ���</param>
      /// <returns></returns>
      public static string SubString(string str, int length)
      {
          if (str.Length <= length)
              return str;
          else
              return str.Substring(0, length - 1) + "...";
      }
      /// <summary>
      /// ����ָ�������ڻ�ø��������ڵļ��ȵĿ�ʼ���ںͽ������ڵ���һ��
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
      //����ָ�����·ݻ�����ڼ������
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
      /// ΪSQL�ַ���������
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
