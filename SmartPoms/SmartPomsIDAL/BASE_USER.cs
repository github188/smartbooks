// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_USER.cs
// 功能描述:用户帐户信息表 -- 接口定义
//
// 创建标识：王 亚 2012-03-14
namespace SmartPoms.IDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using System.Collections;
    using Entity;

    /// <summary>
    /// 用户帐户信息表 -- 接口定义
    /// </summary>
    public interface IBASE_USER {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        bool Exists(int UserID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Entity.BASE_USER entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.BASE_USER entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int UserID);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string UserIDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.BASE_USER GetEntity(int UserID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 用户是否存在
        /// </summary>
        bool UserExists(string UserName);

        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CreateUser(Entity.BASE_USER model);

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        int UpdateUser(Entity.BASE_USER model);

        /// <summary>
        /// 用户登录检测
        /// </summary>
        bool CheckLogin(string UserName, string pwd);

        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        /// <param name="id"></param>
        void UpdateLoginTime(int id);

        /// <summary>
        /// 判断用户原密码是否正确
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">原密码</param>
        /// <returns></returns>
        bool VerifyPassword(int id, string pwd);

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        bool ChangePassword(int id, string pwd);

        /// <summary>
        /// 更新安全信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="question">问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        bool ChangeSecureInfo(int id, string question, string answer);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        bool DeleteUser(int UserID);

        /// <summary>
        /// 根据ID得到用户对象实体
        /// </summary>
        Entity.BASE_USER GetUserModel(int UserID);

        /// <summary>
        /// 根据用户名得到用户对象实体
        /// </summary>
        Entity.BASE_USER GetUserModel(string UserName);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetUserList(string strWhere, string strOrder);

        /// <summary>
        /// 读取角色名称
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        object GetRoleName(int roleid);

        #region 角色操作

        /// <summary>
        /// 添加一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        bool addUserRole(int UserID, int RoleID);

        /// <summary>
        /// 批量添加用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool addUserRole(ArrayList list);

        /// <summary>
        /// 删除一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        bool DeleteUserRole(int UserID, int RoleID);

        /// <summary>
        /// 批量删除用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteUserRole(ArrayList list);

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        DataSet GetUserRole(int UserID);

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        ArrayList GetUserRoleArray(int UserID);

        #endregion
    }
}