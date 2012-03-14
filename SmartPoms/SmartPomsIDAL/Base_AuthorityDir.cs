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
    }
}