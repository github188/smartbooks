// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_AUTHORITYDIR.cs
// 功能描述:Base_AuthorityDir -- 接口定义
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
    /// Base_AuthorityDir -- 接口定义
    /// </summary>
    public interface IBASE_AUTHORITYDIR {
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        bool Exists(int AuthorityID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Entity.BASE_AUTHORITYDIR entity);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Entity.BASE_AUTHORITYDIR entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int AuthorityID);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string AuthorityIDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Entity.BASE_AUTHORITYDIR GetEntity(int AuthorityID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 判断权限标识否存在
        /// </summary>
        /// <param name="AuthorityTag">权限标识</param>
        /// <returns></returns>
        bool Exists(string AuthorityTag);

        /// <summary>
        /// 增加一个权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        bool CreateAuthority(Entity.BASE_AUTHORITYDIR model);

        /// <summary>
        /// 更新指定的权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        bool UpdateAuthority(Entity.BASE_AUTHORITYDIR model);

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        bool DeleteAuthority(int AuthorityID);

        /// <summary>
        /// 得到一个权限实体
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        Entity.BASE_AUTHORITYDIR GetAuthorityModel(int AuthorityID);

        /// <summary>
        /// 获得权限数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetAuthorityList(string strWhere, string strOrder);
    }
}