// Copyright (C) 2009-2012 郑州豫图信息技术有限公司
// 版权所有。 
//
// 文件名称:IBASE_DEPT.cs
// 功能描述:部门信息表 -- 接口定义
//
// 创建标识：王 亚 2012-05-04
namespace SmartHyd.IDAL
{
	using System;
	using System.Text;
	using System.Data.SqlClient;
	using System.Collections.Generic; 
	using System.Data;
	using Entity;
	
 	/// <summary>
	/// 部门信息表 -- 接口定义
	/// </summary>
	public interface IBASE_DEPT
	{
		/// <summary>
		/// 确定记录是否存在
		/// </summary>
		bool Exists(decimal DEPTID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Entity.BASE_DEPT entity);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Entity.BASE_DEPT entity);
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(decimal DEPTID);
		
				
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Entity.BASE_DEPT GetEntity(decimal DEPTID);
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);

        /// <summary>
        /// 获取用户所属的部门和子部门
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns>部门信息</returns>
        DataTable GetUserWhereDepartment(string userName, int issubdept);
	}
}