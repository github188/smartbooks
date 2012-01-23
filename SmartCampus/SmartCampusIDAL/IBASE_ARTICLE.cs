using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCampus.Entity;

namespace SmartCampus.IDAL
{
    public interface IBASE_ARTICLE : IDALBase
    {
        /// <summary>
        /// 判断指定ID编号记录是否存在
        /// </summary>
        /// <param name="articleid">ID编号</param>
        /// <returns>返回：true存在，false不存在</returns>
        bool Exists(int articleid);
        void Add(BASE_ARTICLE entity);
        bool Update(BASE_ARTICLE entity);
        bool Delete(int articleid);
        BASE_ARTICLE GetEntity(int articleid);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
