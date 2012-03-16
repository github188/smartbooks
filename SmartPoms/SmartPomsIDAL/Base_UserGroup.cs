// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_USERGROUP.cs
// 功能描述:Base_UserGroup -- 接口定义
//
// 创建标识：王 亚 2012-03-14
namespace SmartPoms.IDAL {
    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using Entity;

    /// <summary>
    /// Base_UserGroup -- 接口定义
    /// </summary>
    public interface IBASE_USERGROUP {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        bool Exists(int UG_ID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Entity.BASE_USERGROUP entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.BASE_USERGROUP entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int UG_ID);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string UG_IDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.BASE_USERGROUP GetEntity(int UG_ID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);


        #region 用户分组
        /// <summary>
        /// 判断用户分组是否存在
        /// </summary>
        /// <param name="Name">用户分组名称</param>
        /// <returns></returns>
        bool UserGroupExists(string Name);

        /// <summary>
        /// 增加一个用户分组
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        int CreateUserGroup(Entity.BASE_USERGROUP model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        bool UpdateUserGroup(Entity.BASE_USERGROUP model);

        /// <summary>
        /// 删除用户分组
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        int DeleteUserGroup(int id);

        /// <summary>
        /// 获取模块深度
        /// </summary>
        /// <param name="ID">模块ID</param>
        /// <returns></returns>
        int GetUserGroupDepth(int id);

        /// <summary>
        /// 得到一个用户分组实体
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        Entity.BASE_USERGROUP GetUserGroupModel(int id);

        /// <summary>
        /// 获得用户分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        DataSet GetUserGroupList(string strWhere);

        /// <summary>
        /// 获得用户分组下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        DataSet GetChildUserGroupList(int id);

        /// <summary>
        /// 判断用户分组下是否有模块
        /// </summary>
        /// <param name="ID">分类iD</param>
        /// <returns></returns>
        bool IsUser(int id);

        #endregion
    }
}