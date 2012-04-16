using System;
using System.Text.RegularExpressions;


	public class StringValidation
	{
    /// <summary>
    /// 用来验证指定字符串是否具有指定的长度并且全是数字。
    /// </summary>
    /// <param name="str">指定的字符串</param>
    /// <param name="strLength">指定的长度</param>
    /// <returns>返回值</returns>
    public static bool isLengthSetNumString(string str,int strLength)
    {
      return Regex.IsMatch(str,@"\d{" +strLength+ @"}");
    }

    /// <summary>
    /// 用来验证指定的字符串是否是符合中国省份证号码要求。
    /// </summary>
    /// <param name="str">指定的字符串</param>
    /// <returns>返回值</returns>
    public static bool isChinaIDCardNumString(string str)
    {
      return Regex.IsMatch(str,@"\d{18}|\d{15}");
    }

    /// <summary>
    /// 用来验证指定的字符串是否是中国电话号码格式。
    /// </summary>
    /// <param name="str">指定的字符串</param>
    /// <returns>返回值</returns>
    public static bool isChinaTelNumString(string str)
    {
        return Regex.IsMatch(str, @"29\d\d\d\d\d");
    }

    /// <summary>
    /// 用来验证指定的字符串的长度是否在两个指定值之间，并且全是数字。
    /// </summary>
    /// <param name="str">指定的字符串</param>
    /// <param name="minLength">指定的最小长度</param>
    /// <param name="maxLength">指定的最大长度</param>
    /// <returns>返回值</returns>
    public static bool isLengthBetweenNumString(string str,int minLength,int maxLength)
    {
      return Regex.IsMatch(str,@"\d{3}|\d{2}");
    }

    /// <summary>
    /// 用来验证指定的字符串是否是正确的电子邮件格式。
    /// </summary>
    /// <param name="str">指定的字符串</param>
    /// <returns>返回值</returns>
    public static bool isEmailString(string str)
    {
      return Regex.IsMatch(str,@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
	
}
