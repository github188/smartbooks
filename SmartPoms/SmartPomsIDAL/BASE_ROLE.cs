// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_ROLE.cs
// 功能描述:Base_Role -- 接口定义
//
// 创建标识：王 亚 2012-03-14
namespace SmartPoms.IDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Collections;
    using System.Data;
    using Entity;

    /// <summary>
    /// Base_Role -- 接口定义
    /// </summary>
    public interface IBASE_ROLE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        bool Exists(int RoleID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Entity.BASE_ROLE entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.BASE_ROLE entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int RoleID);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string RoleIDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.BASE_ROLE GetEntity(int RoleID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        #region 角色管理

        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <param name="RoleGroupID">角色分组ID</param>
        /// <returns></returns>
        bool RoleExists(string RoleName, int RoleGroupID);

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        int CreateRole(Entity.BASE_ROLE model);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        bool UpdateRole(Entity.BASE_ROLE model);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        int DeleteRole(int RoleID);

        /// <summary>
        /// 获取角色实体
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        Entity.BASE_ROLE GetRoleModel(int RoleID);

        /// <summary>
        /// 获得角色数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetRoleList(string strWhere, string strOrder);

        #endregion

        #region 授权

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        bool RoleAuthorityExists(Entity.BASE_ROLEAUTHORITYLIST model);

        /// <summary>
        /// 修改用户模块权限
        /// </summary>
        bool UpdateUserAuthority(ArrayList list);

        /// <summary>
        /// 读取用户的模块权限
        /// </summary>
        DataSet GetUserAuthorityList(int UserID, int ModuleID);

        /// <summary>
        /// 修改角色模块权限
        /// </summary>
        bool UpdateRoleAuthority(ArrayList list);

        /// <summary>
        /// 读取角色的模块权限
        /// </summary>
        DataSet GetRoleAuthorityList(int RoleID, int ModuleID);

        /// <summary>
        /// 修改分组权限
        /// </summary>
        bool UpdateGroupAuthority(ArrayList list);

        /// <summary>
        /// 读取分组的模块权限
        /// </summary>
        DataSet GetGroupAuthorityList(int GroupID, int ModuleID);

        #endregion
    }
}