using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;


/// <summary>
/// ���ù��ܺ�����
/// </summary>
public class CommonFunction
{
    /// <summary>
    /// js�ű�������ʾ�Ի���
    /// </summary>
    /// <param name="strMsg"></param>
    public static void Alert(Literal lbl, string strMsg)
    {
        lbl.Text = "<script>alert('" + strMsg + "');</script>";
    }
    /// <summary>
    /// js�ű�������ʾ�Ի����ض�����ҳ��
    /// </summary>
    /// <param name="strMsg"></param>
    /// <param name="toURL"></param>
    public static void AlertAndRedirect(Literal lbl, string strMsg, string toURL)
    {
        lbl.Text = "<script>alert('" + strMsg + "');window.location.href='" + toURL + "';</script>";
    }
    /// <summary>
    /// js�ű�������ʾ�Ի���
    /// </summary>
    /// <param name="strMsg"></param>
    public static void Alert(string strMsg)
    {
        HttpContext.Current.Response.Write("<script>alert('" + strMsg + "');</script>");
    }
    /// <summary>
    /// js�ű�������ʾ�Ի����ض�����ҳ��
    /// </summary>
    /// <param name="strMsg"></param>
    /// <param name="toURL"></param>
    public static void AlertAndRedirect(string strMsg, string toURL)
    {
        HttpContext.Current.Response.Write("<script>alert('" + strMsg + "');window.location.href='" + toURL + "';</script>");
    }
    /// <summary>
    /// Ajax��ˢ��js�ű�������ʾ�Ի���
    /// </summary>
    /// <param name="uPanel"></param>
    /// <param name="strMsg"></param>
    public static void AjaxAlert(UpdatePanel uPanel, string strMsg)
    {
        ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "", "alert('" + strMsg + "');", true);
    }
    /// <summary>
    /// Ajax��ˢ��js�ű�������ʾ�Ի����ض�����ҳ��
    /// </summary>
    /// <param name="uPanel"></param>
    /// <param name="strMsg"></param>
    /// <param name="toURL"></param>
    public static void AjaxAlertAndRedirect(UpdatePanel uPanel, string strMsg, string toURL)
    {
        ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "", "alert('" + strMsg + "');window.location.href='" + toURL + "';", true);
    }
    /// <summary>
    /// ���������漴��ӱ���ͼƬ
    /// </summary>
    public static void DrawImage()
    {

        HttpContext.Current.Session["CheckCode"] = RndNum(4);
        CreateImages(HttpContext.Current.Session["CheckCode"].ToString());
    }
    /// <summary>
    /// �����������ĸ
    /// </summary>
    /// <param name="VcodeNum">������ĸ�ĸ���</param>
    /// <returns>string</returns>
    private static string RndNum(int VcodeNum)
    {
        string Vchar = "0,1,2,3,4,5,6,7,8,9";
        string[] VcArray = Vchar.Split(',');
        string VNum = ""; //�����ַ����̣ܶ��Ͳ���StringBuilder��
        int temp = -1; //��¼�ϴ������ֵ������������������һ���������

        //����һ���򵥵��㷨�Ա�֤����������Ĳ�ͬ
        Random rand = new Random();
        for (int i = 1; i < VcodeNum + 1; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(VcArray.Length);
            if (temp != -1 && temp == t)
            {
                return RndNum(VcodeNum);
            }
            temp = t;
            VNum += VcArray[t];
        }
        return VNum;
    }
    /// <summary>
    /// ������֤ͼƬ
    /// </summary>
    /// <param name="checkCode">��֤�ַ�</param>
    public static void CreateImages(string checkCode)
    {
        int iwidth = (int)(checkCode.Length * 13);
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 25);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);
        //������ɫ
        Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
        //�������� 
        string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "����" };
        Random rand = new Random();
        //���������
        for (int i = 0; i < 50; i++)
        {
            int x = rand.Next(image.Width);
            int y = rand.Next(image.Height);
            g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
        }

        //�����ͬ�������ɫ����֤���ַ�
        for (int i = 0; i < checkCode.Length; i++)
        {
            int cindex = rand.Next(7);
            int findex = rand.Next(5);

            Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
            Brush b = new System.Drawing.SolidBrush(c[cindex]);
            int ii = 4;
            if ((i + 1) % 2 == 0)
            {
                ii = 2;
            }
            g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
        }
        //��һ���߿�
        g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

        //����������
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        HttpContext.Current.Response.ClearContent();
        //Response.ClearContent();
        HttpContext.Current.Response.ContentType = "image/Jpeg";
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }
    /// <summary>
    /// �ж��Ƿ��¼��û�е�¼����Ȩ��������ҳ��
    /// </summary>
    public static void isLoginCheck()
    {
        if (HttpContext.Current.Session["ServiceUser"] != null)
        {
            if (HttpContext.Current.Session["ServiceUser"].ToString().Length == 0)
            {
                CommonFunction.AlertAndRedirect("�û���½ʧ�ܣ���δ��½!", "Login.aspx");
                HttpContext.Current.Response.End();
            }
        }
        else
        {
            CommonFunction.AlertAndRedirect("�û���½ʧ�ܣ���δ��½!", "Login.aspx");
            HttpContext.Current.Response.End();

        }
    }
    /// <summary>
    /// �ж��Ƿ�ѡ��һ�����������ư�����˳�ν��������ҳ��
    /// </summary>
    public static void isSelectedService()
    {
        if (HttpContext.Current.Session["serviceinfo"] != null)
        {
            if (HttpContext.Current.Session["serviceinfo"].ToString().Length == 0)
            {
                HttpContext.Current.Response.Redirect("ServiceList.aspx");
                HttpContext.Current.Response.End();
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("ServiceList.aspx");
            HttpContext.Current.Response.End();

        }
    }
    /// <summary> 
    /// �������� 
    /// </summary> 
    /// <param name="Text"></param> 
    /// <param name="sKey"></param> 
    /// <returns></returns> 
    public static string Encrypt(string Text, string sKey)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] inputByteArray;
        inputByteArray = Encoding.Default.GetBytes(Text);
        des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        StringBuilder ret = new StringBuilder();
        foreach (byte b in ms.ToArray())
        {
            ret.AppendFormat("{0:X2}", b);
        }
        return ret.ToString();
    }
    /// <summary> 
    /// �������� 
    /// </summary> 
    /// <param name="Text"></param> 
    /// <param name="sKey"></param> 
    /// <returns></returns> 
    public static string Decrypt(string Text, string sKey)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        int len;
        len = Text.Length / 2;
        byte[] inputByteArray = new byte[len];
        int x, i;
        for (x = 0; x < len; x++)
        {
            i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
            inputByteArray[x] = (byte)i;
        }
        des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Encoding.Default.GetString(ms.ToArray());
    }
    /// <summary>
    /// �ж�������ַ����Ƿ��ǺϷ��ķǸ������������㣩
    /// @author ���
    /// @date 2010-9-26
    /// </summary>
    /// <param name="strInput">Ҫ�жϵ��ַ���</param>
    /// <returns>bool</returns>
    public static bool Is_Nonnegative(string strInput)
    {
        int sum_dot = 0;
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strInput);
        if (bytes.Length == 0)
            return false;
        if (bytes.Length == 1 && !(bytes[0] >= 48 && bytes[0] <= 57))
            return false;
        if (bytes.Length > 1)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 46)
                {
                    sum_dot++;
                }
                else if (bytes[i] >= 48 && bytes[i] <= 57)
                {

                }
                else
                {
                    return false;
                }
            }
            if (sum_dot > 1)
                return false;
        }
        return true;
    }
    /// <summary>
    /// ���ݵ�ǰ���ڵ���϶�̬����ַ���
    /// </summary>
    /// <returns></returns>
    public static string Get_DynamicString()
    {
        return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
    }
    /// <summary>
    /// �ļ��ϴ�
    /// </summary>
    /// <param name="fileUpload">�ϴ��ؼ�</param>
    /// <param name="path">�ϴ�·��</param>
    /// <param name="allowExtension">�����ϴ��ļ��ĺ�׺��</param>
    /// <returns></returns>
    public static bool Is_FileUploadSuccessfully(FileUpload fileUpload, Literal lit, string path, string[] allowExtension)
    {
        bool fileOK = false;
        if (!fileUpload.HasFile)
        {
            CommonFunction.Alert(lit, "ѡ���ϴ����ļ�");
            return false;
        }
        string fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();
        for (int i = 0; i < allowExtension.Length; i++)
        {
            if (fileExtension == allowExtension[i])
            {
                fileOK = true;
                break;
            }
        }
        if (!fileOK)
        {
            CommonFunction.Alert(lit, "�ļ��ĸ�ʽ����ȷ");
            return false;
        }
        try
        {
            fileUpload.PostedFile.SaveAs(path);
            CommonFunction.Alert(lit, "�ϴ��ɹ���");
            return true;
        }
        catch (Exception ex)
        {
            CommonFunction.Alert(lit, "�ϴ�ʧ��");
            return false;
        }
    }

    public static string _GetMidInfo(string strVal, string start, string end)
    {
        if (strVal.Length == 0)
        {
            return "";
        }

        if (strVal.IndexOf(start) >= 0 && strVal.IndexOf(end) > 0)
        {
            int pos1 = strVal.IndexOf(start);
            int pos2 = strVal.IndexOf(end);
            pos1 = pos1 + 1;
            pos2 = pos2 - pos1;

            string mid = "";
            if (strVal.Length > pos1 && strVal.Length > pos2 + pos1 && pos1>0 && pos2>0)
            {
                mid = strVal.Substring(pos1, pos2);
            }

            return mid;
        }
        else
        {
            return strVal;
        }
    }
}
