// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_ROLE.cs
// 功能描述:角色信息表 -- 接口定义
//
// 创建标识：王 亚 2012-03-12
namespace SmartPoms.IDAL
{
	using System;
	using System.Text;
	using System.Data.SqlClient;
	using System.Collections.Generic; 
	using System.Data;
	using Entity;
	
 	/// <summary>
	/// 角色信息表 -- 接口定义
	/// </summary>
	public interface IBASE_ROLE
	{
		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		bool Exists(int ROLEID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(BASE_ROLE entity);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(BASE_ROLE entity);
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int ROLEID);
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		bool DeleteList(string ROLEIDlist );
				
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		BASE_ROLE GetEntity(int ROLEID);
		
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