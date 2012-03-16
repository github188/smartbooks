// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_MODULE.cs
// 功能描述:Base_Module -- 接口定义
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
    /// Base_Module -- 接口定义
    /// </summary>
    public interface IBASE_MODULE {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        bool Exists(int ModuleID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Entity.BASE_MODULE entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.BASE_MODULE entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ModuleID);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string ModuleIDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.BASE_MODULE GetEntity(int ModuleID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);




        #region 模块分类

        /// <summary>
        /// 判断模块分类是否存在
        /// </summary>
        /// <param name="ModuleTypeName">模块分类名称</param>
        /// <returns></returns>
        bool ModuleTypeExists(string ModuleTypeName);

        /// <summary>
        /// 增加一个模块分类
        /// </summary>
        /// <param name="model">模块分类实体类</param>
        /// <returns></returns>
        int CreateModuleType(Entity.BASE_MODULETYPE model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">模块分类实体类</param>
        /// <returns></returns>
        bool UpdateModuleType(Entity.BASE_MODULETYPE model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleTypeID">模块分类ID</param>
        /// <returns></returns>
        int DeleteModuleType(int ModuleTypeID);

        /// <summary>
        /// 得到一个模块分类实体
        /// </summary>
        /// <param name="ModuleTypeID">模块分类ID</param>
        /// <returns></returns>
        Entity.BASE_MODULETYPE GetModuleTypeModel(int ModuleTypeID);

        /// <summary>
        /// 获得模块分类数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetModuleTypeList(string strWhere);

        #endregion

        #region 模块操作
        /// <summary>
        /// 判断模块是否存在
        /// </summary>
        /// <param name="ModuleName">模块名称</param>
        /// <returns></returns>
        bool ModuleExists(string ModuleTag);

        /// <summary>
        /// 更新时判断模块是否存在
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="ModuleName">模块名称</param>
        /// <returns></returns>
        bool UpdateExists(int ModuleID, string ModuleTag);

        /// <summary>
        /// 增加一个模块
        /// </summary>
        /// <param name="model">模块实体类</param>
        /// <returns></returns>
        int CreateModule(Entity.BASE_MODULE model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">模块实体类</param>
        /// <returns></returns>
        int UpdateModule(Entity.BASE_MODULE model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        bool DeleteModule(int ModuleID);

        /// <summary>
        /// 得到一个模块实体
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        Entity.BASE_MODULE GetModuleModel(int ModuleID);

        /// <summary>
        /// 获得模块数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetModuleList(string strWhere);

        /// <summary>
        /// 获得模块数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        DataSet GetModuleList2(string strWhere);

        /// <summary>
        /// 获取模块ID
        /// </summary>
        /// <param name="ModuleTag">模块标识</param>
        /// <returns></returns>
        int GetModuleID(string ModuleTag);

        /// <summary>
        /// 模块是否关闭
        /// </summary>
        /// <param name="ModuleTag">模块标识</param>
        /// <returns></returns>
        bool IsModule(string ModuleTag);

        #endregion

        #region 模块授权

        /// <summary>
        /// 增加模块权限
        /// </summary>
        /// <param name="list">权限列表</param>
        /// <returns></returns>
        bool CreateAuthorityList(ArrayList list);

        /// <summary>
        /// 更新模块权限
        /// </summary>
        bool UpdateAuthorityList(ArrayList list);

        /// <summary>
        /// 删除指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        bool DeleteAuthority(int ModuleID);

        /// <summary>
        /// 获得指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        DataSet GetAuthorityList(int ModuleID);

        /// <summary>
        /// 获得指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        DataSet GetAuthorityNameList(int ModuleID);

        #endregion
    }
}