using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
  [Serializable]
  public  class UserInfo
    {
      /// <summary>
      /// 编号
      /// </summary>
        private int u_ID;
        public int U_ID
        {
            get { return u_ID; }
            set { u_ID = value; }
        }
      /// <summary>
      /// 用户名
      /// </summary>
        private string u_Name;
        public string U_Name
        {
            get { return u_Name; }
            set { u_Name = value; }
        }
      /// <summary>
      /// 密码
      /// </summary>
        private string u_Pwd;
        public string U_Pwd
        {
            get { return u_Pwd; }
            set { u_Pwd = value; }
        }
      /// <summary>
      /// 用户备注
      /// </summary>
        private string u_Remark;
        public string U_Remark
        {
            get { return u_Remark; }
            set { u_Remark = value; }
        }
      /// <summary>
      /// 用户权限
      /// </summary>
        private int u_Power;

        public int U_Power
        {
            get { return u_Power; }
            set { u_Power = value; }
        }
      /// <summary>
      /// 所属服务区编号
      /// </summary>
        private int u_SID;

        public int U_SID
        {
            get { return u_SID; }
            set { u_SID = value; }
        }
    }
}
