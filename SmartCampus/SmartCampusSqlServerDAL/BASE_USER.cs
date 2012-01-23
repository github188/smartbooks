
namespace SmartCampus.SqlServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartCampus.IDAL;

    public class BASE_USER : IBASE_USER
    {
        #region IBASE_USER 成员

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userid">用户编号</param>
        public bool Exists(int userid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <remarks>用户实体对象userid不必赋值。</remarks>
        /// <param name="entity">用户实体</param>
        public void Add(SmartCampus.Entity.BASE_USER entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新一个用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        public bool Update(SmartCampus.Entity.BASE_USER entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>true成功,false失败</returns>
        public bool Delete(int userid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="userid">用户编号</param>
        public SmartCampus.Entity.BASE_USER GetEntity(int userid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        public DataSet GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取前Top条记录
        /// </summary>
        /// <param name="Top">返回几条记录</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="filedOrder">Order字段</param>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
