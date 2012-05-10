﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_AFFICHE.cs
// 功能描述:公告信息表 -- 接口定义
//
// 创建标识：付晓 2012-05-10
namespace SmartHyd.IDAL
{
	using System;
	using System.Text;
	using System.Data.SqlClient;
	using System.Collections.Generic; 
	using System.Data;
	using Entity;
	
 	/// <summary>
	/// 公告信息表 -- 接口定义
	/// </summary>
	public interface IBASE_AFFICHE
	{
		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		bool Exists(decimal AFFICHEID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(Entity.BASE_AFFICHE entity);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Entity.BASE_AFFICHE entity);
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(decimal AFFICHEID);
		
				
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.BASE_AFFICHE GetEntity(decimal AFFICHEID);
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);   
	}
}