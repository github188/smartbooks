// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_GROUP.cs
// 功能描述:Base_Group -- 接口定义
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
    /// Base_Group -- 接口定义
    /// </summary>
    public interface IBASE_GROUP {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        bool Exists(int GroupID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Entity.BASE_GROUP entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.BASE_GROUP entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int GroupID);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string GroupIDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.BASE_GROUP GetEntity(int GroupID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="GroupName">分组名称</param>
        /// <returns></returns>
        bool Exists(string GroupName, int GroupType);

        /// <summary>
        /// 增加一个分组
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        bool CreateGroup(Entity.BASE_GROUP model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        bool UpdateGroup(Entity.BASE_GROUP model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        int DeleteGroup(int GroupID);

        /// <summary>
        /// 得到一个分组实体
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        Entity.BASE_GROUP GetGroupModel(int GroupID);

        /// <summary>
        /// 获得分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetGroupList(string strWhere, string strOrder);
    }
}