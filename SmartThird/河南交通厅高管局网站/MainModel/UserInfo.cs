using System;
using System.Collections.Generic;
using System.Text;

namespace MainModel
{
    /// <summary>
    /// ��̨�����û���Ϣʵ����
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// �û����
        /// </summary>
        private int u_ID;

        public int U_ID
        {
            get { return u_ID; }
            set { u_ID = value; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        private string u_Name;

        public string U_Name
        {
            get { return u_Name; }
            set { u_Name = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        private string u_Pwd;
        public string U_Pwd
        {
            get { return u_Pwd; }
            set { u_Pwd = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        private string u_CreateDate;
        public string U_CreateDate
        {
            set { u_CreateDate = value; }
            get { return u_CreateDate; }
        }
        /// <summary>
        /// ���ű��
        /// </summary>
        private int u_DepartId;
        public int U_DepartId
        {
            get { return u_DepartId; }
            set { u_DepartId = value; }
        }
    }
}
