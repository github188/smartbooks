﻿// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_PLAN.cs
// 功能描述:事务信息表 -- 接口定义
//
// 创建标识：付晓 2012-06-18
namespace SmartHyd.IDAL
{
	using System;
	using System.Text;
	using System.Data.SqlClient;
	using System.Collections.Generic; 
	using System.Data;
	using Entity;
	
 	/// <summary>
	/// 事务信息表 -- 接口定义
	/// </summary>
	public interface IBASE_PLAN
	{
		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		bool Exists(decimal CALENDARID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Entity.BASE_PLAN entity);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Entity.BASE_PLAN entity);
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(decimal CALENDARID);
		
				
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.BASE_PLAN GetEntity(decimal CALENDARID);
		
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