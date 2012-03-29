using System;
using System.Text.RegularExpressions;


	public class StringValidation
	{
    /// <summary>
    /// ������ָ֤���ַ����Ƿ����ָ���ĳ��Ȳ���ȫ�����֡�
    /// </summary>
    /// <param name="str">ָ�����ַ���</param>
    /// <param name="strLength">ָ���ĳ���</param>
    /// <returns>����ֵ</returns>
    public static bool isLengthSetNumString(string str,int strLength)
    {
      return Regex.IsMatch(str,@"\d{" +strLength+ @"}");
    }

    /// <summary>
    /// ������ָ֤�����ַ����Ƿ��Ƿ����й�ʡ��֤����Ҫ��
    /// </summary>
    /// <param name="str">ָ�����ַ���</param>
    /// <returns>����ֵ</returns>
    public static bool isChinaIDCardNumString(string str)
    {
      return Regex.IsMatch(str,@"\d{18}|\d{15}");
    }

    /// <summary>
    /// ������ָ֤�����ַ����Ƿ����й��绰�����ʽ��
    /// </summary>
    /// <param name="str">ָ�����ַ���</param>
    /// <returns>����ֵ</returns>
    public static bool isChinaTelNumString(string str)
    {
        return Regex.IsMatch(str, @"29\d\d\d\d\d");
    }

    /// <summary>
    /// ������ָ֤�����ַ����ĳ����Ƿ�������ָ��ֵ֮�䣬����ȫ�����֡�
    /// </summary>
    /// <param name="str">ָ�����ַ���</param>
    /// <param name="minLength">ָ������С����</param>
    /// <param name="maxLength">ָ������󳤶�</param>
    /// <returns>����ֵ</returns>
    public static bool isLengthBetweenNumString(string str,int minLength,int maxLength)
    {
      return Regex.IsMatch(str,@"\d{3}|\d{2}");
    }

    /// <summary>
    /// ������ָ֤�����ַ����Ƿ�����ȷ�ĵ����ʼ���ʽ��
    /// </summary>
    /// <param name="str">ָ�����ַ���</param>
    /// <returns>����ֵ</returns>
    public static bool isEmailString(string str)
    {
      return Regex.IsMatch(str,@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
	
}
