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
    /// �û���Ϣ���ݷ�����
    /// </summary>
  public static  class UserInfoService
    {
      /// <summary>
      /// ����û�
      /// </summary>
      /// <param name="u"></param>
      /// <returns></returns>
      public static int Insert_User(UserInfo u) {
          string sqlStr = "insert into T_UserInfo(U_Name,U_Pwd,U_Remark,U_Power,U_SID) values('"+u.U_Name+"','"+u.U_Pwd+"','"+u.U_Remark+"','"+u.U_Power+"','"+u.U_SID+"')";
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ɾ���û�
      /// </summary>
      /// <param name="uid"></param>
      /// <returns></returns>
      public static int Delete_User(int uid) {
          string sqlStr = "delete from T_UserInfo where U_ID="+uid;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// �޸��û���Ϣ
      /// </summary>
      /// <param name="u"></param>
      /// <returns></returns>
      public static int Update_User(UserInfo u) {
          string sqlStr = "update T_UserInfo set U_Pwd='"+u.U_Pwd+"',U_Remark='"+u.U_Remark+"' where U_ID="+u.U_ID;
          return DBHelper.ExecuteCommand(sqlStr);
      }
      /// <summary>
      /// ����û���Ϣ
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
      /// ����û���Ϣ
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
      /// ������з������û���Ϣ
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_AllServiceUserInfo() {
          string sqlStr = "select * from T_UserInfo where U_Power=1";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// �ж��û��Ƿ����
      /// </summary>
      /// <param name="strName"></param>
      /// <returns></returns>
      public static bool IsExistUserInfo(string strName) {
          string sqlStr = "select count(*) from T_UserInfo where U_Name='"+strName+"'";
          return DBHelper.IsExistRecord(sqlStr);
      }
      /// <summary>
      /// ��÷������û���ͼ
      /// </summary>
      /// <returns></returns>
      public static DataTable Get_UserView() {
          string sqlStr = "select * from V_UserInfo order by S_ID asc";
          return DBHelper.GetDataSet(sqlStr);
      }
      /// <summary>
      /// �����û�������û���ͼ��Ϣ
      /// </summary>
      /// <param name="strUName"></param>
      /// <returns></returns>
      public static DataTable Get_UserViewByName(string strUName) {
          string sqlStr = "select * from V_UserInfo where U_Name like '%"+strUName+"%'";
          return DBHelper.GetDataSet(sqlStr);
      }  
    }
}
