// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_MESSAGE.cs
// 功能描述:消息记录信息表 -- 接口定义
//
// 创建标识：付晓 2012-05-04
namespace SmartHyd.IDAL
{
	using System;
	using System.Text;
	using System.Data.SqlClient;
	using System.Collections.Generic; 
	using System.Data;
	using Entity;
	
 	/// <summary>
	/// 消息记录信息表 -- 接口定义
	/// </summary>
	public interface IBASE_MESSAGE
	{
		/// <summary>
		/// 确定记录是否存在
		/// </summary>
        bool Exists(decimal MESSAGEID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(Entity.BASE_MESSAGE entity);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Entity.BASE_MESSAGE entity);
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
        bool Delete(decimal MESSAGEID);
		
				
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Entity.BASE_MESSAGE GetEntity(decimal MESSAGEID);
		
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