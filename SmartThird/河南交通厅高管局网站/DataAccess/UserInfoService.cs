using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using PubClass;

namespace DataAccess
{
    /// <summary>
    /// 用户信息数据访问类
    /// </summary>
  public static  class UserInfoService
    {
      /// <summary>
      /// 添加用户
      /// </summary>
      /// <param name="u"></param>
      /// <returns></returns>
      public static int Insert_User(UserInfo u) {
          string sqlStr = "insert into T_UserInfo(U_Name,U_Pwd,U_Remark,U_Power,U_SID) values('"+u.U_Name+"','"+u.U_Pwd+"','"+u.U_Remark+"','"+u.U_Power+"','"+u.U_SID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 删除用户
      /// </summary>
      /// <param name="uid"></param>
      /// <returns></returns>
      public static int Delete_User(int uid) {
          string sqlStr = "delete from T_UserInfo where U_ID="+uid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 修改用户信息
      /// </summary>
      /// <param name="u"></param>
      /// <returns></returns>
      public static int Update_User(UserInfo u) {
          string sqlStr = "update T_UserInfo set U_Pwd='"+u.U_Pwd+"',U_Remark='"+u.U_Remark+"' where U_ID="+u.U_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// 获得用户信息
      /// </summary>
      /// <param name="strName"></param>
      /// <returns></returns>
      public static UserInfo Get_UserInfo(string strName) {
          UserInfo user = null;
          string sqlStr = "select * from T_UserInfo where U_Name=@name";
          SqlParameter[] param = new SqlParameter[]{
            new SqlParameter("@name",strName)
          };
          DataTable dt = DBHelper.GetDataSet(sqlStr,param);
          if (dt != null && dt.Rows.Count > 0) {
              user = new UserInfo();
              user.U_ID = Convert.ToInt32(dt.Rows[0]["U_ID"]);
              user.U_Name = dt.Rows[0]["U_Name"].ToString();
              user.U_Pwd = dt.Rows[0]["U_Pwd"].ToString();
              user.U_Remark = dt.Rows[0]["U_Remark"].ToString();
              user.U_Power = Convert.ToInt32(dt.Rows[0]["U_Power"]);
              user.U_SID = Convert.ToInt32(dt.Rows[0]["U_SID"]);
          }
          return user;
      }
      /// <summary>
      /// 获得用户信息
      /// </summary>
      /// <param name="uid"></param>
      /// <returns></returns>
      public static UserInfo Get_UserInfo(int uid) {
          UserInfo user = null;
          string sqlStr = "select * from T_UserInfo where U_ID=@uid";
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
              user.U_Remark = dt.Rows[0]["U_Remark"].ToString();
              user.U_Power = Convert.ToInt32(dt.Rows[0]["U_Remark"]);
              user.U_SID = Convert.ToInt32(dt.Rows[0]["U_SID"]);
          }
          return user;
      }
      /// <summary>
      /// 获得所有服务区用户信息
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_AllServiceUserInfo() {
          string sqlStr = "select * from T_UserInfo where U_Power=1";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 判断用户是否存在
      /// </summary>
      /// <param name="strName"></param>
      /// <returns></returns>
      public static bool IsExistUserInfo(string strName) {
          string sqlStr = "select count(*) from T_UserInfo where U_Name='"+strName+"'";
          return DBHelper.IsExistRecord(sqlStr);
      }
      /// <summary>
      /// 获得服务区用户视图
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_UserView() {
          string sqlStr = "select * from V_UserInfo order by S_ID asc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// 根据用户名获得用户试图信息
      /// </summary>
      /// <param name="strUName"></param>
      /// <returns></returns>
      public static DataTable Get_UserViewByName(string strUName) {
          string sqlStr = "select * from V_UserInfo where U_Name like '%"+strUName+"%'";
          return DBHelper.GetDataSet(sqlStr);
      }  
    }
}
