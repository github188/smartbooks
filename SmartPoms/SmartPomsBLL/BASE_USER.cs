

namespace SmartPoms.BLL {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Collections;

    public class BASE_USER {
        private readonly SQLServerDAL.BASE_USER dal = new SQLServerDAL.BASE_USER();
		

        /// <summary>
        /// 用户是否存在
        /// </summary>
        public bool UserExists(string UserName)
        {
            return dal.UserExists(UserName);
        }

        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateUser(Entity.BASE_USER model)
        {
            if (!UserExists(model.UserName))
            {
                return dal.CreateUser(model);
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public int UpdateUser(Entity.BASE_USER model)
        {
            return dal.UpdateUser(model);
        }

        /// <summary>
        /// 用户登录检测
        /// </summary>
        public bool CheckLogin(string UserName,string pwd)
        {
            return dal.CheckLogin(UserName, pwd);
        }

        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        /// <param name="id"></param>
        public void UpdateLoginTime(int id)
        {
            dal.UpdateLoginTime(id);
        }

        /// <summary>
        /// 判断用户原密码是否正确
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">原密码</param>
        /// <returns></returns>
        public bool VerifyPassword(int id, string pwd)
        {
            return dal.VerifyPassword(id, pwd);
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool ChangePassword(int id, string pwd)
        {
            return dal.ChangePassword(id, pwd);
        }

        /// <summary>
        /// 更新安全信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="question">问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        public bool ChangeSecureInfo(int id, string question, string answer)
        {
            return dal.ChangeSecureInfo(id, question, answer);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        public bool DeleteUser(int UserID)
        {
            return dal.DeleteUser(UserID);
        }

        /// <summary>
        /// 根据ID得到用户对象实体
        /// </summary>
        public Entity.BASE_USER GetUserModel(int UserID)
        {
            return dal.GetUserModel(UserID);
        }

        /// <summary>
        /// 根据用户名得到用户对象实体
        /// </summary>
        public Entity.BASE_USER GetUserModel(string UserName)
        {
            return dal.GetUserModel(UserName);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserList(string strWhere,string strOrder)
        {
            return dal.GetUserList(strWhere,strOrder);
        }

        /// <summary>
        /// 读取角色名称
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public object GetRoleName(int roleid)
        {
            return dal.GetRoleName(roleid);
        }

        #region 角色操作

        /// <summary>
        /// 添加一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool addUserRole(int UserID, int RoleID)
        {
            return dal.addUserRole(UserID, RoleID);
        }

        /// <summary>
        /// 批量添加用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool addUserRole(ArrayList list)
        {
            return dal.addUserRole(list);
        }

        /// <summary>
        /// 删除一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool DeleteUserRole(int UserID, int RoleID)
        {
            return dal.DeleteUserRole(UserID, RoleID);
        }

        /// <summary>
        /// 批量删除用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteUserRole(ArrayList list)
        {
            return dal.DeleteUserRole(list);
        }

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserRole(int UserID)
        {
            return dal.GetUserRole(UserID);
        }

         /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ArrayList GetUserRoleArray(int UserID)
        {
            return dal.GetUserRoleArray(UserID);
        }

        #endregion
    }
}
