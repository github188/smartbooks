
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 登陆记录类型
    /// </summary>
    public class LoginTypeEnum
    {
        /// <summary>
        /// 1 登陆成功
        /// </summary>
        public const int Successed = 1;
        /// <summary>
        /// 0 退出登陆
        /// </summary>
        public const int Exit = 0;
        /// <summary>
        /// －1 登陆失败 
        /// </summary>
        public const int Failed = -1;
    }
}
