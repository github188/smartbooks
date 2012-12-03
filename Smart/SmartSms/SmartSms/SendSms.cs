
namespace Smart.Sms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Configuration;
    using System.Threading;

    /// <summary>
    /// 短信发送类
    /// </summary>
    public class SendSms
    {
        /// <summary>
        /// 使用Kxcom.cn接口发送短信
        /// </summary>
        /// <param name="phones">电话列表</param>
        /// <param name="content">短信内容</param>
        /// <returns>发送状态</returns>
        public static string SendKxcomcn(string phones, string content)
        {
            Kxcomcn.SmsService sms = new Kxcomcn.SmsService();
          
            return sms.SendSms(
                "zzytxxjsyxgs",
                "zzytxxjsyxgs",
                "000000000000000",
                phones,
                content,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        /// <summary>
        /// 使用K1086Com接口发送短信
        /// </summary>
        /// <param name="phones">电话列表</param>
        /// <param name="content">短信内容</param>
        /// <returns>发送状态</returns>
        public static string Send1086Com(string phones, string content)
        {
            sms1086com.WsAPIs sms = new sms1086com.WsAPIs();
            return sms.Send("yutu_sms", "yutusms", phones, content, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
