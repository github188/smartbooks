using System;
using System.Collections.Generic;
using System.Text;

namespace RoadEntity
{
    /// <summary>
    /// 路政单位用户实体类
    /// </summary>
  [Serializable]
  public  class UserInfo
    {
      /// <summary>
      /// 用户编号
      /// </summary>
        private int u_ID;

        public int U_ID
        {
            get { return u_ID; }
            set { u_ID = value; }
        }
      /// <summary>
      /// 登录用户名
      /// </summary>
        private string u_LoginName;

        public string U_LoginName
        {
            get { return u_LoginName; }
            set { u_LoginName = value; }
        }
      /// <summary>
      /// 登录密码
      /// </summary>
        private string u_LoginPwd;

        public string U_LoginPwd
        {
            get { return u_LoginPwd; }
            set { u_LoginPwd = value; }
        }
      /// <summary>
      /// 用户真实姓名
      /// </summary>
        private string u_TrueName;

        public string U_TrueName
        {
            get { return u_TrueName; }
            set { u_TrueName = value; }
        }
      /// <summary>
      /// 用户联系电话
      /// </summary>
        private string u_Phone;

        public string U_Phone
        {
            get { return u_Phone; }
            set { u_Phone = value; }
        }
      /// <summary>
      /// 用户所属单位实体类对象
      /// </summary>
        private RoadDepart u_RoadDepart;

        public RoadDepart U_RoadDepart
        {
            get { return u_RoadDepart; }
            set { u_RoadDepart = value; }
        }
      /// <summary>
      /// 是否标志为超级管理员 1：超级管理员 0：一般路政单位用户
      /// </summary>
        private int u_IsSuper;

        public int U_IsSuper
        {
            get { return u_IsSuper; }
            set { u_IsSuper = value; }
        }
    }
}
