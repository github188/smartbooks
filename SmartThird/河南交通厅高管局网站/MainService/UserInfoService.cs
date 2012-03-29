using System;
using System.Collections.Generic;
using System.Text;
using MainModel;
using System.Data;
using PubClass;
using System.Data.SqlClient;

namespace MainService
{
    /// <summary>
    /// 后台管理用户数据访问类
    /// </summary>
 public static   class UserInfoService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static int Insert_User(UserInfo u)
        {
            string sqlStr = "insert into Main_UserInfo(U_Name,U_Pwd,U_DepartId) values('" + u.U_Name + "','" +u.U_Pwd+ "','" + u.U_DepartId + "')";
            return DBHelper.ExecuteCommand(sqlStr);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int Delete_User(int uid)
        {
            string sqlStr = "delete from Main_UserInfo where U_ID=" + uid;
            return DBHelper.ExecuteCommand(sqlStr);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static int Update_User(UserInfo u)
        {
            string sqlStr = "update Main_UserInfo set U_Name='" + u.U_Name + "',U_Pwd='" +u.U_Pwd+ "',U_DepartId='" + u.U_DepartId + "' where U_ID=" + u.U_ID;
            return DBHelper.ExecuteCommand(sqlStr);
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static UserInfo Get_UserInfo(string strName)
        {
            UserInfo user = null;
            string sqlStr = "select * from Main_UserInfo where U_Name=@name";
            SqlParameter[] param = new SqlParameter[]{
            new SqlParameter("@name",strName)
          };
            DataTable dt = DBHelper.GetDataSet(sqlStr, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                user = new UserInfo();
                user.U_ID = Convert.ToInt32(dt.Rows[0]["U_ID"]);
                user.U_Name = dt.Rows[0]["U_Name"].ToString();
                user.U_Pwd = dt.Rows[0]["U_Pwd"].ToString();
                user.U_DepartId = Convert.ToInt32(dt.Rows[0]["U_DepartId"]);
            }
            return user;
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static UserInfo Get_UserInfo(int uid)
        {
            UserInfo user = null;
            string sqlStr = "select * from Main_UserInfo where U_ID=@uid";
            SqlParameter[] param = new SqlParameter[]{
            new SqlParameter("@uid",uid)
          };
            DataTable dt = DBHelper.GetDataSet(sqlStr, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                user = new UserInfo();
                user.U_ID = Convert.ToInt32(dt.Rows[0]["U_ID"]);
                user.U_Name = dt.Rows[0]["U_Name"].ToString();
                user.U_Pwd = dt.Rows[0]["U_Pwd"].ToString();
                user.U_DepartId = Convert.ToInt32(dt.Rows[0]["U_DepartId"]);
            }
            return user;
        }
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static bool IsExistUserInfo(string strName)
        {
            string sqlStr = "select count(*) from Main_UserInfo where U_Name='" + strName + "'";
            return DBHelper.IsExistRecord(sqlStr);
        }
    }
}
