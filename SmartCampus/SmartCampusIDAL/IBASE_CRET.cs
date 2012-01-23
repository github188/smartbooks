using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_CRET : IDALBase
    {
        /// <summary>
        /// 判断指定ID编号记录是否存在
        /// </summary>
        /// <param name="cretid">ID编号</param>
        /// <returns>返回：true存在，false不存在</returns>
        bool Exists(int cretid);
        void Add(BASE_CRET entity);
        bool Update(BASE_CRET entity);
        bool Delete(int cretid);
        BASE_CRET GetEntity(int cretid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}