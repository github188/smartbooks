// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_CONFIGURATION.cs
// 功能描述:Base_Configuration -- 接口定义
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
    /// Base_Configuration -- 接口定义
    /// </summary>
    public interface IBASE_CONFIGURATION {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        bool Exists(int ItemID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Entity.BASE_CONFIGURATION entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.BASE_CONFIGURATION entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ItemID);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string ItemIDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.BASE_CONFIGURATION GetEntity(int ItemID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 获取配置项的址
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        string GetItemValue(string ItemName);

        /// <summary>
        /// 判断配置项是否存在
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        bool Exists(string ItemName);

        /// <summary>
        /// 创建新配置
        /// </summary>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        bool CreateItem(string ItemName, string ItemValue);

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        bool UpdateItem(int id, string ItemName, string ItemValue);

        /// <summary>
        /// 更新配置值
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        bool UpdateItem(int id, string ItemValue);

        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool DeleteItem(int id);


        /// <summary>
        /// 获取配置的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetItemList(string strWhere);
    }
}